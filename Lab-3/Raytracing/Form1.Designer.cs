namespace OpenGL
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.openGlControl = new OpenTK.GLControl();
            this.SuspendLayout();
 
            this.timer.Enabled = true;

            this.openGlControl.BackColor = System.Drawing.Color.Black;
            this.openGlControl.Location = new System.Drawing.Point(9, 6);
            this.openGlControl.Margin = new System.Windows.Forms.Padding(1);
            this.openGlControl.Name = "openGlControl";
            this.openGlControl.Size = new System.Drawing.Size(531, 483);
            this.openGlControl.TabIndex = 0;
            this.openGlControl.VSync = false;
            this.openGlControl.Load += new System.EventHandler(this.openGlControl_Load);
            this.openGlControl.Paint += new System.Windows.Forms.PaintEventHandler(this.openGlControl_Paint);
            this.openGlControl.Resize += new System.EventHandler(this.openGlControl_Resize);
 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 499);
            this.Controls.Add(this.openGlControl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ClientSizeChanged += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private OpenTK.GLControl openGlControl;
    }
}

