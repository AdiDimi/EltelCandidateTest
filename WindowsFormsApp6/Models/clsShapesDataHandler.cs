using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace CandidateTest.Models
{
    public class clsShapesDataHandler
    {
        string strJsonpath = "..\\..\\Models\\entityData.json";
        public IEnumerable<strctShapeData> lstAllShapes;

        public clsShapesDataHandler()
        {

            LoadJson();
        }

        public void LoadJson()
        {

            try
            {
                using (StreamReader r = new StreamReader(strJsonpath))
                {
                    string json = r.ReadToEnd();

                    lstAllShapes = JsonConvert.DeserializeObject<IEnumerable<strctShapeData>>(json);

                }
        
            }
            catch (Exception ex)
            {
                throw new System.ArgumentException($"Error on loading Json file : '{ex.Message}'");
            }
        }
        
    }
}
