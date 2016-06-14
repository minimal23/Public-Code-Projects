namespace QuanLyThuChi
{
    partial class MainForm
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.MainMenuLabel = new System.Windows.Forms.Label();
            this.InputDataButton = new System.Windows.Forms.Button();
            this.ReportButton = new System.Windows.Forms.Button();
            this.PlanButton = new System.Windows.Forms.Button();
            this.LogoutButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(196, 20);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(206, 20);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // MainMenuLabel
            // 
            this.MainMenuLabel.AutoSize = true;
            this.MainMenuLabel.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuLabel.Location = new System.Drawing.Point(25, 18);
            this.MainMenuLabel.Name = "MainMenuLabel";
            this.MainMenuLabel.Size = new System.Drawing.Size(118, 24);
            this.MainMenuLabel.TabIndex = 1;
            this.MainMenuLabel.Text = "Main Menu";
            // 
            // InputDataButton
            // 
            this.InputDataButton.Location = new System.Drawing.Point(43, 54);
            this.InputDataButton.Name = "InputDataButton";
            this.InputDataButton.Size = new System.Drawing.Size(112, 44);
            this.InputDataButton.TabIndex = 2;
            this.InputDataButton.Text = "Input Data";
            this.InputDataButton.UseVisualStyleBackColor = true;
            this.InputDataButton.Click += new System.EventHandler(this.InputDataButton_Click);
            // 
            // ReportButton
            // 
            this.ReportButton.Location = new System.Drawing.Point(43, 113);
            this.ReportButton.Name = "ReportButton";
            this.ReportButton.Size = new System.Drawing.Size(112, 44);
            this.ReportButton.TabIndex = 3;
            this.ReportButton.Text = "Report";
            this.ReportButton.UseVisualStyleBackColor = true;
            this.ReportButton.Click += new System.EventHandler(this.ReportButton_Click);
            // 
            // PlanButton
            // 
            this.PlanButton.Location = new System.Drawing.Point(43, 174);
            this.PlanButton.Name = "PlanButton";
            this.PlanButton.Size = new System.Drawing.Size(112, 44);
            this.PlanButton.TabIndex = 4;
            this.PlanButton.Text = "Plan";
            this.PlanButton.UseVisualStyleBackColor = true;
            this.PlanButton.Click += new System.EventHandler(this.PlanButton_Click);
            // 
            // LogoutButton
            // 
            this.LogoutButton.Location = new System.Drawing.Point(43, 233);
            this.LogoutButton.Name = "LogoutButton";
            this.LogoutButton.Size = new System.Drawing.Size(112, 44);
            this.LogoutButton.TabIndex = 5;
            this.LogoutButton.Text = "Logout";
            this.LogoutButton.UseVisualStyleBackColor = true;
            this.LogoutButton.Click += new System.EventHandler(this.LogoutButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(43, 293);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(112, 44);
            this.ExitButton.TabIndex = 6;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(434, 364);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.LogoutButton);
            this.Controls.Add(this.PlanButton);
            this.Controls.Add(this.ReportButton);
            this.Controls.Add(this.InputDataButton);
            this.Controls.Add(this.MainMenuLabel);
            this.Controls.Add(this.dateTimePicker1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label MainMenuLabel;
        private System.Windows.Forms.Button InputDataButton;
        private System.Windows.Forms.Button ReportButton;
        private System.Windows.Forms.Button PlanButton;
        private System.Windows.Forms.Button LogoutButton;
        private System.Windows.Forms.Button ExitButton;
    }
}