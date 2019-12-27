namespace Pwned
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.CheckPasswordBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Password";
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(141, 68);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(197, 20);
            this.PasswordTextBox.TabIndex = 1;
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.Location = new System.Drawing.Point(138, 127);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(58, 13);
            this.ErrorLabel.TabIndex = 2;
            this.ErrorLabel.Text = "Error Label";
            this.ErrorLabel.Visible = false;
            // 
            // CheckPasswordBtn
            // 
            this.CheckPasswordBtn.Location = new System.Drawing.Point(141, 172);
            this.CheckPasswordBtn.Name = "CheckPasswordBtn";
            this.CheckPasswordBtn.Size = new System.Drawing.Size(197, 23);
            this.CheckPasswordBtn.TabIndex = 3;
            this.CheckPasswordBtn.Text = "Check Password";
            this.CheckPasswordBtn.UseVisualStyleBackColor = true;
            this.CheckPasswordBtn.Click += new System.EventHandler(this.CheckPasswordBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 288);
            this.Controls.Add(this.CheckPasswordBtn);
            this.Controls.Add(this.ErrorLabel);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Label ErrorLabel;
        private System.Windows.Forms.Button CheckPasswordBtn;
    }
}

