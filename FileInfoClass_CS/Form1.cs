using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileInfoClassLibrary1;

namespace FileInfoMethodTests
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileInfoClassLibrary1.FileInfoClass1 fileInfoClass1 = new FileInfoClassLibrary1.FileInfoClass1();
            bool _result = false;
            string _data = "";
            _result = fileInfoClass1._AppendText(ref _data);
            if (_result)
            {
                Console.WriteLine("true");
            }
            

        }
    }
}
