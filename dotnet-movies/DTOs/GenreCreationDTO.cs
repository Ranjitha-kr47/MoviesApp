using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using dotnet_movies.Validations;

namespace dotnet_movies.DTOs
{
    public class GenreCreationDTO
    {
        [Required(ErrorMessage = "the field name with {0} is required")]
        [StringLength(50)]
        [FirstLetterUpperCase]
        public string Name { get; set; }
    }
}