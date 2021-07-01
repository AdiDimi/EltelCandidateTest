using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using CandidateTest.Controllers;
using CandidateTest.Shared;

namespace CandidateTest.Models
{
    public class clsShapesDataHandler
    {
     
        public static IEnumerable<strctShapeData> lstAllShapes;

        public clsShapesDataHandler()
        {

            
        }

        public void LoadJson()
        {

            try
            {
                using (StreamReader r = new StreamReader(SharedItems.JSON_FILE_NAME))
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
                using (StreamWriter r = new StreamWriter(SharedItems.CSV_FILE_NAME))
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
