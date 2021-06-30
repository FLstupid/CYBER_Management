
namespace Tiệm_nét
{
    partial class StaffReport
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
            this.dsStaff = new Tiệm_nét.dsStaff();
            this.NhanvienBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.NhanvienTableAdapter = new Tiệm_nét.dsStaffTableAdapters.NhanvienTableAdapter();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.dsStaff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NhanvienBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dsStaff
            // 
            this.dsStaff.DataSetName = "dsStaff";
            this.dsStaff.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // NhanvienBindingSource
            // 
            this.NhanvienBindingSource.DataMember = "Nhanvien";
            this.NhanvienBindingSource.DataSource = this.dsStaff;
            // 
            // NhanvienTableAdapter
            // 
            this.NhanvienTableAdapter.ClearBeforeFill = true;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.NhanvienBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Tiệm_nét.StaffReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // StaffReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "StaffReport";
            this.Text = "StaffReport";
            this.Load += new System.EventHandler(this.StaffReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsStaff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NhanvienBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource NhanvienBindingSource;
        private dsStaff dsStaff;
        private dsStaffTableAdapters.NhanvienTableAdapter NhanvienTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}