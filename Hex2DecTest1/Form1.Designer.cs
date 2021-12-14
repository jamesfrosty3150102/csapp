
namespace Hex2DecTest
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnHex2Dec = new System.Windows.Forms.Button();
            this.tbHex = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnHex2Dec
            // 
            this.btnHex2Dec.Location = new System.Drawing.Point(621, 39);
            this.btnHex2Dec.Name = "btnHex2Dec";
            this.btnHex2Dec.Size = new System.Drawing.Size(87, 57);
            this.btnHex2Dec.TabIndex = 0;
            this.btnHex2Dec.Text = "button1";
            this.btnHex2Dec.UseVisualStyleBackColor = true;
            this.btnHex2Dec.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbHex
            // 
            this.tbHex.Location = new System.Drawing.Point(349, 39);
            this.tbHex.Name = "tbHex";
            this.tbHex.Size = new System.Drawing.Size(139, 25);
            this.tbHex.TabIndex = 1;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(182, 183);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(388, 214);
            this.listBox1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.tbHex);
            this.Controls.Add(this.btnHex2Dec);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnHex2Dec;
        private System.Windows.Forms.TextBox tbHex;
        private System.Windows.Forms.ListBox listBox1;
    }
}

