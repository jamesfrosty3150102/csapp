using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            this.Controls.Add(DGV);
            DataTable dataTable = new DataTable();
            for (int i = 0; i < 16; i++)
            {
                dataTable.Columns.Add("Bit" + i.ToString(), typeof(byte));
            }
            DGV.DataSource = dataTable;

        }
    }
}
