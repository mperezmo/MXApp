namespace UI.Forms
{
    partial class DBInformationForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnRefreshInstInfo = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSQLBuild = new System.Windows.Forms.TextBox();
            this.txtSQLEdition = new System.Windows.Forms.TextBox();
            this.dataGridViewBackupHistory = new System.Windows.Forms.DataGridView();
            this.txtBackupPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLastStartTime = new System.Windows.Forms.TextBox();
            this.txtLogPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDataPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtConfiguredMemory = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnMoreInfoDB = new System.Windows.Forms.Button();
            this.btnBack2 = new System.Windows.Forms.Button();
            this.btnRefreshInstInfoDB = new System.Windows.Forms.Button();
            this.btnCreateDatabase = new System.Windows.Forms.Button();
            this.btnShrinkDatabase = new System.Windows.Forms.Button();
            this.btnTakeBackup = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tareasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurarPermisosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewDatabases = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBackupHistory)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDatabases)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 52);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1245, 665);
            this.tabControl1.TabIndex = 34;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnBack);
            this.tabPage1.Controls.Add(this.btnRefreshInstInfo);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.txtSQLBuild);
            this.tabPage1.Controls.Add(this.txtSQLEdition);
            this.tabPage1.Controls.Add(this.dataGridViewBackupHistory);
            this.tabPage1.Controls.Add(this.txtBackupPath);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txtLastStartTime);
            this.tabPage1.Controls.Add(this.txtLogPath);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtDataPath);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtConfiguredMemory);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1237, 634);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Instance Information";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(27, 513);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(105, 40);
            this.btnBack.TabIndex = 38;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnRefreshInstInfo
            // 
            this.btnRefreshInstInfo.Location = new System.Drawing.Point(930, 513);
            this.btnRefreshInstInfo.Name = "btnRefreshInstInfo";
            this.btnRefreshInstInfo.Size = new System.Drawing.Size(141, 40);
            this.btnRefreshInstInfo.TabIndex = 37;
            this.btnRefreshInstInfo.Text = "Refresh";
            this.btnRefreshInstInfo.UseVisualStyleBackColor = true;
            this.btnRefreshInstInfo.Click += new System.EventHandler(this.btnRefreshInstInfo_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(825, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 18);
            this.label7.TabIndex = 36;
            this.label7.Text = "SQL Build";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(349, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 18);
            this.label6.TabIndex = 35;
            this.label6.Text = "SQL Edition";
            // 
            // txtSQLBuild
            // 
            this.txtSQLBuild.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSQLBuild.Location = new System.Drawing.Point(902, 34);
            this.txtSQLBuild.Name = "txtSQLBuild";
            this.txtSQLBuild.Size = new System.Drawing.Size(203, 24);
            this.txtSQLBuild.TabIndex = 34;
            // 
            // txtSQLEdition
            // 
            this.txtSQLEdition.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSQLEdition.Location = new System.Drawing.Point(442, 31);
            this.txtSQLEdition.Name = "txtSQLEdition";
            this.txtSQLEdition.Size = new System.Drawing.Size(271, 24);
            this.txtSQLEdition.TabIndex = 33;
            // 
            // dataGridViewBackupHistory
            // 
            this.dataGridViewBackupHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBackupHistory.Location = new System.Drawing.Point(15, 308);
            this.dataGridViewBackupHistory.Name = "dataGridViewBackupHistory";
            this.dataGridViewBackupHistory.RowHeadersWidth = 51;
            this.dataGridViewBackupHistory.RowTemplate.Height = 24;
            this.dataGridViewBackupHistory.Size = new System.Drawing.Size(1155, 178);
            this.dataGridViewBackupHistory.TabIndex = 32;
            // 
            // txtBackupPath
            // 
            this.txtBackupPath.Location = new System.Drawing.Point(27, 279);
            this.txtBackupPath.Name = "txtBackupPath";
            this.txtBackupPath.Size = new System.Drawing.Size(568, 24);
            this.txtBackupPath.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 258);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 18);
            this.label4.TabIndex = 26;
            this.label4.Text = "BackupPath";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(599, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 18);
            this.label5.TabIndex = 27;
            this.label5.Text = "LogPath";
            // 
            // txtLastStartTime
            // 
            this.txtLastStartTime.Location = new System.Drawing.Point(76, 31);
            this.txtLastStartTime.Name = "txtLastStartTime";
            this.txtLastStartTime.Size = new System.Drawing.Size(215, 24);
            this.txtLastStartTime.TabIndex = 21;
            // 
            // txtLogPath
            // 
            this.txtLogPath.Location = new System.Drawing.Point(602, 187);
            this.txtLogPath.Name = "txtLogPath";
            this.txtLogPath.Size = new System.Drawing.Size(568, 24);
            this.txtLogPath.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 18);
            this.label1.TabIndex = 18;
            this.label1.Text = "StartUp";
            // 
            // txtDataPath
            // 
            this.txtDataPath.Location = new System.Drawing.Point(27, 187);
            this.txtDataPath.Name = "txtDataPath";
            this.txtDataPath.Size = new System.Drawing.Size(568, 24);
            this.txtDataPath.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 18);
            this.label2.TabIndex = 19;
            this.label2.Text = "Memory";
            // 
            // txtConfiguredMemory
            // 
            this.txtConfiguredMemory.Location = new System.Drawing.Point(100, 102);
            this.txtConfiguredMemory.Name = "txtConfiguredMemory";
            this.txtConfiguredMemory.Size = new System.Drawing.Size(141, 24);
            this.txtConfiguredMemory.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 18);
            this.label3.TabIndex = 20;
            this.label3.Text = "DataPath";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridViewDatabases);
            this.tabPage2.Controls.Add(this.btnMoreInfoDB);
            this.tabPage2.Controls.Add(this.btnBack2);
            this.tabPage2.Controls.Add(this.btnRefreshInstInfoDB);
            this.tabPage2.Controls.Add(this.btnCreateDatabase);
            this.tabPage2.Controls.Add(this.btnShrinkDatabase);
            this.tabPage2.Controls.Add(this.btnTakeBackup);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1237, 634);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "DB Information";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnMoreInfoDB
            // 
            this.btnMoreInfoDB.Location = new System.Drawing.Point(533, 563);
            this.btnMoreInfoDB.Name = "btnMoreInfoDB";
            this.btnMoreInfoDB.Size = new System.Drawing.Size(191, 33);
            this.btnMoreInfoDB.TabIndex = 41;
            this.btnMoreInfoDB.Text = "More Information";
            this.btnMoreInfoDB.UseVisualStyleBackColor = true;
            this.btnMoreInfoDB.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnBack2
            // 
            this.btnBack2.Location = new System.Drawing.Point(15, 556);
            this.btnBack2.Name = "btnBack2";
            this.btnBack2.Size = new System.Drawing.Size(105, 40);
            this.btnBack2.TabIndex = 39;
            this.btnBack2.Text = "Back";
            this.btnBack2.UseVisualStyleBackColor = true;
            this.btnBack2.Click += new System.EventHandler(this.btnBack2_Click);
            // 
            // btnRefreshInstInfoDB
            // 
            this.btnRefreshInstInfoDB.Font = new System.Drawing.Font("Microsoft Tai Le", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshInstInfoDB.Location = new System.Drawing.Point(1073, 556);
            this.btnRefreshInstInfoDB.Name = "btnRefreshInstInfoDB";
            this.btnRefreshInstInfoDB.Size = new System.Drawing.Size(127, 40);
            this.btnRefreshInstInfoDB.TabIndex = 38;
            this.btnRefreshInstInfoDB.Text = "Refresh";
            this.btnRefreshInstInfoDB.UseVisualStyleBackColor = true;
            this.btnRefreshInstInfoDB.Click += new System.EventHandler(this.btnRefreshInstInfoDB_Click);
            // 
            // btnCreateDatabase
            // 
            this.btnCreateDatabase.Location = new System.Drawing.Point(161, 494);
            this.btnCreateDatabase.Name = "btnCreateDatabase";
            this.btnCreateDatabase.Size = new System.Drawing.Size(141, 34);
            this.btnCreateDatabase.TabIndex = 3;
            this.btnCreateDatabase.Text = "Create Database";
            this.btnCreateDatabase.UseVisualStyleBackColor = true;
            this.btnCreateDatabase.Click += new System.EventHandler(this.btnCreateDatabase_Click);
            // 
            // btnShrinkDatabase
            // 
            this.btnShrinkDatabase.Location = new System.Drawing.Point(871, 494);
            this.btnShrinkDatabase.Name = "btnShrinkDatabase";
            this.btnShrinkDatabase.Size = new System.Drawing.Size(142, 34);
            this.btnShrinkDatabase.TabIndex = 2;
            this.btnShrinkDatabase.Text = "Shrink Database";
            this.btnShrinkDatabase.UseVisualStyleBackColor = true;
            // 
            // btnTakeBackup
            // 
            this.btnTakeBackup.Location = new System.Drawing.Point(558, 494);
            this.btnTakeBackup.Name = "btnTakeBackup";
            this.btnTakeBackup.Size = new System.Drawing.Size(118, 34);
            this.btnTakeBackup.TabIndex = 1;
            this.btnTakeBackup.Text = "Take Backup";
            this.btnTakeBackup.UseVisualStyleBackColor = true;
            this.btnTakeBackup.Click += new System.EventHandler(this.btnTakeBackup_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tareasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(1269, 28);
            this.menuStrip1.TabIndex = 35;
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
            // dataGridViewDatabases
            // 
            this.dataGridViewDatabases.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDatabases.Location = new System.Drawing.Point(15, 23);
            this.dataGridViewDatabases.Name = "dataGridViewDatabases";
            this.dataGridViewDatabases.RowHeadersWidth = 51;
            this.dataGridViewDatabases.RowTemplate.Height = 24;
            this.dataGridViewDatabases.Size = new System.Drawing.Size(1155, 465);
            this.dataGridViewDatabases.TabIndex = 42;
            // 
            // DBInformationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1269, 721);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tabControl1);
            this.Name = "DBInformationForm";
            this.Text = "DBInformationForm";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBackupHistory)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDatabases)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnRefreshInstInfo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSQLBuild;
        private System.Windows.Forms.TextBox txtSQLEdition;
        private System.Windows.Forms.DataGridView dataGridViewBackupHistory;
        private System.Windows.Forms.TextBox txtBackupPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLastStartTime;
        private System.Windows.Forms.TextBox txtLogPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDataPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtConfiguredMemory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnBack2;
        private System.Windows.Forms.Button btnRefreshInstInfoDB;
        private System.Windows.Forms.Button btnCreateDatabase;
        private System.Windows.Forms.Button btnShrinkDatabase;
        private System.Windows.Forms.Button btnTakeBackup;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tareasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configurarPermisosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemLogout;
        private System.Windows.Forms.Button btnMoreInfoDB;
        private System.Windows.Forms.DataGridView dataGridViewDatabases;
    }
}