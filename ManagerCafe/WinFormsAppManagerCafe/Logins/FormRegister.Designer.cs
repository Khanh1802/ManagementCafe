namespace WinFormsAppManagerCafe.Logins
{
    partial class FormRegister
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.TbFullName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CbPassword = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CbbUserType = new System.Windows.Forms.ComboBox();
            this.TbPasswork = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.BtCheckUserName = new System.Windows.Forms.Button();
            this.TbUserName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TbPhoneNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TbEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtRegister = new System.Windows.Forms.Button();
            this.BtReturn = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(301, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 38);
            this.label1.TabIndex = 81;
            this.label1.Text = "PAGE LOGIN";
            // 
            // TbFullName
            // 
            this.TbFullName.Location = new System.Drawing.Point(161, 19);
            this.TbFullName.Name = "TbFullName";
            this.TbFullName.Size = new System.Drawing.Size(290, 27);
            this.TbFullName.TabIndex = 65;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.panel1.Controls.Add(this.CbPassword);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.CbbUserType);
            this.panel1.Controls.Add(this.TbPasswork);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.BtCheckUserName);
            this.panel1.Controls.Add(this.TbUserName);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.TbPhoneNumber);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.TbEmail);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.TbFullName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(73, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(581, 324);
            this.panel1.TabIndex = 82;
            // 
            // CbPassword
            // 
            this.CbPassword.AutoSize = true;
            this.CbPassword.Location = new System.Drawing.Point(477, 238);
            this.CbPassword.Name = "CbPassword";
            this.CbPassword.Size = new System.Drawing.Size(63, 24);
            this.CbPassword.TabIndex = 85;
            this.CbPassword.Text = "View";
            this.CbPassword.UseVisualStyleBackColor = true;
            this.CbPassword.CheckedChanged += new System.EventHandler(this.CbPassword_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(17, 286);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 28);
            this.label7.TabIndex = 86;
            this.label7.Text = "User type";
            // 
            // CbbUserType
            // 
            this.CbbUserType.FormattingEnabled = true;
            this.CbbUserType.Location = new System.Drawing.Point(161, 286);
            this.CbbUserType.Name = "CbbUserType";
            this.CbbUserType.Size = new System.Drawing.Size(290, 28);
            this.CbbUserType.TabIndex = 85;
            // 
            // TbPasswork
            // 
            this.TbPasswork.Location = new System.Drawing.Point(161, 235);
            this.TbPasswork.Name = "TbPasswork";
            this.TbPasswork.Size = new System.Drawing.Size(290, 27);
            this.TbPasswork.TabIndex = 73;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(17, 234);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 28);
            this.label6.TabIndex = 72;
            this.label6.Text = "Password";
            // 
            // BtCheckUserName
            // 
            this.BtCheckUserName.Location = new System.Drawing.Point(470, 181);
            this.BtCheckUserName.Name = "BtCheckUserName";
            this.BtCheckUserName.Size = new System.Drawing.Size(94, 27);
            this.BtCheckUserName.TabIndex = 84;
            this.BtCheckUserName.Text = "check";
            this.BtCheckUserName.UseVisualStyleBackColor = true;
            this.BtCheckUserName.Click += new System.EventHandler(this.BtCheckUserName_Click);
            // 
            // TbUserName
            // 
            this.TbUserName.Location = new System.Drawing.Point(161, 181);
            this.TbUserName.Name = "TbUserName";
            this.TbUserName.Size = new System.Drawing.Size(290, 27);
            this.TbUserName.TabIndex = 71;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(17, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 28);
            this.label5.TabIndex = 70;
            this.label5.Text = "User name";
            // 
            // TbPhoneNumber
            // 
            this.TbPhoneNumber.Location = new System.Drawing.Point(161, 127);
            this.TbPhoneNumber.Name = "TbPhoneNumber";
            this.TbPhoneNumber.Size = new System.Drawing.Size(290, 27);
            this.TbPhoneNumber.TabIndex = 69;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(17, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 28);
            this.label4.TabIndex = 68;
            this.label4.Text = "Phone";
            // 
            // TbEmail
            // 
            this.TbEmail.Location = new System.Drawing.Point(161, 73);
            this.TbEmail.Name = "TbEmail";
            this.TbEmail.Size = new System.Drawing.Size(290, 27);
            this.TbEmail.TabIndex = 67;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(17, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 28);
            this.label3.TabIndex = 66;
            this.label3.Text = "Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(17, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 28);
            this.label2.TabIndex = 17;
            this.label2.Text = "Full name";
            // 
            // BtRegister
            // 
            this.BtRegister.Location = new System.Drawing.Point(487, 406);
            this.BtRegister.Name = "BtRegister";
            this.BtRegister.Size = new System.Drawing.Size(117, 32);
            this.BtRegister.TabIndex = 83;
            this.BtRegister.Text = "Register";
            this.BtRegister.UseVisualStyleBackColor = true;
            this.BtRegister.Click += new System.EventHandler(this.BtRegister_Click);
            // 
            // BtReturn
            // 
            this.BtReturn.Location = new System.Drawing.Point(671, 406);
            this.BtReturn.Name = "BtReturn";
            this.BtReturn.Size = new System.Drawing.Size(117, 32);
            this.BtReturn.TabIndex = 84;
            this.BtReturn.Text = "Return";
            this.BtReturn.UseVisualStyleBackColor = true;
            this.BtReturn.Click += new System.EventHandler(this.BtReturn_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // FormRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtReturn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BtRegister);
            this.Name = "FormRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormRegister";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormRegister_FormClosing);
            this.Load += new System.EventHandler(this.FormRegister_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox TbFullName;
        private Panel panel1;
        private TextBox TbUserName;
        private Label label5;
        private TextBox TbPhoneNumber;
        private Label label4;
        private TextBox TbEmail;
        private Label label3;
        private Label label2;
        private Button BtRegister;
        private Button BtReturn;
        private Label label7;
        private ComboBox CbbUserType;
        private ContextMenuStrip contextMenuStrip1;
        private CheckBox CbPassword;
        private TextBox TbPasswork;
        private Label label6;
        private Button BtCheckUserName;
    }
}