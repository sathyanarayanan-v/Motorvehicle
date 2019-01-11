using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MotorVehicle
{
    public partial class ReportGen : Form
    {
        public ReportGen()
        {
            InitializeComponent();
           
        }

        private void ReportGen_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'AccidentTheftReport.Accdet' table. You can move, or remove it, as needed.
            this.AccdetTableAdapter.Fill(this.AccidentTheftReport.Accdet);

            this.reportViewer1.RefreshReport();
            WindowState = FormWindowState.Maximized;
            
        }
    }
}
