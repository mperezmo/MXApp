namespace UI.Forms
{
    partial class IndexForm
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
            this.dataGridViewIndexes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIndexes)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewIndexes
            // 
            this.dataGridViewIndexes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewIndexes.Location = new System.Drawing.Point(34, 24);
            this.dataGridViewIndexes.Name = "dataGridViewIndexes";
            this.dataGridViewIndexes.RowHeadersWidth = 51;
            this.dataGridViewIndexes.RowTemplate.Height = 24;
            this.dataGridViewIndexes.Size = new System.Drawing.Size(582, 368);
            this.dataGridViewIndexes.TabIndex = 0;
            // 
            // IndexForm
            // 
            this.ClientSize = new System.Drawing.Size(663, 447);
            this.Controls.Add(this.dataGridViewIndexes);
            this.Name = "IndexForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIndexes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnDeleteIndex;
        private System.Windows.Forms.Button btnCreateIndex;
        private System.Windows.Forms.Button btnGetIndex;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label labelInst;
        private System.Windows.Forms.DataGridView dataGridViewIndexes;
    }
}