namespace UI.Forms
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnExistingInstances = new System.Windows.Forms.Button();
            this.dataGridViewDatabases = new System.Windows.Forms.DataGridView();
            this.btnViewInstances = new System.Windows.Forms.Button();
            this.btnAddInstance = new System.Windows.Forms.Button();
            this.btnLoadDatabases = new System.Windows.Forms.Button();
            this.txtInstance = new System.Windows.Forms.TextBox();
            this.rdbIntegratedAuth = new System.Windows.Forms.RadioButton();
            this.rdbUserPassword = new System.Windows.Forms.RadioButton();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tareasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurarPermisosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLogout = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDatabases)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExistingInstances
            // 
            this.btnExistingInstances.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExistingInstances.Location = new System.Drawing.Point(323, 494);
            this.btnExistingInstances.Name = "btnExistingInstances";
            this.btnExistingInstances.Size = new System.Drawing.Size(170, 30);
            this.btnExistingInstances.TabIndex = 23;
            this.btnExistingInstances.Text = "View Instances";
            this.btnExistingInstances.UseVisualStyleBackColor = true;
            // 
            // dataGridViewDatabases
            // 
            this.dataGridViewDatabases.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dataGridViewDatabases.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDatabases.Location = new System.Drawing.Point(88, 244);
            this.dataGridViewDatabases.Name = "dataGridViewDatabases";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewDatabases.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewDatabases.RowHeadersWidth = 51;
            this.dataGridViewDatabases.RowTemplate.Height = 24;
            this.dataGridViewDatabases.Size = new System.Drawing.Size(641, 221);
            this.dataGridViewDatabases.TabIndex = 18;
            // 
            // btnViewInstances
            // 
            this.btnViewInstances.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewInstances.Location = new System.Drawing.Point(571, 494);
            this.btnViewInstances.Name = "btnViewInstances";
            this.btnViewInstances.Size = new System.Drawing.Size(158, 30);
            this.btnViewInstances.TabIndex = 22;
            this.btnViewInstances.Text = "More Information";
            this.btnViewInstances.UseVisualStyleBackColor = true;
            this.btnViewInstances.Click += new System.EventHandler(this.btnViewInstances_Click);
            // 
            // btnAddInstance
            // 
            this.btnAddInstance.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddInstance.Location = new System.Drawing.Point(88, 494);
            this.btnAddInstance.Name = "btnAddInstance";
            this.btnAddInstance.Size = new System.Drawing.Size(120, 30);
            this.btnAddInstance.TabIndex = 21;
            this.btnAddInstance.Text = "Add";
            this.btnAddInstance.UseVisualStyleBackColor = true;
            // 
            // btnLoadDatabases
            // 
            this.btnLoadDatabases.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadDatabases.Location = new System.Drawing.Point(585, 56);
            this.btnLoadDatabases.Name = "btnLoadDatabases";
            this.btnLoadDatabases.Size = new System.Drawing.Size(144, 30);
            this.btnLoadDatabases.TabIndex = 20;
            this.btnLoadDatabases.Text = "Test Connection";
            this.btnLoadDatabases.UseVisualStyleBackColor = true;
            this.btnLoadDatabases.Click += new System.EventHandler(this.btnLoadDatabases_Click);
            // 
            // txtInstance
            // 
            this.txtInstance.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtInstance.BackColor = System.Drawing.Color.Gainsboro;
            this.txtInstance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInstance.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInstance.Location = new System.Drawing.Point(197, 60);
            this.txtInstance.Name = "txtInstance";
            this.txtInstance.Size = new System.Drawing.Size(347, 27);
            this.txtInstance.TabIndex = 19;
            // 
            // rdbIntegratedAuth
            // 
            this.rdbIntegratedAuth.AutoSize = true;
            this.rdbIntegratedAuth.Location = new System.Drawing.Point(201, 105);
            this.rdbIntegratedAuth.Name = "rdbIntegratedAuth";
            this.rdbIntegratedAuth.Size = new System.Drawing.Size(119, 20);
            this.rdbIntegratedAuth.TabIndex = 24;
            this.rdbIntegratedAuth.TabStop = true;
            this.rdbIntegratedAuth.Text = "Windows Login";
            this.rdbIntegratedAuth.UseVisualStyleBackColor = true;
            // 
            // rdbUserPassword
            // 
            this.rdbUserPassword.AutoSize = true;
            this.rdbUserPassword.Location = new System.Drawing.Point(443, 105);
            this.rdbUserPassword.Name = "rdbUserPassword";
            this.rdbUserPassword.Size = new System.Drawing.Size(90, 20);
            this.rdbUserPassword.TabIndex = 25;
            this.rdbUserPassword.TabStop = true;
            this.rdbUserPassword.Text = "SQL Login";
            this.rdbUserPassword.UseVisualStyleBackColor = true;
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtUsername.BackColor = System.Drawing.Color.Gainsboro;
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(146, 161);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(229, 27);
            this.txtUsername.TabIndex = 26;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPassword.BackColor = System.Drawing.Color.Gainsboro;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(408, 161);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(229, 27);
            this.txtPassword.TabIndex = 27;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tareasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(837, 28);
            this.menuStrip1.TabIndex = 36;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tareasToolStripMenuItem
            // 
            this.tareasToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.tareasToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tareasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarUsuarioToolStripMenuItem,
            this.configurarPermisosToolStripMenuItem,
            this.menuItemLogout});
            this.tareasToolStripMenuItem.Name = "tareasToolStripMenuItem";
            this.tareasToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.tareasToolStripMenuItem.Text = "Opciones";
            // 
            // agregarUsuarioToolStripMenuItem
            // 
            this.agregarUsuarioToolStripMenuItem.Name = "agregarUsuarioToolStripMenuItem";
            this.agregarUsuarioToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.agregarUsuarioToolStripMenuItem.Text = "Agregar Usuario";
            this.agregarUsuarioToolStripMenuItem.Click += new System.EventHandler(this.agregarUsuarioToolStripMenuItem_Click);
            // 
            // configurarPermisosToolStripMenuItem
            // 
            this.configurarPermisosToolStripMenuItem.Name = "configurarPermisosToolStripMenuItem";
            this.configurarPermisosToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.configurarPermisosToolStripMenuItem.Text = "Configurar Permisos";
            this.configurarPermisosToolStripMenuItem.Click += new System.EventHandler(this.configurarPermisosToolStripMenuItem_Click);
            // 
            // menuItemLogout
            // 
            this.menuItemLogout.Name = "menuItemLogout";
            this.menuItemLogout.Size = new System.Drawing.Size(224, 26);
            this.menuItemLogout.Text = "Cerrar Sesion";
            this.menuItemLogout.Click += new System.EventHandler(this.menuItemLogout_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 564);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.rdbUserPassword);
            this.Controls.Add(this.rdbIntegratedAuth);
            this.Controls.Add(this.btnExistingInstances);
            this.Controls.Add(this.dataGridViewDatabases);
            this.Controls.Add(this.btnViewInstances);
            this.Controls.Add(this.btnAddInstance);
            this.Controls.Add(this.btnLoadDatabases);
            this.Controls.Add(this.txtInstance);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDatabases)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExistingInstances;
        private System.Windows.Forms.DataGridView dataGridViewDatabases;
        private System.Windows.Forms.Button btnViewInstances;
        private System.Windows.Forms.Button btnAddInstance;
        private System.Windows.Forms.Button btnLoadDatabases;
        private System.Windows.Forms.TextBox txtInstance;
        private System.Windows.Forms.RadioButton rdbIntegratedAuth;
        private System.Windows.Forms.RadioButton rdbUserPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tareasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configurarPermisosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemLogout;
    }
}