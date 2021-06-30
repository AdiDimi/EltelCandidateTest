using CandidateTest.Models;
using System.Drawing;

namespace CandidateTest.Controllers
{
    public class clsTriangle : clsShape
    {
        public clsTriangle(strctShapeData shpCurrCirculeData) : base(shpCurrCirculeData) { }

        public override void Draw(Graphics gGraphicsHndlr)
        {
            if (bIsOnStage)
            {
                //gGraphicsHndlr.DrawPolygon(new Pen(Brushes.Green, 2), new Point[] { new Point(shpShapeData.X, shpShapeData.Y), new Point(shpShapeData.X + 25, shpShapeData.Y + 25), new Point(shpShapeData.X, shpShapeData.Y + 50) });
                gGraphicsHndlr.FillPolygon(dicColors[shpShapeData.color], new Point[] { new Point(shpShapeData.X, shpShapeData.Y), new Point(shpShapeData.X + 25, shpShapeData.Y + 25), new Point(shpShapeData.X, shpShapeData.Y + 50) });

            }
        }
    }
}
