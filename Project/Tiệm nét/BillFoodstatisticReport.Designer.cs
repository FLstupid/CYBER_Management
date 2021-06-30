
namespace Tiệm_nét
{
    partial class BillFoodstatisticReport
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
            this.ChinhanhBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsBranch = new Tiệm_nét.dsBranch();
            this.ChinhanhTableAdapter = new Tiệm_nét.dsBranchTableAdapters.ChinhanhTableAdapter();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dsBillFoodstatistics = new Tiệm_nét.dsBillFoodstatistics();
            this.Hoadon_thucanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Hoadon_thucanTableAdapter = new Tiệm_nét.dsBillFoodstatisticsTableAdapters.Hoadon_thucanTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.ChinhanhBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBranch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBillFoodstatistics)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Hoadon_thucanBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ChinhanhBindingSource
            // 
            this.ChinhanhBindingSource.DataMember = "Chinhanh";
            this.ChinhanhBindingSource.DataSource = this.dsBranch;
            // 
            // dsBranch
            // 
            this.dsBranch.DataSetName = "dsBranch";
            this.dsBranch.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ChinhanhTableAdapter
            // 
            this.ChinhanhTableAdapter.ClearBeforeFill = true;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.Hoadon_thucanBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Tiệm_nét.BillFoodstatisticReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // dsBillFoodstatistics
            // 
            this.dsBillFoodstatistics.DataSetName = "dsBillFoodstatistics";
            this.dsBillFoodstatistics.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Hoadon_thucanBindingSource
            // 
            this.Hoadon_thucanBindingSource.DataMember = "Hoadon_thucan";
            this.Hoadon_thucanBindingSource.DataSource = this.dsBillFoodstatistics;
            // 
            // Hoadon_thucanTableAdapter
            // 
            this.Hoadon_thucanTableAdapter.ClearBeforeFill = true;
            // 
            // BillFoodstatisticReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "BillFoodstatisticReport";
            this.Text = "BillFoodstatisticReport";
            this.Load += new System.EventHandler(this.BillFoodstatisticReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ChinhanhBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBranch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBillFoodstatistics)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Hoadon_thucanBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource ChinhanhBindingSource;
        private dsBranch dsBranch;
        private dsBranchTableAdapters.ChinhanhTableAdapter ChinhanhTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource Hoadon_thucanBindingSource;
        private dsBillFoodstatistics dsBillFoodstatistics;
        private dsBillFoodstatisticsTableAdapters.Hoadon_thucanTableAdapter Hoadon_thucanTableAdapter;
    }
}