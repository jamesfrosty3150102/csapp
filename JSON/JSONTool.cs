using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using TPActionDll;

namespace TestPlanCreateJSON
{
    public partial class JSONTool : Form
    {
        //static int g_testCount = 0;//記錄CSV中共有多少筆
        //SBSData[] g_SBSData = new SBSData[1];//用來讀入config_SBS文件中的定義
        //TPActionDll.ActionDll ActionDll = new ActionDll();

        struct SBSData
        {
            public string Catalog;
            public string ID;
            public string Function;
            public string DeviceAddress;
            public string Channel;
            public string Output;
            public string Voltage;
            public string Current;
            public string Log;
            public string RunIfFail;

            public SBSData(string m_catalog, string m_id,string m_function,string m_deviceaddress,string m_channel,string m_output,string m_voltage,string m_current,string m_log,string m_runiffail)
            {
                this.Catalog = m_catalog;
                this.ID = m_id;
                this.Function = m_function;
                this.DeviceAddress = m_deviceaddress;
                this.Channel = m_channel;
                this.Output = m_output;
                this.Voltage = m_voltage;
                this.Current = m_current;
                this.Log = m_log;
                this.RunIfFail = m_runiffail;
            }
        }
        public JSONTool()
        {
            InitializeComponent();
            //GetSBSConfigDataCount();
            #region ComboBox1
            comboBox1.Items.Add("OV1");
            comboBox1.Items.Add("OV2");
            comboBox1.Items.Add("OV3");
            comboBox1.Items.Add("UV1");
            comboBox1.Items.Add("UV2");
            comboBox1.Items.Add("UV3");
            comboBox1.Items.Add("OTC1");
            comboBox1.Items.Add("OTC2");
            comboBox1.Items.Add("OTC3");
            comboBox1.Items.Add("UTC1");
            comboBox1.Items.Add("UTC2");
            comboBox1.Items.Add("UTC3");
            comboBox1.Items.Add("OTD1");
            comboBox1.Items.Add("OTD2");
            comboBox1.Items.Add("OTD3");
            comboBox1.Items.Add("OTD4");
            comboBox1.Items.Add("UTD1");
            comboBox1.Items.Add("UTD2");
            comboBox1.Items.Add("UTD3");
            comboBox1.Items.Add("FET_OT-1");
            comboBox1.Items.Add("FET_OT-2");
            comboBox1.Items.Add("FET_OT-3");
            comboBox1.Items.Add("FET_OT-4");
            comboBox1.Items.Add("CFETF");
            comboBox1.Items.Add("DFETF");
            comboBox1.Items.Add("SUV");
            comboBox1.Items.Add("SOV");
            comboBox1.Items.Add("UTC3noCHG");
            comboBox1.Items.Add("CFETFFuse");
            comboBox1.Items.Add("DFETFFuse");
            #endregion ComboBox1
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public class FDK3KWJson
        {
            //public string Catalog { get; set; }
            //public string ID { get; set; }
            //public Items items;
            public IList<Items> ItemName { get; set; }
            public IList<Items> ItemName2 { get; set; }
            public IList<Items> ItemName3 { get; set; } 
        }
        public class Items
        {
            public string ItemNo;
            public string Enable;
            public string Description;
            //public List<string> Procedure = new List<string> { };
            //public IList<toolSetting> Procedure2 { get; set; }        //<要填class 名稱>
            public List<toolSetting> Procedure = new List<toolSetting>
            {
                new toolSetting{Catalog = "Relay",ID = "R0001",Function = "SetChannel",CellNTCCurrent = "Cell1",PFFuse = "PF",Output = "On",Time = null,Log = "Y",RunIfFail = "Y"}, //先切換 Cell1,NTCTS5,NTCTS1,Current
                new toolSetting{Catalog = "4ChPowerSupply",ID = "4P1001",Function= "SetVoltage(V)",DeviceAddress="7",Channel="1",Output = "On",Voltage = "4000",Current = "3000",Log = "Y",RunIfFail="Y",},
                new toolSetting{Catalog = "4ChPowerSupply",ID = "4P1001",Function= "SetVoltage(V)",DeviceAddress="7",Channel="2",Output = "On",Voltage = "4000",Current = "3000",Log = "Y",RunIfFail="Y",},
                new toolSetting{Catalog = "4ChPowerSupply",ID = "4P1001",Function= "SetVoltage(V)",DeviceAddress="7",Channel="3",Output = "On",Voltage = "4000",Current = "3000",Log = "Y",RunIfFail="Y",},
                new toolSetting{Catalog = "4ChPowerSupply",ID = "4P1001",Function= "SetVoltage(V)",DeviceAddress="7",Channel="4",Output = "On",Voltage = "4000",Current = "3000",Log = "Y",RunIfFail="Y",},
                new toolSetting{Catalog = "Function",ID = "Func501",Time = "15000",Log = "Y",RunIfFail = "Y"},
            };
            public List<toolSetting> Procedure2 = new List<toolSetting>
            {
                new toolSetting{Catalog = "4ChPowerSupply",ID = "4P1001",Function= "SetVoltage(V)",DeviceAddress="7",Channel="1",Output = "On",Voltage = "4100",Current = "3000",Log = "Y",RunIfFail="Y",},
                new toolSetting{Catalog = "4ChPowerSupply",ID = "4P1001",Function= "SetVoltage(V)",DeviceAddress="7",Channel="2",Output = "On",Voltage = "4000",Current = "3000",Log = "Y",RunIfFail="Y",},
                new toolSetting{Catalog = "4ChPowerSupply",ID = "4P1001",Function= "SetVoltage(V)",DeviceAddress="7",Channel="3",Output = "On",Voltage = "4000",Current = "3000",Log = "Y",RunIfFail="Y",},
                new toolSetting{Catalog = "4ChPowerSupply",ID = "4P1001",Function= "SetVoltage(V)",DeviceAddress="7",Channel="4",Output = "On",Voltage = "4000",Current = "3000",Log = "Y",RunIfFail="Y",},
            };
            public List<toolSetting> Procedure3 = new List<toolSetting>
            {
                new toolSetting{Catalog = "4ChPowerSupply",ID = "4P1001",Function= "SetVoltage(V)",DeviceAddress="7",Channel="1",Output = "On",Voltage = "4000",Current = "3000",Log = "Y",RunIfFail="Y",},
                new toolSetting{Catalog = "4ChPowerSupply",ID = "4P1001",Function= "SetVoltage(V)",DeviceAddress="7",Channel="2",Output = "On",Voltage = "4000",Current = "3000",Log = "Y",RunIfFail="Y",},
                new toolSetting{Catalog = "4ChPowerSupply",ID = "4P1001",Function= "SetVoltage(V)",DeviceAddress="7",Channel="3",Output = "On",Voltage = "4000",Current = "3000",Log = "Y",RunIfFail="Y",},
                new toolSetting{Catalog = "4ChPowerSupply",ID = "4P1001",Function= "SetVoltage(V)",DeviceAddress="7",Channel="4",Output = "On",Voltage = "4000",Current = "3000",Log = "Y",RunIfFail="Y",},
            };
        }

        public class toolSetting
        {
            public string Catalog { get; set; }
            public string ID { get; set; }
            public string Function { get; set; }
            public string DeviceAddress { get; set; }
            public string Channel { get; set; } //Power Supply Channel
            public string Output { get; set; }
            public string Voltage { get; set; }
            public string Current { get; set; }
            public string Log { get; set; }
            public string RunIfFail { get; set; }
            public string Time { get; set; }
            public string PFFuse{get;set;}
            public string CellNTCCurrent{get;set;}
        }
#if debug
        private void GetSBSConfigDataCount()
        {
            StreamReader _reader = new StreamReader(Application.StartupPath + "\\" + "Config_createJSON.csv");
            while (!_reader.EndOfStream)
            {
                _reader.ReadLine();
                g_testCount++;
            }
            g_testCount = g_testCount - 1;//減去標頭
            Array.Resize(ref g_SBSData, g_testCount);
            _reader.Close();
            _reader.Dispose();
        }
#endif

        private void btnTPtoJSON_Click(object sender, EventArgs e)
        {
            var fdk3kw = new FDK3KWJson
            {
                ItemName = new List<Items>  //正常波型
                {
                    new Items{ItemNo = "0001",Enable = "Y",Description ="OV1",
                        //Procedure= new List<toolSetting>
                        //{             
                        //},
                    }
                },
                ItemName2 = new List<Items> //Trigger波型
                {
                    new Items{ItemNo = "002",Enable = "Y",Description ="OV2", 
                        Procedure= new List<toolSetting>
                        {                       
                        },
                        Procedure2= new List<toolSetting>
                        {                       
                        },
                        Procedure3= new List<toolSetting>
                        {                       
                        },
                    }
                },
                ItemName3 = new List<Items> //Release 波型
                {
                    new Items{ItemNo = "003",Enable = "Y",Description ="OV3", 
                        Procedure2= new List<toolSetting>
                        {      
                            new toolSetting{Catalog = "4ChPowerSupply",ID = "4P1003",Function= "OV3Release",DeviceAddress="7",Channel="3",Output = "On",},
                        },
                    }
                },

                //items = new Items
                //{
                //    ItemNo = "0001",
                //    Enable = "Y",
                //    Description = "OV1",   //測試名稱
                //    Procedure = new List<toolSetting>
                //    {
                //     new toolSetting{Catalog = "",ID = "",Function = "",DeviceAddress = "",Channel = "",Output="",Voltage= "",Current="",Log = "",RunIfFail= ""}
                //  }
                //},

            };
            string fileName = "FDK3KW.json";
            //string jsonString = JsonConvert.SerializeObject(fdk3kw);
            string jsonString = JsonConvert.SerializeObject(fdk3kw,Formatting.Indented,new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
            Console.WriteLine(jsonString);
            File.WriteAllText((Application.StartupPath + "//" + fileName), jsonString);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string data = "George of the jungle";
            //ActionDll.dlltestAPI(ref data);
        }
    }
}
