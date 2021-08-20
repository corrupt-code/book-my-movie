using BookMyMovie.Data.Models;
using BookMyMovie.Internal.FileIOWrapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookMyMovie.Data
{
    public class MovieRepository : IMovieRepository
    {
        private readonly IFileService _fileService;
        private readonly ILogger _logger;
        private IEnumerable<Movie> _movies;
        public MovieRepository(IConfiguration configuration, IFileService fileService, ILogger<MovieRepository> logger)
        {
            _fileService = fileService;
            _logger = logger;
            // Read datastore
            var filePath = configuration["DataStorePath"];
            InstantiateMoviesCollection(filePath);
        }

        private void InstantiateMoviesCollection(string filePath)
        {
            try
            {
                _movies = JsonConvert.DeserializeObject<Movies>(_fileService.Read(filePath)).MovieCollection;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occured while reading the datastore");
                _movies = new List<Movie>(); // Instantiate with empty
            }
        }

        public IEnumerable<Movie> GetAll() => _movies;

        public Movie GetById(int id) => _movies.FirstOrDefault(x => x.Id == id);
    }
}
