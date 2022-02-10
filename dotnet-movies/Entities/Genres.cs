using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using dotnet_movies.Validations;

namespace dotnet_movies.Entities
{
    public class Genres
    //:IValidatableObject
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="the field name with {0} is required")]
        [StringLength(50)]
        [FirstLetterUpperCase]
         public string Name { get; set; }
        // [Range(18,30)]
        // public int Age { get; set; }
        // [CreditCard]
        // public string CreditCard { get; set; }
        // [Url]
        // public string Url { get; set; }

        // public IEnumerable<ValidationResult> Validate(ValidationContext validationContext){
        //     if(!string.IsNullOrEmpty(Name)){
        //         var firstLetter=Name[0].ToString();

        //         if(firstLetter!=firstLetter.ToUpper()){
        //             yield return new ValidationResult("first letter should be uppercase", new string[] {nameof(Name)});
        //         }
        //     }
        // }
    }
}