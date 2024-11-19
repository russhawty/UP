using System;

namespace RepairApp
{
    partial class RegisterForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.fioRegTextBox = new System.Windows.Forms.TextBox();
            this.phoneRegTextBox = new System.Windows.Forms.TextBox();
            this.loginRegTextBox = new System.Windows.Forms.TextBox();
            this.passwordRegTextBox = new System.Windows.Forms.TextBox();
            this.registerButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(105, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "ФИО";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Номер телефона";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(105, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Логин";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(105, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Пароль";
            // 
            // fioRegTextBox
            // 
            this.fioRegTextBox.Location = new System.Drawing.Point(108, 67);
            this.fioRegTextBox.Name = "fioRegTextBox";
            this.fioRegTextBox.Size = new System.Drawing.Size(100, 22);
            this.fioRegTextBox.TabIndex = 4;
            // 
            // phoneRegTextBox
            // 
            this.phoneRegTextBox.Location = new System.Drawing.Point(108, 123);
            this.phoneRegTextBox.Name = "phoneRegTextBox";
            this.phoneRegTextBox.Size = new System.Drawing.Size(100, 22);
            this.phoneRegTextBox.TabIndex = 5;
            // 
            // loginRegTextBox
            // 
            this.loginRegTextBox.Location = new System.Drawing.Point(108, 174);
            this.loginRegTextBox.Name = "loginRegTextBox";
            this.loginRegTextBox.Size = new System.Drawing.Size(100, 22);
            this.loginRegTextBox.TabIndex = 6;
            // 
            // passwordRegTextBox
            // 
            this.passwordRegTextBox.Location = new System.Drawing.Point(108, 224);
            this.passwordRegTextBox.Name = "passwordRegTextBox";
            this.passwordRegTextBox.Size = new System.Drawing.Size(100, 22);
            this.passwordRegTextBox.TabIndex = 7;
            // 
            // registerButton
            // 
            this.registerButton.Location = new System.Drawing.Point(79, 265);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(165, 23);
            this.registerButton.TabIndex = 8;
            this.registerButton.Text = "Зарегистрироваться";
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(324, 320);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.passwordRegTextBox);
            this.Controls.Add(this.loginRegTextBox);
            this.Controls.Add(this.phoneRegTextBox);
            this.Controls.Add(this.fioRegTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RegisterForm";
            this.Text = "Регистрация";
            this.ResumeLayout(false);
            this.PerformLayout();

        }




        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox fioRegTextBox;
        private System.Windows.Forms.TextBox phoneRegTextBox;
        private System.Windows.Forms.TextBox loginRegTextBox;
        private System.Windows.Forms.TextBox passwordRegTextBox;
        private System.Windows.Forms.Button registerButton;
    }
}