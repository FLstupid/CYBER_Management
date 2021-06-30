using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tiệm_nét
{
    public partial class BillFoodstatisticReport : Form
    {
        public BillFoodstatisticReport()
        {
            InitializeComponent();
        }

        private void BillFoodstatisticReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsBillFoodstatistics.Hoadon_thucan' table. You can move, or remove it, as needed.
            this.Hoadon_thucanTableAdapter.Fill(this.dsBillFoodstatistics.Hoadon_thucan);
            // TODO: This line of code loads data into the 'dsBranch.Chinhanh' table. You can move, or remove it, as needed.
            this.ChinhanhTableAdapter.Fill(this.dsBranch.Chinhanh);

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
