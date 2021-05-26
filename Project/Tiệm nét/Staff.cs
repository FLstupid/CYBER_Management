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
            btEditOff();
        }
        Cyber_netEntities db = null;
        bool Add = false;
        void btEditOff()
        {
            btConfirm.Visible = false;
            btCancel.Visible = false;
            txtName.Enabled = false;
            txtAddress.Enabled = false;
            txtGender.Enabled = false;
            txtManager.Enabled = false;
            txtBranch.Enabled = false;
        }
        void btEditOn()
        {
            btConfirm.Visible = true;
            btCancel.Visible = true;
            txtName.Enabled = true;
            txtAddress.Enabled = true;
            txtGender.Enabled = true;
            txtManager.Enabled = true;
            txtBranch.Enabled = true;
        }

        void Reset()
        {
            txtstaffID.ResetText();
            txtName.ResetText();
            txtAddress.ResetText();
            txtBranch.ResetText();
            txtGender.ResetText();
            txtManager.ResetText();
        }
        private void LoadData()
        {
            try
            {
                db = new Cyber_netEntities();
                var data = db.Nhanviens.ToList();
                foreach (var Item in data)
                {
                    txtstaffID.AutoCompleteCustomSource.Add(Item.Id.ToString());
                    txtManager.AutoCompleteCustomSource.Add(Item.Nhanvien2.Name);
                    txtBranch.AutoCompleteCustomSource.Add(Item.Chinhanh.Chinhanh1);
                }
                Loadinfo();
            }catch(Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void Loadinfo()
        {
            if (txtstaffID.Text.Equals("")) txtstaffID.Text = "1";
            var data = db.Nhanviens.ToList();
            int StaffID = int.Parse(txtstaffID.Text.Trim());
            Nhanvien Staff = data.Where(x => x.Id == StaffID).SingleOrDefault();
            txtName.Text = Staff.Name;
            txtAddress.Text = Staff.Address;
            txtBranch.Text = Staff.Chinhanh.Chinhanh1;
            txtGender.Text = Staff.Gender.Trim();
            txtManager.Text = Staff.Nhanvien2.Name;
        }
        private void btconfirm_Click(object sender, EventArgs e)
        {
            btEditOff();
            if (Add) {
                try
                {
                    db.Nhanviens.Add(new Nhanvien
                    {
                        Id = int.Parse(txtstaffID.Text.Trim()),
                        Address = txtAddress.Text,
                        Gender = txtGender.Text.Trim(),
                        Name = txtName.Text,
                        Id_Manager = db.Nhanviens.ToList().SingleOrDefault(x => x.Name == txtManager.Text).Id,
                        Id_chinhanh = db.Chinhanhs.ToList().SingleOrDefault(x => x.Chinhanh1 == txtBranch.Text).Id
                    }) ;
                    db.SaveChanges();
                    LoadData();
                    // Thông báo
                    MessageBox.Show("Đã thêm dữ liệu thành công!");
                }
                catch (Exception) { MessageBox.Show("Error Save"); }
            }
            else
            {
                try
                {
                    Nhanvien staff = db.Nhanviens.ToList().SingleOrDefault(x => x.Id == int.Parse(txtstaffID.Text.Trim()));
                    staff.Address = txtAddress.Text;
                    staff.Gender = txtGender.Text.Trim();
                    if (txtManager.Text.Equals(txtName.Text)) staff.Id_Manager = int.Parse(txtstaffID.Text.Trim());
                    else
                        staff.Id_Manager = db.Nhanviens.ToList().SingleOrDefault(x => x.Name == txtManager.Text).Id;
                    staff.Id_chinhanh = db.Chinhanhs.ToList().SingleOrDefault(x => x.Chinhanh1 == txtBranch.Text).Id;
                    staff.Name = txtName.Text;
                    db.SaveChanges();

                    LoadData();
                    MessageBox.Show("Đã sửa xong!");
                }
                catch (Exception)
                {
                    MessageBox.Show("Error Edit");
                }
            }
        }
        private void btcancel_Click(object sender, EventArgs e)
        {
            btEditOff();
            Reset();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            Add = true;
            btEditOn();
            Reset();
        }

        private void Staff_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btReload_Click(object sender, EventArgs e)
        {
            LoadData();
            Loadinfo();
            btEditOff();
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            Add = false;
            btEditOn();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            DialogResult CheckYN;
            CheckYN = MessageBox.Show("Có chắc xóa không?", "Trả lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (CheckYN == DialogResult.Yes)
            {
                try
                {
                    string staffID = txtstaffID.Text.Trim();

                    // Lệnh truy vấn SQL
                    Nhanvien staff = db.Nhanviens.ToList().SingleOrDefault(x => x.Id == int.Parse(staffID));
                    db.Nhanviens.Remove(staff);
                    db.SaveChanges();
                    // Thông báo
                    MessageBox.Show("Đã xóa thành công staff ID = " + staffID + ".");

                }
                catch (Exception)
                {
                    MessageBox.Show("Không xóa được staff hiện hành.");
                }
            }
        }
    }
}
