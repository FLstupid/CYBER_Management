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
    public partial class Staff : Form
    {
        public Staff()
        {
            InitializeComponent();
        }
        Cyber_netEntities db = null;
        bool Add = false;
        void btEditOff(object sender, EventArgs e)
        {
            btconfirm.Visible = false;
            btcancel.Visible = false;
        }
        void btEditOn()
        {
            btconfirm.Visible = true;
            btcancel.Visible = true;
        }
        private void LoadData()
        {
            db = new Cyber_netEntities();
            
        }
        private void btconfirm_Click(object sender, EventArgs e)
        {
            
           
        }
        private void btcancel_Click(object sender, EventArgs e)
        {
           
         
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            Add = true;
            btEditOn();
        }
    }
}
