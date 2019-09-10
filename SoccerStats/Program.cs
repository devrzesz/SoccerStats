using System;
using System.Collections.Generic;
using System.IO;

namespace SoccerStats
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentDirectory = Directory.GetCurrentDirectory();

            DirectoryInfo directory = new DirectoryInfo(currentDirectory);

            string fileName = Path.Combine(directory.FullName, "SoccerGameResults.csv");

            var ourResult = ReadSoccerResults(fileName);



            var fileContents = ReadFile(fileName);

            string[] fileLines = fileContents.Split(new char[] { '\n' });

            foreach(var line in fileLines)
            {
                Console.WriteLine(line);
            }

        }




        public static string ReadFile(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                return reader.ReadToEnd();
            }
        }

        public static List<string[]> ReadSoccerResults(string fileName)
        {
            var soccerResults = new List<string[]>();
            
            using (var reader = new StreamReader(fileName))
            {
                string line = "";
                reader.ReadLine();

                while ((line = reader.ReadLine()) != null)
                {
                    var GameResult = new GameResult();
                    string[] values = line.Split(',');

                    soccerResults.Add(values);

                    DateTime gameDate;

                    if (DateTime.TryParse(values[0], out gameDate))
                    {
                        GameResult.GameDate = gameDate;
                    }
                }
            }

            return soccerResults;
        }
    }
}
