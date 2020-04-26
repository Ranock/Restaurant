using RestaurantWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantWork.Services
{
    public interface IParserService
    {
        List<Restaurant> Get(Archive arch);
    }
}
