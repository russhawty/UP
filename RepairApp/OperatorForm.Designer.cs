namespace RepairApp
{
    partial class OperatorForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OperatorForm));
            this.requestsDataGridView = new System.Windows.Forms.DataGridView();
            this.requestsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.updateStatusButton = new System.Windows.Forms.Button();
            this.deleteRequestButton = new System.Windows.Forms.Button();
            this.countLabel = new System.Windows.Forms.Label();
            this.statusComboBox = new System.Windows.Forms.ComboBox();
            this.viewLoginHistoryButton = new System.Windows.Forms.Button();
            this.saveChangesButton = new System.Windows.Forms.Button();
            this.lblFIO = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.masterComboBox = new System.Windows.Forms.ComboBox();
            this.assignMasterButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.requestsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.requestsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // requestsDataGridView
            // 
            this.requestsDataGridView.AllowUserToOrderColumns = true;
            this.requestsDataGridView.AutoGenerateColumns = false;
            this.requestsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.requestsDataGridView.DataSource = this.requestsBindingSource;
            this.requestsDataGridView.Location = new System.Drawing.Point(173, 9);
            this.requestsDataGridView.Name = "requestsDataGridView";
            this.requestsDataGridView.RowHeadersWidth = 51;
            this.requestsDataGridView.RowTemplate.Height = 24;
            this.requestsDataGridView.Size = new System.Drawing.Size(654, 456);
            this.requestsDataGridView.TabIndex = 0;
            // 
            // requestsBindingSource
            // 
            this.requestsBindingSource.DataMember = "Requests";
            // 
            // updateStatusButton
            // 
            this.updateStatusButton.Location = new System.Drawing.Point(13, 65);
            this.updateStatusButton.Name = "updateStatusButton";
            this.updateStatusButton.Size = new System.Drawing.Size(124, 46);
            this.updateStatusButton.TabIndex = 1;
            this.updateStatusButton.Text = "Обновить статус";
            this.updateStatusButton.UseVisualStyleBackColor = true;
            this.updateStatusButton.Click += new System.EventHandler(this.updateStatusButton_Click);
            // 
            // deleteRequestButton
            // 
            this.deleteRequestButton.Location = new System.Drawing.Point(13, 337);
            this.deleteRequestButton.Name = "deleteRequestButton";
            this.deleteRequestButton.Size = new System.Drawing.Size(124, 45);
            this.deleteRequestButton.TabIndex = 2;
            this.deleteRequestButton.Text = "Удалить заявку";
            this.deleteRequestButton.UseVisualStyleBackColor = true;
            this.deleteRequestButton.Click += new System.EventHandler(this.deleteRequestButton_Click);
            // 
            // countLabel
            // 
            this.countLabel.AutoSize = true;
            this.countLabel.Location = new System.Drawing.Point(652, 9);
            this.countLabel.Name = "countLabel";
            this.countLabel.Size = new System.Drawing.Size(0, 16);
            this.countLabel.TabIndex = 4;
            // 
            // statusComboBox
            // 
            this.statusComboBox.FormattingEnabled = true;
            this.statusComboBox.Items.AddRange(new object[] {
            "Новая заявка",
            "В работе",
            "Завершена"});
            this.statusComboBox.Location = new System.Drawing.Point(13, 30);
            this.statusComboBox.Name = "statusComboBox";
            this.statusComboBox.Size = new System.Drawing.Size(121, 24);
            this.statusComboBox.TabIndex = 5;
            // 
            // viewLoginHistoryButton
            // 
            this.viewLoginHistoryButton.Location = new System.Drawing.Point(438, 485);
            this.viewLoginHistoryButton.Name = "viewLoginHistoryButton";
            this.viewLoginHistoryButton.Size = new System.Drawing.Size(113, 58);
            this.viewLoginHistoryButton.TabIndex = 6;
            this.viewLoginHistoryButton.Text = "История входов";
            this.viewLoginHistoryButton.UseVisualStyleBackColor = true;
            this.viewLoginHistoryButton.Click += new System.EventHandler(this.viewLoginHistoryButton_Click);
            // 
            // saveChangesButton
            // 
            this.saveChangesButton.Location = new System.Drawing.Point(13, 275);
            this.saveChangesButton.Name = "saveChangesButton";
            this.saveChangesButton.Size = new System.Drawing.Size(124, 46);
            this.saveChangesButton.TabIndex = 7;
            this.saveChangesButton.Text = "Сохранить изменения";
            this.saveChangesButton.UseVisualStyleBackColor = true;
            this.saveChangesButton.Click += new System.EventHandler(this.saveChangesButton_Click);
            // 
            // lblFIO
            // 
            this.lblFIO.AutoSize = true;
            this.lblFIO.Location = new System.Drawing.Point(855, 198);
            this.lblFIO.Name = "lblFIO";
            this.lblFIO.Size = new System.Drawing.Size(0, 16);
            this.lblFIO.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(845, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 16);
            this.label6.TabIndex = 24;
            this.label6.Text = "ФИО:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(890, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(123, 131);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // masterComboBox
            // 
            this.masterComboBox.FormattingEnabled = true;
            this.masterComboBox.Location = new System.Drawing.Point(16, 137);
            this.masterComboBox.Name = "masterComboBox";
            this.masterComboBox.Size = new System.Drawing.Size(121, 24);
            this.masterComboBox.TabIndex = 26;
            // 
            // assignMasterButton
            // 
            this.assignMasterButton.Location = new System.Drawing.Point(13, 183);
            this.assignMasterButton.Name = "assignMasterButton";
            this.assignMasterButton.Size = new System.Drawing.Size(124, 46);
            this.assignMasterButton.TabIndex = 27;
            this.assignMasterButton.Text = "Назначить мастера";
            this.assignMasterButton.UseVisualStyleBackColor = true;
            this.assignMasterButton.Click += new System.EventHandler(this.assignMasterButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 442);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 28;
            this.button1.Text = "Выход";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // OperatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1038, 605);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.assignMasterButton);
            this.Controls.Add(this.masterComboBox);
            this.Controls.Add(this.lblFIO);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.saveChangesButton);
            this.Controls.Add(this.viewLoginHistoryButton);
            this.Controls.Add(this.statusComboBox);
            this.Controls.Add(this.countLabel);
            this.Controls.Add(this.deleteRequestButton);
            this.Controls.Add(this.updateStatusButton);
            this.Controls.Add(this.requestsDataGridView);
            this.Name = "OperatorForm";
            this.Text = "Оператор";
            ((System.ComponentModel.ISupportInitialize)(this.requestsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.requestsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView requestsDataGridView;
        private System.Windows.Forms.Button updateStatusButton;
        private System.Windows.Forms.Button deleteRequestButton;
        private System.Windows.Forms.Label countLabel;
        private System.Windows.Forms.ComboBox statusComboBox;
        private System.Windows.Forms.Button viewLoginHistoryButton;
      
        private System.Windows.Forms.BindingSource requestsBindingSource;
     
        private System.Windows.Forms.DataGridViewTextBoxColumn requestIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn startDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn problemDescriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn reportDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn masterIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn homeTechIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button saveChangesButton;
        private System.Windows.Forms.Label lblFIO;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox masterComboBox;
        private System.Windows.Forms.Button assignMasterButton;
        private System.Windows.Forms.Button button1;
    }
}