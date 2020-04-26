using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace RestaurantWork.Models
{
    public class Archive
    {
        private IFormFile file;
        private Dictionary<String, bool> props;
        public Archive(IFormFile file, Dictionary<String, bool> props)
        {
            this.File = file;
            this.Props = props;

        }

        public IFormFile File { get => file; set => file = value; }
        public Dictionary<string, bool> Props { get => props; set => props = value; }
    }
}
