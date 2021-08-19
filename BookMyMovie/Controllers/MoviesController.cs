using BookMyMovie.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace BookMyMovie.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly ILogger<MoviesController> _logger;

        public MoviesController(IMovieService movieService, ILogger<MoviesController> logger)
        {
            _movieService = movieService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return new OkObjectResult(_movieService.GetAll());
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occured");
                return StatusCode(500); 
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                return new OkObjectResult(_movieService.GetById(id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured");
                return StatusCode(500);
            }
        }
    }
}
