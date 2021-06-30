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
    public partial class BillReport : Form
    {
        public BillReport()
        {
            InitializeComponent();
        }

        private void BillReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsBill.Hoadon' table. You can move, or remove it, as needed.
            this.HoadonTableAdapter.Fill(this.dsBill.Hoadon);

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
