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
            this.BtReversePage = new System.Windows.Forms.Button();
            this.BtNextPage = new System.Windows.Forms.Button();
            this.TbCurrentPage = new System.Windows.Forms.TextBox();
            this.CbbIndexPage = new System.Windows.Forms.ComboBox();
            this.CbAllResult = new System.Windows.Forms.CheckBox();
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
            this.Dtg.Location = new System.Drawing.Point(163, 257);
            this.Dtg.Name = "Dtg";
            this.Dtg.ReadOnly = true;
            this.Dtg.RowHeadersWidth = 51;
            this.Dtg.RowTemplate.Height = 29;
            this.Dtg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dtg.Size = new System.Drawing.Size(755, 342);
            this.Dtg.TabIndex = 63;
            this.Dtg.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dtg_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(433, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 38);
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
            this.BtRemove.Location = new System.Drawing.Point(795, 678);
            this.BtRemove.Name = "BtRemove";
            this.BtRemove.Size = new System.Drawing.Size(123, 53);
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
            this.BtUpdate.Location = new System.Drawing.Point(498, 676);
            this.BtUpdate.Name = "BtUpdate";
            this.BtUpdate.Size = new System.Drawing.Size(123, 53);
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
            this.BtAdd.Location = new System.Drawing.Point(163, 676);
            this.BtAdd.Name = "BtAdd";
            this.BtAdd.Size = new System.Drawing.Size(123, 53);
            this.BtAdd.TabIndex = 60;
            this.BtAdd.Text = "Add";
            this.BtAdd.UseVisualStyleBackColor = false;
            this.BtAdd.Click += new System.EventHandler(this.BtAdd_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(159, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 28);
            this.label3.TabIndex = 66;
            this.label3.Text = "Search";
            // 
            // BtFind
            // 
            this.BtFind.Location = new System.Drawing.Point(849, 64);
            this.BtFind.Name = "BtFind";
            this.BtFind.Size = new System.Drawing.Size(94, 27);
            this.BtFind.TabIndex = 65;
            this.BtFind.Text = "Find";
            this.BtFind.UseVisualStyleBackColor = true;
            this.BtFind.Click += new System.EventHandler(this.BtFind_Click);
            // 
            // TbFind
            // 
            this.TbFind.Location = new System.Drawing.Point(267, 65);
            this.TbFind.Name = "TbFind";
            this.TbFind.Size = new System.Drawing.Size(545, 27);
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
            this.panel1.Location = new System.Drawing.Point(267, 100);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(545, 149);
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
            this.NUDPriceSell.Location = new System.Drawing.Point(187, 107);
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
            this.NUDPriceBuy.Enabled = false;
            this.NUDPriceBuy.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.NUDPriceBuy.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.NUDPriceBuy.Location = new System.Drawing.Point(187, 61);
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(16, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 28);
            this.label4.TabIndex = 15;
            this.label4.Text = "Price buy";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(16, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 28);
            this.label5.TabIndex = 13;
            this.label5.Text = "Name";
            // 
            // TbName
            // 
            this.TbName.Enabled = false;
            this.TbName.Location = new System.Drawing.Point(187, 16);
            this.TbName.Name = "TbName";
            this.TbName.Size = new System.Drawing.Size(290, 27);
            this.TbName.TabIndex = 10;
            // 
            // CbbFilter
            // 
            this.CbbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbbFilter.FormattingEnabled = true;
            this.CbbFilter.Location = new System.Drawing.Point(939, 257);
            this.CbbFilter.Name = "CbbFilter";
            this.CbbFilter.Size = new System.Drawing.Size(151, 28);
            this.CbbFilter.TabIndex = 68;
            this.CbbFilter.SelectedIndexChanged += new System.EventHandler(this.CbbFilter_SelectedIndexChanged);
            // 
            // BtReversePage
            // 
            this.BtReversePage.Enabled = false;
            this.BtReversePage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.BtReversePage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtReversePage.Location = new System.Drawing.Point(163, 618);
            this.BtReversePage.Name = "BtReversePage";
            this.BtReversePage.Size = new System.Drawing.Size(123, 35);
            this.BtReversePage.TabIndex = 69;
            this.BtReversePage.Text = "Reverse page";
            this.BtReversePage.UseVisualStyleBackColor = true;
            this.BtReversePage.Click += new System.EventHandler(this.BtReversePage_Click);
            // 
            // BtNextPage
            // 
            this.BtNextPage.Enabled = false;
            this.BtNextPage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.BtNextPage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.BtNextPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtNextPage.Location = new System.Drawing.Point(795, 618);
            this.BtNextPage.Name = "BtNextPage";
            this.BtNextPage.Size = new System.Drawing.Size(123, 35);
            this.BtNextPage.TabIndex = 70;
            this.BtNextPage.Text = "Next page";
            this.BtNextPage.UseVisualStyleBackColor = true;
            this.BtNextPage.Click += new System.EventHandler(this.BtNextPage_Click);
            // 
            // TbCurrentPage
            // 
            this.TbCurrentPage.Enabled = false;
            this.TbCurrentPage.Location = new System.Drawing.Point(498, 626);
            this.TbCurrentPage.Name = "TbCurrentPage";
            this.TbCurrentPage.Size = new System.Drawing.Size(125, 27);
            this.TbCurrentPage.TabIndex = 71;
            // 
            // CbbIndexPage
            // 
            this.CbbIndexPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbbIndexPage.FormattingEnabled = true;
            this.CbbIndexPage.Items.AddRange(new object[] {
            "5",
            "10",
            "15"});
            this.CbbIndexPage.Location = new System.Drawing.Point(939, 340);
            this.CbbIndexPage.Name = "CbbIndexPage";
            this.CbbIndexPage.Size = new System.Drawing.Size(151, 28);
            this.CbbIndexPage.TabIndex = 72;
            this.CbbIndexPage.SelectedValueChanged += new System.EventHandler(this.CbbIndexPage_SelectedValueChanged);
            // 
            // CbAllResult
            // 
            this.CbAllResult.AutoSize = true;
            this.CbAllResult.Location = new System.Drawing.Point(1013, 65);
            this.CbAllResult.Name = "CbAllResult";
            this.CbAllResult.Size = new System.Drawing.Size(49, 24);
            this.CbAllResult.TabIndex = 82;
            this.CbAllResult.Text = "All";
            this.CbAllResult.UseVisualStyleBackColor = true;
            this.CbAllResult.CheckedChanged += new System.EventHandler(this.CbAllResult_CheckedChanged);
            // 
            // FormProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 743);
            this.Controls.Add(this.CbAllResult);
            this.Controls.Add(this.CbbIndexPage);
            this.Controls.Add(this.TbCurrentPage);
            this.Controls.Add(this.BtNextPage);
            this.Controls.Add(this.BtReversePage);
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
            this.Name = "FormProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormProduct";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormProduct_FormClosing);
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
        private Button BtReversePage;
        private Button BtNextPage;
        private TextBox TbCurrentPage;
        private ComboBox CbbIndexPage;
        private CheckBox CbAllResult;
    }
}