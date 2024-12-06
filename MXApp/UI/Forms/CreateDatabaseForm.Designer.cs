namespace UI.Forms
{
    partial class CreateDatabaseForm
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
            this.btnBrowseLog = new System.Windows.Forms.Button();
            this.btnBrowseData = new System.Windows.Forms.Button();
            this.btnCreateDatabase = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxRecoveryModel = new System.Windows.Forms.ComboBox();
            this.txtLogPath = new System.Windows.Forms.TextBox();
            this.txtDataPath = new System.Windows.Forms.TextBox();
            this.txtDatabaseName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnBrowseLog
            // 
            this.btnBrowseLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseLog.Location = new System.Drawing.Point(651, 250);
            this.btnBrowseLog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBrowseLog.Name = "btnBrowseLog";
            this.btnBrowseLog.Size = new System.Drawing.Size(39, 36);
            this.btnBrowseLog.TabIndex = 24;
            this.btnBrowseLog.Text = "...";
            this.btnBrowseLog.UseVisualStyleBackColor = true;
            this.btnBrowseLog.Click += new System.EventHandler(this.btnBrowseLog_Click);
            // 
            // btnBrowseData
            // 
            this.btnBrowseData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseData.Location = new System.Drawing.Point(651, 177);
            this.btnBrowseData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBrowseData.Name = "btnBrowseData";
            this.btnBrowseData.Size = new System.Drawing.Size(39, 33);
            this.btnBrowseData.TabIndex = 23;
            this.btnBrowseData.Text = "...";
            this.btnBrowseData.UseVisualStyleBackColor = true;
            this.btnBrowseData.Click += new System.EventHandler(this.btnBrowseData_Click);
            // 
            // btnCreateDatabase
            // 
            this.btnCreateDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateDatabase.Location = new System.Drawing.Point(259, 428);
            this.btnCreateDatabase.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCreateDatabase.Name = "btnCreateDatabase";
            this.btnCreateDatabase.Size = new System.Drawing.Size(178, 45);
            this.btnCreateDatabase.TabIndex = 22;
            this.btnCreateDatabase.Text = "Create";
            this.btnCreateDatabase.UseVisualStyleBackColor = true;
            this.btnCreateDatabase.Click += new System.EventHandler(this.btnCreateDatabase_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(58, 303);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 22);
            this.label5.TabIndex = 21;
            this.label5.Text = "Recovery Model";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(58, 222);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 22);
            this.label4.TabIndex = 20;
            this.label4.Text = "Log File Path";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(58, 149);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 22);
            this.label3.TabIndex = 19;
            this.label3.Text = "Data File Path";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(58, 64);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 22);
            this.label1.TabIndex = 18;
            this.label1.Text = "Database Name";
            // 
            // comboBoxRecoveryModel
            // 
            this.comboBoxRecoveryModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxRecoveryModel.FormattingEnabled = true;
            this.comboBoxRecoveryModel.Items.AddRange(new object[] {
            "FULL",
            "SIMPLE"});
            this.comboBoxRecoveryModel.Location = new System.Drawing.Point(62, 329);
            this.comboBoxRecoveryModel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxRecoveryModel.Name = "comboBoxRecoveryModel";
            this.comboBoxRecoveryModel.Size = new System.Drawing.Size(174, 30);
            this.comboBoxRecoveryModel.TabIndex = 17;
            // 
            // txtLogPath
            // 
            this.txtLogPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLogPath.Location = new System.Drawing.Point(62, 250);
            this.txtLogPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLogPath.Name = "txtLogPath";
            this.txtLogPath.Size = new System.Drawing.Size(589, 28);
            this.txtLogPath.TabIndex = 16;
            // 
            // txtDataPath
            // 
            this.txtDataPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataPath.Location = new System.Drawing.Point(62, 177);
            this.txtDataPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDataPath.Name = "txtDataPath";
            this.txtDataPath.Size = new System.Drawing.Size(589, 28);
            this.txtDataPath.TabIndex = 15;
            // 
            // txtDatabaseName
            // 
            this.txtDatabaseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDatabaseName.Location = new System.Drawing.Point(62, 92);
            this.txtDatabaseName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDatabaseName.Name = "txtDatabaseName";
            this.txtDatabaseName.Size = new System.Drawing.Size(589, 28);
            this.txtDatabaseName.TabIndex = 14;
            // 
            // CreateDatabaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 509);
            this.Controls.Add(this.btnBrowseLog);
            this.Controls.Add(this.btnBrowseData);
            this.Controls.Add(this.btnCreateDatabase);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxRecoveryModel);
            this.Controls.Add(this.txtLogPath);
            this.Controls.Add(this.txtDataPath);
            this.Controls.Add(this.txtDatabaseName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "CreateDatabaseForm";
            this.Text = "CreateDatabaseForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBrowseLog;
        private System.Windows.Forms.Button btnBrowseData;
        private System.Windows.Forms.Button btnCreateDatabase;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxRecoveryModel;
        private System.Windows.Forms.TextBox txtLogPath;
        private System.Windows.Forms.TextBox txtDataPath;
        private System.Windows.Forms.TextBox txtDatabaseName;
    }
}