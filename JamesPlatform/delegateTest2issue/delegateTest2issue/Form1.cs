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
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread thrStart = new Thread(ShowMessage);
            thrStart.Start();
        }

        private void AddMessage(string sMessage)
        {
            this.textBox1.Text += sMessage + Environment.NewLine;
        }

        private void ShowMessage()
        {
            while (true)
            {
                AddMessage("Thread is alive...");
                Thread.Sleep(3000);
            }
        }
    }
}
