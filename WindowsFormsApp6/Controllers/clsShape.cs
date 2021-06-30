using System;
using System.Collections.Generic;
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

        int nAddNextStepsToY;
        int nAddNextStepsToX;
        int nCurrHeading = 0;

        protected const int SCALE_FACTOR = 5;

       protected Dictionary<string, Brush> dicColors; // = new Dictionary<string, Pen>(){;



        public clsShape(strctShapeData shpCurrShapeData) 
        {
   
            shpShapeData = shpCurrShapeData;
            InitAndCheckColor();
            InitMoveTimer();
            queShapeMoves = new clsShapeHistoryQueue(shpShapeData.entity_ID, shpShapeData.name);
            queShapeMoves.InsertMove(shpShapeData.X, shpShapeData.Y);
            

        }


        void InitMoveTimer()
        {
    
            tmrMovmentClock.Tick += new EventHandler(Move);

            // Sets the timer interval to 1 second.
            tmrMovmentClock.Interval = 1000;
           
        }

        public void StartStopTimer(bool bStartStopFlag)
        {
            if (bStartStopFlag)
            {
                tmrMovmentClock.Start();
            }
            else
            {
                tmrMovmentClock.Stop();
            }
        }

        void InitAndCheckColor()
        {
            dicColors = new Dictionary<string, Brush>();
            dicColors.Add("red", Brushes.Red);
            dicColors.Add("green", Brushes.Green);
            dicColors.Add("blue", Brushes.Blue);
            try
            {
                Brush brshColor = dicColors[shpShapeData.color];
            }
            catch (Exception ex)
            {
                throw new System.ArgumentException($"Json illegal color name format : '{shpShapeData.color}' in '{shpShapeData.name}' shape");
            }
        }

        public abstract void Draw(Graphics gGraphicsHndlr);
      
        void CalcNextStepsToShape()
        {
            List<int> lstDirection; // = new List<int> { -1, 0, 1 };
            Random rndCurrHeadin = new Random();
            int nDirIndex;

            if (nCurrHeading == 0)
            {
                lstDirection = new List<int> { 45, 135, 225, 315 };
                nDirIndex = rndCurrHeadin.Next(0, 3);
                nCurrHeading = lstDirection[nDirIndex];
            }
            else
            {
                lstDirection = new List<int> { -1, 0, 1 };
                nDirIndex = rndCurrHeadin.Next(0, 2);
                nCurrHeading += 90 * lstDirection[nDirIndex];

                if (nCurrHeading > 360)
                    nCurrHeading = nCurrHeading - 360;
                else if (nCurrHeading < 0)
                    nCurrHeading += 360;
            }
            nAddNextStepsToY = Convert.ToInt32(5 * Math.Sin(nCurrHeading));
            nAddNextStepsToX = Convert.ToInt32(5 * Math.Cos(nCurrHeading));
            //45,135,225,315
        }

        void Move(Object myObject, EventArgs myEventArgs)
        {
            CalcNextStepsToShape();

            shpShapeData.X += nAddNextStepsToX;
            shpShapeData.Y += nAddNextStepsToY;

            queShapeMoves.InsertMove(shpShapeData.X, shpShapeData.Y); 
           // clsShapesContainer.pnlDrawingCanvas.Invalidate();
        }

        public void chkShape__CheckedChanged(object sender, EventArgs e)
        {
            bIsOnStage = !bIsOnStage;


        }

        public List<stctShapeMoveInfo> GetHistoryQueue()
        {
            return queShapeMoves.GetHistory();
        }

        bool CheckIfValidMove()
        {
            return true;
        }
    }

 

  

  




}
