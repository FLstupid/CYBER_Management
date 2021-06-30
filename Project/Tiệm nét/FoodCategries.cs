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
    public partial class FoodCategries : Form
    {
        public FoodCategries()
        {
            InitializeComponent();
        }
        Cyber_netEntities db = null;
        bool Add = false;
        void btEditOff()
        {
            btConfirm.Visible = btCancel.Visible = txtFName.Enabled = txtPrice.Enabled = false;
            btAdd.Enabled = true;
            btEdit.Enabled = true;
            btDelete.Enabled = true;
        }
        void btEditOn()
        {
            btConfirm.Visible = btCancel.Visible = txtFName.Enabled = txtPrice.Enabled = true;
        }

        void Reset()
        {
            txtFID.ResetText();
            txtFName.ResetText();
            txtPrice.ResetText();
        }
        private void Load_data()
        {
            db = new Cyber_netEntities();
            var dt = db.Thucans.ToList();
            var datas = from i in dt select new { i.Id, Customer = i.Name,i.Price };
            Dataview.DataSource = datas.ToList();
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            Parent.Visible = false;
            this.Hide();
        }

        private void Cate_Load(object sender, EventArgs e)
        {
            Load_data();
            btEditOff();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            Add = true;
            Reset();
            btEditOn();
            btDelete.Enabled = btEdit.Enabled = false;
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            btEditOn();
            btDelete.Enabled = btAdd.Enabled = false;
        }

        private void btReload_Click(object sender, EventArgs e)
        {
            Load_data();
            Loadinfo();
            btEditOff();
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
                    string Food = Dataview.Rows[index].Cells[0].Value.ToString().Trim();
                    int tmpid = int.Parse(Food);
                    Thucan B = db.Thucans.ToList().SingleOrDefault(x => x.Id == tmpid);
                    db.Thucans.Remove(B);
                    db.SaveChanges();
                    Load_data();
                    MessageBox.Show($"Đã xóa thành công loại thực ăn có ID = {Food}.", @"Message", MessageBoxButtons.OK);
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
            txtFID.Text = Dataview.Rows[index].Cells[0].Value.ToString().Trim();
            txtFName.Text = Dataview.Rows[index].Cells[1].Value.ToString().Trim();
            txtPrice.Text = Dataview.Rows[index].Cells[2].Value.ToString().Trim();
        }

        private void btConfirm_Click(object sender, EventArgs e)
        {
            if (Add)
            {
                try
                {
                    db.Thucans.Add(new Thucan
                    {
                        Id = int.Parse(txtFID.Text.Trim()),
                        Name= txtFName.Text,
                        Price=int.Parse(txtPrice.Text)
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
                    int tmpid = int.Parse(txtFID.Text.Trim());
                    Thucan ta = db.Thucans.SingleOrDefault(x => x.Id == tmpid);
                    ta.Name = txtFName.Text;
                    ta.Price = int.Parse(txtPrice.Text);
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
            btEditOff();
            Reset();
            Load_data();
        }
        private void txtFID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { Loadinfo(); }
        }
        private void txtFID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.') e.Handled = true;
            if (e.KeyChar == '.' && ((TextBox)sender).Text.IndexOf('.') > -1) e.Handled = true;
        }
        private void Loadinfo()
        {
            if (txtFID.Text.Equals("")) txtFID.Text = "1";
            int result;
            if (int.TryParse(txtFID.Text.Trim(), out result))
                if (db.Nhanviens.ToList().Where(x => x.Id == result).Count() == 0)
                {
                    MessageBox.Show("Food id not exist");
                    txtFID.Focus();
                }
                else
                {
                    var data = db.Thucans.ToList();
                    Thucan Food = data.Where(x => x.Id == result).SingleOrDefault();
                    txtFName.Text = Food.Name;
                    txtPrice.Text = Food.Price.ToString();
                }
        }
    }
}
