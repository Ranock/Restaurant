using RestaurantWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantWork.Services
{
    public class ParserService : IParserService
    {
        private List<IParser> parsers;

        public ParserService()
        {
            parsers = new List<IParser>
            {
                new CsvParser()
            };
        }
        public List<Restaurant> Get(Archive arch)
        {
            foreach(IParser parser in parsers)
            {
                if (parser.Accepts(arch))
                {
                    return parser.Extract(arch);
                }
            }
            throw new Exception("Archive format not supported");
        }

    }
}
