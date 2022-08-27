using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Winform0827
{
    public partial class listbox_issue : Form
    {
        //Task 參數
        bool g_cycleTaskStart = false;
        bool g_cycleTestFlag = false;
        int g_cycleTestCount = 0;

        public listbox_issue()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!g_cycleTaskStart)
            {
                Task _taskRun = new Task(readingTask);
                _taskRun.Start();
                g_cycleTaskStart = true;         
            }
        }

        private void readingTask()
        { 
            StreamReader _reader = new StreamReader(Application.StartupPath + "\\" + @"data.csv");
            string _line = _reader.ReadLine();
            string[] _tempArray = null;
            int _count = 0;
            while(!_reader.EndOfStream)
            {
                _tempArray = _reader.ReadLine().Split(',');
                Console.WriteLine(_tempArray[0]);
                listBox1.Invoke(new Action(() => listBox1.Items.Add(_tempArray[0])));
                //listBox1.Items.Add(_tempArray[0]);
                _count++;
            }        
        }
    }
}
