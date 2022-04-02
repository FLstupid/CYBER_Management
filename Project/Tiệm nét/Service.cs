using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Tiệm_nét
{
    public partial class Service : Form
    {
        public Service()
        {
            InitializeComponent();
        }
        Cyber_netEntities db = new Cyber_netEntities();
        bool Add = false;
        private void setEditOff()
        {
            btConfirm.Visible = btCancel.Visible = txtOID.Enabled = txtCName.Enabled = txtSName.Enabled = txtCount.Enabled = false;
            btAdd.Enabled = btDelete.Enabled = btEdit.Enabled = true;
        }
        private void setEditOn()
        {
            btConfirm.Visible = btCancel.Visible = txtOID.Enabled = txtCName.Enabled = txtSName.Enabled = txtCount.Enabled = true;
        }
        private void Load_data()
        {
            var dt = db.Hoadon_thucan.ToList();
            var datas = from i in dt select new { i.Id,Customer = i.Khachhang.Name, Staff = i.Nhanvien.Name,i.Total };
            Dataview.DataSource = datas.ToList();
        }
        private void Detail_Click(object sender, EventArgs e)
        {
            BillFood fReport = new BillFood();
            fReport.Show();
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            Parent.Visible = false;
            this.Hide();
        }
        private void btAdd_Click(object sender, EventArgs e)
        {
            Add = true;
            setEditOn();
            btDelete.Enabled = btEdit.Enabled = false;
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            setEditOn();
            btDelete.Enabled = btAdd.Enabled = false;
        }

        private void btReload_Click(object sender, EventArgs e)
        {
            Load_data();
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
                    string Bill = Dataview.Rows[index].Cells[0].Value.ToString().Trim();
                    int tmpid = int.Parse(Bill);
                    Hoadon_thucan B = db.Hoadon_thucan.ToList().SingleOrDefault(x => x.Id == tmpid);
                    db.Hoadon_thucan.Remove(B);
                    db.SaveChanges();
                    Load_data();
                    MessageBox.Show($"Đã xóa thành công hóa đơn có ID = {Bill}.", @"Message", MessageBoxButtons.OK);
                }
                catch (Exception)
                {
                    MessageBox.Show("Không xóa được hóa đơn hiện hành.", @"Message", MessageBoxButtons.OK);
                }
            }
        }
        private void Dataview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = Dataview.CurrentCell.RowIndex;
            txtOID.Text = Dataview.Rows[index].Cells[0].Value.ToString().Trim();
            txtCName.Text = Dataview.Rows[index].Cells[1].Value.ToString().Trim();
            txtSName.Text = Dataview.Rows[index].Cells[2].Value.ToString().Trim();
            txtCount.Text = Dataview.Rows[index].Cells[3].Value.ToString().Trim();
        }

        private void Service_Load(object sender, EventArgs e)
        {
            Load_data();
            setEditOff();
        }
        private void btConfirm_Click(object sender, EventArgs e)
        {
            if (Add)
            {
                try
                {
                    db.Hoadon_thucan.Add(new Hoadon_thucan
                    {
                        Id = int.Parse(txtOID.Text.Trim()),
                        Id_khachhang = db.Khachhangs.ToList().SingleOrDefault(x=>x.Name == txtCName.Text).Id,
                        Id_nhanvien = db.Nhanviens.ToList().SingleOrDefault(x => x.Name == txtSName.Text).Id,
                        Total = int.Parse(txtCount.Text),
                        Date = DateTime.Now
                    });
                    db.SaveChanges();
                    Load_data();
                    setEditOff();
                    MessageBox.Show("Lưu thành công !", @"Message", MessageBoxButtons.OK);
                }
                catch
                {
                    MessageBox.Show(@"Không thêm được, vui lòng thử lại", @"Message", MessageBoxButtons.OK);
                }
            }
            else
            {
                try
                {
                    int tmpid = int.Parse(txtOID.Text.Trim());
                    Hoadon_thucan hdta = db.Hoadon_thucan.SingleOrDefault(x => x.Id == tmpid);
                    hdta.Id_khachhang = db.Khachhangs.ToList().SingleOrDefault(x => x.Name == txtCName.Text).Id;
                    hdta.Id_nhanvien = db.Nhanviens.ToList().SingleOrDefault(x => x.Name == txtSName.Text).Id;
                    hdta.Total = int.Parse(txtCount.Text);
                    db.SaveChanges();
                    Load_data();
                    setEditOff();
                    MessageBox.Show("Sửa thành công !", @"Message", MessageBoxButtons.OK);
                }
                catch
                {
                    MessageBox.Show(@"Không sửa được, vui lòng thử lại", @"Message", MessageBoxButtons.OK);
                }
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            setEditOff();
            Load_data();
        }
    }
}
