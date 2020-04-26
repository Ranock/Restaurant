using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using RestaurantWork.Services;
using RestaurantWork.Models;
using System.Globalization;

namespace WebApplication2.Controllers
{
    
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestauranteService service;
        public RestaurantController(IRestauranteService service)
        {
            this.service = service;
        }

        [HttpPost, DisableRequestSizeLimit]
        [Route("api/restaurants")]
        public IActionResult Post()
        {
            try
            {
               // IRestauranteService service = new RestaurantServiceImpl();
                var file = Request.Form.Files[0];
                Archive arq = new Archive(file, new Dictionary<string, bool>{ { "hasHeaders", true } });
                service.ImportFile(arq);
                return Ok();
            }
            catch(Exception ex)
            {
                return StatusCode(400, $"{ex.Message}");
            }
        }
        [HttpGet]
        [Route("api/restaurants")]
       public IActionResult Get([FromQuery(Name = "time")] string time)
        {
            Nullable<DateTime> parsedTime;
            try
            {
                return Ok(service.GetNames(time));
               
            }catch (Exception)
            {
                return StatusCode(400, $"Incorect format time : [{time}] format : HH:mm");
            }
            
        }
    
    }
}
