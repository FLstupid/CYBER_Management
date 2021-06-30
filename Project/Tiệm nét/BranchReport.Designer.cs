
namespace Tiệm_nét
{
    partial class BranchReport
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
            this.dsBranch = new Tiệm_nét.dsBranch();
            this.ChinhanhBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ChinhanhTableAdapter = new Tiệm_nét.dsBranchTableAdapters.ChinhanhTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dsBranch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChinhanhBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.ChinhanhBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Tiệm_nét.BranchReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // dsBranch
            // 
            this.dsBranch.DataSetName = "dsBranch";
            this.dsBranch.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ChinhanhBindingSource
            // 
            this.ChinhanhBindingSource.DataMember = "Chinhanh";
            this.ChinhanhBindingSource.DataSource = this.dsBranch;
            // 
            // ChinhanhTableAdapter
            // 
            this.ChinhanhTableAdapter.ClearBeforeFill = true;
            // 
            // BranchReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "BranchReport";
            this.Text = "BranchReport";
            this.Load += new System.EventHandler(this.BranchReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsBranch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChinhanhBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ChinhanhBindingSource;
        private dsBranch dsBranch;
        private dsBranchTableAdapters.ChinhanhTableAdapter ChinhanhTableAdapter;
    }
}