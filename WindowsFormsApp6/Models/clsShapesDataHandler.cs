using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using CandidateTest.Controllers;

namespace CandidateTest.Models
{
    public class clsShapesDataHandler
    {
        string strJsonpath = "..\\..\\Models\\entityData.json";
        string strCSVpath = "..\\..\\Models\\MovesData.csv";

        public static IEnumerable<strctShapeData> lstAllShapes;

        public clsShapesDataHandler()
        {

            
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

        public void SaveHistoryToCsv(List<stctShapeMoveInfo> lstAllShapesHistory)
        {
            try
            {
                using (StreamWriter r = new StreamWriter(strCSVpath))
                {

                    foreach (stctShapeMoveInfo dataCurrMove in lstAllShapesHistory)
                    {
                                            //string json = r.ReadToEnd();
                         r.WriteLine($"eID {dataCurrMove.entity_id.ToString()}  ,{dataCurrMove.name} , {dataCurrMove.X} , {dataCurrMove.Y}");
                  
                    }
                }

            }
            catch (Exception ex)
            {
                throw new System.ArgumentException($"Error on loading Json file : '{ex.Message}'");
            }
        }
        
    }
}
