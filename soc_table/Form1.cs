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

namespace soc_table
{
    public partial class Form1 : Form
    {
        string _line = "";
        string[] _tempArray = null;
        string _soc = "";
        string _soc_rec = "";
        double _soc_double = 0.0;
        double _soc_rec_double = 0.0;
        int _dot = 0;
        int _dot_rec = 0;
        bool _percentage = false;
        bool _percenthundred = false;
        string[] PercentageVoltage = new string[105];
        string _prefix = "";
        //string g_filepath = Application.StartupPath + "\\" + _prefix + ".csv";
        string[] _criticalPercentage = new string[1];
        int _count = 0;
        int _clearPercent = 0;
        double _voltage = 0.0;
        int soc_unitsdigit = 0; //個位數
        int soc_rec_unitsdigit = 0; //個位數
        int soc_tensdigits = 0; //十位數

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string _logPath = @"D:\2023\20230421_SDILGC_NewStandard\20230421 Gary\SDI1.csv";
            StreamReader _reader = new StreamReader(_logPath);


            while (!_reader.EndOfStream)
            {
                _tempArray = _reader.ReadLine().Split(',');
                Console.WriteLine("{0},{1},{2},{3}",_tempArray[0], _tempArray[1], (double.Parse(_tempArray[2])*100 +"%"), _tempArray[3]);
                _soc_double = double.Parse(_tempArray[2]) * 100;
                _soc = _tempArray[2];
                //_soc = "0%"; //小數點 -1
                //_dot = _soc.ToString().LastIndexOf('.');
                //_dot_rec = _soc_rec.ToString().LastIndexOf(".");
                _dot = _soc_double.ToString().LastIndexOf('.');
                _dot_rec = _soc_rec_double.ToString().LastIndexOf(".");
                _voltage = double.Parse(_tempArray[0]) * 1000;
                //soc_unitsdigit = _soc.Substring(); 位數不同取法不同, 不能在此算位數
                switch (_dot)
                { 
                    case -1:    //沒有100%, 0%
                        _criticalPercentage[0] = _soc_double.ToString("0") + ":" +_voltage;
                        Array.Copy(_criticalPercentage, 0, PercentageVoltage, _count, 1);
                        _count += 1;
                        //_percenthundred = percentCapHundred(_soc);
                        break;
                    case 2:
                        //soc_unitsdigit = _soc.Substring(0,_soc)
                        if (_dot == _dot_rec)    //確認小數位數相同
                        {
                            //if () //判斷變動位
                            //{ 

                            //}
                        }
                        else if ((_dot == 2) && (_dot_rec == -1))   //99%
                        {
                            _criticalPercentage[0] = _soc_double.ToString().Substring(0, _dot) + ":" + _voltage;
                            Array.Copy(_criticalPercentage, 0, PercentageVoltage, _count, 1);
                            _count += 1;
                            //_percenthundred = percentCapHundred(_soc);
                            break;
                        }
#if debug
                        _criticalPercentage[0] = _soc + ":" + (double.Parse(_tempArray[0]) * 1000).ToString();
                        Array.Copy(_criticalPercentage, 0, PercentageVoltage, _count, 1);
                        _count += 1;
#endif
                        //_percentage = percentCap();
                        break;
                    case 1:
                        Console.WriteLine("_soc:{0}", _soc);
                        Console.WriteLine("_soc_rec:{0}", _soc_rec);
                        break;

                }
                _soc_rec = _soc;
                _soc_rec_double = _soc_double;

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private bool percentCap()
        {
            bool result = false;
            //_criticalPercentage[0] = double.Parse(_soc.Substring(0, _clearPercent)).ToString("0") + "%:" + (double.Parse(_tempArray[0]) * 1000).ToString();
            //Array.Copy(_criticalPercentage, 0, PercentageVoltage, _count, 1);
            ////_count += 1;
            return result;
        }

        private bool percentCapHundred(string soc)
        {
            bool result = false;

            //_criticalPercentage[0] = double.Parse(_soc.Substring(0, _clearPercent)).ToString("0") + "%:" + (double.Parse(_tempArray[0]) * 1000).ToString();
            //Array.Copy(_criticalPercentage, 0, PercentageVoltage, _count, 1);
            //_count += 1;
            return result;
        }

    }
}
