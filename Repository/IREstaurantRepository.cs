using RestaurantWork.Models;
using System;
using System.Collections.Generic;

namespace RestaurantWork.Repository
{
    public interface IREstaurantRepository
    {
        List<String> GetNamesInTime(DateTime time);
        Restaurant GetByName(string name);

        void Update(Restaurant restaurant);

        void SaveOne(Restaurant restaurant);

    }
}
