using BookMyMovie.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyMovie.Service
{
    public interface IMovieService
    {
        IEnumerable<Movie> GetAll();
        Movie GetById(string id);
    }
}
