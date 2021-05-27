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
    public partial class Service : Form
    {
        public Service()
        {
            InitializeComponent();
        }

        private void Detail_Click(object sender, EventArgs e)
        {
            FoodBill f = new FoodBill();
            f.Show();
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
