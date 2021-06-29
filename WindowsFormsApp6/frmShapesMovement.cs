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
        public frmShapesMovement()
        {
            InitializeComponent();
        }

        private void frmShapesMovement_Load(object sender, EventArgs e)
        {
            clsShapesContainer contnr = new clsShapesContainer(this);

        }

    
    }
}
