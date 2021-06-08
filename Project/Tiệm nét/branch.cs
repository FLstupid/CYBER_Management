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
    public partial class branch : Form
    {
        public branch()
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
            btConfirm.Visible = btCancel.Visible = txtBID.Enabled = txtBName.Enabled = txtDID.Enabled = false;
        }
        private void setEditOn()
        {
            btConfirm.Visible = btCancel.Visible = txtBID.Enabled = txtBName.Enabled = txtDID.Enabled = true;
        }
        private void Load_data()
        {
            //Datasource
            var dt = db.Chinhanhs;
            var datas = from i in dt select new { i.Id, i.Chinhanh1, i.District.District1 };
            Dataview.DataSource = datas.ToList();
        }
        private void branch_Load(object sender, EventArgs e)
        {
            Load_data();
            setEditOff();
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
                    string Bid = Dataview.Rows[index].Cells[0].Value.ToString().Trim();
                    Chinhanh B = db.Chinhanhs.ToList().SingleOrDefault(x => x.Id == int.Parse(Bid));
                    db.Chinhanhs.Remove(B);
                    db.SaveChanges();
                    Load_data();
                    MessageBox.Show($"Đã xóa thành công máy tính có ID = {Bid}.", @"Message", MessageBoxButtons.OK);
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
            txtBID.Text = Dataview.Rows[index].Cells[0].Value.ToString().Trim(); 
            txtBName.Text = Dataview.Rows[index].Cells[1].Value.ToString().Trim();
            txtDID.Text = Dataview.Rows[index].Cells[2].Value.ToString().Trim();
        }

        private void btConfirm_Click(object sender, EventArgs e)
        {
            if (Add)
            {
                try
                {
                    db.Chinhanhs.Add(new Chinhanh
                    {
                        Id = int.Parse(txtBID.Text.Trim()),
                        Chinhanh1 = txtBName.Text.TrimEnd(),
                        Id_district = db.Districts.ToList().SingleOrDefault(x=>x.District1 == txtDID.Text).Id 
                    });
                    db.SaveChanges();
                    Load_data();
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
                    Chinhanh cn = db.Chinhanhs.SingleOrDefault(x => x.Id == int.Parse(txtBID.Text.Trim()));
                    cn.Chinhanh1 = txtBName.Text;
                    cn.Id_district = db.Districts.ToList().SingleOrDefault(x => x.District1 == txtDID.Text).Id;
                    db.SaveChanges();
                    Load_data();
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
