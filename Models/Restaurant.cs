using System;

namespace RestaurantWork.Models
{
    public class Restaurant
    {

        String name;
        DateTime start;
        DateTime end;

        public Restaurant()
        { 
        }

        public Restaurant(String name, DateTime start, DateTime end)
        {
            this.End = end;
            this.Start = start;
            this.Name = name;
        }

        public DateTime End { get => end; set => end = value; }
        public DateTime Start { get => start; set => start = value; }
        public string Name { get => name; set => name = value; }
    }
}
