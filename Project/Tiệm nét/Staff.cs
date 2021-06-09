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
            btConfirm.Visible = btCancel.Visible = txtName.Enabled = txtAddress.Enabled = txtGender.Enabled = txtManager.Enabled = txtBranch.Enabled = false;
            btAdd.Enabled = true;
            btEdit.Enabled = true;
            btDelete.Enabled = true;
        }
        void btEditOn()
        {
            btConfirm.Visible = btCancel.Visible = txtName.Enabled = txtAddress.Enabled = txtGender.Enabled = txtManager.Enabled = txtBranch.Enabled = true;
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
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            var dt = db.Nhanviens.ToList();
            var datas = from i in dt select new { i.Id, i.Name, i.Gender, i.Address, i.Id_Manager, i.Id_chinhanh };
            Dataview.DataSource = datas.ToList();
        }
        private void Loadinfo()
        {
            if (txtstaffID.Text.Equals("")) txtstaffID.Text = "1";
            int result;
            if (int.TryParse(txtstaffID.Text.Trim(), out result))
                if (db.Nhanviens.ToList().Where(x => x.Id == result).Count() == 0)
                {
                    MessageBox.Show("Staff id not exist");
                    txtstaffID.Focus();
                }
                else
                {
                    var data = db.Nhanviens.ToList();
                    Nhanvien Staff = data.Where(x => x.Id == result).SingleOrDefault();
                    txtName.Text = Staff.Name;
                    txtAddress.Text = Staff.Address;
                    txtGender.Text = Staff.Gender.Trim();
                    txtBranch.Text = Staff.Chinhanh.Chinhanh1;
                    txtManager.Text = Staff.Nhanvien2.Name;
                }
        }
        private void btconfirm_Click(object sender, EventArgs e)
        {
            var manager = db.Nhanviens.ToList().Where(x => x.Name == txtManager.Text).Count();
            var branch = db.Chinhanhs.ToList().Where(x => x.Chinhanh1 == txtBranch.Text).Count();
            if (manager == 0) { MessageBox.Show("Manager name not exist"); }
            else if (branch == 0) { MessageBox.Show("Branch name not exist"); }
            else
            {
                btEditOff();
                if (Add)
                {
                    if (txtstaffID.Text == "") MessageBox.Show(@"Chưa nhập id nhân viên ! Vui lòng nhập id.", @"Message", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    else if (txtName.Text == "") MessageBox.Show("Chưa nhập tên nhân viên! Vui lòng nhập tên nhân viên", @"Message", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    else if (txtAddress.Text == "") MessageBox.Show("Chưa nhập địa chỉ nhân viên! Vui lòng nhập địa chỉ nhân viên", @"Message", MessageBoxButtons.OK,
                         MessageBoxIcon.Warning);
                    else if (txtBranch.Text == "") MessageBox.Show("Chưa nhập chi nhánh quản lý nhân viên! Vui lòng nhập chi nhánh", @"Message", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    else if (txtGender.Text == "") MessageBox.Show("Chưa nhập hoặc nhập sai giới tính! Vui lòng nhập giới tính", @"Message", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    else if (txtManager.Text == "") MessageBox.Show("Chưa nhập tên quản lý! Vui lòng nhập tên quản lý phụ trách", @"Message", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    else
                    {
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
                            });
                            db.SaveChanges();
                            LoadData();
                            MessageBox.Show("Đã thêm dữ liệu thành công!");
                        }
                        catch (Exception) { MessageBox.Show("Error Save"); }
                    }
                }
                else
                {
                    if (txtstaffID.Text == "") MessageBox.Show("Chưa nhập id nhân viên! Vui lòng nhập ID", @"Message", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    else if (txtName.Text == "") MessageBox.Show("Chưa nhập tên nhân viên! Vui lòng nhập tên nhân viên", @"Message", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    else if (txtAddress.Text == "") MessageBox.Show("Chưa nhập địa chỉ nhân viên! Vui lòng nhập địa chỉ nhân viên", @"Message", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    else if (txtBranch.Text == "") MessageBox.Show("Chưa nhập chi nhánh quản lý nhân viên! Vui lòng nhập chi nhánh", @"Message", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    else if (txtGender.Text == "") MessageBox.Show("Chưa nhập hoặc nhập sai giới tính! Vui lòng nhập nam hoặc nữ", @"Message", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    else if (txtManager.Text == "") MessageBox.Show("Chưa nhập tên quản lý! Vui lòng nhập tên quản lý phụ trách", @"Message", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
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
            }
        }
        private void btcancel_Click(object sender, EventArgs e)
        {
            Add = false;
            Reset();
            btEditOff();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            Add = true;
            btEditOn();
            Reset();
            btEdit.Enabled = false;
            btDelete.Enabled = false;
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
            if (txtstaffID.Text.Equals(""))
            { MessageBox.Show("Staff id can not null"); }
            else
            {
                Add = false;
                btEditOn();
                btAdd.Enabled = false;
                btDelete.Enabled = false;
                txtstaffID.Enabled = false;
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (txtstaffID.Text.Equals("")) { MessageBox.Show("Staff id can not null"); }
            else
            {
                DialogResult CheckYN;
                CheckYN = MessageBox.Show("Có chắc xóa không?", "Trả lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (CheckYN == DialogResult.Yes)
                {
                    try
                    {
                        string staffID = txtstaffID.Text.Trim();
                        Nhanvien staff = db.Nhanviens.ToList().SingleOrDefault(x => x.Id == int.Parse(staffID));
                        db.Nhanviens.Remove(staff);
                        db.SaveChanges();
                        MessageBox.Show("Đã xóa thành công staff ID = " + staffID + ".");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Không xóa được staff hiện hành.");
                    }
                }
            }
        }

        private void txtstaffID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { Loadinfo(); }
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtstaffID_Leave(object sender, EventArgs e)
        {
            int result;
            if (int.TryParse(txtstaffID.Text.Trim(), out result))
            {
                var checkexit = db.Nhanviens.ToList().Where(x => x.Id == result).Count();
                if (Add)
                {
                    if (checkexit != 0)
                        MessageBox.Show("Nhân viên đã tồn tại");
                }
            }
        }

        private void txtstaffID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.') e.Handled = true;
            if (e.KeyChar == '.' && ((TextBox)sender).Text.IndexOf('.') > -1) e.Handled = true;
        }

        private void Dataview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = Dataview.CurrentCell.RowIndex;
            txtstaffID.Text = Dataview.Rows[index].Cells[0].Value.ToString().Trim();
            txtName.Text = Dataview.Rows[index].Cells[1].Value.ToString().Trim();
            txtGender.Text = Dataview.Rows[index].Cells[2].Value.ToString().Trim();
            txtAddress.Text = Dataview.Rows[index].Cells[3].Value.ToString().Trim();
            txtManager.Text = Dataview.Rows[index].Cells[4].Value.ToString().Trim();
            txtBranch.Text = Dataview.Rows[index].Cells[5].Value.ToString().Trim();
        }

        private void txtGender_Leave(object sender, EventArgs e)
        {
            if(txtGender.Text!="Male"|| txtGender.Text != "Female")
            {
                MessageBox.Show("Sai format(Male or Female) hoặc nội duung vui lòng thử lại", "Message", MessageBoxButtons.OK);
                txtGender.Focus();
            }
        }
    }
}

