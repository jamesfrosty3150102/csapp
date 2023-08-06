using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DataGridViewTest3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataGridView DGV = new DataGridView();
            DGV.Dock = DockStyle.Fill;
            DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGV.ColumnHeadersDefaultCellStyle.BackColor = Color.LimeGreen;
            //dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.Black;
            DGV.RowHeadersDefaultCellStyle.BackColor = Color.Salmon;
            //dataGridView1.DefaultCellStyle.SelectionBackColor = Color.White;
            DGV.DefaultCellStyle.SelectionBackColor= Color.LimeGreen; 
            this.Controls.Add(DGV);
            DataTable dataTable = new DataTable();
            bool result = false;
            for (int i = 0; i < 16; i++)
            {
                //dataTable.Columns.Add("Bit" + i.ToString(), typeof(byte));
                dataTable.Columns.Add("Bit" + i.ToString(), typeof(string));
            }
            DGV.DataSource = dataTable;
            //Byte[] row0 = new Byte[8] { 0x41, 0x50, 0x50, 0x00, 0x00, 0x00, 0x00, 0x00 };
            //Byte[] row1 = new Byte[8] { 0x41, 0x50, 0x50, 0x00, 0x00, 0x00, 0x4F, 0x4D };
            Byte[] row0 = new Byte[16] { 0x44, 0x50, 0x53, 0x54, 0x2D, 0x33, 0x30, 0x30, 0x30, 0x47, 0x42,0x20,0x41,0x00,0x00,0x00 };
            Byte[] row1 = new Byte[16] { 0x50, 0x41,0x43,0x4B,0x20,0x30,0x30,0x30,0x30,0x30,0x30,0x20,0x35,0x36,0x33,0x32 };
            string[] _row0 = new string[16];
#if false
            string[] _row0 = new string[16];
            string[] _data = new string[1];
            for (int i = 0; i < row0.Length; i++)
            {
                _data[0] = row0[i].ToString("X");
                Array.Copy(_data, 0, _row0, i, 1);
            }
            dataTable.Rows.Add(_row0); 
#endif
            _row0 = dataInsert(row0);
            dataTable.Rows.Add(_row0);

        }

        private string[] dataInsert(Byte[] DataInRow)
        {
            string[] _dataArrange = new string[1];
            string[] _dataRow = new string[16];
            for (int i = 0; i < DataInRow.Length; i++)
            {
                _dataArrange[0] = DataInRow[i].ToString("X");
                Array.Copy(_dataArrange, 0, _dataRow, i, 1);
            }
            return _dataRow;
        }
    }
}
