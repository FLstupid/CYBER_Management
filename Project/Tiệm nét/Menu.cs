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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            DialogResult CheckExit = MessageBox.Show("Có muốn Exit không?", "Exit confirm!",

            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (CheckExit == DialogResult.Yes) this.Close();
        }

        private void btStaff_Click(object sender, EventArgs e)
        {
            Panel.Controls.Clear();
            Staff s = new Staff();
            s.TopLevel = false;
            Panel.Controls.Add(s);
            s.Show();
            s.FormClosed += Closed_event;
        }

        private void Closed_event(object sender, FormClosedEventArgs e)
        {
            Resoce r = new Resoce();
            r.TopLevel = false;
            Panel.Controls.Add(r);
            r.Show();
        }

        private void Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btComputer_Click(object sender, EventArgs e)
        {
            Panel.Controls.Clear();
            Computer c = new Computer();
            c.TopLevel = false;
            Panel.Controls.Add(c);
            c.Show();
            c.FormClosed += Closed_event;
        }

        private void btBranch_Click(object sender, EventArgs e)
        {
            Panel.Controls.Clear();
            branch b = new branch();
            b.TopLevel = false;
            Panel.Controls.Add(b);
            b.Show();
            b.FormClosed += Closed_event;
        }

        private void btService_Click(object sender, EventArgs e)
        {
            Panel.Controls.Clear();
            Service s = new Service();
            s.TopLevel = false;
            Panel.Controls.Add(s);
            s.Show();
            s.FormClosed += Closed_event;
        }

        private void btCustomer_Click(object sender, EventArgs e)
        {
            Panel.Controls.Clear();
            Customer s = new Customer();
            s.TopLevel = false;
            Panel.Controls.Add(s);
            s.Show();
            s.FormClosed += Closed_event;
        }

        private void guna2ImageButton1_Click_1(object sender, EventArgs e)
        {

            Panel.Controls.Clear();
            FoodCategries s = new FoodCategries();
            s.TopLevel = false;
            Panel.Controls.Add(s);
            s.Show();
            s.FormClosed += Closed_event;
        }

        private void btBillmerchant_Click(object sender, EventArgs e)
        {
            Panel.Controls.Clear();
            InfoBill s = new InfoBill();
            s.TopLevel = false;
            Panel.Controls.Add(s);
            s.Show();
            s.FormClosed += Closed_event;
        }

        private void btStatistic_Click(object sender, EventArgs e)
        {
            Panel.Controls.Clear();
            Statistic s = new Statistic();
            s.TopLevel = false;
            Panel.Controls.Add(s);
            s.Show();
            s.FormClosed += Closed_event;
        }
    }
}
