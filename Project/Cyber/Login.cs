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
        private int counted = 0;
        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            DialogResult CheckExit = MessageBox.Show("Có muốn Exit không?", "Exit confirm!",

            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (CheckExit == DialogResult.Yes) Application.Exit();
        }

        private void btEnter_Click(object sender, EventArgs e)
        {
            try
            {
                counted += 1;
                Cyber_netEntities db = new Cyber_netEntities();
                int uid = int.Parse(txtUser.Text);
                var us = db.Nhanviens;
                foreach(var i in us)
                {
                    if(i.Id == uid && i.Name == txtPassword.Text)
                    {
                        counted = -1;
                        break;
                    }
                }
                if (counted == -1)
                {
                    MessageBox.Show("Đăng nhập thành công !");
                    Hide();
                    Loading l = new Loading();
                    l.Show();
                }
                else
                {
                    MessageBox.Show($"Wrong name or password ! {counted} Times");
                    if (counted > 3) Application.Exit();
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
