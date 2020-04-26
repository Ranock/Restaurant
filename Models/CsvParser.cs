using RestaurantWork.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;


namespace RestaurantWork.Services
{
    public class CsvParser : IParser
    {
        public bool Accepts(Archive archive)
        {
            return archive.File.FileName.EndsWith(".csv") || archive.File.FileName.EndsWith(".CSV");
        }

        public List<Restaurant> Extract(Archive archive)
        {
            List<Restaurant> listRest = new List<Restaurant>(); 
            using (var streamReader = new StreamReader(archive.File.OpenReadStream()))
            {
                string line;
                bool first = true;
                while ((line = streamReader.ReadLine()) != null)
                {
                    var lineValues = line.Split(";");
                    if (!ValidateLine(first, lineValues))
                    {
                        first = false;
                        continue;
                    }
                    first = false;
                    Restaurant rest= new Restaurant();
                    rest.Name = lineValues[0];
                    var dates = lineValues[1].Split("-");
                    rest.Start = DateTime.ParseExact(dates[0], "H:mm", CultureInfo.InvariantCulture);
                    rest.End = DateTime.ParseExact(dates[1], "H:mm", CultureInfo.InvariantCulture);
                    listRest.Add(rest);
                }
            }
            return listRest;
        }
        private bool ValidateLine(bool first, string[] line)
        {
            if (line.Length < 2)
            {
                throw new Exception($"Invalid archive with content : [{line}]");
            }
            
            if(first && !line[1].Contains("-"))
            {
                return false;
            }

            if (!line[1].Contains("-"))
            {
                throw new Exception($"Invalid format date start-end: [{line[1]}]");
            }
            return true;
        }
    }
}
