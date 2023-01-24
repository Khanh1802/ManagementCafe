namespace WinFormsAppManagerCafe
{
    partial class HomePage
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtPageProduct = new System.Windows.Forms.Button();
            this.BtPageWareHouse = new System.Windows.Forms.Button();
            this.BtPageInventory = new System.Windows.Forms.Button();
            this.BtStatistic = new System.Windows.Forms.Button();
            this.BtHistory = new System.Windows.Forms.Button();
            this.BtPageUserType = new System.Windows.Forms.Button();
            this.BtPageChangeInfo = new System.Windows.Forms.Button();
            this.BtLogOut = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TbNameUser = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BtPageProduct
            // 
            this.BtPageProduct.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.BtPageProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtPageProduct.Location = new System.Drawing.Point(88, 92);
            this.BtPageProduct.Name = "BtPageProduct";
            this.BtPageProduct.Size = new System.Drawing.Size(250, 71);
            this.BtPageProduct.TabIndex = 0;
            this.BtPageProduct.Text = "Product";
            this.BtPageProduct.UseVisualStyleBackColor = true;
            this.BtPageProduct.Click += new System.EventHandler(this.button1_Click);
            // 
            // BtPageWareHouse
            // 
            this.BtPageWareHouse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.BtPageWareHouse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtPageWareHouse.Location = new System.Drawing.Point(413, 92);
            this.BtPageWareHouse.Name = "BtPageWareHouse";
            this.BtPageWareHouse.Size = new System.Drawing.Size(250, 71);
            this.BtPageWareHouse.TabIndex = 1;
            this.BtPageWareHouse.Text = "Warehouse";
            this.BtPageWareHouse.UseVisualStyleBackColor = true;
            this.BtPageWareHouse.Click += new System.EventHandler(this.BtPageWareHouse_Click);
            // 
            // BtPageInventory
            // 
            this.BtPageInventory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.BtPageInventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtPageInventory.Location = new System.Drawing.Point(738, 92);
            this.BtPageInventory.Name = "BtPageInventory";
            this.BtPageInventory.Size = new System.Drawing.Size(250, 71);
            this.BtPageInventory.TabIndex = 2;
            this.BtPageInventory.Text = "Inventory";
            this.BtPageInventory.UseVisualStyleBackColor = true;
            this.BtPageInventory.Click += new System.EventHandler(this.BtPageInventory_Click);
            // 
            // BtStatistic
            // 
            this.BtStatistic.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.BtStatistic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtStatistic.Location = new System.Drawing.Point(88, 255);
            this.BtStatistic.Name = "BtStatistic";
            this.BtStatistic.Size = new System.Drawing.Size(250, 71);
            this.BtStatistic.TabIndex = 3;
            this.BtStatistic.Text = "Statistic";
            this.BtStatistic.UseVisualStyleBackColor = true;
            this.BtStatistic.Click += new System.EventHandler(this.BtHistory_Click);
            // 
            // BtHistory
            // 
            this.BtHistory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.BtHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtHistory.Location = new System.Drawing.Point(412, 255);
            this.BtHistory.Name = "BtHistory";
            this.BtHistory.Size = new System.Drawing.Size(250, 71);
            this.BtHistory.TabIndex = 4;
            this.BtHistory.Text = "History";
            this.BtHistory.UseVisualStyleBackColor = true;
            this.BtHistory.Click += new System.EventHandler(this.BtHistory_Click_1);
            // 
            // BtPageUserType
            // 
            this.BtPageUserType.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.BtPageUserType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtPageUserType.Location = new System.Drawing.Point(738, 255);
            this.BtPageUserType.Name = "BtPageUserType";
            this.BtPageUserType.Size = new System.Drawing.Size(250, 71);
            this.BtPageUserType.TabIndex = 5;
            this.BtPageUserType.Text = "UserType";
            this.BtPageUserType.UseVisualStyleBackColor = true;
            this.BtPageUserType.Click += new System.EventHandler(this.BtPageUserType_Click);
            // 
            // BtPageChangeInfo
            // 
            this.BtPageChangeInfo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.BtPageChangeInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtPageChangeInfo.Location = new System.Drawing.Point(88, 418);
            this.BtPageChangeInfo.Name = "BtPageChangeInfo";
            this.BtPageChangeInfo.Size = new System.Drawing.Size(250, 71);
            this.BtPageChangeInfo.TabIndex = 6;
            this.BtPageChangeInfo.Text = "Change infomation";
            this.BtPageChangeInfo.UseVisualStyleBackColor = true;
            this.BtPageChangeInfo.Click += new System.EventHandler(this.BtPageChangeInfo_Click);
            // 
            // BtLogOut
            // 
            this.BtLogOut.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.BtLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtLogOut.Location = new System.Drawing.Point(841, 525);
            this.BtLogOut.Name = "BtLogOut";
            this.BtLogOut.Size = new System.Drawing.Size(250, 71);
            this.BtLogOut.TabIndex = 7;
            this.BtLogOut.Text = "Log out";
            this.BtLogOut.UseVisualStyleBackColor = true;
            this.BtLogOut.Click += new System.EventHandler(this.BtLogOut_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(454, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 38);
            this.label1.TabIndex = 91;
            this.label1.Text = "PAGE HOME";
            // 
            // TbNameUser
            // 
            this.TbNameUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.TbNameUser.Enabled = false;
            this.TbNameUser.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbNameUser.Location = new System.Drawing.Point(895, 12);
            this.TbNameUser.Name = "TbNameUser";
            this.TbNameUser.Size = new System.Drawing.Size(196, 31);
            this.TbNameUser.TabIndex = 92;
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 608);
            this.Controls.Add(this.TbNameUser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtLogOut);
            this.Controls.Add(this.BtPageChangeInfo);
            this.Controls.Add(this.BtPageUserType);
            this.Controls.Add(this.BtHistory);
            this.Controls.Add(this.BtStatistic);
            this.Controls.Add(this.BtPageInventory);
            this.Controls.Add(this.BtPageWareHouse);
            this.Controls.Add(this.BtPageProduct);
            this.Name = "HomePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.HomePage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button BtPageProduct;
        private Button BtPageWareHouse;
        private Button BtPageInventory;
        private Button BtStatistic;
        private Button BtHistory;
        private Button BtPageUserType;
        private Button BtPageChangeInfo;
        private Button BtLogOut;
        private Label label1;
        private TextBox TbNameUser;
    }
}