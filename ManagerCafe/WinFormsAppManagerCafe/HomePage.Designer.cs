namespace WinFormsAppManagerCafe
{
    partial class HomePage
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pageProduct = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pageProduct
            // 
            this.pageProduct.Location = new System.Drawing.Point(419, 26);
            this.pageProduct.Name = "pageProduct";
            this.pageProduct.Size = new System.Drawing.Size(250, 71);
            this.pageProduct.TabIndex = 0;
            this.pageProduct.Text = "Product";
            this.pageProduct.UseVisualStyleBackColor = true;
            this.pageProduct.Click += new System.EventHandler(this.button1_Click);
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 608);
            this.Controls.Add(this.pageProduct);
            this.Name = "HomePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Button pageProduct;
    }
}