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
        //

        public listbox_issue()
        {
            InitializeComponent();
            InitializeBackgroundWorker();
            BGW();
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
            _bw.RunWorkerAsync(g_sbsCount);
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
            while (!_reader.EndOfStream)
            {
                _tempArray = _reader.ReadLine().Split(',');
                Console.WriteLine(_tempArray[0]);
                listBox1.Invoke(new Action(() => listBox1.Items.Add(_tempArray[0])));
                _count++;
            }
        }
        #endregion readingTask


        #region Backgroundworker
        private void BGW()
        {
            ckBGW.Checked = true;
            if (ckBGW.Checked)
            {
                _bw.WorkerReportsProgress = true;
                _bw.WorkerSupportsCancellation = true;
            }
        }

        private void InitializeBackgroundWorker()
        {
            _bw.DoWork += new DoWorkEventHandler(_bw_DoWork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.ProgressChanged += new ProgressChangedEventHandler(_bw_ProgressChanged);
        }

        private void _bw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            if (this.progressBar1.Value == 0)
            {
                for (int i = 1; i <= 10; i++)
                {
                    if (worker.CancellationPending == true)
                    {
                        e.Cancel = true;
                        break;
                    }
                    else
                    {
                        // Perform a time consuming operation and report progress.
                        System.Threading.Thread.Sleep(500);
                        worker.ReportProgress(i * 10);
                    }
                    Console.WriteLine("this.progressBar1.Value:{0}", this.progressBar1.Value);
                    //label1.Text = Convert.ToString(this.progressBar1.Value)+ "%";
                }
            }
            Console.WriteLine("this.progressBar1.Value:{0}", this.progressBar1.Value);
        }

        private void _bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar1.Value = e.ProgressPercentage;
        }

        private void _bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                //resultLabel.Text = "Canceled!";
                //label1.Text = "Cancelled";
                label1.Text = "Canceled!";
            }
            else if (e.Error != null)
            {
                //resultLabel.Text = "Error: " + e.Error.Message;
                label1.Text = "Error:" + e.Error.Message;
            }
            else
            {
                //resultLabel.Text = "Done!";
                //label1.Text = "100%";
                label1.Text = "100%";
            }
        }
        #endregion 
    }
}
