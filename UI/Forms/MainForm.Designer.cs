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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnExistingInstances = new System.Windows.Forms.Button();
            this.dataGridViewDatabases = new System.Windows.Forms.DataGridView();
            this.btnViewInstance = new System.Windows.Forms.Button();
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
            this.idiomaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.españolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inglesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDatabases)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExistingInstances
            // 
            this.btnExistingInstances.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnExistingInstances.Font = new System.Drawing.Font("Microsoft Tai Le", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExistingInstances.Location = new System.Drawing.Point(375, 679);
            this.btnExistingInstances.Margin = new System.Windows.Forms.Padding(4);
            this.btnExistingInstances.Name = "btnExistingInstances";
            this.btnExistingInstances.Size = new System.Drawing.Size(212, 41);
            this.btnExistingInstances.TabIndex = 23;
            this.btnExistingInstances.Tag = "Ver Instancias";
            this.btnExistingInstances.Text = "Ver Instancias";
            this.btnExistingInstances.UseVisualStyleBackColor = true;
            this.btnExistingInstances.Click += new System.EventHandler(this.btnExistingInstances_Click);
            // 
            // dataGridViewDatabases
            // 
            this.dataGridViewDatabases.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridViewDatabases.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dataGridViewDatabases.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDatabases.Location = new System.Drawing.Point(81, 99);
            this.dataGridViewDatabases.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewDatabases.Name = "dataGridViewDatabases";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewDatabases.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewDatabases.RowHeadersWidth = 51;
            this.dataGridViewDatabases.RowTemplate.Height = 24;
            this.dataGridViewDatabases.Size = new System.Drawing.Size(449, 235);
            this.dataGridViewDatabases.TabIndex = 18;
            // 
            // btnViewInstance
            // 
            this.btnViewInstance.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnViewInstance.Font = new System.Drawing.Font("Microsoft Tai Le", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewInstance.Location = new System.Drawing.Point(685, 679);
            this.btnViewInstance.Margin = new System.Windows.Forms.Padding(4);
            this.btnViewInstance.Name = "btnViewInstance";
            this.btnViewInstance.Size = new System.Drawing.Size(198, 41);
            this.btnViewInstance.TabIndex = 22;
            this.btnViewInstance.Tag = "Más Información";
            this.btnViewInstance.Text = "Más Información";
            this.btnViewInstance.UseVisualStyleBackColor = true;
            this.btnViewInstance.Click += new System.EventHandler(this.btnViewInstances_Click);
            // 
            // btnAddInstance
            // 
            this.btnAddInstance.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddInstance.Font = new System.Drawing.Font("Microsoft Tai Le", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddInstance.Location = new System.Drawing.Point(81, 679);
            this.btnAddInstance.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddInstance.Name = "btnAddInstance";
            this.btnAddInstance.Size = new System.Drawing.Size(150, 41);
            this.btnAddInstance.TabIndex = 21;
            this.btnAddInstance.Tag = "Agregar";
            this.btnAddInstance.Text = "Agregar";
            this.btnAddInstance.UseVisualStyleBackColor = true;
            this.btnAddInstance.Click += new System.EventHandler(this.btnAddInstance_Click);
            // 
            // btnLoadDatabases
            // 
            this.btnLoadDatabases.AutoSize = true;
            this.btnLoadDatabases.Font = new System.Drawing.Font("Microsoft Tai Le", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadDatabases.Location = new System.Drawing.Point(1107, 581);
            this.btnLoadDatabases.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoadDatabases.Name = "btnLoadDatabases";
            this.btnLoadDatabases.Size = new System.Drawing.Size(180, 41);
            this.btnLoadDatabases.TabIndex = 20;
            this.btnLoadDatabases.Tag = "Validar Conexión";
            this.btnLoadDatabases.Text = "Validar Conexión";
            this.btnLoadDatabases.UseVisualStyleBackColor = true;
            this.btnLoadDatabases.Click += new System.EventHandler(this.btnLoadDatabases_Click);
            // 
            // txtInstance
            // 
            this.txtInstance.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInstance.BackColor = System.Drawing.Color.Gainsboro;
            this.txtInstance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInstance.Font = new System.Drawing.Font("Microsoft Tai Le", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInstance.Location = new System.Drawing.Point(964, 217);
            this.txtInstance.Margin = new System.Windows.Forms.Padding(4);
            this.txtInstance.Name = "txtInstance";
            this.txtInstance.Size = new System.Drawing.Size(433, 29);
            this.txtInstance.TabIndex = 19;
            // 
            // rdbIntegratedAuth
            // 
            this.rdbIntegratedAuth.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbIntegratedAuth.AutoSize = true;
            this.rdbIntegratedAuth.Location = new System.Drawing.Point(1003, 296);
            this.rdbIntegratedAuth.Margin = new System.Windows.Forms.Padding(4);
            this.rdbIntegratedAuth.Name = "rdbIntegratedAuth";
            this.rdbIntegratedAuth.Size = new System.Drawing.Size(153, 26);
            this.rdbIntegratedAuth.TabIndex = 24;
            this.rdbIntegratedAuth.TabStop = true;
            this.rdbIntegratedAuth.Text = "Windows Login";
            this.rdbIntegratedAuth.UseVisualStyleBackColor = true;
            // 
            // rdbUserPassword
            // 
            this.rdbUserPassword.AutoSize = true;
            this.rdbUserPassword.Location = new System.Drawing.Point(1249, 296);
            this.rdbUserPassword.Margin = new System.Windows.Forms.Padding(4);
            this.rdbUserPassword.Name = "rdbUserPassword";
            this.rdbUserPassword.Size = new System.Drawing.Size(116, 26);
            this.rdbUserPassword.TabIndex = 25;
            this.rdbUserPassword.TabStop = true;
            this.rdbUserPassword.Text = "SQL Login";
            this.rdbUserPassword.UseVisualStyleBackColor = true;
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsername.BackColor = System.Drawing.Color.Gainsboro;
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Tai Le", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(1003, 387);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(4);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(362, 29);
            this.txtUsername.TabIndex = 26;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.BackColor = System.Drawing.Color.Gainsboro;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Tai Le", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(1003, 487);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(362, 29);
            this.txtPassword.TabIndex = 27;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tareasToolStripMenuItem,
            this.idiomaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(10, 3, 0, 3);
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(1446, 38);
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
            this.tareasToolStripMenuItem.Size = new System.Drawing.Size(95, 32);
            this.tareasToolStripMenuItem.Tag = "Opciones";
            this.tareasToolStripMenuItem.Text = "Opciones";
            // 
            // agregarUsuarioToolStripMenuItem
            // 
            this.agregarUsuarioToolStripMenuItem.Name = "agregarUsuarioToolStripMenuItem";
            this.agregarUsuarioToolStripMenuItem.Size = new System.Drawing.Size(247, 28);
            this.agregarUsuarioToolStripMenuItem.Tag = "Agregar Usuario";
            this.agregarUsuarioToolStripMenuItem.Text = "Agregar Usuario";
            this.agregarUsuarioToolStripMenuItem.Click += new System.EventHandler(this.agregarUsuarioToolStripMenuItem_Click);
            // 
            // configurarPermisosToolStripMenuItem
            // 
            this.configurarPermisosToolStripMenuItem.Name = "configurarPermisosToolStripMenuItem";
            this.configurarPermisosToolStripMenuItem.Size = new System.Drawing.Size(247, 28);
            this.configurarPermisosToolStripMenuItem.Tag = "Configurar Permisos";
            this.configurarPermisosToolStripMenuItem.Text = "Configurar Permisos";
            this.configurarPermisosToolStripMenuItem.Click += new System.EventHandler(this.configurarPermisosToolStripMenuItem_Click);
            // 
            // menuItemLogout
            // 
            this.menuItemLogout.Name = "menuItemLogout";
            this.menuItemLogout.Size = new System.Drawing.Size(247, 28);
            this.menuItemLogout.Tag = "Cerrar Sesión";
            this.menuItemLogout.Text = "Cerrar Sesión";
            this.menuItemLogout.Click += new System.EventHandler(this.menuItemLogout_Click);
            // 
            // idiomaToolStripMenuItem
            // 
            this.idiomaToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.idiomaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.españolToolStripMenuItem,
            this.inglesToolStripMenuItem});
            this.idiomaToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idiomaToolStripMenuItem.Name = "idiomaToolStripMenuItem";
            this.idiomaToolStripMenuItem.Size = new System.Drawing.Size(53, 32);
            this.idiomaToolStripMenuItem.Text = "🌐";
            // 
            // españolToolStripMenuItem
            // 
            this.españolToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.españolToolStripMenuItem.Name = "españolToolStripMenuItem";
            this.españolToolStripMenuItem.Size = new System.Drawing.Size(155, 28);
            this.españolToolStripMenuItem.Tag = "Español";
            this.españolToolStripMenuItem.Text = "Español";
            this.españolToolStripMenuItem.Click += new System.EventHandler(this.españolToolStripMenuItem_Click);
            // 
            // inglesToolStripMenuItem
            // 
            this.inglesToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inglesToolStripMenuItem.Name = "inglesToolStripMenuItem";
            this.inglesToolStripMenuItem.Size = new System.Drawing.Size(155, 28);
            this.inglesToolStripMenuItem.Tag = "Ingles";
            this.inglesToolStripMenuItem.Text = "Inglés";
            this.inglesToolStripMenuItem.Click += new System.EventHandler(this.inglesToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1003, 357);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 22);
            this.label1.TabIndex = 37;
            this.label1.Text = "SQL Login";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1003, 461);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 22);
            this.label2.TabIndex = 38;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(960, 181);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 22);
            this.label3.TabIndex = 39;
            this.label3.Tag = "Nombre de Instancia";
            this.label3.Text = "Nombre de Instancia";
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.Font = new System.Drawing.Font("Microsoft Tai Le", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1107, 664);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(180, 41);
            this.button1.TabIndex = 40;
            this.button1.Tag = "Validar Conexión";
            this.button1.Text = "Validar Conexión";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(434, 369);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(449, 235);
            this.dataGridView1.TabIndex = 41;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1446, 776);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.rdbUserPassword);
            this.Controls.Add(this.rdbIntegratedAuth);
            this.Controls.Add(this.btnExistingInstances);
            this.Controls.Add(this.dataGridViewDatabases);
            this.Controls.Add(this.btnViewInstance);
            this.Controls.Add(this.btnAddInstance);
            this.Controls.Add(this.btnLoadDatabases);
            this.Controls.Add(this.txtInstance);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "MonitorXpressApp";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDatabases)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExistingInstances;
        private System.Windows.Forms.DataGridView dataGridViewDatabases;
        private System.Windows.Forms.Button btnViewInstance;
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem idiomaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem españolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inglesToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}