﻿namespace MotorVehicle
{
    partial class ReportGen
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
            this.AccidentTheftReport = new MotorVehicle.AccidentTheftReport();
            this.AccdetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.AccdetTableAdapter = new MotorVehicle.AccidentTheftReportTableAdapters.AccdetTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.AccidentTheftReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccdetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.AccdetBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "MotorVehicle.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(2, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(939, 429);
            this.reportViewer1.TabIndex = 0;
            // 
            // AccidentTheftReport
            // 
            this.AccidentTheftReport.DataSetName = "AccidentTheftReport";
            this.AccidentTheftReport.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // AccdetBindingSource
            // 
            this.AccdetBindingSource.DataMember = "Accdet";
            this.AccdetBindingSource.DataSource = this.AccidentTheftReport;
            // 
            // AccdetTableAdapter
            // 
            this.AccdetTableAdapter.ClearBeforeFill = true;
            // 
            // ReportGen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 430);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReportGen";
            this.Text = "ReportGen";
            this.Load += new System.EventHandler(this.ReportGen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AccidentTheftReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccdetBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource AccdetBindingSource;
        private AccidentTheftReport AccidentTheftReport;
        private AccidentTheftReportTableAdapters.AccdetTableAdapter AccdetTableAdapter;


    }
}