/* Filename: ProvincesController.cs
 * Description: This class is responsible for handing the interaction between the user and Reports.
 * 
 * Revision History:
 *     Ryan Pease, 2016-10-23: Created 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VideoGameStore.Controllers
{
    [Authorize(Roles = "Admin, Employee")]
    public class ReportsController : Controller
    {
        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }
    }
}