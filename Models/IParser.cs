using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using RestaurantWork.Models;

namespace RestaurantWork.Services
{
    public interface IParser
    {
        bool Accepts(Archive file);
        List<Restaurant> Extract(Archive file);
    }
}
