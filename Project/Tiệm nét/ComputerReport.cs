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
    public partial class ComputerReport : Form
    {
        public ComputerReport()
        {
            InitializeComponent();
        }

        private void ComputerReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsComputer.Maytinh' table. You can move, or remove it, as needed.
            this.MaytinhTableAdapter.Fill(this.dsComputer.Maytinh);

            this.reportViewer1.RefreshReport();
        }
    }
}
