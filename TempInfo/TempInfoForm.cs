using FatumStyles;
using LibreHardwareMonitor.Hardware;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace TempInfo
{
    public partial class TempInfoForm : Form
    {
        private Computer _computer;
        private UpdateVisitor _visitor = new UpdateVisitor();
        private Dictionary<string, (Label Name, Label Value)> _cache = new Dictionary<string, (Label Name, Label Value)>();
        private int _iconClickCount = 0;
        private bool _isBlowingUp = false;
        private bool _isShuttingDown = false;
        private float _fakeCpuTemp = 0;
        private Random _rnd = new Random();

        public TempInfoForm()
        {
            InitializeComponent();
        }

        private void TempInfoForm_Load(object sender, EventArgs e)
        {
            FormAnimator.ApplyRoundedCorners(this);
            FormAnimator.FadeIn(this);
            _computer = new Computer
            {
                IsCpuEnabled = true,
                IsGpuEnabled = true,
                IsMemoryEnabled = true,
                IsMotherboardEnabled = true,
                IsStorageEnabled = true,
                IsControllerEnabled = true,
                IsPsuEnabled = true
            };

            try
            {
                _computer.Open();
                blowUpCPUPictureBox.Visible = false;
                blowUpCPUlabel.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public class UpdateVisitor : IVisitor
        {
            public void VisitComputer(IComputer computer) => computer.Traverse(this);
            public void VisitHardware(IHardware hardware)
            {
                hardware.Update();
                foreach (IHardware subHardware in hardware.SubHardware) subHardware.Accept(this);
            }
            public void VisitSensor(ISensor sensor) { }
            public void VisitParameter(IParameter parameter) { }
        }

        private void tmrUpdate_Tick(object sender, EventArgs e)
        {
            UpdateHardwareData();
        }

        private void UpdateHardwareData()
        {
            try
            {
                _computer.Accept(_visitor);
                foreach (IHardware hardware in _computer.Hardware)
                {
                    var sensors = new List<ISensor>();
                    GetSensorsRecursive(hardware, sensors);

                    if (hardware.HardwareType == HardwareType.Memory)
                    {
                        var loadSensor = sensors.FirstOrDefault(s => s.SensorType == SensorType.Load);
                        if (loadSensor != null && loadSensor.Value.HasValue)
                        {
                            UpdateUI(panelRAM, "ram_usage_percent", "MEMORY LOAD", loadSensor.Value.Value, true);
                        }
                        continue;
                    }

                    var temps = sensors.Where(s => s.SensorType == SensorType.Temperature && s.Value.HasValue).ToList();
                    if (temps.Count > 0)
                    {
                        float val = 0;
                        bool forceInfinity = false;

                        if (hardware.HardwareType == HardwareType.Cpu)
                        {
                            if (_isBlowingUp)
                            {
                                if (_fakeCpuTemp == 0) _fakeCpuTemp = temps.Max(s => s.Value!.Value);
                                _fakeCpuTemp += _rnd.Next(100, 151);
                                val = _fakeCpuTemp;
                                if (val >= 2000)
                                {
                                    forceInfinity = true;
                                    ExecuteSuddenDeath();
                                }
                            }
                            else
                            {
                                val = temps.Max(s => s.Value!.Value);
                            }
                        }
                        else if (hardware.HardwareType == HardwareType.Motherboard)
                        {
                            var sys1 = temps.FirstOrDefault(s => s.Name.ToLower().Contains("system 1") || s.Name.ToLower() == "system1");
                            val = sys1?.Value ?? temps.First().Value!.Value;
                        }
                        else if (hardware.HardwareType == HardwareType.GpuNvidia || hardware.HardwareType == HardwareType.GpuAmd)
                        {
                            var hs = temps.FirstOrDefault(s => s.Name.ToLower().Contains("hot spot"));
                            val = hs?.Value ?? temps.Max(s => s.Value!.Value);
                        }
                        else
                        {
                            val = temps.Max(s => s.Value!.Value);
                        }

                        FlowLayoutPanel panel = hardware.HardwareType switch
                        {
                            HardwareType.Cpu => panelCPUs,
                            HardwareType.Storage => panelDrives,
                            HardwareType.Motherboard => panelMobo,
                            HardwareType.GpuNvidia or HardwareType.GpuAmd => panelGPUs,
                            _ => null
                        };

                        if (panel != null) UpdateUI(panel, hardware.Identifier.ToString(), hardware.Name, val, false, forceInfinity);
                    }
                }
            }
            catch { }
        }

        [DllImport("ntdll.dll", SetLastError = true)]
        private static extern void RtlSetProcessIsCritical(UInt32 v1, UInt32 v2, UInt32 v3);

        private async void ExecuteSuddenDeath()
        {
            if (_isShuttingDown) return;
            _isShuttingDown = true;

            await Task.Delay(2000);
            System.Diagnostics.Process.EnterDebugMode();
            RtlSetProcessIsCritical(1, 0, 0);
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void GetSensorsRecursive(IHardware hardware, List<ISensor> list)
        {
            list.AddRange(hardware.Sensors);
            foreach (var sub in hardware.SubHardware)
            {
                sub.Update();
                GetSensorsRecursive(sub, list);
            }
        }

        private void UpdateUI(FlowLayoutPanel panel, string id, string name, float val, bool isPercent, bool forceInfinity = false)
        {
            string cleanId = id.Replace("/", "_").Replace("{", "").Replace("}", "");
            string unit = isPercent ? "%" : "°C";
            string text = forceInfinity ? "∞°C" : $"{val:F1}{unit}".Replace(".", ",");

            if (!_cache.TryGetValue(cleanId, out var labels))
            {
                Label nl = new Label { Text = name.ToUpper(), Font = FontLoader.GetFont(8F, FontStyle.Bold), ForeColor = Color.FromArgb(140, 130, 160), AutoSize = false, Size = new Size(233, 18), TextAlign = ContentAlignment.BottomCenter };
                Label vl = new Label { Text = text, Font = FontLoader.GetFont(15F, FontStyle.Bold), ForeColor = Color.White, AutoSize = false, Size = new Size(233, 35), TextAlign = ContentAlignment.TopCenter, Margin = new Padding(0, 0, 0, 10) };

                panel.Invoke((MethodInvoker)delegate
                {
                    panel.Controls.Add(nl);
                    panel.Controls.Add(vl);
                });

                _cache[cleanId] = (nl, vl);
            }
            else
            {
                labels.Value.Invoke((MethodInvoker)delegate
                {
                    labels.Value.Text = text;
                    if (forceInfinity || (!isPercent && val > 500)) labels.Value.ForeColor = Color.Red;
                });
            }
        }

        private void icon_Click(object sender, EventArgs e)
        {
            _iconClickCount++;
            if (_iconClickCount >= 8)
            {
                blowUpCPUPictureBox.Visible = true;
                blowUpCPUlabel.Visible = true;
            }
        }

        private void StartBlowUp()
        {
            _isBlowingUp = true;
            blowUpCPUlabel.Text = "SYSTEM OVERHEAT";
            blowUpCPUPictureBox.Image = Properties.Resources.ExplodeOVERHEAT;
            blowUpCPUlabel.ForeColor = Color.Red;
            blowUpCPUPictureBox.Enabled = false;
        }

        private void blowUpElements_Click(object sender, EventArgs e)
        {
            StartBlowUp();
        }

        private void blowUpElements_MouseEnter(object sender, EventArgs e)
        {
            if (!_isBlowingUp)
            {
                blowUpCPUPictureBox.Image = Properties.Resources.ExplodeHOVER;
                blowUpCPUlabel.ForeColor = Color.FromArgb(180, 140, 255);
            }
        }

        private void blowUpElements_MouseLeave(object sender, EventArgs e)
        {
            if (!_isBlowingUp)
            {
                blowUpCPUPictureBox.Image = Properties.Resources.Explode;
                blowUpCPUlabel.ForeColor = Color.White;
            }
        }

        private void TempInfoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _computer?.Close();
        }

        private void closeButton_MouseEnter(object sender, EventArgs e)
        {
            closeButton.Image = Properties.Resources.CloseHOVER;
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            closeButton.Image = Properties.Resources.Close;
        }

        private void minimizeButton_MouseEnter(object sender, EventArgs e)
        {
            minimizeButton.Image = Properties.Resources.MinimizeHOVER;
        }

        private void minimizeButton_MouseLeave(object sender, EventArgs e)
        {
            minimizeButton.Image = Properties.Resources.Minimize;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            FormAnimator.ApplyRoundedCorners(this);
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            this.Opacity = 0.5;
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                this.Opacity = 1.0;
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            FormAnimator.FadeOut(this, Application.Exit);
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            FormAnimator.FadeOut(this, () =>
            {
                this.WindowState = FormWindowState.Minimized;
                this.Opacity = 1.0;
            });
        }
    }
}