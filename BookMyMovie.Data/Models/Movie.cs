using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyMovie.Data.Models
{
    public class Movies
    {
        [JsonProperty("movies")]
        public IEnumerable<Movie> MovieCollection { get; set; }
    }

    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public string Location { get; set; }
        public string Plot { get; set; }
        public string Poster { get; set; }
        public List<string> SoundEffects { get; set; }
        public List<string> Stills { get; set; }

        [JsonProperty("imdbID")]
        public string ImdbID { get; set; }

        [JsonProperty("listingType")]
        public string ListingType { get; set; }

        [JsonProperty("imdbRating")]
        public string ImdbRating { get; set; }
    }
}
