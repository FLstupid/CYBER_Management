
namespace Tiệm_nét
{
    partial class BillFood
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dsBill_Food = new Tiệm_nét.dsBill_Food();
            this.Chitiet_hoadonBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Chitiet_hoadonTableAdapter = new Tiệm_nét.dsBill_FoodTableAdapters.Chitiet_hoadonTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dsBill_Food)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chitiet_hoadonBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.Chitiet_hoadonBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Tiệm_nét.Bill_FoodReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // dsBill_Food
            // 
            this.dsBill_Food.DataSetName = "dsBill_Food";
            this.dsBill_Food.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Chitiet_hoadonBindingSource
            // 
            this.Chitiet_hoadonBindingSource.DataMember = "Chitiet_hoadon";
            this.Chitiet_hoadonBindingSource.DataSource = this.dsBill_Food;
            // 
            // Chitiet_hoadonTableAdapter
            // 
            this.Chitiet_hoadonTableAdapter.ClearBeforeFill = true;
            // 
            // BillFood
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "BillFood";
            this.Text = "BillFood";
            this.Load += new System.EventHandler(this.BillFood_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsBill_Food)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chitiet_hoadonBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource Chitiet_hoadonBindingSource;
        private dsBill_Food dsBill_Food;
        private dsBill_FoodTableAdapters.Chitiet_hoadonTableAdapter Chitiet_hoadonTableAdapter;
    }
}