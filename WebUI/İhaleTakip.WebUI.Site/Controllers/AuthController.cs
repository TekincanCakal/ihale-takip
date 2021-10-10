namespace FaturaTakip.Controllers
{
    using İhaleTakip.Data;
    using İhaleTakip.Model;
    using İhaleTakip.WebUI.Site.Managers;
    using İhaleTakip.WebUI.Site.Models;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    public class AuthController : Controller
    {
        EmployeeData _employeeData;
        UserManager _userManager;
       
        public AuthController(EmployeeData employeeData, UserManager userManager)
        {
            _employeeData = employeeData;
            _userManager = userManager;
        }
   
        public ActionResult Index()
        {
            if (_userManager.IsCurrentUserLogined())
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }

        public ActionResult Login()
        {
            if (_userManager.IsCurrentUserLogined())
            {
                return RedirectToAction("Index", "Auth");
            }
            else
            {
                ViewBag.LoginFailed = false;

                var model = new LoginModel()
                {
                    Username = "",
                    Password = ""
                };

                return View(model);
            }
        }

        public ActionResult Logout()
        {
            try
            {
                _userManager.LogoutCurrentUser();
                HttpContext.Session.Clear();
                return RedirectToAction("Login", "Auth");
            }
            catch(Exception ex)
            {
                return RedirectToAction("Index", "Eror", new { errorMessage = ex.Message });
            }
        }       

        public ActionResult LoginServiceAsync(string serviceName)
        {
            try
            {
                ServiceModel loginedService = _userManager.LoginServiceCurrentUser(serviceName);
                return RedirectToAction(loginedService.InitAction, loginedService.InitController);
            }
            catch(Exception ex) 
            {
                return RedirectToAction("Index", "Eror", new { errorMessage = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult Login(string Username, string Password)
        {
            if (_userManager.IsCurrentUserLogined())
            {
                return RedirectToAction("Index", "Eror", new { errorMessage = "Zaten Sisteme Giriş Yapmış Durumdasın" });
            }
            else
            {
                 var electricityEmployeeResult = _employeeData.FirstOrDefault(x => x.Username == Username && x.Password == Password);
                if (!electricityEmployeeResult.IsSucced)
                {
                    return RedirectToAction("Index", "Eror", new { errorMessage = electricityEmployeeResult.Message });
                }

                Employee loginedUser = electricityEmployeeResult.Data;
                if (loginedUser == null)
                {
                    ViewBag.LoginFailed = true;
                    var returnModel = new LoginModel()
                    {
                        Username = Username,
                        Password = ""
                    };
                    return View(returnModel);
                }
                else
                {
                    try
                    {
                        _userManager.SuccessLoginCurrentUser(loginedUser.Username);
                        return RedirectToAction("Index", "Auth");
                    }
                    catch(Exception ex)
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = ex.Message });
                    }
                }
            }
        }
    }
}