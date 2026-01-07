using FatumStyles;

namespace TempInfo
{
    partial class TempInfoForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                FontLoader.ClearResource();
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            FontLoader.LoadCustomFont();
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TempInfoForm));
            tmrUpdate = new System.Windows.Forms.Timer(components);
            panelMobo = new FlowLayoutPanel();
            lblTitleMobo = new Label();
            lineMobo = new Panel();
            panelDrives = new FlowLayoutPanel();
            lblTitleDrives = new Label();
            lineDrives = new Panel();
            panelRAM = new FlowLayoutPanel();
            lblTitleRAM = new Label();
            lineRAM = new Panel();
            panelGPUs = new FlowLayoutPanel();
            lblTitleGPUs = new Label();
            lineGPUs = new Panel();
            panelCPUs = new FlowLayoutPanel();
            lblTitleCPUs = new Label();
            lineCPUs = new Panel();
            pnlContainer = new Panel();
            blowUpCPUPictureBox = new PictureBox();
            blowUpCPUlabel = new Label();
            panelTitleBar = new Panel();
            icon = new PictureBox();
            minimizeButton = new PictureBox();
            closeButton = new PictureBox();
            copyrightLabel = new Label();
            panelMobo.SuspendLayout();
            panelDrives.SuspendLayout();
            panelRAM.SuspendLayout();
            panelGPUs.SuspendLayout();
            panelCPUs.SuspendLayout();
            pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)blowUpCPUPictureBox).BeginInit();
            panelTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)icon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)minimizeButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)closeButton).BeginInit();
            SuspendLayout();
            // 
            // tmrUpdate
            // 
            tmrUpdate.Enabled = true;
            tmrUpdate.Interval = 500;
            tmrUpdate.Tick += tmrUpdate_Tick;
            // 
            // panelMobo
            // 
            panelMobo.AutoSize = true;
            panelMobo.Controls.Add(lblTitleMobo);
            panelMobo.Controls.Add(lineMobo);
            panelMobo.FlowDirection = FlowDirection.TopDown;
            panelMobo.Location = new Point(1166, 80);
            panelMobo.Name = "panelMobo";
            panelMobo.Size = new Size(241, 72);
            panelMobo.TabIndex = 3;
            panelMobo.WrapContents = false;
            // 
            // lblTitleMobo
            // 
            lblTitleMobo.Font = FontLoader.GetFont(18F, FontStyle.Bold);
            lblTitleMobo.ForeColor = Color.FromArgb(180, 140, 255);
            lblTitleMobo.Location = new Point(3, 0);
            lblTitleMobo.Name = "lblTitleMobo";
            lblTitleMobo.Size = new Size(233, 46);
            lblTitleMobo.TabIndex = 0;
            lblTitleMobo.Text = "MOTHERBOARD";
            lblTitleMobo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lineMobo
            // 
            lineMobo.BackColor = Color.FromArgb(100, 60, 180);
            lineMobo.Location = new Point(23, 46);
            lineMobo.Margin = new Padding(23, 0, 23, 23);
            lineMobo.Name = "lineMobo";
            lineMobo.Size = new Size(187, 3);
            lineMobo.TabIndex = 1;
            // 
            // panelDrives
            // 
            panelDrives.AutoSize = true;
            panelDrives.Controls.Add(lblTitleDrives);
            panelDrives.Controls.Add(lineDrives);
            panelDrives.FlowDirection = FlowDirection.TopDown;
            panelDrives.Location = new Point(892, 80);
            panelDrives.Name = "panelDrives";
            panelDrives.Size = new Size(241, 72);
            panelDrives.TabIndex = 2;
            panelDrives.WrapContents = false;
            // 
            // lblTitleDrives
            // 
            lblTitleDrives.Font = FontLoader.GetFont(18F, FontStyle.Bold);
            lblTitleDrives.ForeColor = Color.FromArgb(180, 140, 255);
            lblTitleDrives.Location = new Point(3, 0);
            lblTitleDrives.Name = "lblTitleDrives";
            lblTitleDrives.Size = new Size(233, 46);
            lblTitleDrives.TabIndex = 0;
            lblTitleDrives.Text = "DRIVES";
            lblTitleDrives.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lineDrives
            // 
            lineDrives.BackColor = Color.FromArgb(100, 60, 180);
            lineDrives.Location = new Point(23, 46);
            lineDrives.Margin = new Padding(23, 0, 23, 23);
            lineDrives.Name = "lineDrives";
            lineDrives.Size = new Size(187, 3);
            lineDrives.TabIndex = 1;
            // 
            // panelRAM
            // 
            panelRAM.AutoSize = true;
            panelRAM.Controls.Add(lblTitleRAM);
            panelRAM.Controls.Add(lineRAM);
            panelRAM.FlowDirection = FlowDirection.TopDown;
            panelRAM.Location = new Point(618, 80);
            panelRAM.Name = "panelRAM";
            panelRAM.Size = new Size(241, 72);
            panelRAM.TabIndex = 4;
            panelRAM.WrapContents = false;
            // 
            // lblTitleRAM
            // 
            lblTitleRAM.Font = FontLoader.GetFont(18F, FontStyle.Bold);
            lblTitleRAM.ForeColor = Color.FromArgb(180, 140, 255);
            lblTitleRAM.Location = new Point(3, 0);
            lblTitleRAM.Name = "lblTitleRAM";
            lblTitleRAM.Size = new Size(233, 46);
            lblTitleRAM.TabIndex = 0;
            lblTitleRAM.Text = "RAM USAGE";
            lblTitleRAM.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lineRAM
            // 
            lineRAM.BackColor = Color.FromArgb(100, 60, 180);
            lineRAM.Location = new Point(23, 46);
            lineRAM.Margin = new Padding(23, 0, 23, 23);
            lineRAM.Name = "lineRAM";
            lineRAM.Size = new Size(187, 3);
            lineRAM.TabIndex = 1;
            // 
            // panelGPUs
            // 
            panelGPUs.AutoSize = true;
            panelGPUs.Controls.Add(lblTitleGPUs);
            panelGPUs.Controls.Add(lineGPUs);
            panelGPUs.FlowDirection = FlowDirection.TopDown;
            panelGPUs.Location = new Point(344, 80);
            panelGPUs.Name = "panelGPUs";
            panelGPUs.Size = new Size(241, 72);
            panelGPUs.TabIndex = 1;
            panelGPUs.WrapContents = false;
            // 
            // lblTitleGPUs
            // 
            lblTitleGPUs.Font = FontLoader.GetFont(18F, FontStyle.Bold);
            lblTitleGPUs.ForeColor = Color.FromArgb(180, 140, 255);
            lblTitleGPUs.Location = new Point(3, 0);
            lblTitleGPUs.Name = "lblTitleGPUs";
            lblTitleGPUs.Size = new Size(233, 46);
            lblTitleGPUs.TabIndex = 0;
            lblTitleGPUs.Text = "GPUs";
            lblTitleGPUs.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lineGPUs
            // 
            lineGPUs.BackColor = Color.FromArgb(100, 60, 180);
            lineGPUs.Location = new Point(23, 46);
            lineGPUs.Margin = new Padding(23, 0, 23, 23);
            lineGPUs.Name = "lineGPUs";
            lineGPUs.Size = new Size(187, 3);
            lineGPUs.TabIndex = 1;
            // 
            // panelCPUs
            // 
            panelCPUs.AutoSize = true;
            panelCPUs.Controls.Add(lblTitleCPUs);
            panelCPUs.Controls.Add(lineCPUs);
            panelCPUs.FlowDirection = FlowDirection.TopDown;
            panelCPUs.Location = new Point(52, 80);
            panelCPUs.Name = "panelCPUs";
            panelCPUs.Size = new Size(241, 72);
            panelCPUs.TabIndex = 0;
            panelCPUs.WrapContents = false;
            // 
            // lblTitleCPUs
            // 
            lblTitleCPUs.Font = FontLoader.GetFont(18F, FontStyle.Bold);
            lblTitleCPUs.ForeColor = Color.FromArgb(180, 140, 255);
            lblTitleCPUs.Location = new Point(3, 0);
            lblTitleCPUs.Name = "lblTitleCPUs";
            lblTitleCPUs.Size = new Size(233, 46);
            lblTitleCPUs.TabIndex = 0;
            lblTitleCPUs.Text = "CPUs";
            lblTitleCPUs.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lineCPUs
            // 
            lineCPUs.BackColor = Color.FromArgb(100, 60, 180);
            lineCPUs.Location = new Point(23, 46);
            lineCPUs.Margin = new Padding(23, 0, 23, 23);
            lineCPUs.Name = "lineCPUs";
            lineCPUs.Size = new Size(187, 3);
            lineCPUs.TabIndex = 1;
            // 
            // pnlContainer
            // 
            pnlContainer.AutoScroll = true;
            pnlContainer.BackColor = Color.FromArgb(25, 20, 35);
            pnlContainer.Controls.Add(blowUpCPUPictureBox);
            pnlContainer.Controls.Add(blowUpCPUlabel);
            pnlContainer.Controls.Add(copyrightLabel);
            pnlContainer.Controls.Add(panelCPUs);
            pnlContainer.Controls.Add(panelGPUs);
            pnlContainer.Controls.Add(panelRAM);
            pnlContainer.Controls.Add(panelDrives);
            pnlContainer.Controls.Add(panelMobo);
            pnlContainer.Controls.Add(panelTitleBar);
            pnlContainer.Dock = DockStyle.Fill;
            pnlContainer.Location = new Point(0, 0);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Size = new Size(1458, 400);
            pnlContainer.TabIndex = 0;
            // 
            // blowUpCPUPictureBox
            // 
            blowUpCPUPictureBox.Image = Properties.Resources.Explode;
            blowUpCPUPictureBox.Location = new Point(584, 295);
            blowUpCPUPictureBox.Name = "blowUpCPUPictureBox";
            blowUpCPUPictureBox.Size = new Size(50, 50);
            blowUpCPUPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            blowUpCPUPictureBox.TabIndex = 7;
            blowUpCPUPictureBox.TabStop = false;
            blowUpCPUPictureBox.Click += blowUpElements_Click;
            blowUpCPUPictureBox.MouseEnter += blowUpElements_MouseEnter;
            blowUpCPUPictureBox.MouseLeave += blowUpElements_MouseLeave;
            // 
            // blowUpCPUlabel
            // 
            blowUpCPUlabel.AutoSize = true;
            blowUpCPUlabel.Font = FontLoader.GetFont(20F, FontStyle.Regular);
            blowUpCPUlabel.ForeColor = Color.White;
            blowUpCPUlabel.Location = new Point(640, 300);
            blowUpCPUlabel.Name = "blowUpCPUlabel";
            blowUpCPUlabel.Size = new Size(235, 37);
            blowUpCPUlabel.TabIndex = 6;
            blowUpCPUlabel.Text = "Blow Up Your CPU";
            blowUpCPUlabel.Click += blowUpElements_Click;
            blowUpCPUlabel.MouseEnter += blowUpElements_MouseEnter;
            blowUpCPUlabel.MouseLeave += blowUpElements_MouseLeave;
            // 
            // panelTitleBar
            // 
            panelTitleBar.BackColor = Color.FromArgb(20, 15, 30);
            panelTitleBar.Controls.Add(icon);
            panelTitleBar.Controls.Add(minimizeButton);
            panelTitleBar.Controls.Add(closeButton);
            panelTitleBar.Location = new Point(0, 0);
            panelTitleBar.Name = "panelTitleBar";
            panelTitleBar.Size = new Size(1458, 40);
            panelTitleBar.TabIndex = 5;
            panelTitleBar.MouseDown += panelTitleBar_MouseDown;
            // 
            // icon
            // 
            icon.Cursor = Cursors.Hand;
            icon.Image = Properties.Resources.icon;
            icon.Location = new Point(709, 0);
            icon.Name = "icon";
            icon.Size = new Size(40, 40);
            icon.SizeMode = PictureBoxSizeMode.StretchImage;
            icon.TabIndex = 2;
            icon.TabStop = false;
            icon.Click += icon_Click;
            // 
            // minimizeButton
            // 
            minimizeButton.Image = Properties.Resources.Minimize;
            minimizeButton.Location = new Point(1385, 4);
            minimizeButton.Name = "minimizeButton";
            minimizeButton.Size = new Size(32, 32);
            minimizeButton.SizeMode = PictureBoxSizeMode.StretchImage;
            minimizeButton.TabIndex = 1;
            minimizeButton.TabStop = false;
            minimizeButton.Click += minimizeButton_Click;
            minimizeButton.MouseEnter += minimizeButton_MouseEnter;
            minimizeButton.MouseLeave += minimizeButton_MouseLeave;
            // 
            // closeButton
            // 
            closeButton.Image = Properties.Resources.Close;
            closeButton.Location = new Point(1423, 4);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(32, 32);
            closeButton.SizeMode = PictureBoxSizeMode.StretchImage;
            closeButton.TabIndex = 0;
            closeButton.TabStop = false;
            closeButton.Click += closeButton_Click;
            closeButton.MouseEnter += closeButton_MouseEnter;
            closeButton.MouseLeave += closeButton_MouseLeave;
            // 
            // copyrightLabel
            // 
            copyrightLabel.AutoSize = true;
            copyrightLabel.Font = FontLoader.GetFont(9F, FontStyle.Regular);
            copyrightLabel.ForeColor = Color.DarkGray;
            copyrightLabel.Location = new Point(1249, 378);
            copyrightLabel.Name = "copyrightLabel";
            copyrightLabel.Size = new Size(209, 22);
            copyrightLabel.TabIndex = 8;
            copyrightLabel.Text = "© 2025 fatum. All Rights Reserved.";
            // 
            // TempInfoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 15, 30);
            ClientSize = new Size(1458, 400);
            Controls.Add(pnlContainer);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "TempInfoForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TempInfo";
            FormClosing += TempInfoForm_FormClosing;
            Load += TempInfoForm_Load;
            panelMobo.ResumeLayout(false);
            panelDrives.ResumeLayout(false);
            panelRAM.ResumeLayout(false);
            panelGPUs.ResumeLayout(false);
            panelCPUs.ResumeLayout(false);
            pnlContainer.ResumeLayout(false);
            pnlContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)blowUpCPUPictureBox).EndInit();
            panelTitleBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)icon).EndInit();
            ((System.ComponentModel.ISupportInitialize)minimizeButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)closeButton).EndInit();
            ResumeLayout(false);

        }
        private System.Windows.Forms.Timer tmrUpdate;
        private FlowLayoutPanel panelMobo;
        private Label lblTitleMobo;
        private Panel lineMobo;
        private FlowLayoutPanel panelDrives;
        private Label lblTitleDrives;
        private Panel lineDrives;
        private FlowLayoutPanel panelRAM;
        private Label lblTitleRAM;
        private Panel lineRAM;
        private FlowLayoutPanel panelGPUs;
        private Label lblTitleGPUs;
        private Panel lineGPUs;
        private FlowLayoutPanel panelCPUs;
        private Label lblTitleCPUs;
        private Panel lineCPUs;
        private Panel pnlContainer;
        private Panel panelTitleBar;
        private PictureBox minimizeButton;
        private PictureBox closeButton;
        private PictureBox icon;
        private PictureBox blowUpCPUPictureBox;
        private Label blowUpCPUlabel;
        private Label copyrightLabel;
    }
}