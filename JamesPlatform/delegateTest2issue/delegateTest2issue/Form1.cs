using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace delegateTest2issue
{
    public partial class Form1 : Form
    {
        private delegate void DelShowMessage(string sMessage);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        Thread thrStart;
        bool abort=false;
        private void button1_Click(object sender, EventArgs e)
        {
            thrStart = new Thread(ShowMessage);
            thrStart.Start();
            abort = false;
        }

        private void AddMessage(string sMessage)
        {
            if (this.InvokeRequired) // 若非同執行緒
            {
                DelShowMessage del = new DelShowMessage(AddMessage); //利用委派執行
                this.Invoke(del, sMessage);
            }
            else // 同執行緒
            {
                this.textBox1.Text += sMessage + Environment.NewLine;
            }
        }

        private void ShowMessage()
        {
            while (!abort)
            {
                AddMessage("Thread is alive...");
                Thread.Sleep(3000);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            abort = true;

        }
    }
}
