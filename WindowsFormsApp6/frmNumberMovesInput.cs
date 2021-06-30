using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CandidateTest.Controllers;

namespace WindowsFormsApp6
{
    public partial class frmNumberMovesInput : Form
    {
       

        public frmNumberMovesInput()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtNumberOfMoves.Text != "")
            {
                clsShapeHistoryQueue.nMaxQueueLen = Convert.ToInt32(txtNumberOfMoves.Text);
                //this.DialogResult.Parse(typeof(int),txtNumberOfMoves.Text);
                Close();
            }
        }

        private void txtNumberOfMoves_TextChanged(object sender, EventArgs e)
        {
            // if int.Parse(txtNumberOfMoves.Text,);
            if(!(txtNumberOfMoves.Text.All(Char.IsNumber))) txtNumberOfMoves.Text = "";
            
        }

        private void frmNumberMovesInput_Load(object sender, EventArgs e)
        {

        }
    }
}
