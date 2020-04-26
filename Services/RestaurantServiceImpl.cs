using RestaurantWork.Models;
using RestaurantWork.Repository;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace RestaurantWork.Services
{
    public class RestaurantServiceImpl : IRestauranteService
    {
        private IREstaurantRepository repository;
        private IParserService parserService;
        public RestaurantServiceImpl(IREstaurantRepository repository, IParserService parserService)
        {
            this.repository = repository;
            this.parserService = parserService;
        }

        public List<string> GetNames(string time)
        {
            try
            {
                var parsedTime = DateTime.ParseExact(time, "HH:mm", CultureInfo.InvariantCulture);
                return repository.GetNamesInTime(parsedTime);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Restaurant> ImportFile(Archive file)
        {
            List<Restaurant> restaurants = parserService.Get(file);
            foreach (Restaurant res in restaurants)
            {
                if (repository.GetByName(res.Name) != null)
                {
                    repository.Update(res);
                }
                else
                {
                    repository.SaveOne(res);
                }
            }
            return restaurants;

        }

    }
}
