using Microsoft.AspNetCore.Http;
using RestaurantWork.Models;
using RestaurantWork.Repository;
using System;
using System.Collections.Generic;


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

        public List<string> GetNames(DateTime time)
        {
            return repository.GetNamesInTime(time);
        }

        public List<Restaurant> ImportFile(Archive file)
        {
            List<Restaurant> restaurants = parserService.Get(file);
            foreach(Restaurant res in restaurants)
            {
                if(repository.GetByName(res.Name) != null)
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
