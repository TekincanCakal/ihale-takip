namespace FaturaTakip.Controllers
{
    using İhaleTakip.Data;
    using İhaleTakip.Model;
    using İhaleTakip.WebUI.Site.Managers;
    using Microsoft.AspNetCore.Mvc;
    using System;

    public class ElectricityCompanyController : Controller
    {
        ElectricityCompanyData _electricityCompanyData;
        UserManager _userManager;
        Service _service = Service.Electricity;
        string _controllerName = "ElectricityCompany";

        public ElectricityCompanyController(ElectricityCompanyData electricityCompanyData, UserManager userManager)
        {
            _userManager = userManager;
            _electricityCompanyData = electricityCompanyData;
        }

        public ActionResult Index()
        {
            try
            {
                Perm perm = _userManager.GetServicePerm(_service);
                var companiesResult = _electricityCompanyData.GetAll();
                if (!companiesResult.IsSucced)
                {
                    return RedirectToAction("Index", "Eror", new { errorMessage = companiesResult.Message });
                }
                ViewBag.Companies = companiesResult.Data;
                return View($"~/Views/{_service}/{_controllerName}/{perm}/Index.cshtml");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Eror", new { errorMessage = ex.Message });
            }
        }

        public ActionResult AddElectricityCompany()
        {
            try
            {
                Perm perm = _userManager.GetServicePerm(_service);
                if (perm == Perm.Admin)
                {
                    return View($"~/Views/{_service}/{_controllerName}/{perm}/Add{_controllerName}.cshtml");
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

        public ActionResult UpdateElectricityCompany(int id)
        {
            try
            {
                Perm perm = _userManager.GetServicePerm(_service);
                if (perm == Perm.Admin)
                {
                    var selectedCompanyResult = _electricityCompanyData.GetByKey(id);
                    if (!selectedCompanyResult.IsSucced)
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = selectedCompanyResult.Message });
                    }

                    if (selectedCompanyResult.Data == null)
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = "Var Olmayan Bir Firmayı Güncellemeye Çalıştınız" });
                    }

                    ViewBag.SelectedCompany = selectedCompanyResult.Data;
                    return View($"~/Views/{_service}/{_controllerName}/{perm}/Update{_controllerName}.cshtml");
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

        public ActionResult DeleteElectricityCompany(int id)
        {
            try
            {
                Perm perm = _userManager.GetServicePerm(_service);
                if (perm == Perm.Admin)
                {
                    var checkResult = _electricityCompanyData.GetByKey(id);
                    if (!checkResult.IsSucced)
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = checkResult.Message });
                    }

                    if (checkResult.Data == null)
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = "Var Olmayan Bir Firmayı Silmeye Çalıştınız" });
                    }

                    var result = _electricityCompanyData.Delete(checkResult.Data);
                    if (!result.IsSucced)
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = result.Message });
                    }

                    return RedirectToAction("Index", "ElectricityCompany");
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

        [HttpPost]
        public ActionResult AddElectricityCompany(ElectricityCompany electricityCompany)
        {
            try
            {
                Perm perm = _userManager.GetServicePerm(_service);
                if (perm == Perm.Admin)
                {
                    var checkResult = _electricityCompanyData.FirstOrDefault(x => x.Name == electricityCompany.Name);
                    if (!checkResult.IsSucced)
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = checkResult.Message });
                    }

                    if (checkResult.Data != null)
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = "Bu Firma Adı Zaten Kayıtlı" });
                    }

                    var result = _electricityCompanyData.Insert(electricityCompany);
                    if (!result.IsSucced)
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = result.Message });
                    }

                    return RedirectToAction("Index", "ElectricityCompany");
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
        [HttpPost]
        public ActionResult UpdateElectricityCompany(ElectricityCompany electricityCompany)
        {
            try
            {
                Perm perm = _userManager.GetServicePerm(_service);
                if (perm == Perm.Admin)
                {
                    var checkResult = _electricityCompanyData.FirstOrDefault(x => x.Name == electricityCompany.Name && x.Id != electricityCompany.Id);
                    if (!checkResult.IsSucced)
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = checkResult.Message });
                    }

                    if (checkResult.Data != null)
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = "Bu Firma Zaten Kayıtlı" });
                    }

                    var result = _electricityCompanyData.Update(electricityCompany);
                    if (!result.IsSucced)
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = result.Message });
                    }

                    return RedirectToAction("Index", "ElectricityCompany");
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
    }
}