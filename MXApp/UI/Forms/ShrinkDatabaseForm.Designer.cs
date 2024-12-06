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
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSize)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(457, 295);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(93, 27);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnStartShrink
            // 
            this.btnStartShrink.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartShrink.Location = new System.Drawing.Point(271, 295);
            this.btnStartShrink.Name = "btnStartShrink";
            this.btnStartShrink.Size = new System.Drawing.Size(93, 27);
            this.btnStartShrink.TabIndex = 12;
            this.btnStartShrink.Text = "Start Shrink";
            this.btnStartShrink.UseVisualStyleBackColor = true;
            // 
            // numericUpDownSize
            // 
            this.numericUpDownSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownSize.Location = new System.Drawing.Point(457, 232);
            this.numericUpDownSize.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownSize.Name = "numericUpDownSize";
            this.numericUpDownSize.Size = new System.Drawing.Size(120, 24);
            this.numericUpDownSize.TabIndex = 11;
            // 
            // checkBoxDefaultSize
            // 
            this.checkBoxDefaultSize.AutoSize = true;
            this.checkBoxDefaultSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxDefaultSize.Location = new System.Drawing.Point(224, 232);
            this.checkBoxDefaultSize.Name = "checkBoxDefaultSize";
            this.checkBoxDefaultSize.Size = new System.Drawing.Size(142, 22);
            this.checkBoxDefaultSize.TabIndex = 10;
            this.checkBoxDefaultSize.Text = "Use default value";
            this.checkBoxDefaultSize.UseVisualStyleBackColor = true;
            // 
            // radioButtonLog
            // 
            this.radioButtonLog.AutoSize = true;
            this.radioButtonLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonLog.Location = new System.Drawing.Point(468, 180);
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
            this.radioButtonData.Location = new System.Drawing.Point(287, 180);
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
            this.lblMessage.Location = new System.Drawing.Point(241, 128);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(46, 18);
            this.lblMessage.TabIndex = 7;
            this.lblMessage.Text = "label1";
            // 
            // ShrinkDatabaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnStartShrink);
            this.Controls.Add(this.numericUpDownSize);
            this.Controls.Add(this.checkBoxDefaultSize);
            this.Controls.Add(this.radioButtonLog);
            this.Controls.Add(this.radioButtonData);
            this.Controls.Add(this.lblMessage);
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
    }
}