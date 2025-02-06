using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YTX4WN
{
    class Loader
    {
        public List<Work> LoadData(string filePath)
        {
            List<Work> works = new List<Work>();

            try
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] columns = line.Split(';');
                    works.Add(Parser.WorkParse(columns));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Hiba történt a betöltése közben: " + e.Message);
            }

            return works;
        }
    }
}
