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

namespace DeltaPowerBank
{
    public partial class ModuleSim : Form
    {
        CANAlystII g_CANAdapter;
        Task g_receiveTask;
        public ModuleSim()
        {
            InitializeComponent();
            InitialCANAdapter();
        }

        private void InitialCANAdapter()
        {
            string errMsg = "";
            g_CANAdapter = new CANAlystII();
            if (!g_CANAdapter.DeviceConnected)
                g_CANAdapter = CANDeviceManager.Connect(VCI_CAN_DEVICE_TYPE.USBCAN1, 0, 0, CAN_BAUD_RATE.bps_500Kbps, ref errMsg);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //g_receiveTask = new Task(Receive_Message);
            Receive_Message();
        }

        unsafe private void Receive_Message()
        {
            UInt32 res = new UInt32();
            string errorMessage = "";
            structCANBusDataInfo[] m_recobj = new structCANBusDataInfo[2500];
            do
            {
                res = g_CANAdapter.ReceiveData(ref m_recobj, ref errorMessage);
                if (res == 0xffffffff)
                {
                    errorMessage = "收到資料量達到上限";
                }
                else
                { 
                    for(int i=0;i<res;i++)
                    {
                        Console.WriteLine(m_recobj);
                        //Console.WriteLine(m_recobj.data);

                    }
                }
            }
            while(true);
        }
    }
}
