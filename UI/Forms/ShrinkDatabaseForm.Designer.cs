namespace UI.Forms
{
    partial class ShrinkDatabaseForm
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnStartShrink = new System.Windows.Forms.Button();
            this.numericUpDownSize = new System.Windows.Forms.NumericUpDown();
            this.checkBoxDefaultSize = new System.Windows.Forms.CheckBox();
            this.radioButtonLog = new System.Windows.Forms.RadioButton();
            this.radioButtonData = new System.Windows.Forms.RadioButton();
            this.lblMessage = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxdatabases = new System.Windows.Forms.ComboBox();
            this.comboBoxDBFiles = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSize)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(287, 333);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(116, 37);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Tag = "Cancelar";
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnStartShrink
            // 
            this.btnStartShrink.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartShrink.Location = new System.Drawing.Point(49, 333);
            this.btnStartShrink.Margin = new System.Windows.Forms.Padding(4);
            this.btnStartShrink.Name = "btnStartShrink";
            this.btnStartShrink.Size = new System.Drawing.Size(116, 37);
            this.btnStartShrink.TabIndex = 12;
            this.btnStartShrink.Tag = "Iniciar";
            this.btnStartShrink.Text = "Iniciar";
            this.btnStartShrink.UseVisualStyleBackColor = true;
            this.btnStartShrink.Click += new System.EventHandler(this.btnStartShrink_Click);
            // 
            // numericUpDownSize
            // 
            this.numericUpDownSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownSize.Location = new System.Drawing.Point(263, 269);
            this.numericUpDownSize.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDownSize.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownSize.Name = "numericUpDownSize";
            this.numericUpDownSize.Size = new System.Drawing.Size(150, 24);
            this.numericUpDownSize.TabIndex = 11;
            // 
            // checkBoxDefaultSize
            // 
            this.checkBoxDefaultSize.AutoSize = true;
            this.checkBoxDefaultSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxDefaultSize.Location = new System.Drawing.Point(46, 269);
            this.checkBoxDefaultSize.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxDefaultSize.Name = "checkBoxDefaultSize";
            this.checkBoxDefaultSize.Size = new System.Drawing.Size(205, 22);
            this.checkBoxDefaultSize.TabIndex = 10;
            this.checkBoxDefaultSize.Tag = "Usar valor pre configurado";
            this.checkBoxDefaultSize.Text = "Usar valor pre configurado";
            this.checkBoxDefaultSize.UseVisualStyleBackColor = true;
            // 
            // radioButtonLog
            // 
            this.radioButtonLog.AutoSize = true;
            this.radioButtonLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonLog.Location = new System.Drawing.Point(249, 126);
            this.radioButtonLog.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonLog.Name = "radioButtonLog";
            this.radioButtonLog.Size = new System.Drawing.Size(54, 22);
            this.radioButtonLog.TabIndex = 9;
            this.radioButtonLog.TabStop = true;
            this.radioButtonLog.Text = "Log";
            this.radioButtonLog.UseVisualStyleBackColor = true;
            // 
            // radioButtonData
            // 
            this.radioButtonData.AutoSize = true;
            this.radioButtonData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonData.Location = new System.Drawing.Point(153, 126);
            this.radioButtonData.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonData.Name = "radioButtonData";
            this.radioButtonData.Size = new System.Drawing.Size(60, 22);
            this.radioButtonData.TabIndex = 8;
            this.radioButtonData.TabStop = true;
            this.radioButtonData.Text = "Data";
            this.radioButtonData.UseVisualStyleBackColor = true;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(168, 45);
            this.lblMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(184, 18);
            this.lblMessage.TabIndex = 7;
            this.lblMessage.Text = "Nombre de Base de Datos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(275, 247);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 18);
            this.label1.TabIndex = 14;
            this.label1.Tag = "Valor de Compresion";
            this.label1.Text = "Valor de Compresion";
            // 
            // comboBoxdatabases
            // 
            this.comboBoxdatabases.FormattingEnabled = true;
            this.comboBoxdatabases.Location = new System.Drawing.Point(89, 66);
            this.comboBoxdatabases.Name = "comboBoxdatabases";
            this.comboBoxdatabases.Size = new System.Drawing.Size(280, 30);
            this.comboBoxdatabases.TabIndex = 15;
            // 
            // comboBoxDBFiles
            // 
            this.comboBoxDBFiles.FormattingEnabled = true;
            this.comboBoxDBFiles.Location = new System.Drawing.Point(91, 183);
            this.comboBoxDBFiles.Name = "comboBoxDBFiles";
            this.comboBoxDBFiles.Size = new System.Drawing.Size(280, 30);
            this.comboBoxDBFiles.TabIndex = 16;
            // 
            // ShrinkDatabaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 396);
            this.Controls.Add(this.comboBoxDBFiles);
            this.Controls.Add(this.comboBoxdatabases);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnStartShrink);
            this.Controls.Add(this.numericUpDownSize);
            this.Controls.Add(this.checkBoxDefaultSize);
            this.Controls.Add(this.radioButtonLog);
            this.Controls.Add(this.radioButtonData);
            this.Controls.Add(this.lblMessage);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ShrinkDatabaseForm";
            this.Text = "ShrinkDatabaseForm";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnStartShrink;
        private System.Windows.Forms.NumericUpDown numericUpDownSize;
        private System.Windows.Forms.CheckBox checkBoxDefaultSize;
        private System.Windows.Forms.RadioButton radioButtonLog;
        private System.Windows.Forms.RadioButton radioButtonData;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxdatabases;
        private System.Windows.Forms.ComboBox comboBoxDBFiles;
    }
}