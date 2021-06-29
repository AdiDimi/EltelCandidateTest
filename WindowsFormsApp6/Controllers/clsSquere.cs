//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
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
                gGraphicsHndlr.DrawRectangle(new Pen(Brushes.Yellow, 2), new Rectangle(new Point(shpShapeData.X, shpShapeData.Y), new Size(50, 50)));
            }
        }
    }
}
