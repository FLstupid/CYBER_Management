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
        Customer cus = new Customer();
        FoodCategries cate = new FoodCategries();
        InfoBill Fbill = new InfoBill();
        Statistic Fstatistic = new Statistic();
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
        }

        private void btComputer_Click(object sender, EventArgs e)
        {
            Panel_show.Controls.Clear();
            c.TopLevel = false;
            Panel_show.Controls.Add(c);
            Panel_show.Visible = true;
            c.Show();
        }

        private void btBranch_Click(object sender, EventArgs e)
        {
            Panel_show.Controls.Clear();
            b.TopLevel = false;
            Panel_show.Controls.Add(b);
            b.Show();
            Panel_show.Visible = true;
        }

        private void btService_Click(object sender, EventArgs e)
        {
            Panel_show.Controls.Clear();
            service.TopLevel = false;
            Panel_show.Controls.Add(service);
            service.Show();
            Panel_show.Visible = true;
        }

        private void btCustomer_Click(object sender, EventArgs e)
        {
            Panel_show.Controls.Clear();
            cus.TopLevel = false;
            Panel_show.Controls.Add(cus);
            cus.Show();
            Panel_show.Visible = true;
        }

        private void guna2ImageButton1_Click_1(object sender, EventArgs e)
        {
            Panel_show.Controls.Clear();
            cate.TopLevel = false;
            Panel_show.Controls.Add(cate);
            cate.Show();
            Panel_show.Visible = true;
        }

        private void btBillmerchant_Click(object sender, EventArgs e)
        {
            Panel_show.Controls.Clear();
            Fbill.TopLevel = false;
            Panel_show.Controls.Add(Fbill);
            Fbill.Show();
            Panel_show.Visible = true;
        }

        private void btStatistic_Click(object sender, EventArgs e)
        {
            Panel_show.Controls.Clear();
            Fstatistic.TopLevel = false;
            Panel_show.Controls.Add(Fstatistic);
            Fstatistic.Show();
            Panel_show.Visible = true;
        }

        private void btMinize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
