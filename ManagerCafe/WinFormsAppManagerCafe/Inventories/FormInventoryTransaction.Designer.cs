namespace WinFormsAppManagerCafe.Inventories
{
    partial class FormInventoryTransaction
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
            this.TbFind = new System.Windows.Forms.TextBox();
            this.CbbType = new System.Windows.Forms.ComboBox();
            this.DTPFormDate = new System.Windows.Forms.DateTimePicker();
            this.DTPToDate = new System.Windows.Forms.DateTimePicker();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.CbbWarehouse = new System.Windows.Forms.ComboBox();
            this.checkBoxWarehouse = new System.Windows.Forms.CheckBox();
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
            this.Dtg.Size = new System.Drawing.Size(910, 389);
            this.Dtg.TabIndex = 74;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(436, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 38);
            this.label1.TabIndex = 77;
            this.label1.Text = "PAGE HISTORY";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(156, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 28);
            this.label3.TabIndex = 80;
            this.label3.Text = "Search";
            // 
            // BtFind
            // 
            this.BtFind.Location = new System.Drawing.Point(846, 74);
            this.BtFind.Name = "BtFind";
            this.BtFind.Size = new System.Drawing.Size(94, 27);
            this.BtFind.TabIndex = 79;
            this.BtFind.Text = "Find";
            this.BtFind.UseVisualStyleBackColor = true;
            this.BtFind.Click += new System.EventHandler(this.BtFind_Click);
            // 
            // TbFind
            // 
            this.TbFind.Location = new System.Drawing.Point(270, 75);
            this.TbFind.Name = "TbFind";
            this.TbFind.Size = new System.Drawing.Size(545, 27);
            this.TbFind.TabIndex = 78;
            // 
            // CbbType
            // 
            this.CbbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbbType.FormattingEnabled = true;
            this.CbbType.Location = new System.Drawing.Point(940, 134);
            this.CbbType.Name = "CbbType";
            this.CbbType.Size = new System.Drawing.Size(151, 28);
            this.CbbType.TabIndex = 81;
            // 
            // DTPFormDate
            // 
            this.DTPFormDate.Location = new System.Drawing.Point(175, 137);
            this.DTPFormDate.Name = "DTPFormDate";
            this.DTPFormDate.Size = new System.Drawing.Size(250, 27);
            this.DTPFormDate.TabIndex = 82;
            this.DTPFormDate.Value = new System.DateTime(2023, 1, 10, 0, 0, 0, 0);
            // 
            // DTPToDate
            // 
            this.DTPToDate.Location = new System.Drawing.Point(608, 137);
            this.DTPToDate.Name = "DTPToDate";
            this.DTPToDate.Size = new System.Drawing.Size(250, 27);
            this.DTPToDate.TabIndex = 83;
            this.DTPToDate.Value = new System.DateTime(2023, 1, 10, 0, 0, 0, 0);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(28, 137);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(125, 27);
            this.textBox1.TabIndex = 84;
            this.textBox1.Text = "Form date";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(463, 137);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(125, 27);
            this.textBox2.TabIndex = 85;
            this.textBox2.Text = "To date";
            // 
            // CbbWarehouse
            // 
            this.CbbWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbbWarehouse.FormattingEnabled = true;
            this.CbbWarehouse.Location = new System.Drawing.Point(940, 207);
            this.CbbWarehouse.Name = "CbbWarehouse";
            this.CbbWarehouse.Size = new System.Drawing.Size(151, 28);
            this.CbbWarehouse.TabIndex = 86;
            // 
            // checkBoxWarehouse
            // 
            this.checkBoxWarehouse.AutoSize = true;
            this.checkBoxWarehouse.Location = new System.Drawing.Point(940, 257);
            this.checkBoxWarehouse.Name = "checkBoxWarehouse";
            this.checkBoxWarehouse.Size = new System.Drawing.Size(124, 24);
            this.checkBoxWarehouse.TabIndex = 88;
            this.checkBoxWarehouse.Text = "All warehouse";
            this.checkBoxWarehouse.UseVisualStyleBackColor = true;
            // 
            // FormInventoryTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 608);
            this.Controls.Add(this.checkBoxWarehouse);
            this.Controls.Add(this.CbbWarehouse);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.DTPToDate);
            this.Controls.Add(this.DTPFormDate);
            this.Controls.Add(this.CbbType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtFind);
            this.Controls.Add(this.TbFind);
            this.Controls.Add(this.Dtg);
            this.Name = "FormInventoryTransaction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InventoryTransaction";
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
        private TextBox TbFind;
        private ComboBox CbbType;
        private DateTimePicker DTPFormDate;
        private DateTimePicker DTPToDate;
        private TextBox textBox1;
        private TextBox textBox2;
        private ComboBox CbbWarehouse;
        private CheckBox checkBoxWarehouse;
    }
}