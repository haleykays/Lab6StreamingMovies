using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace Lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new StudioContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }
            using (var db = new StudioContext())
            
            {
                Studio studio1 = new Studio 
                { 
                    StudioName = "20th Century Fox",
                    Movies = new List<Movies>
                {
                    new Movies { MovieTitle = "Avatar", Genre = "Action" },
                    new Movies { MovieTitle = "Deadpool", Genre = "Action"},
                    new Movies { MovieTitle = "Apollo 13", Genre = "Drama"},
                    new Movies { MovieTitle = "The Martian", Genre = "Sci-Fi"}

                }


                };

                Studio studio2 = new Studio
                {
                    StudioName = "Univeral Pictures"
                };

                db.Add(studio1);
                db.Add(studio2);
                db.SaveChanges();
            }
                using (var db = new StudioContext())
                {
                    Movies newMovie = new Movies {MovieTitle = "Jurassic Park", Genre = "Action"};
                    newMovie.Studio = db.Studios.Find(2);
                    db.Add(newMovie);
                    db.SaveChanges();
                }

                using (var db = new StudioContext())
                {
                    Movies movie = db.Movies.Where(m => m.MovieTitle == "Apollo 13").First();
                    movie.Studio = db.Studios.Where(s => s.StudioName == "Universal Pictures").First();
                    db.SaveChanges();
                }

                using (var db = new StudioContext())
                {

                }

        }
    }
}