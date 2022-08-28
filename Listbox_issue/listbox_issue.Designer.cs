namespace Winform0827
{
    partial class listbox_issue
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
            this.button1 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this._bw = new System.ComponentModel.BackgroundWorker();
            this.ckBGW = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(656, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 54);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 18;
            this.listBox1.Location = new System.Drawing.Point(66, 45);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(447, 310);
            this.listBox1.TabIndex = 1;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 409);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(776, 29);
            this.progressBar1.TabIndex = 2;
            // 
            // _bw
            // 
            this._bw.DoWork += new System.ComponentModel.DoWorkEventHandler(this._bw_DoWork);
            this._bw.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this._bw_ProgressChanged);
            this._bw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this._bw_RunWorkerCompleted);
            // 
            // ckBGW
            // 
            this.ckBGW.AutoSize = true;
            this.ckBGW.Location = new System.Drawing.Point(540, 128);
            this.ckBGW.Name = "ckBGW";
            this.ckBGW.Size = new System.Drawing.Size(89, 22);
            this.ckBGW.TabIndex = 3;
            this.ckBGW.Text = "chBGW";
            this.ckBGW.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 377);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // listbox_issue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ckBGW);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button1);
            this.Name = "listbox_issue";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker _bw;
        private System.Windows.Forms.CheckBox ckBGW;
        private System.Windows.Forms.Label label1;
    }
}

