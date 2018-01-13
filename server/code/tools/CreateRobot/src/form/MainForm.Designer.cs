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
            System.Windows.Forms.Label label30;
            this.m_tabMove = new System.Windows.Forms.TabPage();
            this.label29 = new System.Windows.Forms.Label();
            this.m_tabMove_IP = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.m_tabMove_Port = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.m_tabMove_ClientCount = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.m_tabMove_MoveTime = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.m_tabMove_CurClientCount = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.m_tabMove_Start = new System.Windows.Forms.Button();
            this.m_tabMove_StartAccount = new System.Windows.Forms.TextBox();
            this.m_tabLogin = new System.Windows.Forms.TabPage();
            this.label36 = new System.Windows.Forms.Label();
            this.m_tabLogin_IP = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.m_tabLogin_Port = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.m_tabLogin_ClientCount = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.m_tabLogin_DisconTime = new System.Windows.Forms.TextBox();
            this.m_tabLogin_Start = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_tabLogin_CurClientCount = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.m_tabControl = new System.Windows.Forms.TabControl();
            label30 = new System.Windows.Forms.Label();
            this.m_tabMove.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.m_tabLogin.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.m_tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_tabMove
            // 
            this.m_tabMove.Controls.Add(this.m_tabMove_StartAccount);
            this.m_tabMove.Controls.Add(this.m_tabMove_MoveTime);
            this.m_tabMove.Controls.Add(this.m_tabMove_ClientCount);
            this.m_tabMove.Controls.Add(this.m_tabMove_Port);
            this.m_tabMove.Controls.Add(this.m_tabMove_IP);
            this.m_tabMove.Controls.Add(label30);
            this.m_tabMove.Controls.Add(this.m_tabMove_Start);
            this.m_tabMove.Controls.Add(this.label21);
            this.m_tabMove.Controls.Add(this.label23);
            this.m_tabMove.Controls.Add(this.groupBox3);
            this.m_tabMove.Controls.Add(this.label25);
            this.m_tabMove.Controls.Add(this.label26);
            this.m_tabMove.Controls.Add(this.label28);
            this.m_tabMove.Controls.Add(this.label29);
            this.m_tabMove.Location = new System.Drawing.Point(4, 22);
            this.m_tabMove.Name = "m_tabMove";
            this.m_tabMove.Size = new System.Drawing.Size(586, 303);
            this.m_tabMove.TabIndex = 4;
            this.m_tabMove.Text = "角色";
            this.m_tabMove.UseVisualStyleBackColor = true;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(26, 19);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(59, 12);
            this.label29.TabIndex = 40;
            this.label29.Text = "服务器IP:";
            // 
            // m_tabMove_IP
            // 
            this.m_tabMove_IP.Location = new System.Drawing.Point(91, 16);
            this.m_tabMove_IP.Name = "m_tabMove_IP";
            this.m_tabMove_IP.Size = new System.Drawing.Size(173, 21);
            this.m_tabMove_IP.TabIndex = 41;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(366, 19);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(35, 12);
            this.label28.TabIndex = 42;
            this.label28.Text = "端口:";
            // 
            // m_tabMove_Port
            // 
            this.m_tabMove_Port.Location = new System.Drawing.Point(407, 16);
            this.m_tabMove_Port.Name = "m_tabMove_Port";
            this.m_tabMove_Port.Size = new System.Drawing.Size(151, 21);
            this.m_tabMove_Port.TabIndex = 43;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(28, 58);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(59, 12);
            this.label26.TabIndex = 44;
            this.label26.Text = "连接数量:";
            // 
            // m_tabMove_ClientCount
            // 
            this.m_tabMove_ClientCount.Location = new System.Drawing.Point(91, 55);
            this.m_tabMove_ClientCount.Name = "m_tabMove_ClientCount";
            this.m_tabMove_ClientCount.Size = new System.Drawing.Size(173, 21);
            this.m_tabMove_ClientCount.TabIndex = 45;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(28, 100);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(59, 12);
            this.label25.TabIndex = 46;
            this.label25.Text = "移动频率:";
            // 
            // m_tabMove_MoveTime
            // 
            this.m_tabMove_MoveTime.Location = new System.Drawing.Point(91, 97);
            this.m_tabMove_MoveTime.Name = "m_tabMove_MoveTime";
            this.m_tabMove_MoveTime.Size = new System.Drawing.Size(173, 21);
            this.m_tabMove_MoveTime.TabIndex = 47;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label24);
            this.groupBox3.Controls.Add(this.m_tabMove_CurClientCount);
            this.groupBox3.Location = new System.Drawing.Point(7, 138);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(573, 113);
            this.groupBox3.TabIndex = 48;
            this.groupBox3.TabStop = false;
            // 
            // m_tabMove_CurClientCount
            // 
            this.m_tabMove_CurClientCount.Location = new System.Drawing.Point(84, 20);
            this.m_tabMove_CurClientCount.Name = "m_tabMove_CurClientCount";
            this.m_tabMove_CurClientCount.ReadOnly = true;
            this.m_tabMove_CurClientCount.Size = new System.Drawing.Size(173, 21);
            this.m_tabMove_CurClientCount.TabIndex = 20;
            this.m_tabMove_CurClientCount.Text = "0";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(21, 23);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(59, 12);
            this.label24.TabIndex = 19;
            this.label24.Text = "连接数量:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(270, 100);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(17, 12);
            this.label23.TabIndex = 49;
            this.label23.Text = "秒";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(270, 58);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(53, 12);
            this.label21.TabIndex = 50;
            this.label21.Text = "[1-5000]";
            // 
            // m_tabMove_Start
            // 
            this.m_tabMove_Start.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_tabMove_Start.Location = new System.Drawing.Point(233, 257);
            this.m_tabMove_Start.Name = "m_tabMove_Start";
            this.m_tabMove_Start.Size = new System.Drawing.Size(115, 39);
            this.m_tabMove_Start.TabIndex = 51;
            this.m_tabMove_Start.Text = "开始";
            this.m_tabMove_Start.UseVisualStyleBackColor = true;
            this.m_tabMove_Start.Click += new System.EventHandler(this.OnMovePageClick);
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Location = new System.Drawing.Point(342, 58);
            label30.Name = "label30";
            label30.Size = new System.Drawing.Size(59, 12);
            label30.TabIndex = 52;
            label30.Text = "开始账号:";
            // 
            // m_tabMove_StartAccount
            // 
            this.m_tabMove_StartAccount.Location = new System.Drawing.Point(407, 55);
            this.m_tabMove_StartAccount.Name = "m_tabMove_StartAccount";
            this.m_tabMove_StartAccount.Size = new System.Drawing.Size(151, 21);
            this.m_tabMove_StartAccount.TabIndex = 53;
            this.m_tabMove_StartAccount.Text = "1";
            // 
            // m_tabLogin
            // 
            this.m_tabLogin.Controls.Add(this.label20);
            this.m_tabLogin.Controls.Add(this.label22);
            this.m_tabLogin.Controls.Add(this.groupBox2);
            this.m_tabLogin.Controls.Add(this.m_tabLogin_Start);
            this.m_tabLogin.Controls.Add(this.m_tabLogin_DisconTime);
            this.m_tabLogin.Controls.Add(this.m_tabLogin_ClientCount);
            this.m_tabLogin.Controls.Add(this.m_tabLogin_Port);
            this.m_tabLogin.Controls.Add(this.m_tabLogin_IP);
            this.m_tabLogin.Controls.Add(this.label33);
            this.m_tabLogin.Controls.Add(this.label34);
            this.m_tabLogin.Controls.Add(this.label35);
            this.m_tabLogin.Controls.Add(this.label36);
            this.m_tabLogin.Location = new System.Drawing.Point(4, 22);
            this.m_tabLogin.Name = "m_tabLogin";
            this.m_tabLogin.Size = new System.Drawing.Size(586, 303);
            this.m_tabLogin.TabIndex = 2;
            this.m_tabLogin.Text = "账号";
            this.m_tabLogin.UseVisualStyleBackColor = true;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(26, 19);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(59, 12);
            this.label36.TabIndex = 25;
            this.label36.Text = "服务器IP:";
            // 
            // m_tabLogin_IP
            // 
            this.m_tabLogin_IP.Location = new System.Drawing.Point(91, 16);
            this.m_tabLogin_IP.Name = "m_tabLogin_IP";
            this.m_tabLogin_IP.Size = new System.Drawing.Size(173, 21);
            this.m_tabLogin_IP.TabIndex = 26;
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
            // m_tabLogin_Port
            // 
            this.m_tabLogin_Port.Location = new System.Drawing.Point(407, 16);
            this.m_tabLogin_Port.Name = "m_tabLogin_Port";
            this.m_tabLogin_Port.Size = new System.Drawing.Size(151, 21);
            this.m_tabLogin_Port.TabIndex = 28;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(28, 58);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(59, 12);
            this.label34.TabIndex = 29;
            this.label34.Text = "连接数量:";
            // 
            // m_tabLogin_ClientCount
            // 
            this.m_tabLogin_ClientCount.Location = new System.Drawing.Point(91, 55);
            this.m_tabLogin_ClientCount.Name = "m_tabLogin_ClientCount";
            this.m_tabLogin_ClientCount.Size = new System.Drawing.Size(173, 21);
            this.m_tabLogin_ClientCount.TabIndex = 30;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(28, 100);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(59, 12);
            this.label33.TabIndex = 31;
            this.label33.Text = "断开频率:";
            // 
            // m_tabLogin_DisconTime
            // 
            this.m_tabLogin_DisconTime.Location = new System.Drawing.Point(91, 97);
            this.m_tabLogin_DisconTime.Name = "m_tabLogin_DisconTime";
            this.m_tabLogin_DisconTime.Size = new System.Drawing.Size(173, 21);
            this.m_tabLogin_DisconTime.TabIndex = 32;
            // 
            // m_tabLogin_Start
            // 
            this.m_tabLogin_Start.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_tabLogin_Start.Location = new System.Drawing.Point(233, 257);
            this.m_tabLogin_Start.Name = "m_tabLogin_Start";
            this.m_tabLogin_Start.Size = new System.Drawing.Size(115, 39);
            this.m_tabLogin_Start.TabIndex = 35;
            this.m_tabLogin_Start.Text = "开始";
            this.m_tabLogin_Start.UseVisualStyleBackColor = true;
            this.m_tabLogin_Start.Click += new System.EventHandler(this.OnLoginPageClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label27);
            this.groupBox2.Controls.Add(this.m_tabLogin_CurClientCount);
            this.groupBox2.Location = new System.Drawing.Point(7, 138);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(573, 113);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            // 
            // m_tabLogin_CurClientCount
            // 
            this.m_tabLogin_CurClientCount.Location = new System.Drawing.Point(84, 20);
            this.m_tabLogin_CurClientCount.Name = "m_tabLogin_CurClientCount";
            this.m_tabLogin_CurClientCount.ReadOnly = true;
            this.m_tabLogin_CurClientCount.Size = new System.Drawing.Size(173, 21);
            this.m_tabLogin_CurClientCount.TabIndex = 20;
            this.m_tabLogin_CurClientCount.Text = "0";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(21, 23);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(59, 12);
            this.label27.TabIndex = 19;
            this.label27.Text = "连接数量:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(270, 100);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(17, 12);
            this.label22.TabIndex = 38;
            this.label22.Text = "秒";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(270, 58);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(53, 12);
            this.label20.TabIndex = 39;
            this.label20.Text = "[1-5000]";
            // 
            // m_tabControl
            // 
            this.m_tabControl.Controls.Add(this.m_tabLogin);
            this.m_tabControl.Controls.Add(this.m_tabMove);
            this.m_tabControl.Location = new System.Drawing.Point(12, 12);
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.SelectedIndex = 0;
            this.m_tabControl.Size = new System.Drawing.Size(594, 329);
            this.m_tabControl.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 342);
            this.Controls.Add(this.m_tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "创建机器人";
            this.m_tabMove.ResumeLayout(false);
            this.m_tabMove.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.m_tabLogin.ResumeLayout(false);
            this.m_tabLogin.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.m_tabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage m_tabMove;
        private System.Windows.Forms.TextBox m_tabMove_StartAccount;
        private System.Windows.Forms.TextBox m_tabMove_MoveTime;
        private System.Windows.Forms.TextBox m_tabMove_ClientCount;
        private System.Windows.Forms.TextBox m_tabMove_Port;
        private System.Windows.Forms.TextBox m_tabMove_IP;
        private System.Windows.Forms.Button m_tabMove_Start;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox m_tabMove_CurClientCount;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TabPage m_tabLogin;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox m_tabLogin_CurClientCount;
        private System.Windows.Forms.Button m_tabLogin_Start;
        private System.Windows.Forms.TextBox m_tabLogin_DisconTime;
        private System.Windows.Forms.TextBox m_tabLogin_ClientCount;
        private System.Windows.Forms.TextBox m_tabLogin_Port;
        private System.Windows.Forms.TextBox m_tabLogin_IP;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TabControl m_tabControl;

    }
}

