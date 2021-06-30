using System;

using System.Collections.Generic;
using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using CandidateTest.Controllers;
using CandidateTest.Models;

namespace CandidateTest.Views
{
    public class clsShapesContainer
    {
        Panel pnlDrawingCanvas;
        GroupBox grpShapesCheckBoxPnl; 
        
        public static Form frmMainForm;
        List<clsShape> shpAllShapes;

        System.Windows.Forms.Timer tmrRefreshMovmentClock = new System.Windows.Forms.Timer();

        public clsShapesContainer(Form frmInitForm)
        {
            clsShapesContainer.frmMainForm = frmInitForm;

            InitializeComponent();
            InitAllShapes();
            
            InitTimer();
        }

        void InitTimer()
        {

            tmrRefreshMovmentClock.Tick += new EventHandler(RefreshMovement);

            // Sets the timer interval to 1 second.
            tmrRefreshMovmentClock.Interval = 1000;
            
        }

        void RefreshMovement(Object myObject, EventArgs myEventArgs)
        {
            pnlDrawingCanvas.Invalidate();
        }

        void InitAllShapes()
        {
            clsShapesDataHandler hndlr = new clsShapesDataHandler();
            shpAllShapes = new List<clsShape>();

            hndlr.LoadJson();

            foreach (strctShapeData objShapeData in clsShapesDataHandler.lstAllShapes)
            {
                if (shpAllShapes.Count < 10)
                {
                    clsShape shpCurrObj = GetFuctoryShapeObject(objShapeData);
                    CheckBox chkCheckToShapeObj = CreateCheckBoxToShape(shpAllShapes.Count);

                    chkCheckToShapeObj.CheckedChanged += new System.EventHandler(shpCurrObj.chkShape__CheckedChanged);
                    chkCheckToShapeObj.Text = "eID" + objShapeData.entity_ID.ToString() + "_" + objShapeData.name;

                    grpShapesCheckBoxPnl.Controls.Add(chkCheckToShapeObj);
                    shpAllShapes.Add(shpCurrObj);
                }
                else
                {
                    throw new System.ArgumentException("Json illegal shapes amount in file, only 10 shapes are alowed");
                }
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
                default:
                    throw new System.ArgumentException($"Json illegal shape name format : '{currShapeData.shape}' in '{currShapeData.name}' shape");
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

            grpShapesCheckBoxPnl = new System.Windows.Forms.GroupBox();
           
            grpShapesCheckBoxPnl.SuspendLayout();
            frmMainForm.SuspendLayout();

            // 
            // grpShapesCheckBoxPnl
            // 
            grpShapesCheckBoxPnl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            //this.grpShapesCheckBoxPnl.Controls.Add(this.chkShape_);
            grpShapesCheckBoxPnl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            grpShapesCheckBoxPnl.Location = new System.Drawing.Point(49, 29);
            grpShapesCheckBoxPnl.Name = "grpShapesCheckBoxPnl";
            grpShapesCheckBoxPnl.Size = new System.Drawing.Size(107, 349);
            grpShapesCheckBoxPnl.TabIndex = 0;
            grpShapesCheckBoxPnl.TabStop = false;

            frmMainForm.Controls.Add(grpShapesCheckBoxPnl);
            frmMainForm.Controls.Add(pnlDrawingCanvas);
            frmMainForm.ResumeLayout(false);

        }

        CheckBox CreateCheckBoxToShape(int nCurrShapeIndex)
        {
           CheckBox chkShape = new System.Windows.Forms.CheckBox();

            chkShape.AutoSize = true;
            chkShape.Location = new System.Drawing.Point(14, 23 + (nCurrShapeIndex * 25));
            chkShape.Name = "chkShape_" + nCurrShapeIndex.ToString();
            chkShape.Size = new System.Drawing.Size(80, 17);
            chkShape.TabIndex = nCurrShapeIndex;
            chkShape.Checked = true;
           // chkShape.Text = "checkBox1";
            chkShape.UseVisualStyleBackColor = true;
         //   chkShape.CheckedChanged += new System.EventHandler(this.chkShape__CheckedChanged);


            return chkShape;
        }

        public void SaveToHistoryToCsv()
        {
            List<stctShapeMoveInfo>  shpAllShapesHistory = new List<stctShapeMoveInfo>();
            clsShapesDataHandler hndlr = new clsShapesDataHandler();

            foreach (clsShape shpCurrShape in shpAllShapes)
            {
                shpAllShapesHistory.AddRange(shpCurrShape.GetHistoryQueue());
               // shpAllShapesHistory.Concat(shpCurrShape.GetHistoryQueue());
            }

            hndlr.SaveHistoryToCsv(shpAllShapesHistory);
        }

        public void StratOrStopMovingAllShapes(bool bStartStopFlag)
        {
            tmrRefreshMovmentClock.Start();
            foreach (clsShape shpCurrShape in shpAllShapes)
            {
                
                shpCurrShape.StartStopTimer(bStartStopFlag);
            }
        }


        private void pnlDrawingCanvas_Paint(object sender, PaintEventArgs e)
        {
                      

            foreach (clsShape shpCurrShape in shpAllShapes)
            {
                if((shpCurrShape != null))
                    shpCurrShape.Draw(e.Graphics);
            }
            //frmMainForm.ResumeLayout();
            
        }

    }
}
