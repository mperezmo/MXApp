namespace UI.Forms
{
    partial class DeleteDatabaseForm
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.radioBtnLastBackup = new System.Windows.Forms.RadioButton();
            this.btnDeleteDatabase = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(136, 112);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(315, 30);
            this.comboBox1.TabIndex = 0;
            // 
            // radioBtnLastBackup
            // 
            this.radioBtnLastBackup.AutoSize = true;
            this.radioBtnLastBackup.Location = new System.Drawing.Point(157, 185);
            this.radioBtnLastBackup.Name = "radioBtnLastBackup";
            this.radioBtnLastBackup.Size = new System.Drawing.Size(258, 26);
            this.radioBtnLastBackup.TabIndex = 1;
            this.radioBtnLastBackup.TabStop = true;
            this.radioBtnLastBackup.Tag = "Tomar ultimo respaldo FULL";
            this.radioBtnLastBackup.Text = "Tomar ultimo respaldo FULL";
            this.radioBtnLastBackup.UseVisualStyleBackColor = true;
            // 
            // btnDeleteDatabase
            // 
            this.btnDeleteDatabase.Location = new System.Drawing.Point(174, 266);
            this.btnDeleteDatabase.Name = "btnDeleteDatabase";
            this.btnDeleteDatabase.Size = new System.Drawing.Size(213, 39);
            this.btnDeleteDatabase.TabIndex = 2;
            this.btnDeleteDatabase.Text = "Eliminar Base de Datos";
            this.btnDeleteDatabase.UseVisualStyleBackColor = true;
            this.btnDeleteDatabase.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(183, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 22);
            this.label1.TabIndex = 3;
            this.label1.Tag = "Nombre de Base de Datos";
            this.label1.Text = "Nombre de Base de Datos";
            // 
            // DeleteDatabaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 364);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDeleteDatabase);
            this.Controls.Add(this.radioBtnLastBackup);
            this.Controls.Add(this.comboBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DeleteDatabaseForm";
            this.Text = "DeleteDatabaseForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.RadioButton radioBtnLastBackup;
        private System.Windows.Forms.Button btnDeleteDatabase;
        private System.Windows.Forms.Label label1;
    }
}