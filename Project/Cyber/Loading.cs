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
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();
        }
       
        int time = 0;
        private void timer_Tick(object sender, EventArgs e)
        {
            time++;
            if (time == 30)
            
                {
                timer.Stop();
                Hide();
                Menu m = new Menu();
                m.Show();
                } 
        }
    }
}
