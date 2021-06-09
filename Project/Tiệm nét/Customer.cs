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
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }

        Cyber_netEntities db = new Cyber_netEntities();
        bool Add = false;

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void setEditOff()
        {
            btConfirm.Visible = btCancel.Visible = txtCName.Enabled = txtPhone.Enabled = txtPasword.Enabled = txtComputerID.Enabled = txtRID.Enabled = false;
            btAdd.Enabled = true;
            btEdit.Enabled = true;
            btDelete.Enabled = true;
        }
        private void setEditOn()
        {
            btConfirm.Visible = btCancel.Visible = txtCName.Enabled = txtPhone.Enabled = txtPasword.Enabled = txtComputerID.Enabled = txtRID.Enabled = true;
        }
        void Reset()
        {
            txtCID.ResetText();
            txtCName.ResetText();
            txtPasword.ResetText();
            txtPhone.ResetText();
            txtComputerID.ResetText();
            txtRID.ResetText();
        }
        private void Load_data()
        {
            try
            {
                db = new Cyber_netEntities();
                var data = db.Khachhangs.ToList();
                foreach (var Item in data)
                {
                    txtCID.AutoCompleteCustomSource.Add(Item.Id.ToString());
                    txtComputerID.AutoCompleteCustomSource.Add(Item.Maytinh.Id.ToString());
                    txtRID.AutoCompleteCustomSource.Add(Item.Id_phongmay.ToString());
                }
                Loadinfo();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            var dt = db.Khachhangs;
            var datas = from i in dt select new { i.Id, i.Name, i.Password, i.Phone, i.Id_maytinh, i.Id_phongmay };
            Dataview.DataSource = datas.ToList();

        }
        private void Loadinfo()
        {
            if (txtCID.Text.Equals("")) txtCID.Text = "1";
            int result;
            if (int.TryParse(txtCID.Text.Trim(), out result))
                if (db.Khachhangs.ToList().Where(x => x.Id == result).Count() == 0)
                {
                    MessageBox.Show("Costumer id not exist");
                    txtCID.Focus();
                }
                else
                {
                    var data = db.Khachhangs.ToList();
                    Khachhang Costumer = data.Where(x => x.Id == result).SingleOrDefault();
                    txtCName.Text = Costumer.Name;
                    txtPasword.Text = Costumer.Password;
                    txtPhone.Text = Costumer.Phone;
                    txtComputerID.Text = Costumer.Maytinh.Id.ToString();
                    txtRID.Text = Costumer.Id_phongmay.ToString();
                }
        }
        private void Customer_Load(object sender, EventArgs e)
        {
            Load_data();
            setEditOff();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            Add = true;
            setEditOn();
            Reset();
            btEdit.Enabled = false;
            btDelete.Enabled = false;
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (txtCID.Text.Equals(""))
            { MessageBox.Show("Staff id can not null"); }
            else
            {
                Add = false;
                setEditOn();
                btAdd.Enabled = false;
                btDelete.Enabled = false;
                txtCID.Enabled = false;
            }
        }

        private void btReload_Click(object sender, EventArgs e)
        {
            Load_data();
            Loadinfo();
            setEditOff();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            DialogResult CheckYN;
            CheckYN = MessageBox.Show("Có chắc xóa không?", "Trả lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (CheckYN == DialogResult.Yes)
            {
                try
                {
                    int index = Dataview.CurrentCell.RowIndex;
                    string Cid = Dataview.Rows[index].Cells[0].Value.ToString().Trim();
                    Khachhang C = db.Khachhangs.ToList().SingleOrDefault(x => x.Id == int.Parse(txtCID.Text.Trim()));
                    db.Khachhangs.Remove(C);
                    db.SaveChanges();
                    Load_data();
                    MessageBox.Show($"Đã xóa thành công máy tính có ID = {Cid}.", @"Message", MessageBoxButtons.OK);
                }
                catch (Exception)
                {
                    MessageBox.Show("Không xóa được staff hiện hành.", @"Message", MessageBoxButtons.OK);
                }
            }
        }

        private void Dataview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = Dataview.CurrentCell.RowIndex;
            txtCID.Text = Dataview.Rows[index].Cells[0].Value.ToString().Trim();
            txtCName.Text = Dataview.Rows[index].Cells[1].Value.ToString().Trim();
            txtPasword.Text = Dataview.Rows[index].Cells[2].Value.ToString().Trim();
            txtPhone.Text = Dataview.Rows[index].Cells[3].Value.ToString().Trim();
            txtComputerID.Text = Dataview.Rows[index].Cells[4].Value.ToString().Trim();
            txtRID.Text = Dataview.Rows[index].Cells[5].Value.ToString().Trim();
        }

        private void btConfirm_Click(object sender, EventArgs e)
        {
            var phongmay = db.Phongmays.ToList().Where(x => x.Id == int.Parse(txtRID.Text)).Count();
            var maytinh = db.Maytinhs.ToList().Where(x => x.Id == int.Parse(txtComputerID.Text)).Count();
            if (phongmay == 0) { MessageBox.Show("Room ID not exist"); }
            else if (maytinh == 0) { MessageBox.Show("Computer ID not exist"); }
            else
            {
                if (Add)
                    if (txtCID.Text == "") MessageBox.Show(@"Chưa nhập id khách hàng ! Vui lòng nhập id.", @"Message", MessageBoxButtons.OK,
                           MessageBoxIcon.Warning);
                    else if (txtCName.Text == "") MessageBox.Show("Chưa nhập tên khách hàng! Vui lòng nhập", @"Message", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    else if (txtPasword.Text == "") MessageBox.Show("Chưa nhập mật khẩu! Vui lòng nhập", @"Message", MessageBoxButtons.OK,
                         MessageBoxIcon.Warning);
                    else if (txtPhone.Text == "") MessageBox.Show("Chưa nhập số điện thoại khách hàng! Vui lòng nhập", @"Message", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    else if (txtComputerID.Text == "") MessageBox.Show("Chưa nhập ID máy tính! Vui lòng nhập", @"Message", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    else if (txtRID.Text == "") MessageBox.Show("Chưa nhập phòng máy! Vui lòng nhập", @"Message", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    else
                    {
                        try
                        {
                            db.Khachhangs.Add(new Khachhang
                            {
                                Id = int.Parse(txtCID.Text.Trim()),
                                Name = txtCName.Text,
                                Password = txtPasword.Text,
                                Phone = txtPhone.Text,
                                Id_maytinh = db.Maytinhs.ToList().SingleOrDefault(x => x.Id == int.Parse(txtComputerID.Text)).Id,
                                Id_phongmay = db.Phongmays.ToList().SingleOrDefault(x => x.Id == int.Parse(txtRID.Text)).Id
                            });
                            db.SaveChanges();
                            Load_data();
                            MessageBox.Show("Đã thêm dữ liệu thành công!");
                        }
                        catch (Exception) { MessageBox.Show("Error Save"); }
                    }
                else
                {
                    if (txtCID.Text == "") MessageBox.Show("Chưa nhập id khách hàng! Vui lòng nhập ID", @"Message", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    else if (txtCName.Text == "") MessageBox.Show("Chưa nhập tên khách hàng! Vui lòng nhập tên khách hàng", @"Message", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    else if (txtPasword.Text == "") MessageBox.Show("Chưa nhập mật khẩu! Vui lòng nhập mật khẩu", @"Message", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    else if (txtPhone.Text == "") MessageBox.Show("Chưa nhập chi số điện thoại của khách hàng! Vui lòng nhập số điện thoại của khách hàng", @"Message", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    else if (txtComputerID.Text == "") MessageBox.Show("Chưa nhập hoặc nhập sai mã số máy tính! Vui lòng nhập lại mã số máy", @"Message", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    else if (txtRID.Text == "") MessageBox.Show("Chưa nhập mã phòng máy! Vui lòng nhập mã phòng máy", @"Message", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    else
                    {
                        try
                        {
                            Khachhang customer = db.Khachhangs.ToList().SingleOrDefault(x => x.Id == int.Parse(txtCID.Text.Trim()));
                            customer.Name = txtCName.Text;
                            customer.Password = txtPasword.Text;
                            customer.Phone = txtPhone.Text;
                            customer.Id_maytinh = db.Maytinhs.ToList().SingleOrDefault(x => x.Id == int.Parse(txtComputerID.Text)).Id;
                            customer.Id_phongmay = db.Phongmays.ToList().SingleOrDefault(x => x.Id == int.Parse(txtRID.Text)).Id;
                            db.SaveChanges();
                            Load_data();
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

        private void txtCID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { Loadinfo(); }
        }
        private void txtCID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.') e.Handled = true;
            if (e.KeyChar == '.' && ((TextBox)sender).Text.IndexOf('.') > -1) e.Handled = true;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Add = false;
            Reset();
            setEditOff();
        }
    }
}