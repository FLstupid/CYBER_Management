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
    public partial class InfoBill : Form
    {
        public InfoBill()
        {
            InitializeComponent();
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Detail_Click(object sender, EventArgs e)
        {
            Bill b = new Bill();
            b.Show();
        }
    }
}
