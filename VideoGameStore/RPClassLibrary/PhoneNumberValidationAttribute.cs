/* Filename: PhoneNumberValidationAttribute.cs
 * Description: The purpose of this class is to provide validation conditions for phone numbers.
 * 
 * Revision History:
 *     Ryan Pease, 2016-10-30: Created
*/

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
    /// Phone Number Validation class - ensures that phone number is valid
    /// </summary>
    public class PhoneNumberValidationAttribute : ValidationAttribute
    {
        /// <summary>
        /// Default constructor for PhoneNumberValidationAttribute
        /// </summary>
        public PhoneNumberValidationAttribute()
        {
            ErrorMessage = "{0} Does not match phone number pattern (000-000-0000 or 0000000000).";
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult result;
            if (string.IsNullOrWhiteSpace((string)value))
            {
                result = new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }
            else
            {
                Regex pattern = new Regex((@"\d{3}[ -]?\d{3}[ -]?\d{4}"));
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