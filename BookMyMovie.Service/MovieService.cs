using BookMyMovie.Data;
using BookMyMovie.Data.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyMovie.Service
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public IEnumerable<Movie> GetAll()
        {
            return _movieRepository.GetAll();
        }

        public Movie GetById(int id)
        {
            return _movieRepository.GetById(id);
        }
    }
}
