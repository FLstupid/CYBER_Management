
namespace Tiệm_nét
{
    partial class BillReport
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
            this.dsBill = new Tiệm_nét.dsBill();
            this.HoadonBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.HoadonTableAdapter = new Tiệm_nét.dsBillTableAdapters.HoadonTableAdapter();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.dsBill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HoadonBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dsBill
            // 
            this.dsBill.DataSetName = "dsBill";
            this.dsBill.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // HoadonBindingSource
            // 
            this.HoadonBindingSource.DataMember = "Hoadon";
            this.HoadonBindingSource.DataSource = this.dsBill;
            // 
            // HoadonTableAdapter
            // 
            this.HoadonTableAdapter.ClearBeforeFill = true;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.HoadonBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Tiệm_nét.BillReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // BillReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "BillReport";
            this.Text = "BillReport";
            this.Load += new System.EventHandler(this.BillReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsBill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HoadonBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource HoadonBindingSource;
        private dsBill dsBill;
        private dsBillTableAdapters.HoadonTableAdapter HoadonTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}