namespace Assembly_Line_Kanban
{
    partial class Kanban
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
            this.ConnBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Updater = new System.Windows.Forms.Timer(this.components);
            this.OrderAmount = new System.Windows.Forms.TextBox();
            this.Passed = new System.Windows.Forms.TextBox();
            this.InProcess = new System.Windows.Forms.TextBox();
            this.Total = new System.Windows.Forms.TextBox();
            this.Yield = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ConnBtn
            // 
            this.ConnBtn.Location = new System.Drawing.Point(650, 69);
            this.ConnBtn.Name = "ConnBtn";
            this.ConnBtn.Size = new System.Drawing.Size(75, 23);
            this.ConnBtn.TabIndex = 0;
            this.ConnBtn.Text = "Connect";
            this.ConnBtn.UseVisualStyleBackColor = true;
            this.ConnBtn.Click += new System.EventHandler(this.ConnBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Order Amount";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Passed";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "In Processing";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(64, 276);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "Total";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(64, 360);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "Yield";
            // 
            // Updater
            // 
            this.Updater.Tick += new System.EventHandler(this.Updater_Tick);
            // 
            // OrderAmount
            // 
            this.OrderAmount.Location = new System.Drawing.Point(64, 51);
            this.OrderAmount.Name = "OrderAmount";
            this.OrderAmount.Size = new System.Drawing.Size(100, 23);
            this.OrderAmount.TabIndex = 2;
            // 
            // Passed
            // 
            this.Passed.Location = new System.Drawing.Point(64, 128);
            this.Passed.Name = "Passed";
            this.Passed.Size = new System.Drawing.Size(100, 23);
            this.Passed.TabIndex = 2;
            // 
            // InProcess
            // 
            this.InProcess.Location = new System.Drawing.Point(64, 210);
            this.InProcess.Name = "InProcess";
            this.InProcess.Size = new System.Drawing.Size(100, 23);
            this.InProcess.TabIndex = 2;
            // 
            // Total
            // 
            this.Total.Location = new System.Drawing.Point(64, 294);
            this.Total.Name = "Total";
            this.Total.Size = new System.Drawing.Size(100, 23);
            this.Total.TabIndex = 2;
            // 
            // Yield
            // 
            this.Yield.Location = new System.Drawing.Point(64, 378);
            this.Yield.Name = "Yield";
            this.Yield.Size = new System.Drawing.Size(100, 23);
            this.Yield.TabIndex = 2;
            // 
            // Kanban
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Yield);
            this.Controls.Add(this.Total);
            this.Controls.Add(this.InProcess);
            this.Controls.Add(this.Passed);
            this.Controls.Add(this.OrderAmount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ConnBtn);
            this.Name = "Kanban";
            this.Text = "Kanban";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ConnBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer Updater;
        private System.Windows.Forms.TextBox OrderAmount;
        private System.Windows.Forms.TextBox Passed;
        private System.Windows.Forms.TextBox InProcess;
        private System.Windows.Forms.TextBox Total;
        private System.Windows.Forms.TextBox Yield;
    }
}

