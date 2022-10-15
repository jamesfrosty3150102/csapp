using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PathClassLibrary1;
using System.IO;

namespace PathMethodTests
{
    public partial class Form1 : Form
    {
        PathClass1 PathC = new PathClass1();
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add("ChangeExtension");
            comboBox1.Items.Add("Combine");
            comboBox1.Items.Add("GetDirectoryName");
            comboBox1.Items.Add("GetExtension");
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            string path1 = @"C:\temp\MyTest.txt";
            string path2 = @"C:\temp\MyTest";
            string path3 = @"temp";
            string path4 = @"D:\CSharp\TEMP\W896001DA.TxT";
            string path5 = "";

            bool result = false;
            int selectedIndex = comboBox1.SelectedIndex;
            path1 = textBox1.Text;

            switch (selectedIndex)
            { 
                case 0:
                    result = PathC._ChangeExtension(ref path1);
                    break;
                case 1:
                    result = PathC._Combine(ref path1);
                    break;
                case 2:
                    result = PathC._EndsInDirectorySeparator(ref path1);
                    break;
                case 3:
                    result = PathC._GetExtension(ref path4, ref path5);
                    Console.WriteLine(path5);
                    break;
            }
#if debug
            bool result = false;
            string data = "ABC";
            result = PathC.dllTestAPI(ref data);
            if (!result)
            {
                Console.WriteLine("testing failed");
            }
#endif
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = comboBox1.SelectedIndex;
            Console.WriteLine(selectedIndex);
            label1.Text = comboBox1.Items[1].ToString();
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog();
            od.Title = "選擇檔案";
            od.Multiselect = true;
            od.RestoreDirectory = true;
            if (od.ShowDialog() == DialogResult.OK)
            {
                string testingPath = Path.GetDirectoryName(od.FileName);
                textBox1.Text = testingPath;
            }
        }
    }
}
