namespace UI.Forms
{
    partial class BackupForm
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
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtBackupPath = new System.Windows.Forms.TextBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnStartBackup = new System.Windows.Forms.Button();
            this.radioButtonTLog = new System.Windows.Forms.RadioButton();
            this.radioButtonFull = new System.Windows.Forms.RadioButton();
            this.comboBoxdatabases = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(517, 151);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(34, 24);
            this.btnBrowse.TabIndex = 14;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click_1);
            // 
            // txtBackupPath
            // 
            this.txtBackupPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBackupPath.Location = new System.Drawing.Point(89, 151);
            this.txtBackupPath.Name = "txtBackupPath";
            this.txtBackupPath.Size = new System.Drawing.Size(422, 24);
            this.txtBackupPath.TabIndex = 13;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(86, 44);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(46, 18);
            this.lblMessage.TabIndex = 12;
            this.lblMessage.Text = "label1";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(367, 287);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(144, 26);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
            // 
            // btnStartBackup
            // 
            this.btnStartBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartBackup.Location = new System.Drawing.Point(92, 287);
            this.btnStartBackup.Name = "btnStartBackup";
            this.btnStartBackup.Size = new System.Drawing.Size(144, 26);
            this.btnStartBackup.TabIndex = 10;
            this.btnStartBackup.Text = "Start Backup";
            this.btnStartBackup.UseVisualStyleBackColor = true;
            this.btnStartBackup.Click += new System.EventHandler(this.btnStartBackup_Click);
            // 
            // radioButtonTLog
            // 
            this.radioButtonTLog.AutoSize = true;
            this.radioButtonTLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonTLog.Location = new System.Drawing.Point(377, 229);
            this.radioButtonTLog.Name = "radioButtonTLog";
            this.radioButtonTLog.Size = new System.Drawing.Size(124, 22);
            this.radioButtonTLog.TabIndex = 9;
            this.radioButtonTLog.TabStop = true;
            this.radioButtonTLog.Text = "TLOG Backup";
            this.radioButtonTLog.UseVisualStyleBackColor = true;
            // 
            // radioButtonFull
            // 
            this.radioButtonFull.AutoSize = true;
            this.radioButtonFull.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonFull.Location = new System.Drawing.Point(110, 229);
            this.radioButtonFull.Name = "radioButtonFull";
            this.radioButtonFull.Size = new System.Drawing.Size(119, 22);
            this.radioButtonFull.TabIndex = 8;
            this.radioButtonFull.TabStop = true;
            this.radioButtonFull.Text = "FULL Backup";
            this.radioButtonFull.UseVisualStyleBackColor = true;
            // 
            // comboBoxdatabases
            // 
            this.comboBoxdatabases.FormattingEnabled = true;
            this.comboBoxdatabases.Location = new System.Drawing.Point(92, 89);
            this.comboBoxdatabases.Name = "comboBoxdatabases";
            this.comboBoxdatabases.Size = new System.Drawing.Size(371, 24);
            this.comboBoxdatabases.TabIndex = 15;
            // 
            // BackupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 343);
            this.Controls.Add(this.comboBoxdatabases);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtBackupPath);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnStartBackup);
            this.Controls.Add(this.radioButtonTLog);
            this.Controls.Add(this.radioButtonFull);
            this.Name = "BackupForm";
            this.Text = "BackupForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtBackupPath;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnStartBackup;
        private System.Windows.Forms.RadioButton radioButtonTLog;
        private System.Windows.Forms.RadioButton radioButtonFull;
        private System.Windows.Forms.ComboBox comboBoxdatabases;
    }
}