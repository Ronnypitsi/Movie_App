using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Movies.Data.Model;
using Movies.Data;
using Movies.Web.Models;
using System.Collections.Generic;

namespace Movies.Web.Controllers
{
    public class ReportController : Controller
    {
        private readonly ILogger<ReportController> _logger;

        private readonly IConfiguration Configuration;

        public ReportController(ILogger<ReportController> logger, IConfiguration _configuration)
        {
            _logger = logger;
            Configuration = _configuration;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Movies");


          
        }
        public IActionResult Movies()
        {
            string connString = this.Configuration.GetConnectionString("DefaultConnection");

            List<Movie> MovieList = MovieService.GetAllMovies(connString);
            List<MovieData> MoviesData = new List<MovieData>();
            foreach (Movie movie in MovieList)
            {
                Genres Genres = MovieService.GetGenres(connString, movie.Genre);
                MoviesData.Add(new MovieData
                {
                    MovieID = movie.MovieID,
                    MovieName = movie.MovieName,
                    ReleaseYear = movie.ReleaseYear,
                    Genre = Genres,
                    Characters = MovieService.GetCharacters(connString, movie.MovieID)
                });
            }


            return View(MoviesData);
        }
         public IActionResult AddMovie()
        {
            string connString = this.Configuration.GetConnectionString("DefaultConnection");
            List<Genres> Genres = MovieService.GetAllGenres(connString);
          


            return View(Genres);
        }
         public IActionResult formAddMovie(string MovieName,int ReleaseYear, int Genre)
        {
            Movie Movie = new Movie();
            Movie.MovieName = MovieName;
            Movie.ReleaseYear = ReleaseYear;
            Movie.Genre = Genre;
            string connString = this.Configuration.GetConnectionString("DefaultConnection");
            MovieService.AddMovie(connString, Movie);

            List<Genres> Genres = MovieService.GetAllGenres(connString);

            return RedirectToAction("Movies");
        }

        public IActionResult AddCharacters()
        {
            string connString = this.Configuration.GetConnectionString("DefaultConnection");

            List<Actors> Actors = MovieService.GetAllActors(connString);
            List<Movie> Movies = MovieService.GetAllMovies(connString);
            charecterObject charecterObject = new charecterObject();
            charecterObject.Actors = Actors;
            charecterObject.Movies = Movies;
                return View(charecterObject);
        }
         public IActionResult Characters()
        {
            string connString = this.Configuration.GetConnectionString("DefaultConnection");

            List<Characters> Characters = MovieService.GetAllCharacters(connString);
            List<Charactersdata> CharactersdataList = new List<Charactersdata>();
            foreach (Characters Character in Characters)
            {    var movie= MovieService.GetMovies(connString, Character.MovieID); 
                 var Actor = MovieService.GetActor(connString,Character.ActorID); 
                Charactersdata Charactersdata = new Charactersdata();
                Charactersdata.CharacterName = Character.CharacterName;
                Charactersdata.ActorName = Actor.ActorName;
                Charactersdata.MovieName = movie.MovieName;
                CharactersdataList.Add(Charactersdata);

            }
                return View(CharactersdataList);
        }
        public IActionResult formAddCharacter(string CharacterName, int MovieID, int ActorID)
        {
            Characters Character = new Characters();
            Character.CharacterName = CharacterName;
            Character.ActorID = ActorID;
            Character.MovieID= MovieID;
            string connString = this.Configuration.GetConnectionString("DefaultConnection");
            MovieService.AddCharacters(connString, Character);

            List<Genres> Genres = MovieService.GetAllGenres(connString);

            return RedirectToAction("Characters");
        }

        public IActionResult Genres()
        {
            string connString = this.Configuration.GetConnectionString("DefaultConnection");
            List<Genres> Genres = MovieService.GetAllGenres(connString);



            return View(Genres);
        }
        public IActionResult AddGenres()
        {
            return View();
        }
        public IActionResult formAddGenres(string GenreName)
        {
            
           
            string connString = this.Configuration.GetConnectionString("DefaultConnection");
            MovieService.AddGenres(connString, GenreName);

            return RedirectToAction("Genres");
        }
        public IActionResult AddActor()
        {
            return View();
        }


        public IActionResult Actors()
        {
            string connString = this.Configuration.GetConnectionString("DefaultConnection");
            List<Actors> Actors = MovieService.GetAllActors(connString);



            return View(Actors);
        }
         public IActionResult formAddActor(string ActorName,string ActorDOB)
        {
            string connString = this.Configuration.GetConnectionString("DefaultConnection");
             MovieService.AddActor(connString, ActorName, ActorDOB);



            return RedirectToAction("Actors");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}