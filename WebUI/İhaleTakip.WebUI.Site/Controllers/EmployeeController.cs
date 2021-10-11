namespace FaturaTakip.Controllers
{
    using İhaleTakip.Data;
    using İhaleTakip.Model;
    using İhaleTakip.WebUI.Site.Managers;
    using Microsoft.AspNetCore.Mvc;
    using System;

    public class EmployeeController : Controller
    {
        EmployeeData _employeeData;
        UserManager _userManager;
        Service _service = Service.Employee;


        public EmployeeController(EmployeeData employeeData, UserManager userManager)
        {
            _employeeData = employeeData;
            _userManager = userManager;
        }

        public ActionResult Index()
        {
            try
            {
                Perm perm = _userManager.GetServicePerm(_service);
                var employeesResult = _employeeData.GetAll();
                if (!employeesResult.IsSucced)
                {
                    return RedirectToAction("Index", "Eror", new { errorMessage = employeesResult.Message });
                }
                ViewBag.Employees = employeesResult.Data;

                return View($"~/Views/{_service}/{perm}/Index.cshtml");
            }
            catch(Exception ex)
            {
                return RedirectToAction("Index", "Eror", new { errorMessage = ex.Message });
            }           
        }

        public ActionResult AddEmployee()
        {
            try
            {
                Perm perm = _userManager.GetServicePerm(_service);
                if(perm == Perm.Admin)
                {
                    return View($"~/Views/{_service}/{perm}/AddEmployee.cshtml");
                }
                else
                {
                    return RedirectToAction("Index", "Eror", new { errorMessage = "Bu Sayfayı Görüntülemeye Yetkiniz Yetmiyor" });
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Eror", new { errorMessage = ex.Message });
            }
        }

        public ActionResult UpdateEmployee(int id)
        {
            try
            {
                Perm perm = _userManager.GetServicePerm(_service);
                if (perm == Perm.Admin)
                {
                    var selectedEmployeeResult = _employeeData.GetByKey(id);
                    if (!selectedEmployeeResult.IsSucced)
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = selectedEmployeeResult.Message });
                    }

                    if (selectedEmployeeResult.Data == null)
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = "Var Olmayan Bir Personeli Güncellemeye Çalıştınız" });
                    }

                    ViewBag.SelectedEmployee = selectedEmployeeResult.Data;

                    return View($"~/Views/{_service}/{perm}/UpdateEmployee.cshtml");
                }
                else
                {
                    return RedirectToAction("Index", "Eror", new { errorMessage = "Bu Sayfayı Görüntülemeye Yetkiniz Yetmiyor" });
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Eror", new { errorMessage = ex.Message });
            }
        }

        public ActionResult DeleteEmployee(int id)
        {
            var checkResult = _employeeData.GetByKey(id);
            if (!checkResult.IsSucced)
            {
                return RedirectToAction("Index", "Eror", new { errorMessage = checkResult.Message });
            }

            if (checkResult.Data == null)
            {
                return RedirectToAction("Index", "Eror", new { errorMessage = "Var Olmayan Bir Personeli Silmeye Çalıştınız" });
            }

            var result = _employeeData.Delete(checkResult.Data);
            if (!result.IsSucced)
            {
                return RedirectToAction("Index", "Eror", new { errorMessage = result.Message });
            }

            return RedirectToAction("Index", "Employee");
        }

        [HttpPost]
        public ActionResult AddEmployee(Employee employee)
        {
            var checkResult = _employeeData.FirstOrDefault(x => x.Username == employee.Username);
            if (!checkResult.IsSucced)
            {
                return RedirectToAction("Index", "Eror", new { errorMessage = checkResult.Message });
            }

            if (checkResult.Data != null)
            {
                return RedirectToAction("Index", "Eror", new { errorMessage = "Bu Kullanıcı Adı Zaten Kayıtlı" });
            }

            var result = _employeeData.Insert(employee);
            if (!result.IsSucced)
            {
                return RedirectToAction("Index", "Eror", new { errorMessage = result.Message });
            }

            return RedirectToAction("Index", "Employee");
        }
       
        [HttpPost]
        public ActionResult UpdateEmployee(Employee employee)
        {
            var checkResult = _employeeData.FirstOrDefault(x => x.Username == employee.Username && x.Id != employee.Id);
            if (!checkResult.IsSucced)
            {
                return RedirectToAction("Index", "Eror", new { errorMessage = checkResult.Message });
            }

            if (checkResult.Data != null)
            {
                return RedirectToAction("Index", "Eror", new { errorMessage = "Bu Kullanıcı Adı Zaten Kayıtlı" });
            }

            var result = _employeeData.Update(employee);
            if (!result.IsSucced)
            {
                return RedirectToAction("Index", "Eror", new { errorMessage = result.Message });
            }

            return RedirectToAction("Index", "Employee");
        }
    }
}