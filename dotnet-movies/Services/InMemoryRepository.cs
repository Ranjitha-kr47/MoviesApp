using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_movies.Entities;
using Microsoft.AspNetCore.DataProtection.Repositories;

namespace dotnet_movies.Services
{
    public class InMemoryRepository : IRepository
    {
        private List<Genres> _genres;
        public InMemoryRepository()
        {
            _genres = new List<Genres>()
            {
                new Genres(){Id=1,Name="Comedy"},
                new Genres(){Id=2, Name="Action"}
            };
        }

        public async Task<List<Genres>> GetAllGenres()
        {
            await Task.Delay(1);
            return _genres;
        }

        public Genres GetGenreById(int Id)
        {
            return _genres.FirstOrDefault(x => x.Id == Id);
        }

        public void AddGenre(Genres genre){
            genre.Id=_genres.Max(x=>x.Id)+1;
            _genres.Add(genre);
        }
    }
}