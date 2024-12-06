namespace UI.Forms
{
    partial class MoreInfoDBForm
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
            this.dataGridViewExpensiveQueries = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExpensiveQueries)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewExpensiveQueries
            // 
            this.dataGridViewExpensiveQueries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewExpensiveQueries.Location = new System.Drawing.Point(75, 24);
            this.dataGridViewExpensiveQueries.Name = "dataGridViewExpensiveQueries";
            this.dataGridViewExpensiveQueries.RowHeadersWidth = 51;
            this.dataGridViewExpensiveQueries.RowTemplate.Height = 24;
            this.dataGridViewExpensiveQueries.Size = new System.Drawing.Size(613, 338);
            this.dataGridViewExpensiveQueries.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(545, 387);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(113, 387);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Cancel";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // MoreInfoDBForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dataGridViewExpensiveQueries);
            this.Name = "MoreInfoDBForm";
            this.Text = "MoreInfoDBForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExpensiveQueries)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewExpensiveQueries;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClose;
    }
}