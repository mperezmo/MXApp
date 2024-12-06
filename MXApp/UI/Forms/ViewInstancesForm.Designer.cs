namespace UI.Forms
{
    partial class ViewInstancesForm
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
            this.btnBack = new System.Windows.Forms.Button();
            this.btnMoreInfo = new System.Windows.Forms.Button();
            this.dataGridViewInstances = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInstances)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(77, 506);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(86, 36);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // btnMoreInfo
            // 
            this.btnMoreInfo.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoreInfo.Location = new System.Drawing.Point(546, 506);
            this.btnMoreInfo.Name = "btnMoreInfo";
            this.btnMoreInfo.Size = new System.Drawing.Size(177, 36);
            this.btnMoreInfo.TabIndex = 4;
            this.btnMoreInfo.Text = "More Information";
            this.btnMoreInfo.UseVisualStyleBackColor = true;
            // 
            // dataGridViewInstances
            // 
            this.dataGridViewInstances.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dataGridViewInstances.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInstances.Location = new System.Drawing.Point(48, 100);
            this.dataGridViewInstances.Name = "dataGridViewInstances";
            this.dataGridViewInstances.RowHeadersWidth = 51;
            this.dataGridViewInstances.RowTemplate.Height = 24;
            this.dataGridViewInstances.Size = new System.Drawing.Size(591, 354);
            this.dataGridViewInstances.TabIndex = 3;
            // 
            // ViewInstancesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 567);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnMoreInfo);
            this.Controls.Add(this.dataGridViewInstances);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ViewInstancesForm";
            this.Text = "ViewInstancesForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInstances)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnMoreInfo;
        private System.Windows.Forms.DataGridView dataGridViewInstances;
    }
}