﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CANAlystII_API;

namespace HostSimulate
{
    public partial class HostSimulate : Form
    {
        CANAlystII g_CANAdapter;
        Task g_sendTask;
        public HostSimulate()
        {
            InitializeComponent();
            InitialCANAdapter();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //do
            //{ 
            //    Console.WriteLine("button");            
            //}
            //while (true);
            //g_sendTask = new Task(Send_Message);
            bool _result = false;
            uint _moduelID = 0;
            byte[] _txFrame = null;
            string errorMessage = "";

            byte[] g_cmd0x61 = new byte[] { 0x52, 0x61, 0xFD, 0x38 };
            byte[] g_cmd0x62 = new byte[] { 0x52, 0x62, 0xBD, 0x39 };
            byte[] g_cmd0x63 = new byte[] { 0x52, 0x63, 0x7C, 0xF9 };
            byte[] g_cmd0x64 = new byte[] { 0x52, 0x64, 0x3D, 0x3B };
            byte[] g_cmd0x65 = new byte[] { 0x52, 0x65, 0xFC, 0xFB };
            byte[] g_cmd0x66 = new byte[] { 0x52, 0x66, 0xBC, 0xFA };
            byte[] g_cmd0x67 = new byte[] { 0x52, 0x67, 0x7D, 0x3A };
            byte[] g_cmd0x68 = new byte[] { 0x52, 0x68, 0x3D, 0x3E };
            byte[] g_cmd0x69 = new byte[] { 0x52, 0x69, 0xFC, 0xFE };
            byte[] g_cmd0x6A = new byte[] { 0x52, 0x6A, 0xBC, 0xFF };

            //_txFrame = new byte[] { 0x52,0x61,0xFD,0x38 };
            do
            {
                 _txFrame = g_cmd0x61;
                 _result = TransmitMessage(_moduelID + 0x0580, _txFrame, ref errorMessage);
                 if (_result)
                 {
                      Console.WriteLine("_txFrame:g_cmd0x61{0}", g_cmd0x61);
                 }
            }
            while (true);

        }

        private void InitialCANAdapter()
        {
            string errMsg = "";
            g_CANAdapter = new CANAlystII();
            if (!g_CANAdapter.DeviceConnected)
                g_CANAdapter = CANDeviceManager.Connect(VCI_CAN_DEVICE_TYPE.USBCAN1, 0, 0, CAN_BAUD_RATE.bps_500Kbps, ref errMsg);
        }

        //unsafe private void Send_Message()
        //{ 
        //}

        private bool TransmitMessage(UInt32 m_id, byte[] m_data, ref string m_errorMessage)
        {
            bool result = false;
            if (!g_CANAdapter.DeviceConnected)
            {
                return false;
            }
            string messageInfo = "";
            byte[] sendData = null;
            int copyLength = 0;
            int packetAmount = Convert.ToInt16(Math.Ceiling(Convert.ToDouble(m_data.Length) / 8));
            //canBus.AutoPullData = false;
            for (int j = 0; j < packetAmount; j++)
            {
                copyLength = 8;
                if (j == packetAmount - 1)
                {
                    if (m_data.Length % 8 != 0)
                        copyLength = m_data.Length % 8;
                }
                Array.Resize(ref sendData, copyLength);
                Array.Copy(m_data, 8 * j, sendData, 0, copyLength);
                messageInfo = "";
                for (int i = 0; i < sendData.Length; i++)
                {
                    messageInfo += Convert.ToString(sendData[i], 16).ToUpper().PadLeft(2, '0') + " ";
                }
                result = true;
                if (g_CANAdapter.Transmit(CAN_ID_TYPE.StanderID, m_id, sendData, sendData.Length, ref m_errorMessage))
                {
                    messageInfo = DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + ":" + DateTime.Now.Millisecond.ToString().PadLeft(3, '0') + "\tW:ID " + Convert.ToString(m_id, 16).ToUpper().PadLeft(4, '0') + "\t" + messageInfo + ",PASS";
                }
                else
                {
                    messageInfo = DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + ":" + DateTime.Now.Millisecond.ToString().PadLeft(3, '0') + "\tW:ID " + Convert.ToString(m_id, 16).ToUpper().PadLeft(4, '0') + "\t" + messageInfo + ",Fail";
                    result = false;
                    break;
                }
            }
            return result;
        }
    }
}