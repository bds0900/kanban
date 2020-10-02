namespace Workstation_Andon
{
    partial class Andon
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
            this.Harness = new System.Windows.Forms.ProgressBar();
            this.Housing = new System.Windows.Forms.ProgressBar();
            this.Lens = new System.Windows.Forms.ProgressBar();
            this.Bulb = new System.Windows.Forms.ProgressBar();
            this.Bezel = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.LineList = new System.Windows.Forms.ListBox();
            this.ConnBtn = new System.Windows.Forms.Button();
            this.HarnessPer = new System.Windows.Forms.Label();
            this.ReflectorPer = new System.Windows.Forms.Label();
            this.HousingPer = new System.Windows.Forms.Label();
            this.LensPer = new System.Windows.Forms.Label();
            this.BulbPer = new System.Windows.Forms.Label();
            this.Reflector = new System.Windows.Forms.ProgressBar();
            this.BezelPer = new System.Windows.Forms.Label();
            this.Updater = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Harness
            // 
            this.Harness.Location = new System.Drawing.Point(121, 60);
            this.Harness.Name = "Harness";
            this.Harness.Size = new System.Drawing.Size(339, 23);
            this.Harness.TabIndex = 0;
            // 
            // Housing
            // 
            this.Housing.Location = new System.Drawing.Point(121, 155);
            this.Housing.Name = "Housing";
            this.Housing.Size = new System.Drawing.Size(339, 23);
            this.Housing.TabIndex = 0;
            // 
            // Lens
            // 
            this.Lens.Location = new System.Drawing.Point(121, 201);
            this.Lens.Name = "Lens";
            this.Lens.Size = new System.Drawing.Size(339, 23);
            this.Lens.TabIndex = 0;
            // 
            // Bulb
            // 
            this.Bulb.Location = new System.Drawing.Point(121, 248);
            this.Bulb.Name = "Bulb";
            this.Bulb.Size = new System.Drawing.Size(339, 23);
            this.Bulb.TabIndex = 0;
            // 
            // Bezel
            // 
            this.Bezel.Location = new System.Drawing.Point(121, 299);
            this.Bezel.Name = "Bezel";
            this.Bezel.Size = new System.Drawing.Size(339, 23);
            this.Bezel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Harness";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Reflector";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Housing";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "Lens";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 248);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "Bulb";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 299);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 15);
            this.label6.TabIndex = 1;
            this.label6.Text = "Bezel";
            // 
            // LineList
            // 
            this.LineList.FormattingEnabled = true;
            this.LineList.ItemHeight = 15;
            this.LineList.Location = new System.Drawing.Point(561, 60);
            this.LineList.Name = "LineList";
            this.LineList.Size = new System.Drawing.Size(120, 94);
            this.LineList.TabIndex = 2;
            this.LineList.SelectedIndexChanged += new System.EventHandler(this.LineList_SelectedIndexChanged);
            // 
            // ConnBtn
            // 
            this.ConnBtn.Location = new System.Drawing.Point(704, 60);
            this.ConnBtn.Name = "ConnBtn";
            this.ConnBtn.Size = new System.Drawing.Size(75, 23);
            this.ConnBtn.TabIndex = 3;
            this.ConnBtn.Text = "Connect";
            this.ConnBtn.UseVisualStyleBackColor = true;
            this.ConnBtn.Click += new System.EventHandler(this.ConnBtn_Click);
            // 
            // HarnessPer
            // 
            this.HarnessPer.AutoSize = true;
            this.HarnessPer.Location = new System.Drawing.Point(466, 64);
            this.HarnessPer.Name = "HarnessPer";
            this.HarnessPer.Size = new System.Drawing.Size(0, 15);
            this.HarnessPer.TabIndex = 4;
            // 
            // ReflectorPer
            // 
            this.ReflectorPer.AutoSize = true;
            this.ReflectorPer.Location = new System.Drawing.Point(466, 108);
            this.ReflectorPer.Name = "ReflectorPer";
            this.ReflectorPer.Size = new System.Drawing.Size(0, 15);
            this.ReflectorPer.TabIndex = 4;
            // 
            // HousingPer
            // 
            this.HousingPer.AutoSize = true;
            this.HousingPer.Location = new System.Drawing.Point(466, 155);
            this.HousingPer.Name = "HousingPer";
            this.HousingPer.Size = new System.Drawing.Size(0, 15);
            this.HousingPer.TabIndex = 4;
            // 
            // LensPer
            // 
            this.LensPer.AutoSize = true;
            this.LensPer.Location = new System.Drawing.Point(466, 201);
            this.LensPer.Name = "LensPer";
            this.LensPer.Size = new System.Drawing.Size(0, 15);
            this.LensPer.TabIndex = 4;
            // 
            // BulbPer
            // 
            this.BulbPer.AutoSize = true;
            this.BulbPer.Location = new System.Drawing.Point(466, 248);
            this.BulbPer.Name = "BulbPer";
            this.BulbPer.Size = new System.Drawing.Size(0, 15);
            this.BulbPer.TabIndex = 4;
            // 
            // Reflector
            // 
            this.Reflector.Location = new System.Drawing.Point(121, 108);
            this.Reflector.Name = "Reflector";
            this.Reflector.Size = new System.Drawing.Size(339, 23);
            this.Reflector.TabIndex = 0;
            // 
            // BezelPer
            // 
            this.BezelPer.AutoSize = true;
            this.BezelPer.Location = new System.Drawing.Point(466, 299);
            this.BezelPer.Name = "BezelPer";
            this.BezelPer.Size = new System.Drawing.Size(0, 15);
            this.BezelPer.TabIndex = 4;
            // 
            // Updater
            // 
            this.Updater.Tick += new System.EventHandler(this.Updater_Tick);
            // 
            // Andon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BezelPer);
            this.Controls.Add(this.Reflector);
            this.Controls.Add(this.BulbPer);
            this.Controls.Add(this.LensPer);
            this.Controls.Add(this.HousingPer);
            this.Controls.Add(this.ReflectorPer);
            this.Controls.Add(this.HarnessPer);
            this.Controls.Add(this.ConnBtn);
            this.Controls.Add(this.LineList);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Bezel);
            this.Controls.Add(this.Bulb);
            this.Controls.Add(this.Lens);
            this.Controls.Add(this.Housing);
            this.Controls.Add(this.Harness);
            this.Name = "Andon";
            this.Text = "Workstation Andon";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar Harness;
        private System.Windows.Forms.ProgressBar Housing;
        private System.Windows.Forms.ProgressBar Lens;
        private System.Windows.Forms.ProgressBar Bulb;
        private System.Windows.Forms.ProgressBar Bezel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox LineList;
        private System.Windows.Forms.Button ConnBtn;
        private System.Windows.Forms.Label HarnessPer;
        private System.Windows.Forms.Label ReflectorPer;
        private System.Windows.Forms.Label HousingPer;
        private System.Windows.Forms.Label LensPer;
        private System.Windows.Forms.Label BulbPer;
        private System.Windows.Forms.ProgressBar Reflector;
        private System.Windows.Forms.Label BezelPer;
        private System.Windows.Forms.Timer Updater;
    }
}

