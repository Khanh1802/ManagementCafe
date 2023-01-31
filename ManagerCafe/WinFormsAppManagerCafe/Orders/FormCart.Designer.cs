namespace WinFormsAppManagerCafe.Orders
{
    partial class FormCart
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
            this.CbbOrderDetail = new System.Windows.Forms.ComboBox();
            this.NUDQuatity = new System.Windows.Forms.NumericUpDown();
            this.TbPrice = new System.Windows.Forms.TextBox();
            this.TbTotalPrice = new System.Windows.Forms.TextBox();
            this.BtDelete = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TbTotalPay = new System.Windows.Forms.TextBox();
            this.BtPay = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TbTotalProduct = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.NUDQuatity)).BeginInit();
            this.SuspendLayout();
            // 
            // CbbOrderDetail
            // 
            this.CbbOrderDetail.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbbOrderDetail.FormattingEnabled = true;
            this.CbbOrderDetail.Location = new System.Drawing.Point(12, 110);
            this.CbbOrderDetail.Name = "CbbOrderDetail";
            this.CbbOrderDetail.Size = new System.Drawing.Size(360, 28);
            this.CbbOrderDetail.TabIndex = 0;
            this.CbbOrderDetail.SelectedValueChanged += new System.EventHandler(this.CbbProduct_SelectedValueChanged);
            // 
            // NUDQuatity
            // 
            this.NUDQuatity.Location = new System.Drawing.Point(590, 111);
            this.NUDQuatity.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.NUDQuatity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUDQuatity.Name = "NUDQuatity";
            this.NUDQuatity.Size = new System.Drawing.Size(77, 27);
            this.NUDQuatity.TabIndex = 81;
            this.NUDQuatity.ThousandsSeparator = true;
            this.NUDQuatity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUDQuatity.ValueChanged += new System.EventHandler(this.NUDQuatity_ValueChanged);
            // 
            // TbPrice
            // 
            this.TbPrice.Location = new System.Drawing.Point(395, 111);
            this.TbPrice.Name = "TbPrice";
            this.TbPrice.ReadOnly = true;
            this.TbPrice.Size = new System.Drawing.Size(172, 27);
            this.TbPrice.TabIndex = 82;
            // 
            // TbTotalPrice
            // 
            this.TbTotalPrice.Location = new System.Drawing.Point(680, 111);
            this.TbTotalPrice.Name = "TbTotalPrice";
            this.TbTotalPrice.ReadOnly = true;
            this.TbTotalPrice.Size = new System.Drawing.Size(172, 27);
            this.TbTotalPrice.TabIndex = 83;
            // 
            // BtDelete
            // 
            this.BtDelete.Location = new System.Drawing.Point(875, 109);
            this.BtDelete.Name = "BtDelete";
            this.BtDelete.Size = new System.Drawing.Size(94, 29);
            this.BtDelete.TabIndex = 84;
            this.BtDelete.Text = "Delete";
            this.BtDelete.UseVisualStyleBackColor = true;
            this.BtDelete.Click += new System.EventHandler(this.BtDelete_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 28);
            this.label2.TabIndex = 85;
            this.label2.Text = "Product Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(395, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 28);
            this.label1.TabIndex = 86;
            this.label1.Text = "Price";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(590, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 28);
            this.label3.TabIndex = 87;
            this.label3.Text = "Quatity";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(680, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 28);
            this.label4.TabIndex = 88;
            this.label4.Text = "Total Price";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(875, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 28);
            this.label5.TabIndex = 89;
            this.label5.Text = "Delete";
            // 
            // TbTotalPay
            // 
            this.TbTotalPay.Location = new System.Drawing.Point(680, 237);
            this.TbTotalPay.Name = "TbTotalPay";
            this.TbTotalPay.ReadOnly = true;
            this.TbTotalPay.Size = new System.Drawing.Size(172, 27);
            this.TbTotalPay.TabIndex = 90;
            // 
            // BtPay
            // 
            this.BtPay.Location = new System.Drawing.Point(875, 235);
            this.BtPay.Name = "BtPay";
            this.BtPay.Size = new System.Drawing.Size(94, 29);
            this.BtPay.TabIndex = 91;
            this.BtPay.Text = "Pay";
            this.BtPay.UseVisualStyleBackColor = true;
            this.BtPay.Click += new System.EventHandler(this.BtPay_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(680, 189);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 28);
            this.label6.TabIndex = 92;
            this.label6.Text = "Total Pay";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(395, 189);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(136, 28);
            this.label7.TabIndex = 94;
            this.label7.Text = "Total Products";
            // 
            // TbTotalProduct
            // 
            this.TbTotalProduct.Location = new System.Drawing.Point(395, 237);
            this.TbTotalProduct.Name = "TbTotalProduct";
            this.TbTotalProduct.ReadOnly = true;
            this.TbTotalProduct.Size = new System.Drawing.Size(172, 27);
            this.TbTotalProduct.TabIndex = 93;
            // 
            // FormCart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 288);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TbTotalProduct);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BtPay);
            this.Controls.Add(this.TbTotalPay);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtDelete);
            this.Controls.Add(this.TbTotalPrice);
            this.Controls.Add(this.TbPrice);
            this.Controls.Add(this.NUDQuatity);
            this.Controls.Add(this.CbbOrderDetail);
            this.Name = "FormCart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormCart";
            this.Load += new System.EventHandler(this.FormCart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NUDQuatity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox CbbOrderDetail;
        private NumericUpDown NUDQuatity;
        private TextBox TbPrice;
        private TextBox TbTotalPrice;
        private Button BtDelete;
        private Label label2;
        private Label label1;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox TbTotalPay;
        private Button BtPay;
        private Label label6;
        private Label label7;
        private TextBox TbTotalProduct;
    }
}