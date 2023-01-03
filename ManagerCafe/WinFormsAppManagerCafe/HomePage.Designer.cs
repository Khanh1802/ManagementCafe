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
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtPageProduct
            // 
            this.BtPageProduct.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.BtPageProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtPageProduct.Location = new System.Drawing.Point(419, 26);
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
            this.BtPageWareHouse.Location = new System.Drawing.Point(419, 156);
            this.BtPageWareHouse.Name = "BtPageWareHouse";
            this.BtPageWareHouse.Size = new System.Drawing.Size(250, 71);
            this.BtPageWareHouse.TabIndex = 1;
            this.BtPageWareHouse.Text = "Warehouse";
            this.BtPageWareHouse.UseVisualStyleBackColor = true;
            this.BtPageWareHouse.Click += new System.EventHandler(this.BtPageWareHouse_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(419, 286);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(250, 71);
            this.button1.TabIndex = 2;
            this.button1.Text = "Inventory";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 608);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BtPageWareHouse);
            this.Controls.Add(this.BtPageProduct);
            this.Name = "HomePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Button BtPageProduct;
        private Button BtPageWareHouse;
        private Button button1;
    }
}