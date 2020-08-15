using System.Web.Mvc;
using TCAdmin.GameHosting.SDK.Objects;
using TCAdmin.SDK.Web.MVC.Controllers;
using TCAdmin.Web.MVC;

namespace TCAdminGSLT.Controllers
{
    [ExceptionHandler]
    public class GsltController : BaseServiceController
    {
        [HttpPost]
        [ParentAction("Service", "Home")]
        public ActionResult SetToken(string token)
        {
            var service = Service.GetSelectedService();
            service.Variables["GSLT"] = token;
            service.Save();
            service.Configure();

            return Json(new
            {
                Message = "Successfully saved GSLT."
            });
        }
    }
}