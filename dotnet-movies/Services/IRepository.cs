using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_movies.Entities;

namespace dotnet_movies.Services
{
    public interface IRepository
    {
        Task<List<Genres>> GetAllGenres();

         Genres GetGenreById(int Id);

         void AddGenre(Genres genres);
    }
}