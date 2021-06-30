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
    public partial class BranchReport : Form
    {
        public BranchReport()
        {
            InitializeComponent();
        }

        private void BranchReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsBranch.Chinhanh' table. You can move, or remove it, as needed.
            this.ChinhanhTableAdapter.Fill(this.dsBranch.Chinhanh);

            this.reportViewer1.RefreshReport();
        }
    }
}
