namespace Working_Simulation
{
    partial class Runner
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Run = new System.Windows.Forms.Timer(this.components);
            this.StopBtn = new System.Windows.Forms.Button();
            this.RunBtn = new System.Windows.Forms.Button();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.Time = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Run
            // 
            this.Run.Tick += new System.EventHandler(this.Run_Tick);
            // 
            // StopBtn
            // 
            this.StopBtn.Location = new System.Drawing.Point(433, 67);
            this.StopBtn.Name = "StopBtn";
            this.StopBtn.Size = new System.Drawing.Size(107, 97);
            this.StopBtn.TabIndex = 0;
            this.StopBtn.Text = "Stop";
            this.StopBtn.UseVisualStyleBackColor = true;
            this.StopBtn.Click += new System.EventHandler(this.StopBtn_Click);
            // 
            // RunBtn
            // 
            this.RunBtn.Location = new System.Drawing.Point(213, 67);
            this.RunBtn.Name = "RunBtn";
            this.RunBtn.Size = new System.Drawing.Size(115, 97);
            this.RunBtn.TabIndex = 1;
            this.RunBtn.Text = "Start";
            this.RunBtn.UseVisualStyleBackColor = true;
            this.RunBtn.Click += new System.EventHandler(this.RunBtn_Click);
            // 
            // Timer
            // 
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // Time
            // 
            this.Time.AutoSize = true;
            this.Time.Font = new System.Drawing.Font("Segoe UI", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Time.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Time.Location = new System.Drawing.Point(272, 198);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(248, 72);
            this.Time.TabIndex = 2;
            this.Time.Text = "replenish";
            this.Time.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(344, 296);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "second left...";
            // 
            // Runner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Time);
            this.Controls.Add(this.RunBtn);
            this.Controls.Add(this.StopBtn);
            this.Name = "Runner";
            this.Text = "Runner";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer Run;
        private System.Windows.Forms.Button StopBtn;
        private System.Windows.Forms.Button RunBtn;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Label Time;
        private System.Windows.Forms.Label label1;
    }
}

