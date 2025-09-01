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
            this.btnViewJobs = new System.Windows.Forms.Button();
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
            this.btnDBStatus = new System.Windows.Forms.Button();
            this.btnShrinkDatabase = new System.Windows.Forms.Button();
            this.dataGridViewDatabases = new System.Windows.Forms.DataGridView();
            this.btnMoreInfoDB = new System.Windows.Forms.Button();
            this.btnBack2 = new System.Windows.Forms.Button();
            this.btnRefreshInstInfoDB = new System.Windows.Forms.Button();
            this.btnCreateDatabase = new System.Windows.Forms.Button();
            this.btnDeleteDatabase = new System.Windows.Forms.Button();
            this.btnTakeBackup = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dataGridViewDisks = new System.Windows.Forms.DataGridView();
            this.dataGridViewServices = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tareasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurarPermisosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.españolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inglesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label8 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBackupHistory)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDatabases)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDisks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewServices)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 106);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1422, 680);
            this.tabControl1.TabIndex = 34;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnViewJobs);
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
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1414, 645);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Tag = "Información de la Instancia";
            this.tabPage1.Text = "Información de la Instancia";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnViewJobs
            // 
            this.btnViewJobs.Location = new System.Drawing.Point(620, 573);
            this.btnViewJobs.Name = "btnViewJobs";
            this.btnViewJobs.Size = new System.Drawing.Size(172, 45);
            this.btnViewJobs.TabIndex = 39;
            this.btnViewJobs.Tag = "Ver Trabajos del Agente SQL";
            this.btnViewJobs.Text = "Ver Trabajos del Agente SQL";
            this.btnViewJobs.UseVisualStyleBackColor = true;
            this.btnViewJobs.Click += new System.EventHandler(this.btnViewJobs_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(27, 564);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(105, 40);
            this.btnBack.TabIndex = 38;
            this.btnBack.Tag = "Atrás";
            this.btnBack.Text = "Atrás";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnRefreshInstInfo
            // 
            this.btnRefreshInstInfo.Location = new System.Drawing.Point(1209, 567);
            this.btnRefreshInstInfo.Name = "btnRefreshInstInfo";
            this.btnRefreshInstInfo.Size = new System.Drawing.Size(141, 40);
            this.btnRefreshInstInfo.TabIndex = 37;
            this.btnRefreshInstInfo.Tag = "Actualizar";
            this.btnRefreshInstInfo.Text = "Actualizar";
            this.btnRefreshInstInfo.UseVisualStyleBackColor = true;
            this.btnRefreshInstInfo.Click += new System.EventHandler(this.btnRefreshInstInfo_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(794, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(192, 18);
            this.label7.TabIndex = 36;
            this.label7.Tag = "Compilación de SQL Server";
            this.label7.Text = "Compilación de SQL Server";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(340, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(158, 18);
            this.label6.TabIndex = 35;
            this.label6.Tag = "Edición de SQL Server";
            this.label6.Text = "Edición de SQL Server";
            // 
            // txtSQLBuild
            // 
            this.txtSQLBuild.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSQLBuild.Location = new System.Drawing.Point(992, 37);
            this.txtSQLBuild.Name = "txtSQLBuild";
            this.txtSQLBuild.Size = new System.Drawing.Size(203, 24);
            this.txtSQLBuild.TabIndex = 34;
            // 
            // txtSQLEdition
            // 
            this.txtSQLEdition.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSQLEdition.Location = new System.Drawing.Point(504, 40);
            this.txtSQLEdition.Name = "txtSQLEdition";
            this.txtSQLEdition.Size = new System.Drawing.Size(271, 24);
            this.txtSQLEdition.TabIndex = 33;
            // 
            // dataGridViewBackupHistory
            // 
            this.dataGridViewBackupHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBackupHistory.Location = new System.Drawing.Point(19, 304);
            this.dataGridViewBackupHistory.Name = "dataGridViewBackupHistory";
            this.dataGridViewBackupHistory.RowHeadersWidth = 51;
            this.dataGridViewBackupHistory.RowTemplate.Height = 24;
            this.dataGridViewBackupHistory.Size = new System.Drawing.Size(1371, 231);
            this.dataGridViewBackupHistory.TabIndex = 32;
            // 
            // txtBackupPath
            // 
            this.txtBackupPath.Location = new System.Drawing.Point(36, 250);
            this.txtBackupPath.Name = "txtBackupPath";
            this.txtBackupPath.Size = new System.Drawing.Size(631, 24);
            this.txtBackupPath.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(207, 18);
            this.label4.TabIndex = 26;
            this.label4.Tag = "Ruta de Archivos de Respaldo";
            this.label4.Text = "Ruta de Archivos de Respaldo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(780, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(169, 18);
            this.label5.TabIndex = 27;
            this.label5.Tag = "Ruta de Archivos de Log";
            this.label5.Text = "Ruta de Archivos de Log";
            // 
            // txtLastStartTime
            // 
            this.txtLastStartTime.Location = new System.Drawing.Point(119, 40);
            this.txtLastStartTime.Name = "txtLastStartTime";
            this.txtLastStartTime.Size = new System.Drawing.Size(215, 24);
            this.txtLastStartTime.TabIndex = 21;
            // 
            // txtLogPath
            // 
            this.txtLogPath.Location = new System.Drawing.Point(772, 140);
            this.txtLogPath.Name = "txtLogPath";
            this.txtLogPath.Size = new System.Drawing.Size(618, 24);
            this.txtLogPath.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 18);
            this.label1.TabIndex = 18;
            this.label1.Tag = "Fecha de Inicio";
            this.label1.Text = "Fecha de Inicio";
            // 
            // txtDataPath
            // 
            this.txtDataPath.Location = new System.Drawing.Point(36, 140);
            this.txtDataPath.Name = "txtDataPath";
            this.txtDataPath.Size = new System.Drawing.Size(631, 24);
            this.txtDataPath.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1227, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 18);
            this.label2.TabIndex = 19;
            this.label2.Tag = "Memoria";
            this.label2.Text = "Memoria";
            // 
            // txtConfiguredMemory
            // 
            this.txtConfiguredMemory.Location = new System.Drawing.Point(1300, 37);
            this.txtConfiguredMemory.Name = "txtConfiguredMemory";
            this.txtConfiguredMemory.Size = new System.Drawing.Size(90, 24);
            this.txtConfiguredMemory.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 18);
            this.label3.TabIndex = 20;
            this.label3.Tag = "Ruta de Archivos de Datos";
            this.label3.Text = "Ruta de Archivos de Datos";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnDBStatus);
            this.tabPage2.Controls.Add(this.btnShrinkDatabase);
            this.tabPage2.Controls.Add(this.dataGridViewDatabases);
            this.tabPage2.Controls.Add(this.btnMoreInfoDB);
            this.tabPage2.Controls.Add(this.btnBack2);
            this.tabPage2.Controls.Add(this.btnRefreshInstInfoDB);
            this.tabPage2.Controls.Add(this.btnCreateDatabase);
            this.tabPage2.Controls.Add(this.btnDeleteDatabase);
            this.tabPage2.Controls.Add(this.btnTakeBackup);
            this.tabPage2.Location = new System.Drawing.Point(4, 31);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1414, 645);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Tag = "Información de Base de Datos";
            this.tabPage2.Text = "Información de Base de Datos";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnDBStatus
            // 
            this.btnDBStatus.Location = new System.Drawing.Point(1153, 518);
            this.btnDBStatus.Name = "btnDBStatus";
            this.btnDBStatus.Size = new System.Drawing.Size(171, 62);
            this.btnDBStatus.TabIndex = 44;
            this.btnDBStatus.Tag = "Cambiar Estado de Base de Datos";
            this.btnDBStatus.Text = "Cambiar Estado de Base de Datos";
            this.btnDBStatus.UseVisualStyleBackColor = true;
            this.btnDBStatus.Click += new System.EventHandler(this.btnDBStatus_Click);
            // 
            // btnShrinkDatabase
            // 
            this.btnShrinkDatabase.Location = new System.Drawing.Point(858, 518);
            this.btnShrinkDatabase.Name = "btnShrinkDatabase";
            this.btnShrinkDatabase.Size = new System.Drawing.Size(171, 62);
            this.btnShrinkDatabase.TabIndex = 43;
            this.btnShrinkDatabase.Tag = "Reducir Base de Datos";
            this.btnShrinkDatabase.Text = "Reducir Base de Datos";
            this.btnShrinkDatabase.UseVisualStyleBackColor = true;
            this.btnShrinkDatabase.Click += new System.EventHandler(this.btnShrinkDatabase_Click);
            // 
            // dataGridViewDatabases
            // 
            this.dataGridViewDatabases.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDatabases.Location = new System.Drawing.Point(32, 27);
            this.dataGridViewDatabases.Name = "dataGridViewDatabases";
            this.dataGridViewDatabases.RowHeadersWidth = 51;
            this.dataGridViewDatabases.RowTemplate.Height = 24;
            this.dataGridViewDatabases.Size = new System.Drawing.Size(1347, 465);
            this.dataGridViewDatabases.TabIndex = 42;
            // 
            // btnMoreInfoDB
            // 
            this.btnMoreInfoDB.Location = new System.Drawing.Point(612, 593);
            this.btnMoreInfoDB.Name = "btnMoreInfoDB";
            this.btnMoreInfoDB.Size = new System.Drawing.Size(191, 33);
            this.btnMoreInfoDB.TabIndex = 41;
            this.btnMoreInfoDB.Tag = "Más Información";
            this.btnMoreInfoDB.Text = "Más Información";
            this.btnMoreInfoDB.UseVisualStyleBackColor = true;
            this.btnMoreInfoDB.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnBack2
            // 
            this.btnBack2.Location = new System.Drawing.Point(32, 586);
            this.btnBack2.Name = "btnBack2";
            this.btnBack2.Size = new System.Drawing.Size(105, 40);
            this.btnBack2.TabIndex = 39;
            this.btnBack2.Tag = "Atras";
            this.btnBack2.Text = "Atras";
            this.btnBack2.UseVisualStyleBackColor = true;
            this.btnBack2.Click += new System.EventHandler(this.btnBack2_Click);
            // 
            // btnRefreshInstInfoDB
            // 
            this.btnRefreshInstInfoDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshInstInfoDB.Location = new System.Drawing.Point(1233, 586);
            this.btnRefreshInstInfoDB.Name = "btnRefreshInstInfoDB";
            this.btnRefreshInstInfoDB.Size = new System.Drawing.Size(127, 40);
            this.btnRefreshInstInfoDB.TabIndex = 38;
            this.btnRefreshInstInfoDB.Tag = "Actualizar";
            this.btnRefreshInstInfoDB.Text = "Actualizar";
            this.btnRefreshInstInfoDB.UseVisualStyleBackColor = true;
            this.btnRefreshInstInfoDB.Click += new System.EventHandler(this.btnRefreshInstInfoDB_Click);
            // 
            // btnCreateDatabase
            // 
            this.btnCreateDatabase.Location = new System.Drawing.Point(113, 518);
            this.btnCreateDatabase.Name = "btnCreateDatabase";
            this.btnCreateDatabase.Size = new System.Drawing.Size(174, 62);
            this.btnCreateDatabase.TabIndex = 3;
            this.btnCreateDatabase.Tag = "Crear Base de Datos";
            this.btnCreateDatabase.Text = "Crear Base de Datos";
            this.btnCreateDatabase.UseVisualStyleBackColor = true;
            this.btnCreateDatabase.Click += new System.EventHandler(this.btnCreateDatabase_Click);
            // 
            // btnDeleteDatabase
            // 
            this.btnDeleteDatabase.Location = new System.Drawing.Point(591, 518);
            this.btnDeleteDatabase.Name = "btnDeleteDatabase";
            this.btnDeleteDatabase.Size = new System.Drawing.Size(171, 62);
            this.btnDeleteDatabase.TabIndex = 2;
            this.btnDeleteDatabase.Tag = "Eliminar Base de Datos";
            this.btnDeleteDatabase.Text = "Eliminar Base de Datos";
            this.btnDeleteDatabase.UseVisualStyleBackColor = true;
            this.btnDeleteDatabase.Click += new System.EventHandler(this.btnDeleteDatabase_Click);
            // 
            // btnTakeBackup
            // 
            this.btnTakeBackup.Location = new System.Drawing.Point(353, 518);
            this.btnTakeBackup.Name = "btnTakeBackup";
            this.btnTakeBackup.Size = new System.Drawing.Size(166, 62);
            this.btnTakeBackup.TabIndex = 1;
            this.btnTakeBackup.Tag = "Realizar Respaldo";
            this.btnTakeBackup.Text = "Realizar Respaldo";
            this.btnTakeBackup.UseVisualStyleBackColor = true;
            this.btnTakeBackup.Click += new System.EventHandler(this.btnTakeBackup_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.dataGridViewDisks);
            this.tabPage3.Controls.Add(this.dataGridViewServices);
            this.tabPage3.Location = new System.Drawing.Point(4, 31);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1414, 645);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Tag = "Información del Servidor";
            this.tabPage3.Text = "Información del Servidor";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1240, 583);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 41);
            this.button1.TabIndex = 4;
            this.button1.Tag = "Actualizar";
            this.button1.Text = "Actualizar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(59, 333);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(186, 22);
            this.label10.TabIndex = 3;
            this.label10.Tag = "Información de Discos";
            this.label10.Text = "Información de Discos";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(77, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(268, 22);
            this.label9.TabIndex = 2;
            this.label9.Tag = "Estado de Servicios SQL Server";
            this.label9.Text = "Estado de Servicios SQL Server";
            // 
            // dataGridViewDisks
            // 
            this.dataGridViewDisks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDisks.Location = new System.Drawing.Point(39, 371);
            this.dataGridViewDisks.Name = "dataGridViewDisks";
            this.dataGridViewDisks.RowHeadersWidth = 51;
            this.dataGridViewDisks.RowTemplate.Height = 24;
            this.dataGridViewDisks.Size = new System.Drawing.Size(1144, 220);
            this.dataGridViewDisks.TabIndex = 1;
            // 
            // dataGridViewServices
            // 
            this.dataGridViewServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewServices.Location = new System.Drawing.Point(39, 71);
            this.dataGridViewServices.Name = "dataGridViewServices";
            this.dataGridViewServices.RowHeadersWidth = 51;
            this.dataGridViewServices.RowTemplate.Height = 24;
            this.dataGridViewServices.Size = new System.Drawing.Size(1144, 231);
            this.dataGridViewServices.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tareasToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(1446, 35);
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
            this.tareasToolStripMenuItem.Size = new System.Drawing.Size(85, 31);
            this.tareasToolStripMenuItem.Tag = "Opciones";
            this.tareasToolStripMenuItem.Text = "Opciones";
            // 
            // agregarUsuarioToolStripMenuItem
            // 
            this.agregarUsuarioToolStripMenuItem.Name = "agregarUsuarioToolStripMenuItem";
            this.agregarUsuarioToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.agregarUsuarioToolStripMenuItem.Tag = "Agregar Usuario";
            this.agregarUsuarioToolStripMenuItem.Text = "Agregar Usuario";
            this.agregarUsuarioToolStripMenuItem.Click += new System.EventHandler(this.agregarUsuarioToolStripMenuItem_Click);
            // 
            // configurarPermisosToolStripMenuItem
            // 
            this.configurarPermisosToolStripMenuItem.Name = "configurarPermisosToolStripMenuItem";
            this.configurarPermisosToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.configurarPermisosToolStripMenuItem.Tag = "Configurar Permisos";
            this.configurarPermisosToolStripMenuItem.Text = "Configurar Permisos";
            this.configurarPermisosToolStripMenuItem.Click += new System.EventHandler(this.configurarPermisosToolStripMenuItem_Click);
            // 
            // menuItemLogout
            // 
            this.menuItemLogout.Name = "menuItemLogout";
            this.menuItemLogout.Size = new System.Drawing.Size(224, 26);
            this.menuItemLogout.Tag = "Cerrar Sesión";
            this.menuItemLogout.Text = "Cerrar Sesión";
            this.menuItemLogout.Click += new System.EventHandler(this.menuItemLogout_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.españolToolStripMenuItem,
            this.inglesToolStripMenuItem});
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(53, 31);
            this.toolStripMenuItem1.Text = "🌐";
            // 
            // españolToolStripMenuItem
            // 
            this.españolToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.españolToolStripMenuItem.Name = "españolToolStripMenuItem";
            this.españolToolStripMenuItem.Size = new System.Drawing.Size(224, 28);
            this.españolToolStripMenuItem.Text = "Español";
            this.españolToolStripMenuItem.Click += new System.EventHandler(this.españolToolStripMenuItem_Click);
            // 
            // inglesToolStripMenuItem
            // 
            this.inglesToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inglesToolStripMenuItem.Name = "inglesToolStripMenuItem";
            this.inglesToolStripMenuItem.Size = new System.Drawing.Size(224, 28);
            this.inglesToolStripMenuItem.Text = "Inglés";
            this.inglesToolStripMenuItem.Click += new System.EventHandler(this.inglesToolStripMenuItem_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(535, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 32);
            this.label8.TabIndex = 36;
            // 
            // DBInformationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1446, 798);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tabControl1);
            this.Name = "DBInformationForm";
            this.Text = "DBInformationForm";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBackupHistory)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDatabases)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDisks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewServices)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.Button btnDeleteDatabase;
        private System.Windows.Forms.Button btnTakeBackup;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tareasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configurarPermisosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemLogout;
        private System.Windows.Forms.Button btnMoreInfoDB;
        private System.Windows.Forms.DataGridView dataGridViewDatabases;
        private System.Windows.Forms.Button btnViewJobs;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnShrinkDatabase;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dataGridViewDisks;
        private System.Windows.Forms.DataGridView dataGridViewServices;
        private System.Windows.Forms.Button btnDBStatus;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem españolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inglesToolStripMenuItem;
    }
}