using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using CandidateTest.Models;
using System.Drawing;


namespace CandidateTest.Controllers
{
    public abstract class clsShape
    {
        protected strctShapeData shpShapeData;
        System.Windows.Forms.Timer tmrMovmentClock = new System.Windows.Forms.Timer();
        protected bool bIsOnStage = true;
        clsShapeHistoryQueue queShapeMoves;

        public clsShape(strctShapeData shpCurrShapeData) 
        {
   
            shpShapeData = shpCurrShapeData;
            queShapeMoves = new clsShapeHistoryQueue(shpShapeData.entity_ID, shpShapeData.name);
            queShapeMoves.InsertMove(shpShapeData.X, shpShapeData.Y);
            InitTimer();

        }


        void InitTimer()
        {
    
            tmrMovmentClock.Tick += new EventHandler(Move);

            // Sets the timer interval to 1 second.
            tmrMovmentClock.Interval = 1000;
            tmrMovmentClock.Start();
        }


        public abstract void Draw(Graphics gGraphicsHndlr);
      


        void Move(Object myObject, EventArgs myEventArgs)
        {
            shpShapeData.X += 5;
            shpShapeData.Y += 3;

            queShapeMoves.InsertMove(shpShapeData.X, shpShapeData.Y); 
           // clsShapesContainer.pnlDrawingCanvas.Invalidate();
        }

        public void chkShape__CheckedChanged(object sender, EventArgs e)
        {
            bIsOnStage = !bIsOnStage;


        }

        bool CheckIfValidMove()
        {
            return true;
        }
    }

 

  

  




}
