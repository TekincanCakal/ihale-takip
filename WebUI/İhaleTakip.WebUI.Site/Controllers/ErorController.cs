namespace FaturaTakip.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class ErorController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index(string errorMessage)
        {
            ViewBag.ErrorMessage = errorMessage;
            return View();
        }
    }
}