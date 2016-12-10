using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace RPClassLibrary
{
    /// <summary>
    /// Postal Code Validation class - contains validation to check format for postal code data
    /// </summary>
    public class PostalCodeValidationAttribute : ValidationAttribute
    {
        /// <summary>
        /// Default constructor for PostalCodeValidationAttribute
        /// </summary>
        public PostalCodeValidationAttribute()
        {
            ErrorMessage = "{0} does not match the required pattern (H0H0H0 or H0H 0H0)";
        }
        /// <summary>
        /// This method checks to see if the postal code value is valid
        /// </summary>
        /// <param name="value">value to be checked</param>
        /// <param name="validationContext">the means by which the data was sent</param>
        /// <returns>ValidationResult - if value conforms to formatting or not</returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult result;
            if (String.IsNullOrWhiteSpace(value.ToString()))
            {
                result = new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }
            else
            {
                Regex pattern = new Regex((@"^([ABCEGHJKLMNPRSTVXY]\d[A-Z] ?\d[A-Z]\d)$"), RegexOptions.IgnoreCase);
                if (pattern.IsMatch(value.ToString()))
                {
                    result = ValidationResult.Success;
                }
                else
                {
                    result = new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
                }
            }
            return result;
        }
    }
}
