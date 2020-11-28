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
            //Title (must not be blank)
            if (EnglishName == null || EnglishName.Trim() == "")
                yield return new ValidationResult("English Name cannot be blank.", new[] { nameof(EnglishName) });
            else
                EnglishName = EnglishName.Trim();
            //Player Count (must not be blank and be a number)
            if (EnglishPlayerCount == null || EnglishPlayerCount.Trim() == "")
                yield return new ValidationResult("Player Count cannot be blank.", new[] { nameof(EnglishPlayerCount) });
            else if (ModelValidations.IsStringNumeric(EnglishPlayerCount))
                EnglishPlayerCount = EnglishPlayerCount.Trim();
            //Category is an int, does not need to be validated.
            //Perspective Code (must not be blank)
            if (GamePerspectiveCode == null || GamePerspectiveCode.Trim() == "")
                yield return new ValidationResult("Perspective Code cannot be blank.", new[] { nameof(GamePerspectiveCode) });
            else
                GamePerspectiveCode = GamePerspectiveCode.Trim();
            //Status Code (must not be blank)
            if (GameFormatCode == null || GameFormatCode.Trim() == "")
                yield return new ValidationResult("Status Code cannot be blank.", new[] { nameof(GameFormatCode) });
            else
                GameFormatCode = GameFormatCode.Trim();
            //Subcategory is an int, does not need to be validated.
            //Description (must not be blank)
            if (EnglishDescription == null || EnglishDescription.Trim() == "")
                yield return new ValidationResult("Description cannot be blank.", new[] { nameof(EnglishDescription) });
            else
                EnglishDescription = EnglishDescription.Trim();
            //Status Code (must not be blank)
            if (EnglishDetail == null || EnglishDetail.Trim() == "")
                yield return new ValidationResult("Detail cannot be blank.", new[] { nameof(EnglishDetail) });
            else
                EnglishDetail = EnglishDetail.Trim();

            yield return ValidationResult.Success;
        }
    }
    public class GameMetaData
    {
        public Guid Guid { get; set; }
        [Display(Name = "Format")]
        public string GameFormatCode { get; set; }
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
        [Display(Name = "Perspective")]
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
