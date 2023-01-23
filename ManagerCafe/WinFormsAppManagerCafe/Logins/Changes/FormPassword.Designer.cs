namespace WinFormsAppManagerCafe.Logins.Changes
{
    partial class FormPassword
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
            this.components = new System.ComponentModel.Container();
            this.CbPasswordOld = new System.Windows.Forms.CheckBox();
            this.TbPasswordOld = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.BtReturn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TbPassWordNewRepeat = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CbPasswordNew = new System.Windows.Forms.CheckBox();
            this.TbPassWordNew = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BtChange = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CbPasswordOld
            // 
            this.CbPasswordOld.AutoSize = true;
            this.CbPasswordOld.Location = new System.Drawing.Point(485, 39);
            this.CbPasswordOld.Name = "CbPasswordOld";
            this.CbPasswordOld.Size = new System.Drawing.Size(63, 24);
            this.CbPasswordOld.TabIndex = 85;
            this.CbPasswordOld.Text = "View";
            this.CbPasswordOld.UseVisualStyleBackColor = true;
            this.CbPasswordOld.CheckedChanged += new System.EventHandler(this.CbPasswordOld_CheckedChanged);
            // 
            // TbPasswordOld
            // 
            this.TbPasswordOld.Location = new System.Drawing.Point(169, 36);
            this.TbPasswordOld.Name = "TbPasswordOld";
            this.TbPasswordOld.Size = new System.Drawing.Size(290, 27);
            this.TbPasswordOld.TabIndex = 73;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(2, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 28);
            this.label6.TabIndex = 72;
            this.label6.Text = "Old password";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // BtReturn
            // 
            this.BtReturn.Location = new System.Drawing.Point(338, 405);
            this.BtReturn.Name = "BtReturn";
            this.BtReturn.Size = new System.Drawing.Size(117, 32);
            this.BtReturn.TabIndex = 88;
            this.BtReturn.Text = "Return";
            this.BtReturn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(283, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 38);
            this.label1.TabIndex = 85;
            this.label1.Text = "PAGE PASSWORD";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.panel1.Controls.Add(this.TbPassWordNewRepeat);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.CbPasswordNew);
            this.panel1.Controls.Add(this.TbPassWordNew);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.CbPasswordOld);
            this.panel1.Controls.Add(this.TbPasswordOld);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(110, 94);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(581, 199);
            this.panel1.TabIndex = 86;
            // 
            // TbPassWordNewRepeat
            // 
            this.TbPassWordNewRepeat.Location = new System.Drawing.Point(169, 138);
            this.TbPassWordNewRepeat.Name = "TbPassWordNewRepeat";
            this.TbPassWordNewRepeat.Size = new System.Drawing.Size(290, 27);
            this.TbPassWordNewRepeat.TabIndex = 90;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(2, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 28);
            this.label3.TabIndex = 89;
            this.label3.Text = "Retype password";
            // 
            // CbPasswordNew
            // 
            this.CbPasswordNew.AutoSize = true;
            this.CbPasswordNew.Location = new System.Drawing.Point(485, 89);
            this.CbPasswordNew.Name = "CbPasswordNew";
            this.CbPasswordNew.Size = new System.Drawing.Size(63, 24);
            this.CbPasswordNew.TabIndex = 88;
            this.CbPasswordNew.Text = "View";
            this.CbPasswordNew.UseVisualStyleBackColor = true;
            this.CbPasswordNew.CheckedChanged += new System.EventHandler(this.CbPasswordNew_CheckedChanged);
            // 
            // TbPassWordNew
            // 
            this.TbPassWordNew.Location = new System.Drawing.Point(169, 86);
            this.TbPassWordNew.Name = "TbPassWordNew";
            this.TbPassWordNew.Size = new System.Drawing.Size(290, 27);
            this.TbPassWordNew.TabIndex = 87;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(2, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 28);
            this.label2.TabIndex = 86;
            this.label2.Text = "New password";
            // 
            // BtChange
            // 
            this.BtChange.Location = new System.Drawing.Point(154, 405);
            this.BtChange.Name = "BtChange";
            this.BtChange.Size = new System.Drawing.Size(117, 32);
            this.BtChange.TabIndex = 87;
            this.BtChange.Text = "Change";
            this.BtChange.UseVisualStyleBackColor = true;
            this.BtChange.Click += new System.EventHandler(this.BtChange_Click);
            // 
            // FormPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtReturn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BtChange);
            this.Name = "FormPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormPass";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CheckBox CbPasswordOld;
        private TextBox TbPasswordOld;
        private Label label6;
        private ContextMenuStrip contextMenuStrip1;
        private Button BtReturn;
        private Label label1;
        private Panel panel1;
        private Button BtChange;
        private CheckBox CbPasswordNew;
        private TextBox TbPassWordNew;
        private Label label2;
        private TextBox TbPassWordNewRepeat;
        private Label label3;
    }
}