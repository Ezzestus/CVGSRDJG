///Created by David Klumpenhower
///Dec 12, 2016
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DataAnnotationsExtensions;
using RPClassLibrary;
using VideoGameStore.Models;
using System.Linq;
using System.Web;

namespace VideoGameStore.Models
{
    public class AverageGameRatingMetaData
    {
        [Display(Name = "Game ID")]
        public int game_id { get; set; }
        [Required]
        [Display(Name = "Game Name")]
        public string game_name { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string description { get; set; }
        [Required]
        [Display(Name = "Cost")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal cost { get; set; }
        [Required]
        [Display(Name = "List Price")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal list_price { get; set; }
        [Required]
        [Display(Name = "Quantity On Hand")]
        [Min(0)]
        public int on_hand { get; set; }
        [Required]
        [Display(Name = "Developer")]
        public string developer_name { get; set; }
        [Required]
        [Display(Name = "Publisher")]
        public string publisher_name { get; set; }
        [Required]
        [Display(Name = "Genre")]
        public string genre { get; set; }
        [Required]
        [Display(Name = "Release Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime release_date { get; set; }
        [Display(Name = "On Sale?")]
        public bool is_on_sale { get; set; }
        [Display(Name = "Discontinued?")]
        public bool is_discontinued { get; set; }
        [Display(Name = "Downloadable?")]
        public bool is_downloadable { get; set; }
        [Display(Name = "Physical Copy?")]
        public bool is_physical_copy { get; set; }
        [Display(Name = "Cover")]
        public string image_location { get; set; }
        [Display(Name = "Average Rating")]
        public string averageRating { get; set; }
    }
    [MetadataType(typeof(AverageGameRatingMetaData))]
    public partial class AverageGameRating : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            game_name = RPValidations.Capitalize(game_name, true);
            description = RPValidations.CapitalizeSentences(description);
            yield return ValidationResult.Success;
        }
    }
}