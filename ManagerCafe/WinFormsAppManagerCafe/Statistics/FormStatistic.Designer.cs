namespace WinFormsAppManagerCafe.Inventories
{
    partial class FormStatistic
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
            this.label3 = new System.Windows.Forms.Label();
            this.BtFind = new System.Windows.Forms.Button();
            this.CbbType = new System.Windows.Forms.ComboBox();
            this.DTPFormDate = new System.Windows.Forms.DateTimePicker();
            this.DTPToDate = new System.Windows.Forms.DateTimePicker();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.CbbWarehouse = new System.Windows.Forms.ComboBox();
            this.CbAll = new System.Windows.Forms.CheckBox();
            this.TbCurrentPage = new System.Windows.Forms.TextBox();
            this.BtNextPage = new System.Windows.Forms.Button();
            this.BtReversePage = new System.Windows.Forms.Button();
            this.CbbPage = new System.Windows.Forms.ComboBox();
            this.CbbFilter = new System.Windows.Forms.ComboBox();
            this.CbbProduct = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg)).BeginInit();
            this.SuspendLayout();
            // 
            // Dtg
            // 
            this.Dtg.BackgroundColor = System.Drawing.Color.White;
            this.Dtg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dtg.Location = new System.Drawing.Point(12, 207);
            this.Dtg.Name = "Dtg";
            this.Dtg.ReadOnly = true;
            this.Dtg.RowHeadersWidth = 51;
            this.Dtg.RowTemplate.Height = 29;
            this.Dtg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dtg.Size = new System.Drawing.Size(910, 470);
            this.Dtg.TabIndex = 74;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(436, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 38);
            this.label1.TabIndex = 77;
            this.label1.Text = "PAGE STATISTIC";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(34, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 28);
            this.label3.TabIndex = 80;
            this.label3.Text = "Search";
            // 
            // BtFind
            // 
            this.BtFind.Location = new System.Drawing.Point(724, 109);
            this.BtFind.Name = "BtFind";
            this.BtFind.Size = new System.Drawing.Size(94, 27);
            this.BtFind.TabIndex = 79;
            this.BtFind.Text = "Find";
            this.BtFind.UseVisualStyleBackColor = true;
            this.BtFind.Click += new System.EventHandler(this.BtFind_Click);
            // 
            // CbbType
            // 
            this.CbbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbbType.FormattingEnabled = true;
            this.CbbType.Location = new System.Drawing.Point(940, 207);
            this.CbbType.Name = "CbbType";
            this.CbbType.Size = new System.Drawing.Size(151, 28);
            this.CbbType.TabIndex = 81;
            // 
            // DTPFormDate
            // 
            this.DTPFormDate.Location = new System.Drawing.Point(175, 165);
            this.DTPFormDate.Name = "DTPFormDate";
            this.DTPFormDate.Size = new System.Drawing.Size(250, 27);
            this.DTPFormDate.TabIndex = 82;
            this.DTPFormDate.Value = new System.DateTime(2023, 1, 10, 0, 0, 0, 0);
            // 
            // DTPToDate
            // 
            this.DTPToDate.Location = new System.Drawing.Point(608, 165);
            this.DTPToDate.Name = "DTPToDate";
            this.DTPToDate.Size = new System.Drawing.Size(250, 27);
            this.DTPToDate.TabIndex = 83;
            this.DTPToDate.Value = new System.DateTime(2023, 1, 10, 0, 0, 0, 0);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(28, 165);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(125, 27);
            this.textBox1.TabIndex = 84;
            this.textBox1.Text = "Form date";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(463, 165);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(125, 27);
            this.textBox2.TabIndex = 85;
            this.textBox2.Text = "To date";
            // 
            // CbbWarehouse
            // 
            this.CbbWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbbWarehouse.FormattingEnabled = true;
            this.CbbWarehouse.Location = new System.Drawing.Point(169, 108);
            this.CbbWarehouse.Name = "CbbWarehouse";
            this.CbbWarehouse.Size = new System.Drawing.Size(151, 28);
            this.CbbWarehouse.TabIndex = 86;
            // 
            // CbAll
            // 
            this.CbAll.AutoSize = true;
            this.CbAll.Location = new System.Drawing.Point(920, 110);
            this.CbAll.Name = "CbAll";
            this.CbAll.Size = new System.Drawing.Size(49, 24);
            this.CbAll.TabIndex = 88;
            this.CbAll.Text = "All";
            this.CbAll.UseVisualStyleBackColor = true;
            this.CbAll.CheckedChanged += new System.EventHandler(this.CbAll_CheckedChanged);
            // 
            // TbCurrentPage
            // 
            this.TbCurrentPage.Enabled = false;
            this.TbCurrentPage.Location = new System.Drawing.Point(438, 699);
            this.TbCurrentPage.Name = "TbCurrentPage";
            this.TbCurrentPage.Size = new System.Drawing.Size(125, 27);
            this.TbCurrentPage.TabIndex = 91;
            // 
            // BtNextPage
            // 
            this.BtNextPage.Enabled = false;
            this.BtNextPage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.BtNextPage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.BtNextPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtNextPage.Location = new System.Drawing.Point(735, 691);
            this.BtNextPage.Name = "BtNextPage";
            this.BtNextPage.Size = new System.Drawing.Size(123, 35);
            this.BtNextPage.TabIndex = 90;
            this.BtNextPage.Text = "Next page";
            this.BtNextPage.UseVisualStyleBackColor = true;
            this.BtNextPage.Click += new System.EventHandler(this.BtNextPage_Click);
            // 
            // BtReversePage
            // 
            this.BtReversePage.Enabled = false;
            this.BtReversePage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.BtReversePage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtReversePage.Location = new System.Drawing.Point(103, 691);
            this.BtReversePage.Name = "BtReversePage";
            this.BtReversePage.Size = new System.Drawing.Size(123, 35);
            this.BtReversePage.TabIndex = 89;
            this.BtReversePage.Text = "Reverse page";
            this.BtReversePage.UseVisualStyleBackColor = true;
            this.BtReversePage.Click += new System.EventHandler(this.BtReversePage_Click);
            // 
            // CbbPage
            // 
            this.CbbPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbbPage.FormattingEnabled = true;
            this.CbbPage.Location = new System.Drawing.Point(940, 280);
            this.CbbPage.Name = "CbbPage";
            this.CbbPage.Size = new System.Drawing.Size(151, 28);
            this.CbbPage.TabIndex = 92;
            this.CbbPage.SelectedValueChanged += new System.EventHandler(this.CbbPage_SelectedValueChanged);
            // 
            // CbbFilter
            // 
            this.CbbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbbFilter.FormattingEnabled = true;
            this.CbbFilter.Location = new System.Drawing.Point(940, 350);
            this.CbbFilter.Name = "CbbFilter";
            this.CbbFilter.Size = new System.Drawing.Size(182, 28);
            this.CbbFilter.TabIndex = 93;
            this.CbbFilter.SelectedValueChanged += new System.EventHandler(this.CbbFilter_SelectedValueChanged);
            // 
            // CbbProduct
            // 
            this.CbbProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbbProduct.FormattingEnabled = true;
            this.CbbProduct.Location = new System.Drawing.Point(448, 108);
            this.CbbProduct.Name = "CbbProduct";
            this.CbbProduct.Size = new System.Drawing.Size(151, 28);
            this.CbbProduct.TabIndex = 94;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(193, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 25);
            this.label2.TabIndex = 95;
            this.label2.Text = "Warehouse";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(489, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 25);
            this.label4.TabIndex = 96;
            this.label4.Text = "Product";
            // 
            // FormStatistic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 743);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CbbProduct);
            this.Controls.Add(this.CbbFilter);
            this.Controls.Add(this.CbbPage);
            this.Controls.Add(this.TbCurrentPage);
            this.Controls.Add(this.BtNextPage);
            this.Controls.Add(this.BtReversePage);
            this.Controls.Add(this.CbAll);
            this.Controls.Add(this.CbbWarehouse);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.DTPToDate);
            this.Controls.Add(this.DTPFormDate);
            this.Controls.Add(this.CbbType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtFind);
            this.Controls.Add(this.Dtg);
            this.Name = "FormStatistic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InventoryTransaction";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormStatistic_FormClosing);
            this.Load += new System.EventHandler(this.FormInventoryTransaction_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dtg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView Dtg;
        private Label label1;
        private Label label3;
        private Button BtFind;
        private ComboBox CbbType;
        private DateTimePicker DTPFormDate;
        private DateTimePicker DTPToDate;
        private TextBox textBox1;
        private TextBox textBox2;
        private ComboBox CbbWarehouse;
        private CheckBox CbAll;
        private TextBox TbCurrentPage;
        private Button BtNextPage;
        private Button BtReversePage;
        private ComboBox CbbPage;
        private ComboBox CbbFilter;
        private ComboBox CbbProduct;
        private Label label2;
        private Label label4;
    }
}