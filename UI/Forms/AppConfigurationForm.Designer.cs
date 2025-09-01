namespace UI.Forms
{
    partial class AppConfigurationForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtInstanceName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.rdbUserPassword = new System.Windows.Forms.RadioButton();
            this.rdbIntegratedAuth = new System.Windows.Forms.RadioButton();
            this.btnLoadDatabases = new System.Windows.Forms.Button();
            this.txtUsernameApp = new System.Windows.Forms.TextBox();
            this.txtPasswordApp = new System.Windows.Forms.TextBox();
            this.btnConfigApp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(296, 20);
            this.label1.TabIndex = 0;
            this.label1.Tag = "Nombre de servidor de Base de Datos";
            this.label1.Text = "Nombre de servidor de Base de Datos";
            // 
            // txtInstanceName
            // 
            this.txtInstanceName.Location = new System.Drawing.Point(70, 81);
            this.txtInstanceName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtInstanceName.Name = "txtInstanceName";
            this.txtInstanceName.Size = new System.Drawing.Size(294, 27);
            this.txtInstanceName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(107, 310);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 44;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(107, 218);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 43;
            this.label3.Text = "SQL Login";
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.Gainsboro;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Tai Le", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(111, 335);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(193, 29);
            this.txtPassword.TabIndex = 42;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.Gainsboro;
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Tai Le", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(111, 243);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(193, 29);
            this.txtUsername.TabIndex = 41;
            // 
            // rdbUserPassword
            // 
            this.rdbUserPassword.AutoSize = true;
            this.rdbUserPassword.Location = new System.Drawing.Point(263, 153);
            this.rdbUserPassword.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.rdbUserPassword.Name = "rdbUserPassword";
            this.rdbUserPassword.Size = new System.Drawing.Size(110, 24);
            this.rdbUserPassword.TabIndex = 40;
            this.rdbUserPassword.TabStop = true;
            this.rdbUserPassword.Text = "SQL Login";
            this.rdbUserPassword.UseVisualStyleBackColor = true;
            // 
            // rdbIntegratedAuth
            // 
            this.rdbIntegratedAuth.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbIntegratedAuth.AutoSize = true;
            this.rdbIntegratedAuth.Location = new System.Drawing.Point(55, 153);
            this.rdbIntegratedAuth.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.rdbIntegratedAuth.Name = "rdbIntegratedAuth";
            this.rdbIntegratedAuth.Size = new System.Drawing.Size(144, 24);
            this.rdbIntegratedAuth.TabIndex = 39;
            this.rdbIntegratedAuth.TabStop = true;
            this.rdbIntegratedAuth.Text = "Windows Login";
            this.rdbIntegratedAuth.UseVisualStyleBackColor = true;
            // 
            // btnLoadDatabases
            // 
            this.btnLoadDatabases.AutoSize = true;
            this.btnLoadDatabases.Font = new System.Drawing.Font("Microsoft Tai Le", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadDatabases.Location = new System.Drawing.Point(141, 393);
            this.btnLoadDatabases.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnLoadDatabases.Name = "btnLoadDatabases";
            this.btnLoadDatabases.Size = new System.Drawing.Size(150, 32);
            this.btnLoadDatabases.TabIndex = 45;
            this.btnLoadDatabases.Tag = "Validar Conexión";
            this.btnLoadDatabases.Text = "Validar Conexión";
            this.btnLoadDatabases.UseVisualStyleBackColor = true;
            this.btnLoadDatabases.Click += new System.EventHandler(this.btnLoadDatabases_Click);
            // 
            // txtUsernameApp
            // 
            this.txtUsernameApp.Location = new System.Drawing.Point(111, 541);
            this.txtUsernameApp.Name = "txtUsernameApp";
            this.txtUsernameApp.Size = new System.Drawing.Size(193, 27);
            this.txtUsernameApp.TabIndex = 46;
            // 
            // txtPasswordApp
            // 
            this.txtPasswordApp.Location = new System.Drawing.Point(111, 590);
            this.txtPasswordApp.Name = "txtPasswordApp";
            this.txtPasswordApp.Size = new System.Drawing.Size(193, 27);
            this.txtPasswordApp.TabIndex = 47;
            // 
            // btnConfigApp
            // 
            this.btnConfigApp.Location = new System.Drawing.Point(111, 684);
            this.btnConfigApp.Name = "btnConfigApp";
            this.btnConfigApp.Size = new System.Drawing.Size(194, 29);
            this.btnConfigApp.TabIndex = 48;
            this.btnConfigApp.Tag = "Configurar Aplicacion";
            this.btnConfigApp.Text = "Configurar Aplicacion";
            this.btnConfigApp.UseVisualStyleBackColor = true;
            this.btnConfigApp.Click += new System.EventHandler(this.btnConfigApp_Click);
            // 
            // AppConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 763);
            this.Controls.Add(this.btnConfigApp);
            this.Controls.Add(this.txtPasswordApp);
            this.Controls.Add(this.txtUsernameApp);
            this.Controls.Add(this.btnLoadDatabases);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.rdbUserPassword);
            this.Controls.Add(this.rdbIntegratedAuth);
            this.Controls.Add(this.txtInstanceName);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AppConfigurationForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInstanceName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.RadioButton rdbUserPassword;
        private System.Windows.Forms.RadioButton rdbIntegratedAuth;
        private System.Windows.Forms.Button btnLoadDatabases;
        private System.Windows.Forms.TextBox txtUsernameApp;
        private System.Windows.Forms.TextBox txtPasswordApp;
        private System.Windows.Forms.Button btnConfigApp;
    }
}