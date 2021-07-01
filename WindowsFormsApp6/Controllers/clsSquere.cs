using System;
using System.Collections.Generic;
using CandidateTest.Models;
using System.Drawing;


namespace CandidateTest.Controllers
{
    public class clsSquere : clsShape
    {
        public clsSquere(strctShapeData shpCurrCirculeData) : base(shpCurrCirculeData) { }

  

        public override void Draw(Graphics gGraphicsHndlr)
        {
            if (bIsOnStage)
            {
                Point pntCurrPos = new Point(shpShapeData.X * SCALE_FACTOR, shpShapeData.Y * SCALE_FACTOR);
                gGraphicsHndlr.FillRectangle(dicColors[shpShapeData.color], new Rectangle(new Point(shpShapeData.X * SCALE_FACTOR, shpShapeData.Y * SCALE_FACTOR), dicSizes[shpShapeData.size]));

                
            }
        }
    }
}
