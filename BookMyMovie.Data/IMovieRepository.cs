using BookMyMovie.Data.Models;
using System;
using System.Collections.Generic;

namespace BookMyMovie.Data
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAll();
        Movie GetById(int id);
    }
}
