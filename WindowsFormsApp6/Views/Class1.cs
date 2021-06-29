using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CandidateTest.Controllers;
using CandidateTest.Models;

namespace CandidateTest.Views
{
    public class clsShapesContainer
    {
        Panel pnlDrawingCanvas;
        public static Form frmMainForm;
        List<clsShape> shpAllShapes;
        System.Windows.Forms.Timer tmrRefreshMovmentClock = new System.Windows.Forms.Timer();

        public clsShapesContainer(Form frmInitForm)
        {
            clsShapesContainer.frmMainForm = frmInitForm;
            InitAllShapes();
            InitializeComponent();
            InitTimer();
        }

        void InitTimer()
        {

            tmrRefreshMovmentClock.Tick += new EventHandler(RefreshMovement);

            // Sets the timer interval to 1 second.
            tmrRefreshMovmentClock.Interval = 500;
            tmrRefreshMovmentClock.Start();
        }

        void RefreshMovement(Object myObject, EventArgs myEventArgs)
        {
            pnlDrawingCanvas.Invalidate();
        }

        void InitAllShapes()
        {
            clsShapesDataHandler hndlr = new clsShapesDataHandler();
            shpAllShapes = new List<clsShape>();

            foreach (strctShapeData objShapeData in hndlr.lstAllShapes)
            {
                shpAllShapes.Add(GetFuctoryShapeObject(objShapeData));
            }
        }

        clsShape GetFuctoryShapeObject(strctShapeData currShapeData)
        {
            clsShape shpTmpShape = null;

            switch(currShapeData.shape)
            {
                case "circle":
                    shpTmpShape = new clsCircle(currShapeData);
                    break;
                case "square":
                    shpTmpShape = new clsSquere(currShapeData);
                    break;
                case "triangle":
                    shpTmpShape = new clsTriangle(currShapeData);
                    break;
            }

            return shpTmpShape;
        }

        private void InitializeComponent()
        {
            pnlDrawingCanvas = new System.Windows.Forms.Panel();
       
            // pnlDrawingCanvas
            // 
            pnlDrawingCanvas.BackColor = System.Drawing.Color.White;
            pnlDrawingCanvas.Location = new System.Drawing.Point(289, 34);
            pnlDrawingCanvas.Name = "pnlDrawingCanvas";
            pnlDrawingCanvas.Size = new System.Drawing.Size(500, 500);
            pnlDrawingCanvas.TabIndex = 0;
            pnlDrawingCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlDrawingCanvas_Paint);
            frmMainForm.Controls.Add(pnlDrawingCanvas);
            frmMainForm.ResumeLayout(false);

        }

        private void pnlDrawingCanvas_Paint(object sender, PaintEventArgs e)
        {
                      

            foreach (clsShape s in shpAllShapes)
            {
                if((s!=null))
                     s.Draw(e.Graphics);
            }
            //frmMainForm.ResumeLayout();
            
        }

    }
}
