namespace WinFormsAppManagerCafe.Orders
{
    partial class FormOrderDetail
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
            this.TbProductName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.NUDQuatity = new System.Windows.Forms.NumericUpDown();
            this.TbPrice = new System.Windows.Forms.TextBox();
            this.BtAddToCart = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.TbTotalQuatity = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.NUDQuatity)).BeginInit();
            this.SuspendLayout();
            // 
            // TbProductName
            // 
            this.TbProductName.Location = new System.Drawing.Point(12, 12);
            this.TbProductName.Name = "TbProductName";
            this.TbProductName.ReadOnly = true;
            this.TbProductName.Size = new System.Drawing.Size(800, 27);
            this.TbProductName.TabIndex = 76;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(237, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 28);
            this.label2.TabIndex = 83;
            this.label2.Text = "Price";
            // 
            // NUDQuatity
            // 
            this.NUDQuatity.Location = new System.Drawing.Point(12, 123);
            this.NUDQuatity.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.NUDQuatity.Name = "NUDQuatity";
            this.NUDQuatity.Size = new System.Drawing.Size(168, 27);
            this.NUDQuatity.TabIndex = 80;
            this.NUDQuatity.ThousandsSeparator = true;
            this.NUDQuatity.ValueChanged += new System.EventHandler(this.NUDQuatity_ValueChanged);
            // 
            // TbPrice
            // 
            this.TbPrice.Location = new System.Drawing.Point(12, 60);
            this.TbPrice.Name = "TbPrice";
            this.TbPrice.ReadOnly = true;
            this.TbPrice.Size = new System.Drawing.Size(168, 27);
            this.TbPrice.TabIndex = 82;
            // 
            // BtAddToCart
            // 
            this.BtAddToCart.Location = new System.Drawing.Point(662, 260);
            this.BtAddToCart.Name = "BtAddToCart";
            this.BtAddToCart.Size = new System.Drawing.Size(116, 71);
            this.BtAddToCart.TabIndex = 75;
            this.BtAddToCart.Text = "Add Cart";
            this.BtAddToCart.UseVisualStyleBackColor = true;
            this.BtAddToCart.Click += new System.EventHandler(this.BtAddToCart_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(237, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 28);
            this.label5.TabIndex = 79;
            this.label5.Text = "Quatity";
            // 
            // TbTotalQuatity
            // 
            this.TbTotalQuatity.Location = new System.Drawing.Point(345, 123);
            this.TbTotalQuatity.Name = "TbTotalQuatity";
            this.TbTotalQuatity.ReadOnly = true;
            this.TbTotalQuatity.Size = new System.Drawing.Size(219, 27);
            this.TbTotalQuatity.TabIndex = 84;
            // 
            // FormOrderDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 357);
            this.Controls.Add(this.TbTotalQuatity);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TbPrice);
            this.Controls.Add(this.NUDQuatity);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TbProductName);
            this.Controls.Add(this.BtAddToCart);
            this.Name = "FormOrderDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormOrderDetail";
            this.Load += new System.EventHandler(this.FormOrderDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NUDQuatity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox TbProductName;
        private Label label2;
        private NumericUpDown NUDQuatity;
        private TextBox TbPrice;
        private Button BtAddToCart;
        private Label label5;
        private TextBox TbTotalQuatity;
    }
}