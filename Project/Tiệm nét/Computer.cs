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
    public partial class Computer : Form
    {
        public Computer()
        {
            InitializeComponent();
            btEditOff();
            cbBName.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRoomID.DropDownStyle = ComboBoxStyle.DropDownList;
            cbType.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        Cyber_netEntities db = new Cyber_netEntities();
        bool Add = false;
        void btEditOff()
        {
            btConfirm.Visible = btCancel.Visible = cbBName.Enabled = txtBID.Enabled = cbRoomID.Enabled = cbType.Enabled = false;
            btAdd.Enabled = btEdit.Enabled = btDelete.Enabled = true;
        }
        void btEditOn()
        {
            btConfirm.Visible = btCancel.Visible = cbBName.Enabled = txtBID.Enabled = cbRoomID.Enabled = cbType.Enabled = true;
        }
        private void LoadData()
        {
            try
            {
                var dt = db.Maytinhs;
                if (cbBName.Text != "") {
                    var info = from d in dt 
                               where d.Phongmay.Chinhanh.Chinhanh1 == cbBName.Text 
                               select new { d.Id, d.Status, d.Time_use };
                    Data.DataSource = info.ToList();
                }
                else if (cbType.Text != "") {
                    var info = from d in dt 
                               where d.Phongmay.Chinhanh.Chinhanh1 == cbBName.Text && d.Phongmay.Typed == cbType.Text
                               select new { d.Id, d.Status, d.Time_use };
                    Data.DataSource = info.ToList();
                }
                else if (cbRoomID.Text != "") {
                    var info = from d in dt
                               where d.Phongmay.Chinhanh.Chinhanh1 == cbBName.Text 
                               && d.Phongmay.Typed == cbType.Text 
                               && d.Id_Phongmay.ToString() == cbRoomID.Text
                               select new { d.Id, d.Status, d.Time_use };
                    Data.DataSource = info.ToList();
                }
                else {
                    var info = from d in dt select new { d.Id, d.Status, d.Time_use };
                    Data.DataSource = info.ToList();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void btconfirm_Click(object sender, EventArgs e)
        {
            btEditOff();
            if (Add)
            {
                    
            try
            {
                db.Maytinhs.Add(new Maytinh
                {
                    Id = int.Parse(txtCID.Text),
                    Status = txtStatus.Text,
                    Time_use = int.Parse(txtTimeused.Text.Trim()),
                    Id_Phongmay = int.Parse(cbRoomID.Text.Trim())
                });
                db.SaveChanges();
                LoadData();
                MessageBox.Show("Đã thêm dữ liệu thành công!");
            }
            catch (Exception) { MessageBox.Show("Error Save"); }

            }
            else
            {
                try 
                {
                    int r = Data.CurrentCell.RowIndex;
                    string tmpID = Data.Rows[r].Cells[0].Value.ToString();
                    Maytinh cpt = db.Maytinhs.SingleOrDefault(x => x.Id == int.Parse(tmpID));
                    cpt.Id = int.Parse(txtCID.Text);
                    cpt.Status = txtStatus.Text;
                    cpt.Time_use = int.Parse(txtTimeused.Text.Trim());
                    cpt.Id_Phongmay = int.Parse(cbRoomID.Text.Trim());
                    db.SaveChanges();
                    LoadData();
                    MessageBox.Show("Đã sửa xong!");
                }
                catch (Exception)
                {
                    MessageBox.Show("Error Edit",@"Message",MessageBoxButtons.OK);
                }
            }
        }
        private void btcancel_Click(object sender, EventArgs e)
        {
            Add = false;
            btEditOff();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            Add = true;
            btEditOn();
            btEdit.Enabled = false;
            btDelete.Enabled = false;
        }
        private void btReload_Click(object sender, EventArgs e)
        {
            btEditOff();
            btAdd.Enabled = false;
            btDelete.Enabled = false;
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
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
                    int index = Data.CurrentCell.RowIndex;
                    string Cid = Data.Rows[index].Cells[0].Value.ToString().Trim();
                    Maytinh Cpt = db.Maytinhs.ToList().SingleOrDefault(x => x.Id == int.Parse(Cid));
                    db.Maytinhs.Remove(Cpt);
                    db.SaveChanges();
                    LoadData();
                    MessageBox.Show($"Đã xóa thành công máy tính có ID = {Cid}.", @"Message", MessageBoxButtons.OK);
                }
                catch (Exception)
                {
                    MessageBox.Show("Không xóa được staff hiện hành.", @"Message", MessageBoxButtons.OK);
                }
            }
        }
        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Computer_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
