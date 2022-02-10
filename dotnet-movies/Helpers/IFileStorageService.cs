using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace dotnet_movies.Helpers
{
    public interface IFileStorageService
    {
        Task DeleteFile(string fileRoute,string containerName);
        Task<string> SaveFile(string containerName,IFormFile file);
        Task<string> EditFile(string containerName, string fileRoute, IFormFile file);
    }
}