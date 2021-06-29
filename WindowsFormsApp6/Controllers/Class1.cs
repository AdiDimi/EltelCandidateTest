using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CandidateTest.Models;
using System.Drawing;
using CandidateTest.Views;

namespace CandidateTest.Controllers
{
    public abstract class clsShape
    {
        protected strctShapeData shpShapeData;
        System.Windows.Forms.Timer tmrMovmentClock = new System.Windows.Forms.Timer();
         protected bool bIsOnStage = false;

        public clsShape(strctShapeData shpCurrShapeData) 
        {
   
            shpShapeData = shpCurrShapeData;
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
           // clsShapesContainer.pnlDrawingCanvas.Invalidate();
        }

        bool CheckIfValidMove()
        {
            return true;
        }
    }

    public class clsCircle:clsShape
    {
        public clsCircle(strctShapeData shpCurrCirculeData) : base(shpCurrCirculeData) { }

        public override void Draw(Graphics gGraphicsHndlr)
        {
            gGraphicsHndlr.DrawEllipse(new Pen(Brushes.Red, 2), new Rectangle(new Point(shpShapeData.X, shpShapeData.Y), new Size(50,50)));
        }
    }

    public class clsSquere : clsShape
    {
        public clsSquere(strctShapeData shpCurrCirculeData) : base(shpCurrCirculeData) { }

        public override void Draw(Graphics gGraphicsHndlr)
        {
            gGraphicsHndlr.DrawRectangle(new Pen(Brushes.Yellow, 2), new Rectangle(new Point(shpShapeData.X, shpShapeData.Y), new Size(50, 50)));
        }
    }

    public class clsTriangle : clsShape
    {
        public clsTriangle(strctShapeData shpCurrCirculeData) : base(shpCurrCirculeData) { }

        public override void Draw(Graphics gGraphicsHndlr)
        {
            gGraphicsHndlr.DrawPolygon(new Pen(Brushes.Green, 2), new Point[] { new Point(shpShapeData.X, shpShapeData.Y), new Point(shpShapeData.X + 25, shpShapeData.Y + 25), new Point(shpShapeData.X , shpShapeData.Y + 50) });
        }
    }




}
