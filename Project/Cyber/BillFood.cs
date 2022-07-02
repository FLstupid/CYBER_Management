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
    public partial class BillFood : Form
    {
        public BillFood()
        {
            InitializeComponent();
        }

        private void BillFood_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsBill_Food.Chitiet_hoadon' table. You can move, or remove it, as needed.
            this.Chitiet_hoadonTableAdapter.Fill(this.dsBill_Food.Chitiet_hoadon);

            this.reportViewer1.RefreshReport();
        }
    }
}
