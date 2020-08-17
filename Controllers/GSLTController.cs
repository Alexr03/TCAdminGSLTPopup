using System;
using System.Web.Mvc;
using TCAdmin.SDK.Objects;
using TCAdmin.SDK.Web.MVC.Controllers;
using TCAdmin.Web.MVC;
using Service = TCAdmin.GameHosting.SDK.Objects.Service;

namespace TCAdminGSLT.Controllers
{
    [ExceptionHandler]
    public class GsltController : BaseServiceController
    {
        [HttpPost]
        [ParentAction("Service", "Home")]
        public ActionResult SetToken(int id, string token)
        {
            try
            {
                ObjectBase.GlobalSkipSecurityCheck = true;
                var service = Service.GetSelectedService();
                service.Variables["GSLT"] = token;
                service.Save();
                service.Configure();

                return Json(new
                {
                    Message = "Successfully saved GSLT."
                });
            }
            finally
            {
                ObjectBase.GlobalSkipSecurityCheck = false;
            }
        }
    }
}