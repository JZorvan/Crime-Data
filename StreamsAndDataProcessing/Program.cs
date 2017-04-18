using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StreamsAndDataProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            var fileName = Path.Combine(directory.FullName, "SacramentocrimeJanuary2006.csv");
            var fileContents = ReadCrimeResults(fileName);
        }

        public static string ReadFile(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                return reader.ReadToEnd();
            }
        }

        public static List<CrimeResult> ReadCrimeResults(string fileName)
        {
            var crimeResults = new List<CrimeResult>();
            using (var reader = new StreamReader(fileName))
            {
                string line = "";
                reader.ReadLine();
                while ((line = reader.ReadLine()) != null)
                {
                    var crimeResult = new CrimeResult();
                    string[] values = line.Split(',');
                    int parseInt;

                    DateTime timeOfIncident;
                    if (DateTime.TryParse(values[0], out timeOfIncident))
                    {
                        crimeResult.TimeOfIncident = timeOfIncident;
                    }

                    crimeResult.Address = values[1].Trim();

                    if (int.TryParse(values[2], out parseInt))
                    {
                        crimeResult.District = parseInt;
                    }

                    crimeResult.Beat = values[3].Trim();

                    if (int.TryParse(values[4], out parseInt))
                    {
                        crimeResult.Grid = parseInt;
                    }

                    crimeResult.Description = values[5].Trim();

                    if (int.TryParse(values[6], out parseInt))
                    {
                        crimeResult.NCIC_Code = parseInt;
                    }

                    double latitude;
                    if (double.TryParse(values[7], out latitude))
                    {
                        crimeResult.Latitude = latitude;
                    }

                    double longitude;
                    if (double.TryParse(values[8], out longitude))
                    {
                        crimeResult.Longitude = longitude;
                    }

                    crimeResults.Add(crimeResult);
                }
            }
            return crimeResults;
        }
    }
}
