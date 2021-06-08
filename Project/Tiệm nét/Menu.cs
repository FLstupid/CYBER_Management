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
        Staff st = new Staff();
        Computer c = new Computer();
        branch b = new branch();
        Service service = new Service();
        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            DialogResult CheckExit = MessageBox.Show("Có muốn Exit không?", "Exit confirm!",

            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (CheckExit == DialogResult.Yes)  Application.Exit();
        }

        private void btStaff_Click(object sender, EventArgs e)
        {
            Panel_show.Controls.Clear();
            
            st.TopLevel = false;
            Panel_show.Controls.Add(st);
            Panel_show.Visible = true;
            st.Show();
            st.FormClosed += Closed_event;
        }

        private void Closed_event(object sender, FormClosedEventArgs e)
        {
            Panel_show.Visible = false;
        }

        private void btComputer_Click(object sender, EventArgs e)
        {
            Panel_show.Controls.Clear();
            c.TopLevel = false;
            Panel_show.Controls.Add(c);
            Panel_show.Visible = true;
            c.Show();
            c.FormClosed += Closed_event;
        }

        private void btBranch_Click(object sender, EventArgs e)
        {
            Panel_show.Controls.Clear();
            b.TopLevel = false;
            Panel_show.Controls.Add(b);
            b.Show();
            Panel_show.Visible = true;
            b.FormClosed += Closed_event;
        }

        private void btService_Click(object sender, EventArgs e)
        {
            Panel_show.Controls.Clear();
            service.TopLevel = false;
            Panel_show.Controls.Add(service);
            service.Show();
            Panel_show.Visible = true;
            service.FormClosed += Closed_event;
        }

        private void btCustomer_Click(object sender, EventArgs e)
        {
            Panel_show.Controls.Clear();
            Customer s = new Customer();
            s.TopLevel = false;
            Panel_show.Controls.Add(s);
            s.Show();
            Panel_show.Visible = true;
            s.FormClosed += Closed_event;
        }

        private void guna2ImageButton1_Click_1(object sender, EventArgs e)
        {

            Panel_show.Controls.Clear();
            FoodCategries s = new FoodCategries();
            s.TopLevel = false;
            Panel_show.Controls.Add(s);
            s.Show();
            Panel_show.Visible = true;
            s.FormClosed += Closed_event;
        }

        private void btBillmerchant_Click(object sender, EventArgs e)
        {
            Panel_show.Controls.Clear();
            InfoBill s = new InfoBill();
            s.TopLevel = false;
            Panel_show.Controls.Add(s);
            s.Show();
            Panel_show.Visible = true;
            s.FormClosed += Closed_event;
        }

        private void btStatistic_Click(object sender, EventArgs e)
        {
            Panel_show.Controls.Clear();
            Statistic s = new Statistic();
            s.TopLevel = false;
            Panel_show.Controls.Add(s);
            s.Show();
            Panel_show.Visible = true;
            s.FormClosed += Closed_event;
        }
    }
}
