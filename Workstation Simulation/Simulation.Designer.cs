namespace Workstation_Simulation
{
    partial class Simulation
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
            this.ActivateBtn = new System.Windows.Forms.Button();
            this.DeactivateBtn = new System.Windows.Forms.Button();
            this.EmployeeComboBox = new System.Windows.Forms.ComboBox();
            this.AddBtn = new System.Windows.Forms.Button();
            this.RefreshBtn = new System.Windows.Forms.Button();
            this.AssemblyLines = new System.Windows.Forms.ListBox();
            this.EmployeeList = new System.Windows.Forms.ListBox();
            this.ActivatedLines = new System.Windows.Forms.ListBox();
            this.WorkSpeed = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // ConnBtn
            // 
            this.ConnBtn.Location = new System.Drawing.Point(658, 44);
            this.ConnBtn.Name = "ConnBtn";
            this.ConnBtn.Size = new System.Drawing.Size(75, 23);
            this.ConnBtn.TabIndex = 0;
            this.ConnBtn.Text = "Connect";
            this.ConnBtn.UseVisualStyleBackColor = true;
            this.ConnBtn.Click += new System.EventHandler(this.ConnBtn_Click);
            // 
            // ActivateBtn
            // 
            this.ActivateBtn.Location = new System.Drawing.Point(658, 195);
            this.ActivateBtn.Name = "ActivateBtn";
            this.ActivateBtn.Size = new System.Drawing.Size(75, 23);
            this.ActivateBtn.TabIndex = 0;
            this.ActivateBtn.Text = "Activate";
            this.ActivateBtn.UseVisualStyleBackColor = true;
            this.ActivateBtn.Click += new System.EventHandler(this.ActivateBtn_Click);
            // 
            // DeactivateBtn
            // 
            this.DeactivateBtn.Location = new System.Drawing.Point(658, 351);
            this.DeactivateBtn.Name = "DeactivateBtn";
            this.DeactivateBtn.Size = new System.Drawing.Size(75, 23);
            this.DeactivateBtn.TabIndex = 0;
            this.DeactivateBtn.Text = "Deactivate";
            this.DeactivateBtn.UseVisualStyleBackColor = true;
            this.DeactivateBtn.Click += new System.EventHandler(this.DeactivateBtn_Click);
            // 
            // EmployeeComboBox
            // 
            this.EmployeeComboBox.FormattingEnabled = true;
            this.EmployeeComboBox.Location = new System.Drawing.Point(45, 44);
            this.EmployeeComboBox.Name = "EmployeeComboBox";
            this.EmployeeComboBox.Size = new System.Drawing.Size(121, 23);
            this.EmployeeComboBox.TabIndex = 1;
            // 
            // AddBtn
            // 
            this.AddBtn.Location = new System.Drawing.Point(192, 44);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(75, 23);
            this.AddBtn.TabIndex = 0;
            this.AddBtn.Text = "Add";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // RefreshBtn
            // 
            this.RefreshBtn.Location = new System.Drawing.Point(192, 142);
            this.RefreshBtn.Name = "RefreshBtn";
            this.RefreshBtn.Size = new System.Drawing.Size(75, 23);
            this.RefreshBtn.TabIndex = 0;
            this.RefreshBtn.Text = "Refresh";
            this.RefreshBtn.UseVisualStyleBackColor = true;
            this.RefreshBtn.Click += new System.EventHandler(this.RefreshBtn_Click);
            // 
            // AssemblyLines
            // 
            this.AssemblyLines.FormattingEnabled = true;
            this.AssemblyLines.ItemHeight = 15;
            this.AssemblyLines.Location = new System.Drawing.Point(340, 195);
            this.AssemblyLines.Name = "AssemblyLines";
            this.AssemblyLines.Size = new System.Drawing.Size(120, 94);
            this.AssemblyLines.TabIndex = 2;
            // 
            // EmployeeList
            // 
            this.EmployeeList.FormattingEnabled = true;
            this.EmployeeList.ItemHeight = 15;
            this.EmployeeList.Location = new System.Drawing.Point(45, 195);
            this.EmployeeList.Name = "EmployeeList";
            this.EmployeeList.Size = new System.Drawing.Size(120, 94);
            this.EmployeeList.TabIndex = 3;
            // 
            // ActivatedLines
            // 
            this.ActivatedLines.FormattingEnabled = true;
            this.ActivatedLines.ItemHeight = 15;
            this.ActivatedLines.Location = new System.Drawing.Point(340, 351);
            this.ActivatedLines.Name = "ActivatedLines";
            this.ActivatedLines.Size = new System.Drawing.Size(120, 94);
            this.ActivatedLines.TabIndex = 4;
            // 
            // Simulation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ActivatedLines);
            this.Controls.Add(this.EmployeeList);
            this.Controls.Add(this.AssemblyLines);
            this.Controls.Add(this.RefreshBtn);
            this.Controls.Add(this.AddBtn);
            this.Controls.Add(this.EmployeeComboBox);
            this.Controls.Add(this.DeactivateBtn);
            this.Controls.Add(this.ActivateBtn);
            this.Controls.Add(this.ConnBtn);
            this.Name = "Simulation";
            this.Text = "Workstaion Simulation";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ConnBtn;
        private System.Windows.Forms.Button ActivateBtn;
        private System.Windows.Forms.Button DeactivateBtn;
        private System.Windows.Forms.ComboBox EmployeeComboBox;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Button RefreshBtn;
        private System.Windows.Forms.ListBox AssemblyLines;
        private System.Windows.Forms.ListBox EmployeeList;
        private System.Windows.Forms.ListBox ActivatedLines;
        private System.Windows.Forms.Timer WorkSpeed;
    }
}

