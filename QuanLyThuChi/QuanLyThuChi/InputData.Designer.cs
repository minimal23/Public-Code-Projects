namespace QuanLyThuChi
{
    partial class InputData
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
            this.InputDataLabel = new System.Windows.Forms.Label();
            this.BackButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // InputDataLabel
            // 
            this.InputDataLabel.AutoSize = true;
            this.InputDataLabel.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputDataLabel.Location = new System.Drawing.Point(25, 18);
            this.InputDataLabel.Name = "InputDataLabel";
            this.InputDataLabel.Size = new System.Drawing.Size(113, 24);
            this.InputDataLabel.TabIndex = 0;
            this.InputDataLabel.Text = "Input Data";
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(321, 310);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(88, 36);
            this.BackButton.TabIndex = 1;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // InputData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 364);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.InputDataLabel);
            this.Name = "InputData";
            this.Text = "InputData";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label InputDataLabel;
        private System.Windows.Forms.Button BackButton;
    }
}