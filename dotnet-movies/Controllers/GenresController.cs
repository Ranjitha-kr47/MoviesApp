using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_movies.DTOs;
using dotnet_movies.Entities;
using dotnet_movies.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MySqlX.XDevAPI.Common;
using Renci.SshNet.Messages;

namespace dotnet_movies.Controllers
{
    [Route("api/genres")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly ILogger<GenresController> logger;
        private readonly ApplicationDbContext _context;
        private readonly IMapper mapper;

        public GenresController(ILogger<GenresController> logger, ApplicationDbContext context,
        IMapper mapper)
        {
            this.logger = logger;
            this._context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        [HttpGet("/allgenres")]
        public async Task<ActionResult<List<GenreDTO>>> GetAllGenres()
        {
            logger.LogInformation("Getting All Genres");
            var genres = await _context.genres.ToListAsync();
            return mapper.Map<List<GenreDTO>>(genres);
            //return new List<Genres>() {new Genres() {Id=1, Name="Comedy"}};
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<GenreDTO>> Get(int Id)
        {
            var genre = await _context.genres.FirstOrDefaultAsync(x=> x.Id==Id);
            if (genre == null)
            {
                return NotFound();
            }
            return mapper.Map<GenreDTO>(genre);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] GenreCreationDTO genreCreationDTO)
        {
            var genre = mapper.Map<Genres>(genreCreationDTO);
            _context.Add(genre);
            await _context.SaveChangesAsync();
            return Ok(genre);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<GenreCreationDTO>> Put(int id,[FromBody] GenreCreationDTO genreCreationDTO)
        {
            var genre=mapper.Map<Genres>(genreCreationDTO);
            genre.Id=id;
            _context.Entry(genre).State=EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(genre);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var genre=await _context.genres.FirstOrDefaultAsync(x=>x.Id==id);
            if(genre==null){
                return NotFound();
            }

            _context.Remove(genre);
            await _context.SaveChangesAsync();
            return Ok(new {
                Message=$"Genre with Id {id} deleted Successfully"
            });
        }
    }
}