namespace İhaleTakip.WebUI.Site.Controllers
{
    using İhaleTakip.Data;
    using İhaleTakip.Data.Infrastructure;
    using İhaleTakip.Model;
    using İhaleTakip.WebUI.Site.Managers;
    using Microsoft.AspNetCore.Mvc;
    using System;

    public class ElectricityBillController : Controller
    {
        ElectricityBillData _electricityBillData;
        ElectricitySubscriberData _electricitySubscriberData;
        UserManager _userManager;
        Service _service = Service.Electricity;
        string _controllerName = "ElectricityBill";

        public ElectricityBillController(ElectricityBillData electricityBillData, ElectricitySubscriberData electricitySubscriberData, UserManager userManager)
        {
            _electricityBillData = electricityBillData;
            _electricitySubscriberData = electricitySubscriberData;
            _userManager = userManager;
        }

        public ActionResult AddElectricityBill(int year, int month, string installationNumber)
        {
            try
            {
                Perm perm = _userManager.GetServicePerm(_service);
                if (perm == Perm.Admin)
                {
                    ViewBag.DateText = DateConverter.GetDateText(year, month);
                    ViewBag.SelectedInstallationNumber = installationNumber;
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

        public ActionResult UpdateElectricityBill(int id)
        {
            try
            {
                Perm perm = _userManager.GetServicePerm(_service);
                if (perm == Perm.Admin)
                {
                    var selectedElectricityBillResult = _electricityBillData.GetByKey(id);
                    if (!selectedElectricityBillResult.IsSucced)
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = selectedElectricityBillResult.Message });
                    }

                    if (selectedElectricityBillResult.Data == null)
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = "Var Olmayan Bir Faturayı Güncellemeye Çalıştınız" });
                    }

                    ViewBag.SelectedElectricityBill = selectedElectricityBillResult.Data;
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

        public ActionResult DeleteElectricityBill(int id)
        {
            try
            {
                Perm perm = _userManager.GetServicePerm(_service);
                if (perm == Perm.Admin)
                {
                    var checkResult = _electricityBillData.GetByKey(id);
                    if (!checkResult.IsSucced)
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = checkResult.Message });
                    }

                    if (checkResult.Data == null)
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = "Var Olmayan Bir Faturayı Silmeye Çalıştınız" });
                    }

                    var result = _electricityBillData.Delete(checkResult.Data);
                    if (!result.IsSucced)
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = checkResult.Message });
                    }

                    return RedirectToAction("Index", "ElectricitySubscriber");
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
        public ActionResult AddElectricityBill(ElectricityBill electricityBill)
        {
            try
            {
                Perm perm = _userManager.GetServicePerm(_service);
                if (perm == Perm.Admin)
                {
                    DateTime dateTime = new DateTime(electricityBill.Period.Year, electricityBill.Period.Month, 1);

                    var checkResult = _electricityBillData.FirstOrDefault(x => x.InstallationNumber == electricityBill.InstallationNumber && x.Period.Year == dateTime.Year && x.Period.Month == dateTime.Month);
                    if (!checkResult.IsSucced)
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = checkResult.Message });
                    }

                    bool isExist;
                    try
                    {
                        isExist = isInstallationNumberExist(electricityBill.InstallationNumber, dateTime);
                    }
                    catch (Exception ex)
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = ex.Message + ex.InnerException == null ? "" : "(" + ex.InnerException + ")" });
                    }

                    if (checkResult.Data != null)
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = "Bu Döneme Ait Zaten Kayıtlı Fatura Bulunmakta" });
                    }
                    else if (!isExist)
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = "Var Olmayan Bir Tesisat Numarasına Ait Fatura Eklemeye Çalıştınız" });
                    }
                    else
                    {
                        var result = _electricityBillData.Insert(electricityBill);
                        if (result.IsSucced)
                        {
                            return RedirectToAction("Index", "ElectricitySubscriber");
                        }
                        else
                        {
                            return RedirectToAction("Index", "Eror", new { errorMessage = result.Message });
                        }
                    }
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
        public ActionResult UpdateElectricityBill(ElectricityBill electricityBill)
        {
            try
            {
                Perm perm = _userManager.GetServicePerm(_service);
                if (perm == Perm.Admin)
                {
                    var result = _electricityBillData.Update(electricityBill);
                    if (!result.IsSucced)
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = result.Message });
                    }

                    return RedirectToAction("Index", "ElectricitySubscriber");
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

        private bool isInstallationNumberExist(string installationNumber, DateTime dateTime)
        {
            return GetByInstallationNumber(installationNumber, dateTime) != null;
        }
        private ElectricitySubscriber GetByInstallationNumber(string installationNumber, DateTime dateTime)
        {
            var electricitySubscribersResult = _electricitySubscriberData.GetBy(x => x.InstallationNumber == installationNumber, "CreateDate", true);
            if (!electricitySubscribersResult.IsSucced)
            {
                throw new Exception(electricitySubscribersResult.Message);
            }

            foreach (ElectricitySubscriber subscriber in electricitySubscribersResult.Data)
            {
                if (subscriber.CreateDate <= dateTime)
                {
                    if (subscriber.EndDate == null || subscriber.EndDate.Value > dateTime)
                    {
                        return subscriber;
                    }
                }
            }
            return null;
        }
    }
}
