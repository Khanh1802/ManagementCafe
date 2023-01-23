namespace WinFormsAppManagerCafe
{
    partial class FormAccount
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
            this.BtChangePassword = new System.Windows.Forms.Button();
            this.BtChangeInfo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BtReturn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtChangePassword
            // 
            this.BtChangePassword.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.BtChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtChangePassword.Location = new System.Drawing.Point(433, 120);
            this.BtChangePassword.Name = "BtChangePassword";
            this.BtChangePassword.Size = new System.Drawing.Size(250, 71);
            this.BtChangePassword.TabIndex = 6;
            this.BtChangePassword.Text = "Change password";
            this.BtChangePassword.UseVisualStyleBackColor = true;
            this.BtChangePassword.Click += new System.EventHandler(this.BtChangePassword_Click);
            // 
            // BtChangeInfo
            // 
            this.BtChangeInfo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.BtChangeInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtChangeInfo.Location = new System.Drawing.Point(109, 120);
            this.BtChangeInfo.Name = "BtChangeInfo";
            this.BtChangeInfo.Size = new System.Drawing.Size(250, 71);
            this.BtChangeInfo.TabIndex = 5;
            this.BtChangeInfo.Text = "Change infomation";
            this.BtChangeInfo.UseVisualStyleBackColor = true;
            this.BtChangeInfo.Click += new System.EventHandler(this.BtChangeInfo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(298, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 38);
            this.label1.TabIndex = 90;
            this.label1.Text = "PAGE ACCOUNT";
            // 
            // BtReturn
            // 
            this.BtReturn.Location = new System.Drawing.Point(669, 406);
            this.BtReturn.Name = "BtReturn";
            this.BtReturn.Size = new System.Drawing.Size(117, 32);
            this.BtReturn.TabIndex = 94;
            this.BtReturn.Text = "Return";
            this.BtReturn.UseVisualStyleBackColor = true;
            this.BtReturn.Click += new System.EventHandler(this.BtReturn_Click);
            // 
            // FormAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtReturn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtChangePassword);
            this.Controls.Add(this.BtChangeInfo);
            this.Name = "FormAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormChangInfomation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button BtChangePassword;
        private Button BtChangeInfo;
        private Label label1;
        private Button BtReturn;
    }
}