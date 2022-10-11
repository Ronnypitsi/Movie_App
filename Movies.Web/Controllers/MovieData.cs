using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movies.Data.Model;

namespace Movies.Web.Models
{
    public class MovieData
    {
        public int MovieID { get; set; }
        public string MovieName { get; set; }
        public int ReleaseYear { get; set; }
        public Genres Genre { get; set; }
        public List<Characters> Characters { get; set; }

    }
    
}
