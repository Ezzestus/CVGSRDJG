/* Filename: LoginModel.cs
 * Description: This class is responsible for the characteristics for the user login model.
 * 
 * Note: Some of the code is based on the tutorial found at the link below:
 * http://kristianguevara.net/creating-your-asp-net-mvc-5-application-from-scratch-for-beginners-using-entity-framework-6-and-identity-with-crud-functionalities/ 
 *
 * Revision History:
 *     Ryan Pease, 2016-11-29: Created 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace VideoGameStore.Models
{
    public class LoginModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ReturnUrl { get; set; }
    }
}