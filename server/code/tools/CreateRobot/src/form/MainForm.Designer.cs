namespace dc
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
            this.m_tabUser = new System.Windows.Forms.TabPage();
            this.m_tabUser_DB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_tabLogin_Start = new System.Windows.Forms.Button();
            this.m_tabUser_StartAccount = new System.Windows.Forms.TextBox();
            this.m_tabUser_EndAccount = new System.Windows.Forms.TextBox();
            this.m_tabUser_Port = new System.Windows.Forms.TextBox();
            this.m_tabUser_IP = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.m_tabControl = new System.Windows.Forms.TabControl();
            this.m_tabUser.SuspendLayout();
            this.m_tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_tabUser
            // 
            this.m_tabUser.Controls.Add(this.m_tabUser_DB);
            this.m_tabUser.Controls.Add(this.label1);
            this.m_tabUser.Controls.Add(this.m_tabLogin_Start);
            this.m_tabUser.Controls.Add(this.m_tabUser_StartAccount);
            this.m_tabUser.Controls.Add(this.m_tabUser_EndAccount);
            this.m_tabUser.Controls.Add(this.m_tabUser_Port);
            this.m_tabUser.Controls.Add(this.m_tabUser_IP);
            this.m_tabUser.Controls.Add(this.label33);
            this.m_tabUser.Controls.Add(this.label34);
            this.m_tabUser.Controls.Add(this.label35);
            this.m_tabUser.Controls.Add(this.label36);
            this.m_tabUser.Location = new System.Drawing.Point(4, 22);
            this.m_tabUser.Name = "m_tabUser";
            this.m_tabUser.Size = new System.Drawing.Size(586, 299);
            this.m_tabUser.TabIndex = 2;
            this.m_tabUser.Text = "角色";
            this.m_tabUser.UseVisualStyleBackColor = true;
            // 
            // m_tabUser_DB
            // 
            this.m_tabUser_DB.Location = new System.Drawing.Point(91, 57);
            this.m_tabUser_DB.Name = "m_tabUser_DB";
            this.m_tabUser_DB.ReadOnly = true;
            this.m_tabUser_DB.Size = new System.Drawing.Size(173, 21);
            this.m_tabUser_DB.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 38;
            this.label1.Text = "数据库名:";
            // 
            // m_tabLogin_Start
            // 
            this.m_tabLogin_Start.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_tabLogin_Start.Location = new System.Drawing.Point(227, 248);
            this.m_tabLogin_Start.Name = "m_tabLogin_Start";
            this.m_tabLogin_Start.Size = new System.Drawing.Size(115, 39);
            this.m_tabLogin_Start.TabIndex = 35;
            this.m_tabLogin_Start.Text = "开始";
            this.m_tabLogin_Start.UseVisualStyleBackColor = true;
            this.m_tabLogin_Start.Click += new System.EventHandler(this.OnLoginPageClick);
            // 
            // m_tabUser_StartAccount
            // 
            this.m_tabUser_StartAccount.Location = new System.Drawing.Point(91, 97);
            this.m_tabUser_StartAccount.Name = "m_tabUser_StartAccount";
            this.m_tabUser_StartAccount.Size = new System.Drawing.Size(173, 21);
            this.m_tabUser_StartAccount.TabIndex = 32;
            this.m_tabUser_StartAccount.Text = "0";
            // 
            // m_tabUser_EndAccount
            // 
            this.m_tabUser_EndAccount.Location = new System.Drawing.Point(405, 94);
            this.m_tabUser_EndAccount.Name = "m_tabUser_EndAccount";
            this.m_tabUser_EndAccount.Size = new System.Drawing.Size(173, 21);
            this.m_tabUser_EndAccount.TabIndex = 30;
            this.m_tabUser_EndAccount.Text = "0";
            // 
            // m_tabUser_Port
            // 
            this.m_tabUser_Port.Location = new System.Drawing.Point(407, 16);
            this.m_tabUser_Port.Name = "m_tabUser_Port";
            this.m_tabUser_Port.ReadOnly = true;
            this.m_tabUser_Port.Size = new System.Drawing.Size(151, 21);
            this.m_tabUser_Port.TabIndex = 28;
            // 
            // m_tabUser_IP
            // 
            this.m_tabUser_IP.Location = new System.Drawing.Point(91, 16);
            this.m_tabUser_IP.Name = "m_tabUser_IP";
            this.m_tabUser_IP.ReadOnly = true;
            this.m_tabUser_IP.Size = new System.Drawing.Size(173, 21);
            this.m_tabUser_IP.TabIndex = 26;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(28, 100);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(59, 12);
            this.label33.TabIndex = 31;
            this.label33.Text = "开始账号:";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(342, 97);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(59, 12);
            this.label34.TabIndex = 29;
            this.label34.Text = "结束账号:";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(366, 19);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(35, 12);
            this.label35.TabIndex = 27;
            this.label35.Text = "端口:";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(26, 19);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(59, 12);
            this.label36.TabIndex = 25;
            this.label36.Text = "数据库IP:";
            // 
            // m_tabControl
            // 
            this.m_tabControl.Controls.Add(this.m_tabUser);
            this.m_tabControl.Location = new System.Drawing.Point(12, 12);
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.SelectedIndex = 0;
            this.m_tabControl.Size = new System.Drawing.Size(594, 325);
            this.m_tabControl.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 349);
            this.Controls.Add(this.m_tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "创建机器人";
            this.m_tabUser.ResumeLayout(false);
            this.m_tabUser.PerformLayout();
            this.m_tabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage m_tabUser;
        private System.Windows.Forms.Button m_tabLogin_Start;
        private System.Windows.Forms.TextBox m_tabUser_StartAccount;
        private System.Windows.Forms.TextBox m_tabUser_EndAccount;
        private System.Windows.Forms.TextBox m_tabUser_Port;
        private System.Windows.Forms.TextBox m_tabUser_IP;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TabControl m_tabControl;
        private System.Windows.Forms.TextBox m_tabUser_DB;
        private System.Windows.Forms.Label label1;

    }
}

