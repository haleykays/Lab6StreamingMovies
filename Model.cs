using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Lab6
{
    public class StudioContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = database.db");
        }
        public DbSet<Studio> Studios {get; set;}

        public DbSet<Movies> Movies {get; set;}

    }

    public class Studio
    {
        public int StudioId {get; set;}

        public string StudioName {get; set;}

        public List<Movies> Movies {get; set;}

        public override string ToString()
        {
            return $"Studio {StudioId} - {StudioName}";
        }
    }

    public class Movies
    {
        public int MovieID {get; set;}

        public string MovieTitle {get; set;}

        public string Genre {get; set;}

        public int StudioId {get; set;}

        public Studio Studio {get; set;}

        public override string ToString() 
        {
            return $"Movie {MovieID} - {MovieTitle}";
        }
    }










}