using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateTest.Controllers
{
    public class clsShapeHistoryQueue
    {
        public static int nMaxQueueLen = 1;
        List<stctShapeMoveInfo> quShapesQueue;
        int nEntityID;
        string strEntityName;

        public clsShapeHistoryQueue(int nEntity_ID,string strEntity_Name)
        {
            nEntityID = nEntity_ID;
            strEntityName = strEntity_Name;
            quShapesQueue = new List<stctShapeMoveInfo>();
        }

        public static void SetMaxQueueLen(int nMaxLen)
        {
            nMaxQueueLen = nMaxLen;
        }

        public void InsertMove(int X,int Y)
        {
            stctShapeMoveInfo movCurrShapeMove = new stctShapeMoveInfo();

            movCurrShapeMove.entity_id = nEntityID;
            movCurrShapeMove.name = strEntityName;
            movCurrShapeMove.X = X;
            movCurrShapeMove.Y = Y;

            quShapesQueue.Add(movCurrShapeMove);

            if (quShapesQueue.Count > nMaxQueueLen)
            {
                quShapesQueue.RemoveAt(0);
            }
        }

        public List<stctShapeMoveInfo> GetHistory()
        {
            return quShapesQueue;
          }
    }

    public struct stctShapeMoveInfo
    {
        public int entity_id;
        public string name;
        public int X;
        public int Y;
    }
}
