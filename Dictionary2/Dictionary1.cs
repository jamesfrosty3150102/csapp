using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dictionary1
{
    public partial class Dictionary1 : Form
    {
        Dictionary<int, DataGridView> SBSViews = new Dictionary<int, DataGridView>();
        int CurrentGridCount = 0;

        public Dictionary1()
        {
            InitializeComponent();
        }

        void InitiateSBSUIByMaximum2Grid()
        {
            #region
            List<string> PresentDataList = new List<string>();
            for (int i = 0; i < this.CurrentGridCount; i++)
            {
                DataGridView dg = this.SBSViews[i];

                for (int RowIndex = 0; RowIndex < dg.Rows.Count; RowIndex++)
                    PresentDataList.Add(dg["VALUE",RowIndex].Value.ToString());
            }
            #endregion
        }
    }
}
