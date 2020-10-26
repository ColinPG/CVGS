using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CVGS.Models
{

    [ModelMetadataTypeAttribute(typeof(GameMetaData))]
    public partial class Game : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (EnglishName == null || EnglishName.Trim() == "")
                yield return new ValidationResult("English Name cannot be blank.", new[] { nameof(EnglishName) });
            else
                EnglishName = ModelValidations.Capitilize(EnglishName).Trim();
            yield return ValidationResult.Success;

            //Title captilized
            //player count  must be number
            //ESRB rating code, category, perspective category, status code, subcategory dropdowns (no blanks)
            //description, detail no blanks no formatting
        }
    }
    public class GameMetaData
    {
        public Guid Guid { get; set; }
        [Display(Name = "Status Code")]
        public string GameStatusCode { get; set; }
        [Display(Name = "Category")]
        public int GameCategoryId { get; set; }
        [Display(Name = "Subcategory")]
        public int? GameSubCategoryId { get; set; }
        [Display(Name = "Esrb Rating Code")]
        public string EsrbRatingCode { get; set; }
        [Display(Name = "Title")]
        public string EnglishName { get; set; }
        [Display(Name = "Titre")]
        public string FrenchName { get; set; }
        [Display(Name = "French Version")]
        public bool FrenchVersion { get; set; }
        [Display(Name = "Player Count")]
        public string EnglishPlayerCount { get; set; }
        [Display(Name = "French Player Count")]
        public string FrenchPlayerCount { get; set; }
        [Display(Name = "Perspective Code")]
        public string GamePerspectiveCode { get; set; }
        [Display(Name = "Trailer")]
        public string EnglishTrailer { get; set; }
        [Display(Name = "bande annonce")]
        public string FrenchTrailer { get; set; }
        [Display(Name = "Description")]
        public string EnglishDescription { get; set; }
        [Display(Name = "La Description")]
        public string FrenchDescription { get; set; }
        [Display(Name = "Detail")]
        public string EnglishDetail { get; set; }
        [Display(Name = "Détail")]
        public string FrenchDetail { get; set; }
        [Display(Name = "")]
        public string UserName { get; set; }

    }
}
