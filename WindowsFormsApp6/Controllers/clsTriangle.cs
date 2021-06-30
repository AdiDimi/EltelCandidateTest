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
                Rectangle recBounds = new Rectangle(new Point(shpShapeData.X * SCALE_FACTOR, shpShapeData.Y * SCALE_FACTOR), dicSizes[shpShapeData.size]);

                Point pntTop = new Point(recBounds.X + recBounds.Width / 2, recBounds.Y);
                Point pntRight = new Point(recBounds.X + recBounds.Width, recBounds.Y + recBounds.Height);
                Point pntLeft = new Point(recBounds.X, recBounds.Y + recBounds.Height);
                //gGraphicsHndlr.DrawPolygon(new Pen(Brushes.Green, 2), new Point[] { new Point(shpShapeData.X, shpShapeData.Y), new Point(shpShapeData.X + 25, shpShapeData.Y + 25), new Point(shpShapeData.X, shpShapeData.Y + 50) });
                gGraphicsHndlr.FillPolygon(dicColors[shpShapeData.color], new Point[] { pntTop, pntRight, pntLeft });

            }
        }
    }
}
