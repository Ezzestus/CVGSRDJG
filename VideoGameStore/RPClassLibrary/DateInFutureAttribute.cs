/* Filename: DateInFutureAttribute.cs
 * Description: This class is responsible for validating a date is in the future.
 * 
 * Revision History:
 *      Ryan Pease 2016-10-29: Created
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RPClassLibrary
{    
        /// <summary>
        /// Date Validation class - contains validation to check date to ensure it's after the current date.
        /// </summary>
        public class DateInFutureAttribute : ValidationAttribute
        {
            /// <summary>
            /// Default constructor for DateInFutureAttribute
            /// </summary>
            public DateInFutureAttribute()
            {
                ErrorMessage = "{0} must be on or after the current date.";
            }
            /// <summary>
            /// This method checks to see if the date entered is valid
            /// </summary>
            /// <param name="value">date value to be checked</param>
            /// <param name="validationContext">the means by which the data was sent</param>
            /// <returns>ValidationResult - if value conforms to formatting or not</returns>
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                ValidationResult result;
                if (value == null)
                {
                    result = new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
                }
                else
                {
                    if ((DateTime)value >= (DateTime.Now))
                    {
                        result = ValidationResult.Success;
                    }
                    else
                    {
                        result =  new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
                    }
                }
                return result;
            }
        }
    }
