namespace FoxPro2SQL
{
    partial class Form1
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
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.integratedSecurityCheckBox = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.userNameTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.databaseNameTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.serverNameTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.testConnectionButton = new System.Windows.Forms.Button();
            this.sqlCommandTextBox = new System.Windows.Forms.TextBox();
            this.createFoxProTableButton = new System.Windows.Forms.Button();
            this.convertFoxProToSQLButton = new System.Windows.Forms.Button();
            this.openDBFdirectoryButton = new System.Windows.Forms.Button();
            this.DBFdirectoryTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(114, 138);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(80, 20);
            this.passwordTextBox.TabIndex = 44;
            this.passwordTextBox.Text = "SQLPassword";
            // 
            // integratedSecurityCheckBox
            // 
            this.integratedSecurityCheckBox.AutoSize = true;
            this.integratedSecurityCheckBox.Location = new System.Drawing.Point(220, 89);
            this.integratedSecurityCheckBox.Name = "integratedSecurityCheckBox";
            this.integratedSecurityCheckBox.Size = new System.Drawing.Size(115, 17);
            this.integratedSecurityCheckBox.TabIndex = 43;
            this.integratedSecurityCheckBox.Text = "Integrated Security";
            this.integratedSecurityCheckBox.UseVisualStyleBackColor = true;
            this.integratedSecurityCheckBox.CheckedChanged += new System.EventHandler(this.integratedSecurityCheckBox_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(52, 141);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 42;
            this.label8.Text = "Password:";
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.Location = new System.Drawing.Point(114, 112);
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.Size = new System.Drawing.Size(80, 20);
            this.userNameTextBox.TabIndex = 41;
            this.userNameTextBox.Text = "SQLUser";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(76, 115);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 40;
            this.label7.Text = "User:";
            // 
            // databaseNameTextBox
            // 
            this.databaseNameTextBox.Location = new System.Drawing.Point(114, 86);
            this.databaseNameTextBox.Name = "databaseNameTextBox";
            this.databaseNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.databaseNameTextBox.TabIndex = 39;
            this.databaseNameTextBox.Text = "MyDatabase";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 38;
            this.label6.Text = "Database Name:";
            // 
            // serverNameTextBox
            // 
            this.serverNameTextBox.Location = new System.Drawing.Point(114, 60);
            this.serverNameTextBox.Name = "serverNameTextBox";
            this.serverNameTextBox.Size = new System.Drawing.Size(120, 20);
            this.serverNameTextBox.TabIndex = 37;
            this.serverNameTextBox.Text = "(local)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 36;
            this.label5.Text = "SQL Server Name:";
            // 
            // testConnectionButton
            // 
            this.testConnectionButton.Location = new System.Drawing.Point(281, 121);
            this.testConnectionButton.Name = "testConnectionButton";
            this.testConnectionButton.Size = new System.Drawing.Size(75, 37);
            this.testConnectionButton.TabIndex = 45;
            this.testConnectionButton.Text = "Test Connection";
            this.testConnectionButton.UseVisualStyleBackColor = true;
            this.testConnectionButton.Click += new System.EventHandler(this.testConnectionButton_Click);
            // 
            // sqlCommandTextBox
            // 
            this.sqlCommandTextBox.Location = new System.Drawing.Point(12, 164);
            this.sqlCommandTextBox.Multiline = true;
            this.sqlCommandTextBox.Name = "sqlCommandTextBox";
            this.sqlCommandTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.sqlCommandTextBox.Size = new System.Drawing.Size(344, 188);
            this.sqlCommandTextBox.TabIndex = 46;
            // 
            // createFoxProTableButton
            // 
            this.createFoxProTableButton.Location = new System.Drawing.Point(12, 358);
            this.createFoxProTableButton.Name = "createFoxProTableButton";
            this.createFoxProTableButton.Size = new System.Drawing.Size(107, 43);
            this.createFoxProTableButton.TabIndex = 48;
            this.createFoxProTableButton.Text = "Create FoxPro Example Table";
            this.createFoxProTableButton.UseVisualStyleBackColor = true;
            this.createFoxProTableButton.Click += new System.EventHandler(this.createFoxProTableButton_Click);
            // 
            // convertFoxProToSQLButton
            // 
            this.convertFoxProToSQLButton.Location = new System.Drawing.Point(268, 358);
            this.convertFoxProToSQLButton.Name = "convertFoxProToSQLButton";
            this.convertFoxProToSQLButton.Size = new System.Drawing.Size(88, 43);
            this.convertFoxProToSQLButton.TabIndex = 47;
            this.convertFoxProToSQLButton.Text = "Convert FoxPro to SQL";
            this.convertFoxProToSQLButton.UseVisualStyleBackColor = true;
            this.convertFoxProToSQLButton.Click += new System.EventHandler(this.convertFoxProToSQLButton_Click);
            // 
            // openDBFdirectoryButton
            // 
            this.openDBFdirectoryButton.Location = new System.Drawing.Point(331, 25);
            this.openDBFdirectoryButton.Name = "openDBFdirectoryButton";
            this.openDBFdirectoryButton.Size = new System.Drawing.Size(25, 20);
            this.openDBFdirectoryButton.TabIndex = 51;
            this.openDBFdirectoryButton.Text = "...";
            this.openDBFdirectoryButton.UseVisualStyleBackColor = true;
            this.openDBFdirectoryButton.Click += new System.EventHandler(this.openDBFdirectoryButton_Click);
            // 
            // DBFdirectoryTextBox
            // 
            this.DBFdirectoryTextBox.Location = new System.Drawing.Point(15, 25);
            this.DBFdirectoryTextBox.Name = "DBFdirectoryTextBox";
            this.DBFdirectoryTextBox.Size = new System.Drawing.Size(341, 20);
            this.DBFdirectoryTextBox.TabIndex = 50;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 49;
            this.label1.Text = "Choose the DBF directory:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 411);
            this.Controls.Add(this.openDBFdirectoryButton);
            this.Controls.Add(this.DBFdirectoryTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.createFoxProTableButton);
            this.Controls.Add(this.convertFoxProToSQLButton);
            this.Controls.Add(this.sqlCommandTextBox);
            this.Controls.Add(this.testConnectionButton);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.integratedSecurityCheckBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.userNameTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.databaseNameTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.serverNameTextBox);
            this.Controls.Add(this.label5);
            this.Name = "Form1";
            this.Text = "FoxPro2SQL";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.CheckBox integratedSecurityCheckBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox userNameTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox databaseNameTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox serverNameTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button testConnectionButton;
        private System.Windows.Forms.TextBox sqlCommandTextBox;
        private System.Windows.Forms.Button createFoxProTableButton;
        private System.Windows.Forms.Button convertFoxProToSQLButton;
        private System.Windows.Forms.Button openDBFdirectoryButton;
        private System.Windows.Forms.TextBox DBFdirectoryTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;

    }
}

