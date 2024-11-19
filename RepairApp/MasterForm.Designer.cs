namespace RepairApp
{
    partial class MasterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MasterForm));
            this.addCommentButton = new System.Windows.Forms.Button();
            this.completeRequestButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblFIO = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.commentTextBox = new System.Windows.Forms.TextBox();
            this.requestsDataGridView = new System.Windows.Forms.DataGridView();
            this.requestsTableAdapter = new RepairApp.DataSet1TableAdapters.RequestsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.requestsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // addCommentButton
            // 
            this.addCommentButton.Location = new System.Drawing.Point(40, 68);
            this.addCommentButton.Name = "addCommentButton";
            this.addCommentButton.Size = new System.Drawing.Size(168, 61);
            this.addCommentButton.TabIndex = 1;
            this.addCommentButton.Text = "Добавить комментарий к заявке";
            this.addCommentButton.UseVisualStyleBackColor = true;
            this.addCommentButton.Click += new System.EventHandler(this.addCommentButton_Click);
            // 
            // completeRequestButton
            // 
            this.completeRequestButton.Location = new System.Drawing.Point(40, 135);
            this.completeRequestButton.Name = "completeRequestButton";
            this.completeRequestButton.Size = new System.Drawing.Size(168, 23);
            this.completeRequestButton.TabIndex = 2;
            this.completeRequestButton.Text = "Завершить заявку";
            this.completeRequestButton.UseVisualStyleBackColor = true;
            this.completeRequestButton.Click += new System.EventHandler(this.completeRequestButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(40, 355);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 29);
            this.button1.TabIndex = 10;
            this.button1.Text = "Выход";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(887, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(123, 131);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // lblFIO
            // 
            this.lblFIO.AutoSize = true;
            this.lblFIO.Location = new System.Drawing.Point(853, 200);
            this.lblFIO.Name = "lblFIO";
            this.lblFIO.Size = new System.Drawing.Size(0, 16);
            this.lblFIO.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(837, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 16);
            this.label4.TabIndex = 22;
            this.label4.Text = "ФИО:";
            // 
            // commentTextBox
            // 
            this.commentTextBox.Location = new System.Drawing.Point(40, 27);
            this.commentTextBox.Name = "commentTextBox";
            this.commentTextBox.Size = new System.Drawing.Size(168, 22);
            this.commentTextBox.TabIndex = 26;
            // 
            // requestsDataGridView
            // 
            this.requestsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.requestsDataGridView.Location = new System.Drawing.Point(242, 27);
            this.requestsDataGridView.Name = "requestsDataGridView";
            this.requestsDataGridView.RowHeadersWidth = 51;
            this.requestsDataGridView.RowTemplate.Height = 24;
            this.requestsDataGridView.Size = new System.Drawing.Size(572, 357);
            this.requestsDataGridView.TabIndex = 27;
            // 
            // requestsTableAdapter
            // 
            this.requestsTableAdapter.ClearBeforeFill = true;
            // 
            // MasterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1058, 450);
            this.Controls.Add(this.requestsDataGridView);
            this.Controls.Add(this.commentTextBox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblFIO);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.completeRequestButton);
            this.Controls.Add(this.addCommentButton);
            this.Name = "MasterForm";
            this.Text = "Мастер";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.requestsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button addCommentButton;
        private System.Windows.Forms.Button completeRequestButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblFIO;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox commentTextBox;
        
        private System.Windows.Forms.DataGridView requestsDataGridView;
     
        private System.Windows.Forms.DataGridViewTextBoxColumn requestIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn startDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn problemDescriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn reportDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn masterIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn homeTechIDDataGridViewTextBoxColumn;
        private DataSet1TableAdapters.RequestsTableAdapter requestsTableAdapter;
    }
}