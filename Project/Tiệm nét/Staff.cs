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

        void Reset()
        {
            txtname.ResetText();
            txtaddress.ResetText();
            txtbranch.ResetText();
            txtgender.ResetText();
            txtmanager_id.ResetText();
        }
        private void LoadData()
        {
            if (txtstaffID.Equals(""))
                txtstaffID.Text = "1";
            try
            {
                db = new Cyber_netEntities();
                var data = db.Nhanviens.ToList();
                int StaffID = int.Parse(txtstaffID.Text.Trim());
                Nhanvien Staff = data.Where(x => x.Id == StaffID).SingleOrDefault();
            //Reset();
            txtname.Text = Staff.Id.ToString();
            txtaddress.Text = Staff.Address;
            txtbranch.Text = Staff.Chinhanh.ToString();
            txtgender.Text = Staff.Gender;
            txtmanager_id.Text = Staff.Id_Manager.ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
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

        private void Staff_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
