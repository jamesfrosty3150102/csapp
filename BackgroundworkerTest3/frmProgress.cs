using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace backgroundworkerProtytype
{
    public partial class frmProgress : Form
    {
        private delegate void DelShowMessage(string sMessage);
        public frmProgress()
        {
            InitializeComponent();
        }

        private void InitializeBackgroundWorker()
        {
            _bw.DoWork += new DoWorkEventHandler(_bw_DoWork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.ProgressChanged += new ProgressChangedEventHandler(_bw_ProgressChanged);
        }


        #region 委派相關
        private void AddMessage(string sMessage)
        {
            if (this.InvokeRequired)
            {
                DelShowMessage del = new DelShowMessage(AddMessage);
                this.Invoke(del, sMessage);
            }
            else
            {
                //this.label1.Text += sMessage + Environment.NewLine;
                this.Text = sMessage + Environment.NewLine;
            }
        }
        private void ShowMessage()
        {
            while (true)
            {
                string status = "";
                switch (this.progressBar1.Value)
                {
                    case 0:
                        //status = "UTC";
                        //status = "OV1";
                        //status = "" + label2.Text;
                        AddMessage(status);
                        break;
                    //case 68:
                    //status = "UTC-Trigger/Release計算";
                    //status = "OV1-Trigger/Release計算";
                    case 15:
                        //status = label2.Text + " trigger";
                        AddMessage(status);
                        break;
                    case 35:
                        //status = label2.Text + " release";
                        AddMessage(status);
                        break;
                    case 50:
                        //status = label2.Text + "-Trigger/Release計算";
                        AddMessage(status);
                        break;
                    case 58:
                        //status = label2.Text + "-Trigger截圖";
                        AddMessage(status);
                        break;
                    case 63:
                        //status = label2.Text + "-Trigger/Release計算";
                        AddMessage(status);
                        break;
                    case 75:
                        //status = label2.Text + "-Release截圖";
                        AddMessage(status);
                        break;
                }
            }
        }
        #endregion

        private void _bw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            if (this.progressBar1.Value == 0)
            {
                for (int i = 1; i <= 100; i++)
                {
                    if (worker.CancellationPending == true)
                    {
                        e.Cancel = true;
                        break;
                    }
                    else
                    {
                        // Perform a time consuming operation and report progress.
                        //System.Threading.Thread.Sleep(50);  //50  0.05sec   80,000
                        //System.Threading.Thread.Sleep(800);  //80,000   80sec 包含模擬+抓trigger release 800*100 = 80000 時間不夠長
                        //System.Threading.Thread.Sleep(1100);  //時間太長
                        System.Threading.Thread.Sleep(100);  //時間太長
                        //System.Threading.Thread.Sleep(900);  //時間太長
                        worker.ReportProgress(i);
                        //worker.ReportProgress(i * 10);
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
            this.label1.Text = e.ProgressPercentage.ToString() + "%";
        }

        private void _bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                //resultLabel.Text = "Canceled!";
                //label1.Text = "Cancelled";
            }
            else if (e.Error != null)
            {
                //resultLabel.Text = "Error: " + e.Error.Message;
            }
            else
            {
                //resultLabel.Text = "Done!";
                //label1.Text = "100%";
                this.Close();
            }
        }



        #region 模板 UTC3Simulate()
        //        private void UTC3Simulate()
        //        {
        //            _bw.WorkerReportsProgress = true;
        //            _bw.WorkerSupportsCancellation = true;
        //            //initScope2();
        //            //_Scope.DisplayClr();
        //            #region 開機
        //            PauseMessagebox();
        //            //MessageBox.Show("請確認電池正常,CB Off and ClearPF", "OTC2關CB/PF");
        //            #endregion

        //            InitializeBackgroundWorker();
        //            Thread thrStart = new Thread(ShowMessage);
        //            Task _taskUTC3 = new Task(UTC3ProgressForm4);
        //            if (_bw.IsBusy != true)
        //            {// Start the asynchronous operation.
        //                _bw.RunWorkerAsync();
        //            }

        //            Task subThread1 = new Task(() =>
        //            {
        //                thrStart.Start();
        //                Thread.Sleep(1000);
        //                Console.WriteLine("I am subThread1!");
        //                _taskUTC3.Start();
        //                Thread.Sleep(1000);
        //            });

        //            subThread1.Start();
        //            Task subThread2 = new Task(() =>
        //            {
        //                Thread.Sleep(1000);
        //                Console.WriteLine("I am subThread2!");
        //            });

        //            subThread2.GetAwaiter().OnCompleted(() =>
        //            {
        //                subThread2.Wait(55000);
        //            });
        //            //subThread2.GetAwaiter().GetResult();  
        //        }
        //        private void UTC3ProgressForm4()
        //        {
        //            _Scope.DisplayClr();
        //            UTC3Form4();
        //            _Scope.Stop();
        //            UTC3TriggerReleaseForm4();
        //        }
        //        private void UTC3Form4()
        //        {
        //#if debug
        //            System.Threading.Thread.Sleep(52000);   //total 52 sec
        //#endif
        //            #region 正常設定
        //            #region UTC3正常設定
        //            //listBox1.Items.Add("UTC3: RT5: 25");
        //            Application.DoEvents();
        //            CelciusSet(_CelciusVol[0]);
        //            //listBox1.Items.Add("Delay: 15000ms");
        //            Application.DoEvents();
        //            System.Threading.Thread.Sleep(15000);
        //            #endregion
        //            #region UTC3 Trigger
        //            //listBox1.Items.Add("UTC3 trigger: RT5: -5");
        //            Application.DoEvents();
        //            CelciusSet(_CelciusVol[11]);
        //            //listBox1.Items.Add("Trigger Delay: 20000ms");
        //            Application.DoEvents();
        //            System.Threading.Thread.Sleep(20000);
        //            #endregion
        //            #region UTC3 Release
        //            Application.DoEvents();
        //            CelciusSet(_CelciusVol[5]);
        //            //listBox1.Items.Add("Release Delay: 21500ms");
        //            Application.DoEvents();
        //            System.Threading.Thread.Sleep(21500);
        //            #endregion
        //            #endregion
        //        }
        //        private void UTC3TriggerReleaseForm4()   //標籤Trigger/Release
        //        {
        //            bool result = false;
        //            string Msg = "";
        //            result = _Scope.UTC2Trigger(ref Msg);
        //            _Scope.CaptureWaveform("UTC3Trigger");
        //            result = _Scope.UTC2Release(ref Msg);
        //            _Scope.CaptureWaveform("UTC3Release");
        //        }
        #endregion

        #region 模板
        //private void FETOTSimulate()
        //{
        //}
        //private void FETOTProgressForm4()
        //{
        //    _Scope.DisplayClr();
        //    FETOTForm4();
        //    _Scope.Stop();
        //    FETOTTriggerReleaseForm4();
        //}
        //private void FETOTForm4()
        //{

        //}
        //private void FETOTTriggerReleaseForm4()   //標籤Trigger/Release
        //{
        //}
        #endregion

        private void frmProgress_Load(object sender, EventArgs e)
        {
            _bw.WorkerReportsProgress = true;
            _bw.WorkerSupportsCancellation = true;
            InitializeBackgroundWorker();
            Thread thrStart = new Thread(ShowMessage);
            Task _taskNTCCHG = new Task(taskProgram);
            if (_bw.IsBusy != true)
            {// Start the asynchronous operation.
                _bw.RunWorkerAsync();
            }
        }

        private void taskProgram()
        {
            System.Threading.Thread.Sleep(10000);
        }
    }
}
