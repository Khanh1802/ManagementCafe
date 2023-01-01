namespace WinFormsAppManagerCafe.Products
{
    partial class FormAddProduct
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.NUDPriceSell = new System.Windows.Forms.NumericUpDown();
            this.NUDPriceBuy = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TbName = new System.Windows.Forms.TextBox();
            this.BtAdd = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDPriceSell)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDPriceBuy)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.NUDPriceSell);
            this.panel1.Controls.Add(this.NUDPriceBuy);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.TbName);
            this.panel1.Location = new System.Drawing.Point(45, 84);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(545, 149);
            this.panel1.TabIndex = 60;
            // 
            // NUDPriceSell
            // 
            this.NUDPriceSell.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NUDPriceSell.Location = new System.Drawing.Point(188, 106);
            this.NUDPriceSell.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.NUDPriceSell.Name = "NUDPriceSell";
            this.NUDPriceSell.Size = new System.Drawing.Size(290, 27);
            this.NUDPriceSell.TabIndex = 63;
            this.NUDPriceSell.ThousandsSeparator = true;
            // 
            // NUDPriceBuy
            // 
            this.NUDPriceBuy.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NUDPriceBuy.Location = new System.Drawing.Point(188, 61);
            this.NUDPriceBuy.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.NUDPriceBuy.Name = "NUDPriceBuy";
            this.NUDPriceBuy.Size = new System.Drawing.Size(290, 27);
            this.NUDPriceBuy.TabIndex = 62;
            this.NUDPriceBuy.ThousandsSeparator = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(16, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 28);
            this.label2.TabIndex = 17;
            this.label2.Text = "Price sell";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(16, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 28);
            this.label1.TabIndex = 15;
            this.label1.Text = "Price buy";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(16, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 28);
            this.label4.TabIndex = 13;
            this.label4.Text = "Name";
            // 
            // TbName
            // 
            this.TbName.Location = new System.Drawing.Point(188, 16);
            this.TbName.Name = "TbName";
            this.TbName.Size = new System.Drawing.Size(290, 27);
            this.TbName.TabIndex = 10;
            // 
            // BtAdd
            // 
            this.BtAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.BtAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.BtAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtAdd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtAdd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtAdd.Location = new System.Drawing.Point(45, 380);
            this.BtAdd.Name = "BtAdd";
            this.BtAdd.Size = new System.Drawing.Size(123, 40);
            this.BtAdd.TabIndex = 61;
            this.BtAdd.Text = "Add";
            this.BtAdd.UseVisualStyleBackColor = false;
            this.BtAdd.Click += new System.EventHandler(this.BtAdd_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(280, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(243, 38);
            this.label3.TabIndex = 62;
            this.label3.Text = "CREATE PRODUCT";
            // 
            // FormAddProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtAdd);
            this.Controls.Add(this.panel1);
            this.Name = "FormAddProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormAddProduct";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDPriceSell)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDPriceBuy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panel1;
        private Label label4;
        private TextBox TbName;
        private Label label2;
        private Label label1;
        private Button BtAdd;
        private NumericUpDown NUDPriceSell;
        private NumericUpDown NUDPriceBuy;
        private Label label3;
    }
}