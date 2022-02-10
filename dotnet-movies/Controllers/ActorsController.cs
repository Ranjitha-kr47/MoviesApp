using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_movies.DTOs;
using dotnet_movies.Entities;
using dotnet_movies.Helpers;
using dotnet_movies.Migrations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnet_movies.Controllers
{
    [Route("api/actors")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper mapper;
        private readonly IFileStorageService fileStorageService;
        private readonly string containerName = "actors";
        public ActorsController(ApplicationDbContext context, IMapper mapper,
         IFileStorageService fileStorageService)
        {
            this._context = context;
            this.mapper = mapper;
            this.fileStorageService = fileStorageService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ActorDTO>>> Get()
        {
            var actors = await _context.actors.ToListAsync();
            return mapper.Map<List<ActorDTO>>(actors);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ActorDTO>> GetById(int Id)
        {
            var actor = await _context.actors.FirstOrDefaultAsync(x => x.Id == Id);
            if (actor == null)
            {
                return NotFound();
            }

            return mapper.Map<ActorDTO>(actor);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] ActorCreationDTO actorCreationDTO)
        {
            var actor = mapper.Map<Actors>(actorCreationDTO);
            if (actorCreationDTO.Picture != null)
            {
                actor.Picture = await fileStorageService.SaveFile(containerName, actorCreationDTO.Picture);
            }
            _context.Add(actor);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        //  [HttpPost]
        // public async Task<ActionResult> Post([FromForm] ActorCreationDTO actorCreationDTO)
        // {
        //     var actor = mapper.Map<actors>(actorCreationDTO);

        //     if (actorCreationDTO.Picture != null)
        //     {
        //         // actor.Picture = await fileStorageService.SaveFile(containerName, actorCreationDTO.Picture);
        //         actor.Picture=await fileStorageService.SaveFile(containerName, actorCreationDTO.Picture)
        //     }

        //     _context.Add(actor);
        //     await _context.SaveChangesAsync();
        //     return NoContent();
        // }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ActorCreationDTO>> Put(int Id, [FromBody] ActorCreationDTO actorCreationDTO)
        {
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int Id)
        {
            var actor = await _context.actors.FirstOrDefaultAsync(x => x.Id == Id);
            if (actor == null)
            {
                return NotFound();
            }

            _context.Remove(actor);
            await _context.SaveChangesAsync();
            return Ok(new
            {
                message = $"Actor with Id: {Id} delteted successfully"
            });
        }
    }
}