namespace SqlServerAndStruct
{
    partial class Report
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
            this.СотрудникиBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.EmployeesDataSet = new SqlServerAndStruct.EmployeesDataSet();
            this.СотрудникиTableAdapter = new SqlServerAndStruct.EmployeesDataSetTableAdapters.СотрудникиTableAdapter();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.СотрудникиBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeesDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // СотрудникиBindingSource
            // 
            this.СотрудникиBindingSource.DataMember = "Сотрудники";
            this.СотрудникиBindingSource.DataSource = this.EmployeesDataSet;
            // 
            // EmployeesDataSet
            // 
            this.EmployeesDataSet.DataSetName = "EmployeesDataSet";
            this.EmployeesDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // СотрудникиTableAdapter
            // 
            this.СотрудникиTableAdapter.ClearBeforeFill = true;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.СотрудникиBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SqlServerAndStruct.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(689, 312);
            this.reportViewer1.TabIndex = 0;
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 312);
            this.Controls.Add(this.reportViewer1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(705, 350);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(705, 350);
            this.Name = "Report";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report";
            this.Load += new System.EventHandler(this.Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.СотрудникиBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeesDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource СотрудникиBindingSource;
        private EmployeesDataSet EmployeesDataSet;
        private EmployeesDataSetTableAdapters.СотрудникиTableAdapter СотрудникиTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}