//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using CandidateTest.Models;
using System.Drawing;

namespace CandidateTest.Controllers
{
    public class clsCircle : clsShape
    {
        public clsCircle(strctShapeData shpCurrCirculeData) : base(shpCurrCirculeData) { }

        public override void Draw(Graphics gGraphicsHndlr)
        {
            if (bIsOnStage)
            {
               
                //gGraphicsHndlr.DrawEllipse(new Pen(Brushes.Red, 2), new Rectangle(new Point(shpShapeData.X, shpShapeData.Y), new Size(50, 50)));
                gGraphicsHndlr.FillEllipse(dicColors[shpShapeData.color], new Rectangle(new Point(shpShapeData.X * SCALE_FACTOR, shpShapeData.Y * SCALE_FACTOR), new Size(50, 50)));
            }
        }
    }
}
