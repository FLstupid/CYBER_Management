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
    public partial class CustomerReport : Form
    {
        public CustomerReport()
        {
            InitializeComponent();
        }

        private void CustomerReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsCustomer.Khachhang' table. You can move, or remove it, as needed.
            this.KhachhangTableAdapter.Fill(this.dsCustomer.Khachhang);

            this.reportViewer1.RefreshReport();
        }
    }
}
