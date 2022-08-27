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
        //Get Data Cnt
        int g_sbsCount = 0;

        public listbox_issue()
        {
            InitializeComponent();
            GetDataCnt();
        }

        #region GetDataCnt
        private void GetDataCnt()
        {
            //label1.Text = "計算 Delay time 數量";
            StreamReader _reader = new StreamReader(Application.StartupPath + "\\" + @"data.csv");

            while (!_reader.EndOfStream)
            {
                _reader.ReadLine();
                g_sbsCount++;
            }
            g_sbsCount = g_sbsCount - 1;
            listBox1.Items.Add("資料數量:" + g_sbsCount);
            //Array.Resize(ref g_SBSData, g_sbsCount);
            _reader.Close();
            _reader.Dispose();
        }
        #endregion

        #region button1
        private void button1_Click(object sender, EventArgs e)
        {
            if (!g_cycleTaskStart)
            {
                Task _taskRun = new Task(readingTask);
                _taskRun.Start();
                g_cycleTaskStart = true;         
            }
        }
        #endregion

        #region readingTask
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
                _count++;
            }        
        }
        #endregion readingTask
    }
}
