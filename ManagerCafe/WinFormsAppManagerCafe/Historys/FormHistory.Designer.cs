namespace WinFormsAppManagerCafe.History
{
    partial class FormHistory
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
            this.CbbFilter = new System.Windows.Forms.ComboBox();
            this.TbCurrentPage = new System.Windows.Forms.TextBox();
            this.BtNextPage = new System.Windows.Forms.Button();
            this.BtReversePage = new System.Windows.Forms.Button();
            this.CbAllResult = new System.Windows.Forms.CheckBox();
            this.CbbWareHouse = new System.Windows.Forms.ComboBox();
            this.CbbProduct = new System.Windows.Forms.ComboBox();
            this.Dtg = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.CbbPage = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BtFind = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.DTPToDate = new System.Windows.Forms.DateTimePicker();
            this.DTPFormDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CbbType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg)).BeginInit();
            this.SuspendLayout();
            // 
            // CbbFilter
            // 
            this.CbbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbbFilter.FormattingEnabled = true;
            this.CbbFilter.Location = new System.Drawing.Point(930, 354);
            this.CbbFilter.Name = "CbbFilter";
            this.CbbFilter.Size = new System.Drawing.Size(198, 28);
            this.CbbFilter.TabIndex = 100;
            // 
            // TbCurrentPage
            // 
            this.TbCurrentPage.Enabled = false;
            this.TbCurrentPage.Location = new System.Drawing.Point(386, 704);
            this.TbCurrentPage.Name = "TbCurrentPage";
            this.TbCurrentPage.Size = new System.Drawing.Size(125, 27);
            this.TbCurrentPage.TabIndex = 99;
            // 
            // BtNextPage
            // 
            this.BtNextPage.Enabled = false;
            this.BtNextPage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.BtNextPage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.BtNextPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtNextPage.Location = new System.Drawing.Point(683, 696);
            this.BtNextPage.Name = "BtNextPage";
            this.BtNextPage.Size = new System.Drawing.Size(123, 35);
            this.BtNextPage.TabIndex = 98;
            this.BtNextPage.Text = "Next page";
            this.BtNextPage.UseVisualStyleBackColor = true;
            // 
            // BtReversePage
            // 
            this.BtReversePage.Enabled = false;
            this.BtReversePage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.BtReversePage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtReversePage.Location = new System.Drawing.Point(51, 696);
            this.BtReversePage.Name = "BtReversePage";
            this.BtReversePage.Size = new System.Drawing.Size(123, 35);
            this.BtReversePage.TabIndex = 97;
            this.BtReversePage.Text = "Reverse page";
            this.BtReversePage.UseVisualStyleBackColor = true;
            // 
            // CbAllResult
            // 
            this.CbAllResult.AutoSize = true;
            this.CbAllResult.Location = new System.Drawing.Point(884, 123);
            this.CbAllResult.Name = "CbAllResult";
            this.CbAllResult.Size = new System.Drawing.Size(49, 24);
            this.CbAllResult.TabIndex = 96;
            this.CbAllResult.Text = "All";
            this.CbAllResult.UseVisualStyleBackColor = true;
            // 
            // CbbWareHouse
            // 
            this.CbbWareHouse.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CbbWareHouse.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CbbWareHouse.FormattingEnabled = true;
            this.CbbWareHouse.Location = new System.Drawing.Point(458, 121);
            this.CbbWareHouse.Name = "CbbWareHouse";
            this.CbbWareHouse.Size = new System.Drawing.Size(151, 28);
            this.CbbWareHouse.TabIndex = 95;
            // 
            // CbbProduct
            // 
            this.CbbProduct.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CbbProduct.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CbbProduct.FormattingEnabled = true;
            this.CbbProduct.Location = new System.Drawing.Point(229, 121);
            this.CbbProduct.Name = "CbbProduct";
            this.CbbProduct.Size = new System.Drawing.Size(151, 28);
            this.CbbProduct.TabIndex = 94;
            // 
            // Dtg
            // 
            this.Dtg.BackgroundColor = System.Drawing.Color.White;
            this.Dtg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dtg.Location = new System.Drawing.Point(12, 210);
            this.Dtg.Name = "Dtg";
            this.Dtg.ReadOnly = true;
            this.Dtg.RowHeadersWidth = 51;
            this.Dtg.RowTemplate.Height = 29;
            this.Dtg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dtg.Size = new System.Drawing.Size(910, 470);
            this.Dtg.TabIndex = 89;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(447, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 38);
            this.label1.TabIndex = 86;
            this.label1.Text = "PAGE HISTORY";
            // 
            // CbbPage
            // 
            this.CbbPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbbPage.FormattingEnabled = true;
            this.CbbPage.Location = new System.Drawing.Point(930, 282);
            this.CbbPage.Name = "CbbPage";
            this.CbbPage.Size = new System.Drawing.Size(151, 28);
            this.CbbPage.TabIndex = 93;
            this.CbbPage.SelectedValueChanged += new System.EventHandler(this.CbbPage_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(19, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 28);
            this.label3.TabIndex = 91;
            this.label3.Text = "Search";
            // 
            // BtFind
            // 
            this.BtFind.Location = new System.Drawing.Point(709, 122);
            this.BtFind.Name = "BtFind";
            this.BtFind.Size = new System.Drawing.Size(94, 27);
            this.BtFind.TabIndex = 90;
            this.BtFind.Text = "Find";
            this.BtFind.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(447, 166);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(125, 27);
            this.textBox2.TabIndex = 104;
            this.textBox2.Text = "To date";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 166);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(125, 27);
            this.textBox1.TabIndex = 103;
            this.textBox1.Text = "Form date";
            // 
            // DTPToDate
            // 
            this.DTPToDate.Location = new System.Drawing.Point(592, 166);
            this.DTPToDate.Name = "DTPToDate";
            this.DTPToDate.Size = new System.Drawing.Size(250, 27);
            this.DTPToDate.TabIndex = 102;
            this.DTPToDate.Value = new System.DateTime(2023, 1, 10, 0, 0, 0, 0);
            // 
            // DTPFormDate
            // 
            this.DTPFormDate.Location = new System.Drawing.Point(159, 166);
            this.DTPFormDate.Name = "DTPFormDate";
            this.DTPFormDate.Size = new System.Drawing.Size(250, 27);
            this.DTPFormDate.TabIndex = 101;
            this.DTPFormDate.Value = new System.DateTime(2023, 1, 10, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(496, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 25);
            this.label4.TabIndex = 106;
            this.label4.Text = "Product";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(258, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 25);
            this.label2.TabIndex = 105;
            this.label2.Text = "Warehouse";
            // 
            // CbbType
            // 
            this.CbbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbbType.FormattingEnabled = true;
            this.CbbType.Location = new System.Drawing.Point(930, 210);
            this.CbbType.Name = "CbbType";
            this.CbbType.Size = new System.Drawing.Size(151, 28);
            this.CbbType.TabIndex = 107;
            // 
            // FormHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 743);
            this.Controls.Add(this.CbbType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.DTPToDate);
            this.Controls.Add(this.DTPFormDate);
            this.Controls.Add(this.CbbFilter);
            this.Controls.Add(this.TbCurrentPage);
            this.Controls.Add(this.BtNextPage);
            this.Controls.Add(this.BtReversePage);
            this.Controls.Add(this.CbAllResult);
            this.Controls.Add(this.CbbWareHouse);
            this.Controls.Add(this.CbbProduct);
            this.Controls.Add(this.Dtg);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CbbPage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtFind);
            this.Name = "FormHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormHistory";
            this.Load += new System.EventHandler(this.FormHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dtg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox CbbFilter;
        private TextBox TbCurrentPage;
        private Button BtNextPage;
        private Button BtReversePage;
        private CheckBox CbAllResult;
        private ComboBox CbbWareHouse;
        private ComboBox CbbProduct;
        private DataGridView Dtg;
        private Label label1;
        private ComboBox CbbPage;
        private Label label3;
        private Button BtFind;
        private TextBox textBox2;
        private TextBox textBox1;
        private DateTimePicker DTPToDate;
        private DateTimePicker DTPFormDate;
        private Label label4;
        private Label label2;
        private ComboBox CbbType;
    }
}