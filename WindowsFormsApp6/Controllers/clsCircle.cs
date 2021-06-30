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
                gGraphicsHndlr.FillEllipse(dicColors[shpShapeData.color], new Rectangle(new Point(shpShapeData.X * SCALE_FACTOR, shpShapeData.Y * SCALE_FACTOR), dicSizes[shpShapeData.size]));
            }
        }
    }
}
