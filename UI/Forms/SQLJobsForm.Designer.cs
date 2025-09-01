namespace UI.Forms
{
    partial class SQLJobsForm
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
            this.dataGridViewJobs = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.btnViewJobSteps = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewJobs)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewJobs
            // 
            this.dataGridViewJobs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewJobs.Location = new System.Drawing.Point(27, 59);
            this.dataGridViewJobs.Name = "dataGridViewJobs";
            this.dataGridViewJobs.RowHeadersWidth = 51;
            this.dataGridViewJobs.RowTemplate.Height = 24;
            this.dataGridViewJobs.Size = new System.Drawing.Size(737, 404);
            this.dataGridViewJobs.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(27, 486);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 39);
            this.button1.TabIndex = 1;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnViewJobSteps
            // 
            this.btnViewJobSteps.Location = new System.Drawing.Point(613, 486);
            this.btnViewJobSteps.Name = "btnViewJobSteps";
            this.btnViewJobSteps.Size = new System.Drawing.Size(140, 39);
            this.btnViewJobSteps.TabIndex = 2;
            this.btnViewJobSteps.Text = "More Information";
            this.btnViewJobSteps.UseVisualStyleBackColor = true;
            this.btnViewJobSteps.Click += new System.EventHandler(this.btnViewJobSteps_Click_1);
            // 
            // SQLJobsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 545);
            this.Controls.Add(this.btnViewJobSteps);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridViewJobs);
            this.Name = "SQLJobsForm";
            this.Text = "SQLJobsForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewJobs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewJobs;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnViewJobSteps;
    }
}