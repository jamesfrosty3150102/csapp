using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CANAlystII_API;
using System.IO;
using Dynapack.utility;
using static DeltaPowerBank.ModuleSim;

namespace DeltaPowerBank
{
    public partial class ModuleSim : Form
    {
        CANAlystII g_CANAdapter;
        Task g_receiveTask;
        CcheckCode g_checkSum = new CcheckCode();
        bool g_exitReceiveFlag = false;
        public static moduleData[] g_moduleData = new moduleData[14];
        SBSData[] g_SBSData = new SBSData[1];

        struct SBSData
        {
            public string sbsAddress;
            public string name;
            public int dataLength;
            public int dataOffset;
            public string value;
            public string unit;
            public string type;
            public bool intPosNeg;
            public SBSData(string m_sbsAddress, string m_name, int m_dataLength, int m_dataOffset, string m_value, string m_unit, string m_type, bool m_intPosNeg)
            {
                this.sbsAddress = m_sbsAddress;
                this.name = m_name;
                this.dataLength = m_dataLength;
                this.dataOffset = m_dataOffset;
                this.value = m_value;
                this.unit = m_unit;
                this.type = m_type;
                this.intPosNeg = m_intPosNeg;
            }
        }
        public ModuleSim()
        {
            InitializeComponent();
            InitialCANAdapter();
            InitializeSBSData();
            initialModuleData();
        }

        byte[] g_cmd0x01 = new byte[]{0x00 ,0x00,0xE0 ,0x01 ,0x0A ,0x00 ,0x00 ,0x00 ,0x00 ,0x00 ,0xFF ,0xFF ,0xFF ,0xFF ,0x01 ,0x00
   ,0xD6 ,0x0B ,0xFC ,0xBD ,0xFF ,0xFF ,0xFF ,0xFF,0x01 ,0x00 };

        private void InitialCANAdapter()
        {
            string errMsg = "";
            g_CANAdapter = new CANAlystII();
            if (!g_CANAdapter.DeviceConnected)
                g_CANAdapter = CANDeviceManager.Connect(VCI_CAN_DEVICE_TYPE.USBCAN1, 0, 0, CAN_BAUD_RATE.bps_500Kbps, ref errMsg);
        }

        private void InitializeSBSData()
        {
            StreamReader _reader = new StreamReader(Application.StartupPath + "\\" + "Config_simulateESSModuleSBS.csv");
            string _line = _reader.ReadLine();//標頭
            string[] _tempArray = null;
            int _count = 0;
            while (!_reader.EndOfStream)
            {
                _tempArray = _reader.ReadLine().Split(',');
                g_SBSData[_count].name = _tempArray[0];
                g_SBSData[_count].sbsAddress = _tempArray[1];
                g_SBSData[_count].dataLength = Convert.ToInt16(_tempArray[2]);
                g_SBSData[_count].dataOffset = Convert.ToInt16(_tempArray[3]);
                g_SBSData[_count].value = _tempArray[4];
                g_SBSData[_count].unit = _tempArray[5];
                g_SBSData[_count].type = _tempArray[6];
                _count++;
            }
        }

            private void button1_Click(object sender, EventArgs e)
        {
            //g_receiveTask = new Task(Receive_Message);
            Receive_Message();
        }

        private byte[] GetFram(byte[] m_data)
        {
            byte[] _data = g_checkSum.GetModbusCrc16(m_data);
            byte[] _ret = new byte[m_data.Length + 2];
            Array.Copy(m_data, _ret, m_data.Length);
            _ret[_ret.Length - 2] = _data[0];
            _ret[_ret.Length - 1] = _data[1];
            return _ret;
        }


        unsafe private void Receive_Message()
        {
            int loopTime = System.Environment.TickCount + 1000;
            try
            {
                UInt32 res = new UInt32();
                string errorMessage = "";
                uint _moduelID = 0;
                structCANBusDataInfo[] m_recobj = new structCANBusDataInfo[2500];
                byte[] _txFrame = null;
                bool _result = false;
                do
                {
                    res = g_CANAdapter.ReceiveData(ref m_recobj, ref errorMessage);
                    if (res == 0xffffffff)
                    {
                        errorMessage = "收到資料量達到上限";
                    }
                    else
                    {
                        for (int i = 0; i < res; i++)
                        {
                            if (g_exitReceiveFlag)
                                break;
                            _moduelID = (m_recobj[i].ID & 0xff);
                            switch (m_recobj[i].data[0])
                            {
                                case 0x52:
                                    switch (m_recobj[i].data[1])
                                    {
                                        case 0x01:
                                            //_txFrame = GetFram(g_moduleData[_moduelID - 1].command01);
                                            break;

                                    }
                                    break;
                            }

                            //Console.WriteLine(m_recobj);
                            //Console.WriteLine(m_recobj.data);
                            listBox1.Items.Add(m_recobj[i].data[0].ToString("X") + m_recobj[i].data[1].ToString("X") + m_recobj[i].data[2].ToString("X") + m_recobj[i].data[3].ToString("X"));
                            Application.DoEvents();
                        }
                    }
                }
                while (true);
            }
            catch (Exception e)
            {
                Console.WriteLine("happen exception Receive_Message():" + e.Message);
            }
        }

        public struct moduleData
        {
            public byte[] command01;
            public byte[] command02;
            public byte[] command03;
            public byte[] command04;
            public moduleData(byte[] _cmd01, byte[] _cmd02, byte[] _cmd03, byte[] _cmd04)
            {
                this.command01 = _cmd01;
                this.command02 = _cmd02;
                this.command03 = _cmd03;
                this.command04 = _cmd04;
            }       			
        }

        private void initialModuleData()
        {
            for (int i = 0; i < g_moduleData.Length; i++)
            {
                g_moduleData[i].command01 = g_cmd0x01;
            }
        }

        private void ModuleSim_Load(object sender, EventArgs e)
        {

        }
    }
}
