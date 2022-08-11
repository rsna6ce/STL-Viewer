namespace STLViewer
{
    partial class AppMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppMainForm));
            this.DrawTimer = new System.Windows.Forms.Timer(this.components);
            this.GL_Monitor = new OpenTK.GLControl();
            this.AppToolBarMStp = new System.Windows.Forms.MenuStrip();
            this.ToolBarFileMenuBt = new System.Windows.Forms.ToolStripMenuItem();
            this.FileMenuImportBt = new System.Windows.Forms.ToolStripMenuItem();
            this.FileMenuExitBt = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolBarHelpMenuBt = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpMenuHowToUseBt = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpMenuAboutBt = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.animationGIFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerAnimationGif = new System.Windows.Forms.Timer(this.components);
            this.AppToolBarMStp.SuspendLayout();
            this.SuspendLayout();
            // 
            // DrawTimer
            // 
            this.DrawTimer.Enabled = true;
            this.DrawTimer.Interval = 25;
            this.DrawTimer.Tick += new System.EventHandler(this.DrawTimer_Tick);
            // 
            // GL_Monitor
            // 
            this.GL_Monitor.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.GL_Monitor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GL_Monitor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GL_Monitor.Location = new System.Drawing.Point(0, 30);
            this.GL_Monitor.Name = "GL_Monitor";
            this.GL_Monitor.Padding = new System.Windows.Forms.Padding(1);
            this.GL_Monitor.Size = new System.Drawing.Size(784, 474);
            this.GL_Monitor.TabIndex = 15;
            this.GL_Monitor.VSync = false;
            this.GL_Monitor.Load += new System.EventHandler(this.GL_Monitor_Load);
            this.GL_Monitor.DragDrop += new System.Windows.Forms.DragEventHandler(this.GL_Monitor_DragDrop);
            this.GL_Monitor.DragEnter += new System.Windows.Forms.DragEventHandler(this.GL_Monitor_DragEnter);
            this.GL_Monitor.Paint += new System.Windows.Forms.PaintEventHandler(this.GL_Monitor_Paint);
            // 
            // AppToolBarMStp
            // 
            this.AppToolBarMStp.AutoSize = false;
            this.AppToolBarMStp.BackColor = System.Drawing.Color.Transparent;
            this.AppToolBarMStp.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.AppToolBarMStp.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.AppToolBarMStp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolBarFileMenuBt,
            this.ToolBarHelpMenuBt,
            this.testToolStripMenuItem});
            this.AppToolBarMStp.Location = new System.Drawing.Point(0, 0);
            this.AppToolBarMStp.Name = "AppToolBarMStp";
            this.AppToolBarMStp.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.AppToolBarMStp.Size = new System.Drawing.Size(784, 30);
            this.AppToolBarMStp.TabIndex = 16;
            this.AppToolBarMStp.Text = "AppToolBar";
            this.AppToolBarMStp.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.AppToolBarMStp_MouseDoubleClick);
            this.AppToolBarMStp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AppToolBarMStp_MouseDown);
            this.AppToolBarMStp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.AppToolBarMStp_MouseUp);
            // 
            // ToolBarFileMenuBt
            // 
            this.ToolBarFileMenuBt.BackColor = System.Drawing.Color.Transparent;
            this.ToolBarFileMenuBt.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenuImportBt,
            this.FileMenuExitBt});
            this.ToolBarFileMenuBt.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ToolBarFileMenuBt.Name = "ToolBarFileMenuBt";
            this.ToolBarFileMenuBt.Size = new System.Drawing.Size(41, 26);
            this.ToolBarFileMenuBt.Text = "File";
            // 
            // FileMenuImportBt
            // 
            this.FileMenuImportBt.BackColor = System.Drawing.SystemColors.ControlLight;
            this.FileMenuImportBt.Name = "FileMenuImportBt";
            this.FileMenuImportBt.Size = new System.Drawing.Size(180, 24);
            this.FileMenuImportBt.Text = "Import";
            this.FileMenuImportBt.Click += new System.EventHandler(this.FileMenuImportBt_Click);
            // 
            // FileMenuExitBt
            // 
            this.FileMenuExitBt.BackColor = System.Drawing.SystemColors.ControlLight;
            this.FileMenuExitBt.Name = "FileMenuExitBt";
            this.FileMenuExitBt.Size = new System.Drawing.Size(180, 24);
            this.FileMenuExitBt.Text = "Exit";
            this.FileMenuExitBt.Click += new System.EventHandler(this.FileMenuExitBt_Click);
            // 
            // ToolBarHelpMenuBt
            // 
            this.ToolBarHelpMenuBt.BackColor = System.Drawing.Color.Transparent;
            this.ToolBarHelpMenuBt.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HelpMenuHowToUseBt,
            this.HelpMenuAboutBt});
            this.ToolBarHelpMenuBt.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.ToolBarHelpMenuBt.Name = "ToolBarHelpMenuBt";
            this.ToolBarHelpMenuBt.Size = new System.Drawing.Size(49, 26);
            this.ToolBarHelpMenuBt.Text = "Help";
            // 
            // HelpMenuHowToUseBt
            // 
            this.HelpMenuHowToUseBt.BackColor = System.Drawing.SystemColors.ControlLight;
            this.HelpMenuHowToUseBt.Name = "HelpMenuHowToUseBt";
            this.HelpMenuHowToUseBt.Size = new System.Drawing.Size(180, 24);
            this.HelpMenuHowToUseBt.Text = "How to Use";
            this.HelpMenuHowToUseBt.Click += new System.EventHandler(this.HelpMenuHowToUseBt_Click);
            // 
            // HelpMenuAboutBt
            // 
            this.HelpMenuAboutBt.BackColor = System.Drawing.SystemColors.ControlLight;
            this.HelpMenuAboutBt.Name = "HelpMenuAboutBt";
            this.HelpMenuAboutBt.Size = new System.Drawing.Size(180, 24);
            this.HelpMenuAboutBt.Text = "About";
            this.HelpMenuAboutBt.Click += new System.EventHandler(this.HelpMenuAboutBt_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.animationGIFToolStripMenuItem});
            this.testToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(60, 26);
            this.testToolStripMenuItem.Text = "Export";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // animationGIFToolStripMenuItem
            // 
            this.animationGIFToolStripMenuItem.Name = "animationGIFToolStripMenuItem";
            this.animationGIFToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.animationGIFToolStripMenuItem.Text = "Animation GIF";
            this.animationGIFToolStripMenuItem.Click += new System.EventHandler(this.animationGIFToolStripMenuItem_Click);
            // 
            // timerAnimationGif
            // 
            this.timerAnimationGif.Interval = 10;
            this.timerAnimationGif.Tick += new System.EventHandler(this.timerAnimationGIF_Tick);
            // 
            // AppMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 504);
            this.Controls.Add(this.GL_Monitor);
            this.Controls.Add(this.AppToolBarMStp);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.AppToolBarMStp;
            this.Name = "AppMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "STL Viewer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.AppToolBarMStp.ResumeLayout(false);
            this.AppToolBarMStp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer DrawTimer;
        private OpenTK.GLControl GL_Monitor;
        private System.Windows.Forms.MenuStrip AppToolBarMStp;
        private System.Windows.Forms.ToolStripMenuItem ToolBarFileMenuBt;
        private System.Windows.Forms.ToolStripMenuItem FileMenuImportBt;
        private System.Windows.Forms.ToolStripMenuItem FileMenuExitBt;
        private System.Windows.Forms.ToolStripMenuItem ToolBarHelpMenuBt;
        private System.Windows.Forms.ToolStripMenuItem HelpMenuHowToUseBt;
        private System.Windows.Forms.ToolStripMenuItem HelpMenuAboutBt;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem animationGIFToolStripMenuItem;
        private System.Windows.Forms.Timer timerAnimationGif;
    }
}

