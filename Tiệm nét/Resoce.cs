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
    public partial class Resoce : Form
    {
        public Resoce()
        {
            InitializeComponent();
        }

        private void btStatistic_Click(object sender, EventArgs e)
        {
            this.Close();
            Statistic s = new Statistic();
            s.Show();
        }

        private void btBillmerchant_Click(object sender, EventArgs e)
        {
            this.Close();
            InfoBill s = new InfoBill();
            s.Show();
        }
    }
}
