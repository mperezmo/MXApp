namespace UI.Forms
{
    partial class JobStepsForm
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
            this.dataGridViewJobSteps = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridSchedule = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewJobSteps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSchedule)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewJobSteps
            // 
            this.dataGridViewJobSteps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewJobSteps.Location = new System.Drawing.Point(30, 73);
            this.dataGridViewJobSteps.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewJobSteps.Name = "dataGridViewJobSteps";
            this.dataGridViewJobSteps.RowHeadersWidth = 51;
            this.dataGridViewJobSteps.RowTemplate.Height = 24;
            this.dataGridViewJobSteps.Size = new System.Drawing.Size(918, 194);
            this.dataGridViewJobSteps.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "SQL Job Name: ";
            // 
            // dataGridSchedule
            // 
            this.dataGridSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridSchedule.Location = new System.Drawing.Point(30, 325);
            this.dataGridSchedule.Name = "dataGridSchedule";
            this.dataGridSchedule.RowHeadersWidth = 51;
            this.dataGridSchedule.RowTemplate.Height = 24;
            this.dataGridSchedule.Size = new System.Drawing.Size(918, 150);
            this.dataGridSchedule.TabIndex = 2;
            // 
            // JobStepsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 670);
            this.Controls.Add(this.dataGridSchedule);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewJobSteps);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "JobStepsForm";
            this.Text = "JobSteps";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewJobSteps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSchedule)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewJobSteps;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridSchedule;
    }
}