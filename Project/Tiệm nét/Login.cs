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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private int count = 0;
        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            DialogResult CheckExit = MessageBox.Show("Có muốn Exit không?", "Exit confirm!",

            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (CheckExit == DialogResult.Yes) this.Close();
        }

        private void btEnter_Click(object sender, EventArgs e)
        {
            try
            {
                count += 1;
                Cyber_netEntities db = new Cyber_netEntities();
                int uid = int.Parse(txtUser.Text);
                var us = db.Nhanviens.ToList().Select(x => x.Id == uid && x.Name == txtPassword.Text).Count();
                if (us > 0)
                {
                    MessageBox.Show("Đăng nhập thành công !");
                    Hide();
                    Loading l = new Loading();
                    l.Show();
                }
                else
                {
                    MessageBox.Show($"Wrong name or password ! {count} Times");
                    if (count > 3) Application.Exit();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.') e.Handled = true;
            if (e.KeyChar == '.' && ((TextBox)sender).Text.IndexOf('.') > -1) e.Handled = true;
        }
    }
}
