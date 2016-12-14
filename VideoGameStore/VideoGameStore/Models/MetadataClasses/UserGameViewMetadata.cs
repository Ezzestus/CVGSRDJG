///Created By David Klumpenhower
///Createde Dec 13, 2016
using RPClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VideoGameStore.Models.MetadataClasses
{
    public class UserGameViewMetadata
    {
        public int userGameID { get; set; }
        public int gameID { get; set; }
        [Display(Name = "Cover")]
        public string imageLocation { get; set; }
        [Display(Name = "Description")]
        public string description { get; set; }
        [Display(Name = "Game Name")]
        public string gameName { get; set; }
        public int? reviewID { get; set; }
        [Display(Name = "Rating")]
        public int? rating { get; set; }
        [Display(Name = "Date of Purchase")]
        public DateTime datePurchased { get;set; }
    }
    [MetadataType(typeof(UserGameViewMetadata))]
    public partial class UserGameViewModel : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield return ValidationResult.Success;
        }
    }
}