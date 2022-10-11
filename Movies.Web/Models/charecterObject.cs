using Movies.Data.Model;

namespace Movies.Web.Models
{
    public class charecterObject
    {
        public charecterObject()
        {
            Actors = new List<Actors>();
            Movies = new List<Movie>();
        }
        public List<Actors> Actors { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
