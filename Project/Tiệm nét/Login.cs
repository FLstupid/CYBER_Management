﻿using System;
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

     

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            DialogResult CheckExit = MessageBox.Show("Có muốn Exit không?", "Exit confirm!",

            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (CheckExit == DialogResult.Yes) this.Close();
        }

        private void btEnter_Click(object sender, EventArgs e)
        {
            Hide();
            Loading l = new Loading();
            l.Show();

        }
    }
}
