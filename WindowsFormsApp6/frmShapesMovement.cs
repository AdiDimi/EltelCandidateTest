using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CandidateTest.Views;

namespace WindowsFormsApp6
{
    public partial class frmShapesMovement : Form
    {
        clsShapesContainer contnr;
        

        public frmShapesMovement()
        {
            InitializeComponent();
        }

        private void frmShapesMovement_Load(object sender, EventArgs e)
        {
             contnr = new clsShapesContainer(this);

        }


        private void btnStop_Click(object sender, EventArgs e)
        {
            contnr.StratOrStopMovingAllShapes(false);
            contnr.SaveToHistoryToCsv();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            frmNumberMovesInput frmNumberMovesInput = new frmNumberMovesInput();
            frmNumberMovesInput.ShowDialog();

            
            contnr.StratOrStopMovingAllShapes(true);


        }
    }

}
