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
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(573, 172);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(42, 33);
            this.btnBrowse.TabIndex = 14;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click_1);
            // 
            // txtBackupPath
            // 
            this.txtBackupPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBackupPath.Location = new System.Drawing.Point(39, 175);
            this.txtBackupPath.Margin = new System.Windows.Forms.Padding(4);
            this.txtBackupPath.Name = "txtBackupPath";
            this.txtBackupPath.Size = new System.Drawing.Size(526, 24);
            this.txtBackupPath.TabIndex = 13;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(50, 36);
            this.lblMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(184, 18);
            this.lblMessage.TabIndex = 12;
            this.lblMessage.Tag = "Nombre de Base de Datos";
            this.lblMessage.Text = "Nombre de Base de Datos";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(374, 337);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(180, 36);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Tag = "Cancelar";
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
            // 
            // btnStartBackup
            // 
            this.btnStartBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartBackup.Location = new System.Drawing.Point(30, 337);
            this.btnStartBackup.Margin = new System.Windows.Forms.Padding(4);
            this.btnStartBackup.Name = "btnStartBackup";
            this.btnStartBackup.Size = new System.Drawing.Size(180, 36);
            this.btnStartBackup.TabIndex = 10;
            this.btnStartBackup.Tag = "Inciar Respaldo";
            this.btnStartBackup.Text = "Inciar Respaldo";
            this.btnStartBackup.UseVisualStyleBackColor = true;
            this.btnStartBackup.Click += new System.EventHandler(this.btnStartBackup_Click);
            // 
            // radioButtonTLog
            // 
            this.radioButtonTLog.AutoSize = true;
            this.radioButtonTLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonTLog.Location = new System.Drawing.Point(386, 257);
            this.radioButtonTLog.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonTLog.Name = "radioButtonTLog";
            this.radioButtonTLog.Size = new System.Drawing.Size(137, 22);
            this.radioButtonTLog.TabIndex = 9;
            this.radioButtonTLog.TabStop = true;
            this.radioButtonTLog.Tag = "Respaldo TLOG";
            this.radioButtonTLog.Text = "Respaldo TLOG";
            this.radioButtonTLog.UseVisualStyleBackColor = true;
            // 
            // radioButtonFull
            // 
            this.radioButtonFull.AutoSize = true;
            this.radioButtonFull.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonFull.Location = new System.Drawing.Point(53, 257);
            this.radioButtonFull.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonFull.Name = "radioButtonFull";
            this.radioButtonFull.Size = new System.Drawing.Size(132, 22);
            this.radioButtonFull.TabIndex = 8;
            this.radioButtonFull.TabStop = true;
            this.radioButtonFull.Tag = "Respaldo FULL";
            this.radioButtonFull.Text = "Respaldo FULL";
            this.radioButtonFull.UseVisualStyleBackColor = true;
            // 
            // comboBoxdatabases
            // 
            this.comboBoxdatabases.FormattingEnabled = true;
            this.comboBoxdatabases.Location = new System.Drawing.Point(39, 74);
            this.comboBoxdatabases.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxdatabases.Name = "comboBoxdatabases";
            this.comboBoxdatabases.Size = new System.Drawing.Size(463, 30);
            this.comboBoxdatabases.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(53, 140);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 18);
            this.label1.TabIndex = 16;
            this.label1.Tag = "Ruta de Respaldo";
            this.label1.Text = "Ruta de Respaldo";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // BackupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 423);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxdatabases);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtBackupPath);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnStartBackup);
            this.Controls.Add(this.radioButtonTLog);
            this.Controls.Add(this.radioButtonFull);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.Label label1;
    }
}