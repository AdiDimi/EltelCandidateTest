using System;
using System.Collections.Generic;
using CandidateTest.Models;
using System.Drawing;


namespace CandidateTest.Controllers
{

    /// <summary>
    /// Public abstract class clsShape - the base class of all shapes implements shared methods and properties
    /// Ddeclares the abstruct draw function whitch must be implemnted on the driven classes
    /// </summary>
    public abstract class clsShape
    {
        // Var that holds the shape data from json file
        protected strctShapeData shpShapeData;

        // Movement timer
        System.Windows.Forms.Timer tmrMovmentClock = new System.Windows.Forms.Timer();

        // Flag indicator for drawing
        protected bool bIsOnStage = true;

        // History moves variable
        clsShapeHistoryQueue queShapeMoves;

        // Variables use for next step culc
        protected int nAddNextStepsToY;
        protected int nAddNextStepsToX;
        protected int nCurrHeading = 0;

        protected const int SCALE_FACTOR = 5;

        // Const shapes sizes
        protected const int SMALL_SHAPE_SIZE = 30;
        protected const int MEDIUM_SHAPE_SIZE = 40;
        protected const int LARGE_SHAPE_SIZE = 50;

        // Dictionaries resposible on shapes color and size
        protected Dictionary<string, Brush> dicColors;
        protected Dictionary<string, Size> dicSizes;



        /// <summary>
        /// Public clsShape(strctShapeData shpCurrShapeData) - Ctor
        /// Gets and init loclly shpCurrShapeData , param that holds the json data related to this object
        /// </summary>
        public clsShape(strctShapeData shpCurrShapeData) 
        {
   
            shpShapeData = shpCurrShapeData;

            InitAndCheckColor();
            InitAndCheckSize();
            InitMoveTimer();
            
            // Set first move to History queue
            queShapeMoves = new clsShapeHistoryQueue(shpShapeData.entity_ID, shpShapeData.name);
            queShapeMoves.InsertMove(shpShapeData.X, shpShapeData.Y);

            

        }

        // Init movement timer
        void InitMoveTimer()
        {
    
            tmrMovmentClock.Tick += new EventHandler(Move);

            // Sets the timer interval to 5 second.
            tmrMovmentClock.Interval = 5000;
           
        }

        // Public function that allows start and stop shape movement
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

        void InitAndCheckSize()
        {
             
                //Point pntCurrPos = new Point(shpShapeData.X * SCALE_FACTOR, shpShapeData.Y * SCALE_FACTOR);
                dicSizes = new Dictionary<string, Size>();

                dicSizes.Add("small",  new Size(SMALL_SHAPE_SIZE, SMALL_SHAPE_SIZE));
                dicSizes.Add("medium", new Size(MEDIUM_SHAPE_SIZE, MEDIUM_SHAPE_SIZE));
                dicSizes.Add("large",  new Size(LARGE_SHAPE_SIZE, MEDIUM_SHAPE_SIZE));

                try
                {

                   Size sizeTestName = dicSizes[shpShapeData.size];
                }
                catch (Exception ex)
                {
                    throw new System.ArgumentException($"Json illegal size name format : '{shpShapeData.size}' in '{shpShapeData.name}' shape");
                }
            //recBounds = new Rectangle(new Point(shpShapeData.X * SCALE_FACTOR, shpShapeData.Y * SCALE_FACTOR), new Size(50, 50));
        }

        public abstract void Draw(Graphics gGraphicsHndlr);

        protected  void CalcNextStepsToShape()
        {
            List<int> lstDirection; // = new List<int> { -1, 0, 1 };
            Random rndCurrHeadin = new Random();
            int nDirIndex;

            if (nCurrHeading == 0)
            {
                lstDirection = new List<int> { 0, 90, 180, 360 };
                nDirIndex = rndCurrHeadin.Next(0, 3);
                nCurrHeading = lstDirection[nDirIndex];
            }
            else
            {
               
                lstDirection = new List<int> { -1, 0, 1, -1, 0,1 };
                nDirIndex = rndCurrHeadin.Next(0, 5);
                nCurrHeading = nCurrHeading + ( 90 * lstDirection[nDirIndex]);

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
