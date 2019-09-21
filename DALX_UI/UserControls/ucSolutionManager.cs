using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DALX_UI.UserControls
{
    public partial class ucSolutionManager : UserControl
    {
        private frmMain frmMain { get; set; }
        public ucSolutionManager(frmMain form1)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.frmMain = form1;
            SetSolutionText();
        }

        public void SetSolutionText()
        {
            this.lblSolution.Text = "Solution - " + frmMain.SolutionSelected;
        }
    }

}
