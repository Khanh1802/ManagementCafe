namespace WinFormsAppManagerCafe.Inventories
{
    partial class FormInventory
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
            this.TbQuatity = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Dtg = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.BtRemove = new System.Windows.Forms.Button();
            this.BtUpdate = new System.Windows.Forms.Button();
            this.BtAdd = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.BtFind = new System.Windows.Forms.Button();
            this.TbFind = new System.Windows.Forms.TextBox();
            this.CbbFilter = new System.Windows.Forms.ComboBox();
            this.CbbProduct = new System.Windows.Forms.ComboBox();
            this.CbbWareHouse = new System.Windows.Forms.ComboBox();
            this.CbAllResult = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.TbQuatity);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(260, 102);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(545, 63);
            this.panel1.TabIndex = 77;
            // 
            // TbQuatity
            // 
            this.TbQuatity.Enabled = false;
            this.TbQuatity.Location = new System.Drawing.Point(125, 22);
            this.TbQuatity.Name = "TbQuatity";
            this.TbQuatity.Size = new System.Drawing.Size(290, 27);
            this.TbQuatity.TabIndex = 65;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(24, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 28);
            this.label2.TabIndex = 17;
            this.label2.Text = "Quatity";
            // 
            // Dtg
            // 
            this.Dtg.BackgroundColor = System.Drawing.Color.White;
            this.Dtg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dtg.Location = new System.Drawing.Point(155, 171);
            this.Dtg.Name = "Dtg";
            this.Dtg.ReadOnly = true;
            this.Dtg.RowHeadersWidth = 51;
            this.Dtg.RowTemplate.Height = 29;
            this.Dtg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dtg.Size = new System.Drawing.Size(755, 372);
            this.Dtg.TabIndex = 73;
            this.Dtg.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dtg_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(415, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 38);
            this.label1.TabIndex = 69;
            this.label1.Text = "PAGE INVENTORY";
            // 
            // BtRemove
            // 
            this.BtRemove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BtRemove.Enabled = false;
            this.BtRemove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.BtRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtRemove.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtRemove.Location = new System.Drawing.Point(787, 551);
            this.BtRemove.Name = "BtRemove";
            this.BtRemove.Size = new System.Drawing.Size(123, 53);
            this.BtRemove.TabIndex = 72;
            this.BtRemove.Text = "Delete";
            this.BtRemove.UseVisualStyleBackColor = false;
            // 
            // BtUpdate
            // 
            this.BtUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.BtUpdate.Enabled = false;
            this.BtUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.BtUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtUpdate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtUpdate.Location = new System.Drawing.Point(490, 549);
            this.BtUpdate.Name = "BtUpdate";
            this.BtUpdate.Size = new System.Drawing.Size(123, 53);
            this.BtUpdate.TabIndex = 71;
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
            this.BtAdd.Location = new System.Drawing.Point(155, 549);
            this.BtAdd.Name = "BtAdd";
            this.BtAdd.Size = new System.Drawing.Size(123, 53);
            this.BtAdd.TabIndex = 70;
            this.BtAdd.Text = "Add";
            this.BtAdd.UseVisualStyleBackColor = false;
            this.BtAdd.Click += new System.EventHandler(this.BtAdd_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(146, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 28);
            this.label3.TabIndex = 76;
            this.label3.Text = "Search";
            // 
            // BtFind
            // 
            this.BtFind.Location = new System.Drawing.Point(836, 66);
            this.BtFind.Name = "BtFind";
            this.BtFind.Size = new System.Drawing.Size(94, 27);
            this.BtFind.TabIndex = 75;
            this.BtFind.Text = "Find";
            this.BtFind.UseVisualStyleBackColor = true;
            // 
            // TbFind
            // 
            this.TbFind.Location = new System.Drawing.Point(260, 67);
            this.TbFind.Name = "TbFind";
            this.TbFind.Size = new System.Drawing.Size(545, 27);
            this.TbFind.TabIndex = 74;
            // 
            // CbbFilter
            // 
            this.CbbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbbFilter.FormattingEnabled = true;
            this.CbbFilter.Location = new System.Drawing.Point(931, 171);
            this.CbbFilter.Name = "CbbFilter";
            this.CbbFilter.Size = new System.Drawing.Size(151, 28);
            this.CbbFilter.TabIndex = 78;
            // 
            // CbbProduct
            // 
            this.CbbProduct.FormattingEnabled = true;
            this.CbbProduct.Location = new System.Drawing.Point(819, 102);
            this.CbbProduct.Name = "CbbProduct";
            this.CbbProduct.Size = new System.Drawing.Size(151, 28);
            this.CbbProduct.TabIndex = 79;
            this.CbbProduct.SelectedIndexChanged += new System.EventHandler(this.CbbProduct_SelectedIndexChanged);
            // 
            // CbbWareHouse
            // 
            this.CbbWareHouse.FormattingEnabled = true;
            this.CbbWareHouse.Location = new System.Drawing.Point(819, 137);
            this.CbbWareHouse.Name = "CbbWareHouse";
            this.CbbWareHouse.Size = new System.Drawing.Size(151, 28);
            this.CbbWareHouse.TabIndex = 80;
            this.CbbWareHouse.SelectedIndexChanged += new System.EventHandler(this.CbbWareHouse_SelectedIndexChanged);
            // 
            // CbAllResult
            // 
            this.CbAllResult.AutoSize = true;
            this.CbAllResult.Location = new System.Drawing.Point(989, 102);
            this.CbAllResult.Name = "CbAllResult";
            this.CbAllResult.Size = new System.Drawing.Size(71, 24);
            this.CbAllResult.TabIndex = 81;
            this.CbAllResult.Text = "Tất cả";
            this.CbAllResult.UseVisualStyleBackColor = true;
            this.CbAllResult.CheckedChanged += new System.EventHandler(this.CbAllResult_CheckedChanged);
            // 
            // FormInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 608);
            this.Controls.Add(this.CbAllResult);
            this.Controls.Add(this.CbbWareHouse);
            this.Controls.Add(this.CbbProduct);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Dtg);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtRemove);
            this.Controls.Add(this.BtUpdate);
            this.Controls.Add(this.BtAdd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtFind);
            this.Controls.Add(this.TbFind);
            this.Controls.Add(this.CbbFilter);
            this.Name = "FormInventory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormInventory";
            this.Load += new System.EventHandler(this.FormInventory_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panel1;
        private Label label2;
        private DataGridView Dtg;
        private Label label1;
        private Button BtRemove;
        private Button BtUpdate;
        private Button BtAdd;
        private Label label3;
        private Button BtFind;
        private TextBox TbFind;
        private ComboBox CbbFilter;
        private ComboBox CbbProduct;
        private ComboBox CbbWareHouse;
        private TextBox TbQuatity;
        private CheckBox CbAllResult;
    }
}