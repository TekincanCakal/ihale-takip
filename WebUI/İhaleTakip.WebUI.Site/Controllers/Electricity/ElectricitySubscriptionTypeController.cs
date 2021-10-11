namespace FaturaTakip.Controllers
{
    using İhaleTakip.Data;
    using İhaleTakip.Model;
    using İhaleTakip.WebUI.Site.Managers;
    using Microsoft.AspNetCore.Mvc;
    using System;

    public class ElectricitySubscriptionTypeController : Controller
    {
        ElectricitySubscriptionTypeData _electricitySubscriptionTypeData;
        UserManager _userManager;
        Service _service = Service.Electricity;
        string _controllerName = "ElectricitySubscriptionType";

        public ElectricitySubscriptionTypeController(ElectricitySubscriptionTypeData electricitySubscriptionTypeData, UserManager userManager)
        {
            _userManager = userManager;
            _electricitySubscriptionTypeData = electricitySubscriptionTypeData;
        }

        public ActionResult Index()
        {
            try
            {
                Perm perm = _userManager.GetServicePerm(_service);
                var electricitySubscriptionTypesResult = _electricitySubscriptionTypeData.GetAll();
                if (!electricitySubscriptionTypesResult.IsSucced)
                {
                    return RedirectToAction("Index", "Eror", new { errorMessage = electricitySubscriptionTypesResult.Message });
                }
                ViewBag.ElectricitySubscriptionTypes = electricitySubscriptionTypesResult.Data;
                return View($"~/Views/{_service}/{_controllerName}/{perm}/Index.cshtml");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Eror", new { errorMessage = ex.Message });
            }
        }

        public ActionResult AddElectricitySubscriptionType()
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

        public ActionResult UpdateElectricitySubscriptionType(int id)
        {
            try
            {
                Perm perm = _userManager.GetServicePerm(_service);
                if (perm == Perm.Admin)
                {
                    var selectedSubscriptionTypeResult = _electricitySubscriptionTypeData.GetByKey(id);
                    if (!selectedSubscriptionTypeResult.IsSucced)
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = selectedSubscriptionTypeResult.Message });
                    }

                    if (selectedSubscriptionTypeResult.Data == null)
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = "Var Olmayan Bir Abonelik Türünü Güncellemeye Çalıştınız" });
                    }

                    ViewBag.SelectedSubscriptionType = selectedSubscriptionTypeResult.Data;
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

        public ActionResult DeleteElectricitySubscriptionType(int id)
        {
            try
            {
                Perm perm = _userManager.GetServicePerm(_service);
                if (perm == Perm.Admin)
                {
                    var checkResult = _electricitySubscriptionTypeData.GetByKey(id);
                    if (!checkResult.IsSucced)
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = checkResult.Message });
                    }

                    if (checkResult.Data == null)
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = "Var Olmayan Bir Abonelik Türünü Silmeye Çalıştınız" });
                    }

                    var result = _electricitySubscriptionTypeData.Delete(checkResult.Data);
                    if (!result.IsSucced)
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = checkResult.Message });
                    }

                    return RedirectToAction("Index", "ElectricitySubscriptionType");
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
        public ActionResult AddElectricitySubscriptionType(ElectricitySubscriptionType electricitySubscriptionType)
        {
            try
            {
                Perm perm = _userManager.GetServicePerm(_service);
                if (perm == Perm.Admin)
                {
                    var checkResult = _electricitySubscriptionTypeData.FirstOrDefault(x => x.Name == electricitySubscriptionType.Name);
                    if (!checkResult.IsSucced)
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = checkResult.Message });
                    }

                    if (checkResult.Data != null)
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = "Bu Abonelik Türü Zaten Kayıtlı" });
                    }

                    var result = _electricitySubscriptionTypeData.Insert(electricitySubscriptionType);
                    if (!result.IsSucced)
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = result.Message });
                    }

                    return RedirectToAction("Index", "ElectricitySubscriptionType");
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
        public ActionResult UpdateElectricitySubscriptionType(ElectricitySubscriptionType electricitySubscriptionType)
        {
            try
            {
                Perm perm = _userManager.GetServicePerm(_service);
                if (perm == Perm.Admin)
                {
                    var checkResult = _electricitySubscriptionTypeData.FirstOrDefault(x => x.Name == electricitySubscriptionType.Name && x.Id != electricitySubscriptionType.Id);
                    if (!checkResult.IsSucced)
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = checkResult.Message });
                    }

                    if (checkResult.Data != null)
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = "Bu Abonelik Türü Zaten Kayıtlı" });
                    }

                    var result = _electricitySubscriptionTypeData.Update(electricitySubscriptionType);
                    if (!result.IsSucced)
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = result.Message });
                    }

                    return RedirectToAction("Index", "ElectricitySubscriptionType");
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