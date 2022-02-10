using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_movies.DTOs;
using dotnet_movies.Entities;
using Google.Protobuf.WellKnownTypes;

namespace dotnet_movies.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<GenreDTO, Genres>().ReverseMap();
            CreateMap<GenreCreationDTO, Genres>();

            CreateMap<ActorDTO, Actors>().ReverseMap();
            CreateMap<ActorCreationDTO, Actors>()
            .ForMember(x => x.Picture, Option => Option.Ignore());
        }
    }
}