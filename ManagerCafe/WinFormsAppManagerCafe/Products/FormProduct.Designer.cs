namespace WinFormsAppManagerCafe
{
    partial class FormProduct
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
            this.Dtg = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.BtRemove = new System.Windows.Forms.Button();
            this.BtUpdate = new System.Windows.Forms.Button();
            this.BtAdd = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.BtFind = new System.Windows.Forms.Button();
            this.TbFind = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.NUDPriceSell = new System.Windows.Forms.NumericUpDown();
            this.NUDPriceBuy = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TbName = new System.Windows.Forms.TextBox();
            this.CbbFilter = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDPriceSell)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDPriceBuy)).BeginInit();
            this.SuspendLayout();
            // 
            // Dtg
            // 
            this.Dtg.BackgroundColor = System.Drawing.Color.White;
            this.Dtg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dtg.Location = new System.Drawing.Point(143, 193);
            this.Dtg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Dtg.Name = "Dtg";
            this.Dtg.ReadOnly = true;
            this.Dtg.RowHeadersWidth = 51;
            this.Dtg.RowTemplate.Height = 29;
            this.Dtg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dtg.Size = new System.Drawing.Size(661, 213);
            this.Dtg.TabIndex = 63;
            this.Dtg.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dtg_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(379, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 30);
            this.label1.TabIndex = 58;
            this.label1.Text = "PAGE PRODUCT";
            // 
            // BtRemove
            // 
            this.BtRemove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BtRemove.Enabled = false;
            this.BtRemove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.BtRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtRemove.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtRemove.Location = new System.Drawing.Point(696, 412);
            this.BtRemove.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtRemove.Name = "BtRemove";
            this.BtRemove.Size = new System.Drawing.Size(108, 40);
            this.BtRemove.TabIndex = 62;
            this.BtRemove.Text = "Delete";
            this.BtRemove.UseVisualStyleBackColor = false;
            this.BtRemove.Click += new System.EventHandler(this.BtRemove_Click);
            // 
            // BtUpdate
            // 
            this.BtUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.BtUpdate.Enabled = false;
            this.BtUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.BtUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtUpdate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtUpdate.Location = new System.Drawing.Point(436, 410);
            this.BtUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtUpdate.Name = "BtUpdate";
            this.BtUpdate.Size = new System.Drawing.Size(108, 40);
            this.BtUpdate.TabIndex = 61;
            this.BtUpdate.Text = "Update";
            this.BtUpdate.UseVisualStyleBackColor = false;
            this.BtUpdate.Click += new System.EventHandler(this.BtUpdate_Click);
            // 
            // BtAdd
            // 
            this.BtAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.BtAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.BtAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtAdd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtAdd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtAdd.Location = new System.Drawing.Point(143, 410);
            this.BtAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtAdd.Name = "BtAdd";
            this.BtAdd.Size = new System.Drawing.Size(108, 40);
            this.BtAdd.TabIndex = 60;
            this.BtAdd.Text = "Add";
            this.BtAdd.UseVisualStyleBackColor = false;
            this.BtAdd.Click += new System.EventHandler(this.BtAdd_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(139, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 21);
            this.label3.TabIndex = 66;
            this.label3.Text = "Search";
            // 
            // BtFind
            // 
            this.BtFind.Location = new System.Drawing.Point(743, 48);
            this.BtFind.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtFind.Name = "BtFind";
            this.BtFind.Size = new System.Drawing.Size(82, 20);
            this.BtFind.TabIndex = 65;
            this.BtFind.Text = "Find";
            this.BtFind.UseVisualStyleBackColor = true;
            this.BtFind.Click += new System.EventHandler(this.BtFind_Click);
            // 
            // TbFind
            // 
            this.TbFind.Location = new System.Drawing.Point(234, 49);
            this.TbFind.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TbFind.Name = "TbFind";
            this.TbFind.Size = new System.Drawing.Size(477, 23);
            this.TbFind.TabIndex = 64;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.NUDPriceSell);
            this.panel1.Controls.Add(this.NUDPriceBuy);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.TbName);
            this.panel1.Location = new System.Drawing.Point(234, 75);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(477, 112);
            this.panel1.TabIndex = 67;
            // 
            // NUDPriceSell
            // 
            this.NUDPriceSell.Enabled = false;
            this.NUDPriceSell.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.NUDPriceSell.Location = new System.Drawing.Point(164, 80);
            this.NUDPriceSell.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NUDPriceSell.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.NUDPriceSell.Name = "NUDPriceSell";
            this.NUDPriceSell.Size = new System.Drawing.Size(254, 23);
            this.NUDPriceSell.TabIndex = 63;
            this.NUDPriceSell.ThousandsSeparator = true;
            // 
            // NUDPriceBuy
            // 
            this.NUDPriceBuy.Enabled = false;
            this.NUDPriceBuy.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.NUDPriceBuy.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.NUDPriceBuy.Location = new System.Drawing.Point(164, 46);
            this.NUDPriceBuy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NUDPriceBuy.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.NUDPriceBuy.Name = "NUDPriceBuy";
            this.NUDPriceBuy.Size = new System.Drawing.Size(254, 23);
            this.NUDPriceBuy.TabIndex = 62;
            this.NUDPriceBuy.ThousandsSeparator = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(14, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 21);
            this.label2.TabIndex = 17;
            this.label2.Text = "Price sell";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(14, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 21);
            this.label4.TabIndex = 15;
            this.label4.Text = "Price buy";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(14, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 21);
            this.label5.TabIndex = 13;
            this.label5.Text = "Name";
            // 
            // TbName
            // 
            this.TbName.Enabled = false;
            this.TbName.Location = new System.Drawing.Point(164, 12);
            this.TbName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TbName.Name = "TbName";
            this.TbName.Size = new System.Drawing.Size(254, 23);
            this.TbName.TabIndex = 10;
            // 
            // CbbFilter
            // 
            this.CbbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbbFilter.FormattingEnabled = true;
            this.CbbFilter.Location = new System.Drawing.Point(822, 193);
            this.CbbFilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CbbFilter.Name = "CbbFilter";
            this.CbbFilter.Size = new System.Drawing.Size(133, 23);
            this.CbbFilter.TabIndex = 68;
            this.CbbFilter.SelectedIndexChanged += new System.EventHandler(this.CbbFilter_SelectedIndexChanged);
            // 
            // FormProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 456);
            this.Controls.Add(this.CbbFilter);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Dtg);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtRemove);
            this.Controls.Add(this.BtUpdate);
            this.Controls.Add(this.BtAdd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtFind);
            this.Controls.Add(this.TbFind);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormProduct";
            this.Load += new System.EventHandler(this.FormProduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dtg)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDPriceSell)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDPriceBuy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView Dtg;
        private Label label1;
        private Button BtRemove;
        private Button BtUpdate;
        private Button BtAdd;
        private Label label3;
        private Button BtFind;
        private TextBox TbFind;
        private Panel panel1;
        private NumericUpDown NUDPriceSell;
        private NumericUpDown NUDPriceBuy;
        private Label label2;
        private Label label4;
        private Label label5;
        private TextBox TbName;
        private ComboBox CbbFilter;
    }
}