namespace RepairApp
{
    partial class LoginHistoryForm
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
            this.sortByDateButton = new System.Windows.Forms.Button();
            this.loginHistoryDataGridView = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.loginHistoryDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // sortByDateButton
            // 
            this.sortByDateButton.Location = new System.Drawing.Point(23, 133);
            this.sortByDateButton.Name = "sortByDateButton";
            this.sortByDateButton.Size = new System.Drawing.Size(130, 48);
            this.sortByDateButton.TabIndex = 0;
            this.sortByDateButton.Text = "Сортировать по дате";
            this.sortByDateButton.UseVisualStyleBackColor = true;
            this.sortByDateButton.Click += new System.EventHandler(this.sortByDateButton_Click);
            // 
            // loginHistoryDataGridView
            // 
            this.loginHistoryDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.loginHistoryDataGridView.Location = new System.Drawing.Point(171, 47);
            this.loginHistoryDataGridView.Name = "loginHistoryDataGridView";
            this.loginHistoryDataGridView.RowHeadersWidth = 51;
            this.loginHistoryDataGridView.RowTemplate.Height = 24;
            this.loginHistoryDataGridView.Size = new System.Drawing.Size(678, 257);
            this.loginHistoryDataGridView.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(23, 280);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(69, 24);
            this.button1.TabIndex = 2;
            this.button1.Text = "Выход";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LoginHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 403);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.loginHistoryDataGridView);
            this.Controls.Add(this.sortByDateButton);
            this.Name = "LoginHistoryForm";
            this.Text = "История входа";
            ((System.ComponentModel.ISupportInitialize)(this.loginHistoryDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button sortByDateButton;
        private System.Windows.Forms.DataGridView loginHistoryDataGridView;
        
        private System.Windows.Forms.DataGridViewTextBoxColumn loginDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn attemptTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn successDataGridViewCheckBoxColumn;
        private System.Windows.Forms.Button button1;
    }
}