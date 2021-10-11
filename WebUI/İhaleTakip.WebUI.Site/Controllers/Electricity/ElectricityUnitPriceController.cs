namespace FaturaTakip.Controllers
{
    using İhaleTakip.Data;
    using İhaleTakip.Model;
    using İhaleTakip.WebUI.Site.Managers;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Dynamic;

    public class ElectricityUnitPriceController : Controller
    {
        ElectricityUnitPriceData _electricityUnitPriceData;
        ElectricitySubscriptionTypeData _electricitySubscriptionTypeData;
        ElectricityRateData _rateData;
        UserManager _userManager;
        Service _service = Service.Electricity;
        string _controllerName = "ElectricityUnitPrice";

        public ElectricityUnitPriceController(ElectricityUnitPriceData electricityUnitPriceData, ElectricitySubscriptionTypeData electricitySubscriptionTypeData, ElectricityRateData rateData, UserManager userManager)
        {
            _userManager = userManager;
            _electricityUnitPriceData = electricityUnitPriceData;
            _electricitySubscriptionTypeData = electricitySubscriptionTypeData;
            _rateData = rateData;
        }

        public ActionResult Index()
        {
            try
            {
                Perm perm = _userManager.GetServicePerm(_service);

                var electricityUnitPriceResult = _electricityUnitPriceData.GetAll();
                if (!electricityUnitPriceResult.IsSucced)
                {
                    return RedirectToAction("Index", "Eror", new { errorMessage = electricityUnitPriceResult.Message });
                }

                var rateResult = _rateData.GetByKey(1);
                if (!rateResult.IsSucced)
                {
                    return RedirectToAction("Index", "Eror", new { errorMessage = rateResult.Message });
                }
                ViewBag.Rate = rateResult.Data;

                List<dynamic> unitPrices = new List<dynamic>();
                foreach (ElectricityUnitPrice electricityUnitPrice in electricityUnitPriceResult.Data)
                {
                    dynamic obj = new ExpandoObject();
                    obj.UnitPrice = electricityUnitPrice;

                    var subscriptionTypeResult = _electricitySubscriptionTypeData.GetByKey(electricityUnitPrice.SubscriptionTypeId);
                    if (!subscriptionTypeResult.IsSucced)
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = subscriptionTypeResult.Message });
                    }
                    obj.SubscriptionType = subscriptionTypeResult.Data;

                    double EnergyFund = electricityUnitPrice.OneTimeEnergyCost * rateResult.Data.EnergyFund / 100;
                    double TRTShare = electricityUnitPrice.OneTimeEnergyCost * rateResult.Data.TRTShare / 100;
                    double ElectricityConsumptionTax = electricityUnitPrice.OneTimeEnergyCost * rateResult.Data.ElectricityConsumptionTax / 100;
                    double SubTotal = electricityUnitPrice.OneTimeEnergyCost + electricityUnitPrice.DistributionCost + EnergyFund + TRTShare + ElectricityConsumptionTax;
                    double KDV = SubTotal * rateResult.Data.KDV / 100;
                    obj.CalculatedUnitPrice = SubTotal + KDV;

                    unitPrices.Add(obj);
                }
                ViewBag.UnitPrices = unitPrices;
                return View($"~/Views/{_service}/{_controllerName}/{perm}/Index.cshtml");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Eror", new { errorMessage = ex.Message });
            }
        }

        public ActionResult AddElectricityUnitPrice()
        {
            try
            {
                Perm perm = _userManager.GetServicePerm(_service);
                if (perm == Perm.Admin)
                {
                    var subscriptionTypeNamesResult = _electricitySubscriptionTypeData.GetAll();
                    if (!subscriptionTypeNamesResult.IsSucced)
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = subscriptionTypeNamesResult.Message });
                    }

                    ViewBag.SubscriptionTypes = subscriptionTypeNamesResult.Data;
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

        public ActionResult UpdateElectricityUnitPrice(int id)
        {
            try
            {
                Perm perm = _userManager.GetServicePerm(_service);
                if (perm == Perm.Admin)
                {
                    var selectedUnitPriceResult = _electricityUnitPriceData.GetByKey(id);
                    if (!selectedUnitPriceResult.IsSucced)
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = selectedUnitPriceResult.Message });
                    }

                    if (selectedUnitPriceResult.Data == null)
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = "Var Olmayan Bir Birim Fiyatı Güncellemeye Çalıştınız" });
                    }

                    ViewBag.SelectedUnitPrice = selectedUnitPriceResult.Data;
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

        public ActionResult DeleteElectricityUnitPrice(int id)
        {
            try
            {
                Perm perm = _userManager.GetServicePerm(_service);
                if (perm == Perm.Admin)
                {
                    var checkResult = _electricityUnitPriceData.GetByKey(id);
                    if (!checkResult.IsSucced)
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = checkResult.Message });
                    }

                    if (checkResult.Data == null)
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = "Var Olmayan Bir Birim Fiyatı Silmeye Çalıştınız" });
                    }

                    var result = _electricityUnitPriceData.Delete(checkResult.Data);
                    if (!result.IsSucced)
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = checkResult.Message });
                    }

                    return RedirectToAction("Index", "ElectricityUnitPrice");
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
        public ActionResult AddElectricityUnitPrice(ElectricityUnitPrice electricityUnitPrice)
        {
            try
            {
                Perm perm = _userManager.GetServicePerm(_service);
                if (perm == Perm.Admin)
                {
                    var checkResult = _electricityUnitPriceData.FirstOrDefault(x => x.SubscriptionTypeId == electricityUnitPrice.SubscriptionTypeId && x.Period.Year == electricityUnitPrice.Period.Year && x.Period.Month == electricityUnitPrice.Period.Month);
                    if (!checkResult.IsSucced)
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = checkResult.Message });
                    }

                    if (checkResult.Data != null)
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = "Bu Birim Fiyat Zaten Kayıtlı" });
                    }

                    var result = _electricityUnitPriceData.Insert(electricityUnitPrice);
                    if (!result.IsSucced)
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = result.Message });
                    }

                    return RedirectToAction("Index", "ElectricityUnitPrice");
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
        public ActionResult UpdateElectricityUnitPrice(ElectricityUnitPrice electricityUnitPrice)
        {
            try
            {
                Perm perm = _userManager.GetServicePerm(_service);
                if (perm == Perm.Admin)
                {
                    var result = _electricityUnitPriceData.Update(electricityUnitPrice);
                    if (result.IsSucced)
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = result.Message });
                    }

                    return RedirectToAction("Index", "ElectricityUnitPrice");
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
        public ActionResult UpdateElectricityRate(ElectricityRate rate)
        {
            try
            {
                Perm perm = _userManager.GetServicePerm(_service);
                if (perm == Perm.Admin)
                {
                    var result = _rateData.Update(rate);
                    if (!result.IsSucced)
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = result.Message });
                    }

                    return RedirectToAction("Index", "ElectricityUnitPrice");
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