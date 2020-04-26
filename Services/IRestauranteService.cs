using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using RestaurantWork.Models;

namespace RestaurantWork.Services
{
    public interface IRestauranteService
    {
        List<Restaurant> ImportFile(Archive file);
        List<string> GetNames(string time);
    }
}
