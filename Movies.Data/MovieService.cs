using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using Movies.Data.Model;
using Microsoft.Extensions.Configuration;

namespace Movies.Data
{
    public class MovieService
    {

        
        public static List<Actors> GetAllActors(string CS)
        {
            
            List<Actors> ActorsList = new List<Actors>();
           
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Actors", con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var Actors = new Actors();

                    Actors.ActorID = Convert.ToInt32(rdr["ActorID"]);
                    Actors.ActorName = rdr["ActorName"].ToString();
                    Actors.ActorDOB = Convert.ToDateTime(rdr["ActorDOB"].ToString());
                    
                    ActorsList.Add(Actors);
                }
                con.Close();
            }
            
            return ActorsList;
        }
         public static Actors GetActor(string CS,int ActorID)
        {
            
            Actors Actor = new Actors();
           
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand($"SELECT * FROM Actors where ActorID={ActorID}", con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    

                    Actor.ActorID = Convert.ToInt32(rdr["ActorID"]);
                    Actor.ActorName = rdr["ActorName"].ToString();
                    Actor.ActorDOB = Convert.ToDateTime(rdr["ActorDOB"].ToString());
                    
                   
                }
                con.Close();
            }
            
            return Actor;
        }
        public static void AddActor(string CS, string ActorName, string ActorDOB)
        {

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand($"INSERT INTO Actors (ActorName,ActorDOB) VALUES (\'{ActorName}\',{ActorDOB})", con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                cmd.ExecuteNonQuery();
                
                con.Close();
            }

        }
        public static List<Movie> GetAllMovies(string CS)
        {
            
            List<Movie> MovieList = new List<Movie>();
           
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Movies", con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var Movie = new Movie();

                    Movie.MovieID = Convert.ToInt32(rdr["MovieID"]);
                    Movie.MovieName = rdr["MovieName"].ToString();
                    Movie.Genre = Convert.ToInt32(rdr["Genre"]);
                    Movie.ReleaseYear = Convert.ToInt32(rdr["ReleaseYear"]);
                    MovieList.Add(Movie);
                }
                con.Close();
            }
            
            return MovieList;
        }
        public static Movie GetMovies(string CS,int MovieID)
        {

            Movie Movie = new Movie();

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand($"SELECT * FROM Movies where MovieID={MovieID}", con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                  

                    Movie.MovieID = Convert.ToInt32(rdr["MovieID"]);
                    Movie.MovieName = rdr["MovieName"].ToString();
                    Movie.Genre = Convert.ToInt32(rdr["Genre"]);
                    Movie.ReleaseYear = Convert.ToInt32(rdr["ReleaseYear"]);
                   
                }
                con.Close();
            }
            
            return Movie;
        }
        public static void AddMovie(string CS, Movie Movie)
        {

            List<Movie> MovieList = new List<Movie>();

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand($"INSERT INTO Movies (MovieName , ReleaseYear , Genre) VALUES (\'{Movie.MovieName}\' , {Movie.ReleaseYear} , {Movie.Genre})", con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

        public static Movie UpdateMovies(string CS, Movie Movie)
        {

            Movie Movies = new Movie();

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand($"UPDATE Characters SET  MovieName = {Movie.MovieName}, ReleaseYear = {Movie.ReleaseYear}, Genre = {Movie.Genre} WHERE MovieID = {Movie.MovieID};", con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {


                    Movies.MovieID = Convert.ToInt32(rdr["MovieID"]);
                    Movies.MovieName = rdr["MovieName"].ToString();
                    Movies.ReleaseYear = Convert.ToInt32(rdr["ReleaseYear"]);
                    Movies.Genre = Convert.ToInt32(rdr["Genre"]);

                  
                }
                con.Close();
            }

            return Movies;
        }

        public static Genres GetGenres(string CS,int GenreID)
        {

            Genres Genres = new Genres();

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand($"SELECT * FROM Genres where GenreID={GenreID}", con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {


                    Genres.GenreID= Convert.ToInt32(rdr["GenreID"]);
                    Genres.GenreName = rdr["GenreName"].ToString();
                    
                }
                con.Close();
            }
            return Genres;
        }
        public static Genres UpdateGenres(string CS, Genres Genre)
        {

            Genres Genres = new Genres();

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand($"UPDATE Genres SET GenreName = {Genre.GenreName} WHERE CharacterName={Genre.GenreID}", con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {


                    Genres.GenreID= Convert.ToInt32(rdr["GenreID"]);
                    Genres.GenreName = rdr["GenreName"].ToString();
                    
                }
                con.Close();
            }
            return Genres;
        }
        public static List<Genres> GetAllGenres(string CS)
        {

            List<Genres> Genres = new List<Genres>();

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand($"SELECT * FROM Genres", con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    Genres Genre = new Genres();

                    Genre.GenreID= Convert.ToInt32(rd["GenreID"]);
                    Genre.GenreName = rd["GenreName"].ToString();
                    Genres.Add(Genre);
                }
                con.Close();
            }
            return Genres;
        }
        public static void AddGenres(string CS,string GenreName)
        {

           
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand($"INSERT INTO Genres (GenreName) VALUES (\'{GenreName}\')", con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                cmd.ExecuteNonQuery();
               
                con.Close();
            }

           
        }

        public static List<Characters> RemoveCharacters(string CS, Characters Characters)
        {

            List<Characters> CharactersList = new List<Characters>();

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand($"DELETE FROM Characters WHERE CharacterName={Characters.CharacterName};", con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var Character = new Characters();

                    Character.MovieID = Convert.ToInt32(rdr["MovieID"]);
                    Character.CharacterName = rdr["CharacterName"].ToString();
                    Character.ActorID = Convert.ToInt32(rdr["ActorID"]);

                    CharactersList.Add(Character);
                }
                con.Close();
            }

            return CharactersList;
        }
        public static Characters UpdateCharacters(string CS, Characters Characters)
        {

            Characters CharactersList = new Characters();

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand($"UPDATE Characters SET MovieID = {Characters.MovieID}, ActorID = {Characters.ActorID} WHERE CharacterName={Characters.CharacterName};", con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var Character = new Characters();

                    Character.MovieID = Convert.ToInt32(rdr["MovieID"]);
                    Character.CharacterName = rdr["CharacterName"].ToString();
                    Character.ActorID = Convert.ToInt32(rdr["ActorID"]);

                    CharactersList=Character;
                }
                con.Close();
            }

            return CharactersList;
        }
        public static List<Characters> AddCharacters(string CS, Characters Characters)
        {

            List<Characters> CharactersList = new List<Characters>();

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand($"INSERT INTO Characters (MovieID, ActorID, CharacterName) VALUES ({Characters.MovieID}, {Characters.ActorID}, \'{Characters.CharacterName}\')", con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var Character = new Characters();

                    Character.MovieID = Convert.ToInt32(rdr["MovieID"]);
                    Character.CharacterName = rdr["CharacterName"].ToString();
                    Character.ActorID = Convert.ToInt32(rdr["ActorID"]);

                    CharactersList.Add(Character);
                }
                con.Close();
            }

            return CharactersList;
        }
        public static List<Characters> GetCharacters(string CS,int MovieID)
        {

            List<Characters> CharactersList = new List<Characters>();

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand($"SELECT * FROM Characters where MovieID={MovieID}", con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var Character = new Characters();

                    Character.MovieID = Convert.ToInt32(rdr["MovieID"]);
                    Character.CharacterName = rdr["CharacterName"].ToString();
                    Character.ActorID = Convert.ToInt32(rdr["ActorID"]);

                    CharactersList.Add(Character);
                }
                con.Close();
            }

            return CharactersList;
        }
        public static List<Characters> GetAllCharacters(string CS)
        {

            List<Characters> CharactersList = new List<Characters>();

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand($"SELECT * FROM Characters ", con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var Character = new Characters();

                    Character.MovieID = Convert.ToInt32(rdr["MovieID"]);
                    Character.CharacterName = rdr["CharacterName"].ToString();
                    Character.ActorID = Convert.ToInt32(rdr["ActorID"]);

                    CharactersList.Add(Character);
                }
                con.Close();
            }

            return CharactersList;
        }
    }



}
