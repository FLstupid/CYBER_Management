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
    public partial class Statistic : Form
    {
        public Statistic()
        {
            InitializeComponent();
        }
        Cyber_netEntities db = new Cyber_netEntities();
        private void Load_data(string table)
        {
            switch (table) {
                case "0":
                    var d0 = db.Chinhanhs;
                    var info0 = from i in d0
                               select new { i.Id, Branch = i.Chinhanh1, District = i.District.District1 };
                    dataview.DataSource = info0.ToList();
                        break;
                case "1":
                    var d1 = db.Nhanviens;
                    var info1 = from i in d1
                                select new { i.Id, i.Name,i.Address,i.Gender,Branch = i.Chinhanh.Chinhanh1, Manager = i.Nhanvien2.Name };
                    dataview.DataSource = info1.ToList();
                    break;
                case "2":
                    var d2 = db.Maytinhs;
                    var info2 = from i in d2
                                select new { i.Id, i.Phongmay.Typed,i.Status,i.Time_use,Branch = i.Phongmay.Chinhanh.Chinhanh1 };
                    dataview.DataSource = info2.ToList();
                    break;
                case "3":
                    var d3 = db.Khachhangs;
                    var info3 = from i in d3
                                select new { i.Id, i.Name,i.Password,i.Phone,Branch = i.Maytinh.Phongmay.Chinhanh.Chinhanh1 };
                    dataview.DataSource = info3.ToList();
                    break;
                case "4":
                    var d4 = db.Hoadons;
                    var info4 = from i in d4
                                select new { i.Id,Customer = i.Khachhang.Name,Staff = i.Nhanvien.Name, i.Date,i.Time_use,i.Fee,i.Extra_fee,i.Description, i.Total };
                    dataview.DataSource = info4.ToList();
                    break;
                case "5":
                    var d5 = db.Hoadon_thucan;
                    var info5 = from i in d5
                                select new { i.Id, Customer = i.Khachhang.Name, Staff = i.Nhanvien.Name,i.Date,i.Total };
                    dataview.DataSource = info5.ToList();
                    break;
            }
        }
        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_data(cbChoose.SelectedIndex.ToString());
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            Parent.Visible = false;
            this.Hide();
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            switch (cbChoose.Text)
            {
                case "Branch":
                    BranchReport branchReport = new BranchReport();
                    branchReport.Show();
                    break;
                case "Staff":
                    StaffReport staffReport = new StaffReport();
                    staffReport.Show();
                    break;
                case "Computer":
                    ComputerReport computerReport = new ComputerReport();
                    computerReport.Show();
                    break;
                case "Customer":
                    CustomerReport customerReport = new CustomerReport();
                    customerReport.Show();
                    break;
                case "Bill":
                    BillReport billReport = new BillReport();
                    billReport.Show();
                    break;
                case "Bill Food":
                    BillFoodstatisticReport billFoodstatisticReport = new BillFoodstatisticReport();
                    billFoodstatisticReport.Show();
                    break;
            }
        }
    }
}
