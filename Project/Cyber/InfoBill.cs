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
    public partial class InfoBill : Form
    {
        public InfoBill()
        {
            InitializeComponent();
        }

        Cyber_netEntities db = new Cyber_netEntities();
        bool Add = false;

        private void btExit_Click(object sender, EventArgs e)
        {
            Parent.Visible = false;
            this.Hide();
        }
        private void setEditOff()
        {
            btConfirm.Visible = btCancel.Visible = txtID.Enabled = txtDate.Enabled = txtDecription.Enabled = txtExtrafee.Enabled = txtStaffid.Enabled = txtTime.Enabled = txtCid.Enabled = txtTotal.Enabled = false;
            btAdd.Enabled = true;
            btEdit.Enabled = true;
            btDelete.Enabled = true;
        }
        private void setEditOn()
        {
            btConfirm.Visible = btCancel.Visible = txtID.Enabled = txtDate.Enabled = txtDecription.Enabled = txtExtrafee.Enabled = txtStaffid.Enabled = txtTime.Enabled = txtCid.Enabled = txtTotal.Enabled = true;
        }
        void Reset()
        {
            txtID.ResetText();
            txtDate.ResetText();
            txtDecription.ResetText();
            txtExtrafee.ResetText();
            txtStaffid.ResetText();
            txtTime.ResetText(); 
            txtCid.ResetText();
            txtTotal.ResetText();
        }
        private void Load_data()
        {
            var dt = db.Hoadons;
            var datas = from i in dt select new { i.Id, CustomerId = i.Id_khachhang, i.Date, i.Total, i.Time_use, i.Extra_fee, i.Description, StaffID = i.Id_nhanvien };
            Dataview.DataSource = datas.ToList();
            txtID.ReadOnly = true;
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
            if (txtID.Text.Equals(""))
            { MessageBox.Show("Bill id can not null"); }
            else
            {
                Add = false;
                setEditOn();
                btAdd.Enabled = false;
                btDelete.Enabled = false;
            }
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
                    int tmpid = int.Parse(txtID.Text.Trim());
                    Khachhang C = db.Khachhangs.ToList().SingleOrDefault(x => x.Id == tmpid);
                    db.Khachhangs.Remove(C);
                    db.SaveChanges();
                    Load_data();
                    MessageBox.Show($"Đã xóa thành công Bill có ID = {Cid}.", @"Message", MessageBoxButtons.OK);
                    setEditOff();
                }
                catch (Exception)
                {
                    MessageBox.Show("Không xóa được bill hiện hành.", @"Message", MessageBoxButtons.OK);
                }
            }
        }

        private void Dataview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = Dataview.CurrentCell.RowIndex;
            txtID.Text = Dataview.Rows[index].Cells[0].Value.ToString().Trim();
            txtCid.Text = Dataview.Rows[index].Cells[1].Value.ToString().Trim();
            txtDate.Text = Dataview.Rows[index].Cells[2].Value.ToString().Trim();
            txtTotal.Text = Dataview.Rows[index].Cells[3].Value.ToString().Trim();
            txtTime.Text = Dataview.Rows[index].Cells[4].Value.ToString().Trim();
            txtExtrafee.Text = Dataview.Rows[index].Cells[5].Value.ToString().Trim();
            txtDecription.Text = Dataview.Rows[index].Cells[6].Value.ToString().Trim();
            txtStaffid.Text = Dataview.Rows[index].Cells[7].Value.ToString().Trim();
        }

        private void btConfirm_Click(object sender, EventArgs e)
        {
            if (Add)
                if (txtID.Text == "") MessageBox.Show(@"Chưa nhập id hoa don ! Vui lòng nhập id.", @"Message", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                else if (txtCid.Text == "") MessageBox.Show("Chưa nhập id khach hang! Vui lòng nhập", @"Message", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                else if (txtDate.Text == "") MessageBox.Show("Chưa nhập ngày! Vui lòng nhập", @"Message", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                else if (txtTotal.Text == "") MessageBox.Show("Chưa nhập số tiền! Vui lòng nhập", @"Message", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                else if (txtTime.Text == "") MessageBox.Show("Chưa nhập thời gian sử dụng! Vui lòng nhập", @"Message", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                else if (txtExtrafee.Text == "") txtExtrafee.Text = "0";
                else if (txtDecription.Text == "") txtDecription.Text = " ";
                else if (txtStaffid.Text == "") MessageBox.Show("Chưa nhập id nhan vien! Vui lòng nhập", @"Message", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                else
                {
                    try
                    {
                        db.Hoadons.Add(new Hoadon
                        {
                            Id = int.Parse(txtID.Text.Trim()),
                            Id_khachhang = int.Parse(txtCid.Text.Trim()),
                            Date = DateTime.Parse(txtDate.Text),
                            Total = int.Parse(txtTotal.Text.Trim()), 
                            Time_use = int.Parse(txtTime.Text.Trim()), 
                            Extra_fee = int.Parse(txtExtrafee.Text.Trim()), 
                            Description = txtDecription.Text,
                            Id_nhanvien = int.Parse(txtStaffid.Text.Trim())
                        });
                        db.SaveChanges();
                        Load_data();
                        setEditOff();
                        MessageBox.Show("Đã thêm dữ liệu thành công!");
                    }
                    catch (Exception) { MessageBox.Show("Error Save"); }
                }
            else
            {
                if (txtID.Text == "") MessageBox.Show(@"Chưa nhập id hoa don ! Vui lòng nhập id.", @"Message", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                else if (txtCid.Text == "") MessageBox.Show("Chưa nhập id khach hang! Vui lòng nhập", @"Message", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                else if (txtDate.Text == "") MessageBox.Show("Chưa nhập ngày! Vui lòng nhập", @"Message", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                else if (txtTotal.Text == "") MessageBox.Show("Chưa nhập số tiền! Vui lòng nhập", @"Message", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                else if (txtTime.Text == "") MessageBox.Show("Chưa nhập thời gian sử dụng! Vui lòng nhập", @"Message", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                else if (txtExtrafee.Text == "") txtExtrafee.Text = "0";
                else if (txtDecription.Text == "") txtDecription.Text = " ";
                else if (txtStaffid.Text == "") MessageBox.Show("Chưa nhập id nhan vien! Vui lòng nhập", @"Message", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                else
                {
                    try
                    {
                        int BillId = int.Parse(txtID.Text.Trim());
                        Hoadon hd = db.Hoadons.ToList().SingleOrDefault(x => x.Id == BillId);
                        hd.Id = int.Parse(txtID.Text.Trim());
                        hd.Id_khachhang = int.Parse(txtCid.Text.Trim());
                        hd.Date = DateTime.Parse(txtDate.Text);
                        hd.Total = int.Parse(txtTotal.Text.Trim());
                        hd.Time_use = int.Parse(txtTime.Text.Trim());
                        hd.Extra_fee = int.Parse(txtExtrafee.Text.Trim());
                        hd.Description = txtDecription.Text;
                        hd.Id_nhanvien = int.Parse(txtStaffid.Text.Trim());
                        db.SaveChanges();
                        Load_data();
                        setEditOff();
                        MessageBox.Show("Đã sửa xong!");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error Edit");
                    }
                }
            }
        }
        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
