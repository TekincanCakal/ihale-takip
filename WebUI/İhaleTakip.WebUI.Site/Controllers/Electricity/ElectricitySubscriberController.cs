namespace FaturaTakip.Controllers
{
    using İhaleTakip.Data;
    using İhaleTakip.Data.Infrastructure;
    using İhaleTakip.Model;
    using İhaleTakip.WebUI.Site.Managers;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Dynamic;

    public class ElectricitySubscriberController : Controller
    {
        ElectricitySubscriberData _electricitySubscriberData;
        ElectricityCompanyData _companyData;
        ElectricitySubscriptionTypeData _electricitySubscriptionTypeData;
        ElectricityBillData _electricityBillData;
        ElectricityUnitPriceData _electricityUnitPriceData;
        ElectricityRateData _rateData;
        UserManager _userManager;
        Service _service = Service.Electricity;
        string _controllerName = "ElectricitySubscriber";

        public ElectricitySubscriberController(ElectricitySubscriberData electricitySubscriberData, ElectricityCompanyData companyData, ElectricitySubscriptionTypeData electricitySubscriptionTypeData, ElectricityBillData electricityBillData, ElectricityUnitPriceData electricityUnitPriceData, ElectricityRateData rateData, UserManager userManager)
        {
            _userManager = userManager;
            _electricitySubscriberData = electricitySubscriberData;
            _companyData = companyData;
            _electricitySubscriptionTypeData = electricitySubscriptionTypeData;
            _electricityBillData = electricityBillData;
            _electricityUnitPriceData = electricityUnitPriceData;
            _rateData = rateData;
        }

        public ActionResult Index(int? year, int? month)
        {
            try
            {
                Perm perm = _userManager.GetServicePerm(_service);
                if (year == null || month == null)
                {

                    (int, int, string) temp = DateConverter.GetCurrentDate();
                    ViewBag.Year = temp.Item1;
                    ViewBag.Month = temp.Item2;
                    ViewBag.DateText = temp.Item3;
                }
                else
                {
                    ViewBag.Year = year.Value;
                    ViewBag.Month = month.Value;
                    ViewBag.DateText = DateConverter.GetDateText(year.Value, month.Value);
                }
                DateTime dateTime = new DateTime(ViewBag.Year, ViewBag.Month, 1);
                List<dynamic> subscriptions = new List<dynamic>();

                List<ElectricitySubscriber> electricitySubscribers;

                try
                {
                    electricitySubscribers = GetAll(dateTime);
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index", "Eror", new { errorMessage = ex.Message + ex.InnerException == null ? "" : "(" + ex.InnerException + ")" });
                }

                foreach (ElectricitySubscriber electricitySubscriber in electricitySubscribers)
                {
                    dynamic obj = new ExpandoObject();
                    obj.Subscriber = electricitySubscriber;

                    var subscriptionTypeResult = _electricitySubscriptionTypeData.GetByKey(electricitySubscriber.SubscriptionTypeId);
                    if (!subscriptionTypeResult.IsSucced)
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = subscriptionTypeResult.Message });
                    }
                    obj.SubscriptionType = subscriptionTypeResult.Data;

                    var companyResult = _companyData.GetByKey(electricitySubscriber.CompanyId);
                    if (!companyResult.IsSucced)
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = companyResult.Message });
                    }
                    obj.Company = companyResult.Data;


                    var currentBillResult = _electricityBillData.FirstOrDefault(x => x.InstallationNumber == electricitySubscriber.InstallationNumber && x.Period.Year == dateTime.Year && x.Period.Month == dateTime.Month);
                    if (!currentBillResult.IsSucced)
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = currentBillResult.Message });
                    }
                    obj.CurrentBill = currentBillResult.Data;

                    var electricityUnitPriceResult = _electricityUnitPriceData.FirstOrDefault(x => x.SubscriptionTypeId == electricitySubscriber.SubscriptionTypeId && x.Period.Year == dateTime.Year && x.Period.Month == dateTime.Month);
                    if (!electricityUnitPriceResult.IsSucced)
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = electricityUnitPriceResult.Message });
                    }

                    var rateResult = _rateData.GetByKey(1);
                    if (!rateResult.IsSucced)
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = rateResult.Message });
                    }

                    if (electricityUnitPriceResult.Data != null)
                    {
                        double EnergyFund = electricityUnitPriceResult.Data.OneTimeEnergyCost * rateResult.Data.EnergyFund / 100;
                        double TRTShare = electricityUnitPriceResult.Data.OneTimeEnergyCost * rateResult.Data.TRTShare / 100;
                        double ElectricityConsumptionTax = electricityUnitPriceResult.Data.OneTimeEnergyCost * rateResult.Data.ElectricityConsumptionTax / 100;
                        double SubTotal = electricityUnitPriceResult.Data.OneTimeEnergyCost + electricityUnitPriceResult.Data.DistributionCost + EnergyFund + TRTShare + ElectricityConsumptionTax;
                        double KDV = SubTotal * rateResult.Data.KDV / 100;
                        obj.CurrentUnitPrice = SubTotal + KDV;
                    }
                    else
                    {
                        obj.CurrentUnitPrice = null;
                    }

                    if (obj.CurrentBill != null && obj.CurrentBill.Amount != 0)
                    {
                        obj.CurrentUnitPriceDebt = obj.CurrentUnitPrice * obj.CurrentBill.Amount;
                    }
                    else
                    {
                        obj.CurrentUnitPriceDebt = null;
                    }
                    subscriptions.Add(obj);
                }
                ViewBag.Subscriptions = subscriptions;

                return View($"~/Views/{_service}/{_controllerName}/{perm}/Index.cshtml");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Eror", new { errorMessage = ex.Message });
            }
        }
        public ActionResult AddElectricitySubscriber(int year, int month)
        {
            try
            {
                Perm perm = _userManager.GetServicePerm(_service);
                if (perm == Perm.Admin)
                {
                    ViewBag.Year = year;
                    ViewBag.Month = month;

                    var companiesResult = _companyData.GetAll();
                    if (!companiesResult.IsSucced)
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = companiesResult.Message });
                    }
                    ViewBag.Companies = companiesResult.Data;

                    var subscriptionTypesResult = _electricitySubscriptionTypeData.GetAll();
                    if (!subscriptionTypesResult.IsSucced)
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = subscriptionTypesResult.Message });
                    }
                    ViewBag.SubscriptionTypes = subscriptionTypesResult.Data;
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
        public ActionResult UpdateElectricitySubscriber(int id, int year, int month)
        {
            try
            {
                Perm perm = _userManager.GetServicePerm(_service);
                if (perm == Perm.Admin)
                {
                    ViewBag.Year = year;
                    ViewBag.Month = month;

                    var selectedSubscriberResult = _electricitySubscriberData.GetByKey(id);
                    if (!selectedSubscriberResult.IsSucced)
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = selectedSubscriberResult.Message });
                    }

                    if (selectedSubscriberResult.Data == null)
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = "Var Olmayan Bir Aboneliği Güncellemeye Çalıştınız" });
                    }

                    var companiesResult = _companyData.GetAll();
                    if (!companiesResult.IsSucced)
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = companiesResult.Message });
                    }
                    ViewBag.Companies = companiesResult.Data;

                    var subscriptionTypesResult = _electricitySubscriptionTypeData.GetAll();
                    if (!subscriptionTypesResult.IsSucced)
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = subscriptionTypesResult.Message });
                    }
                    ViewBag.SubscriptionTypes = subscriptionTypesResult.Data;

                    var selectedCompanyResult = _companyData.GetByKey(selectedSubscriberResult.Data.CompanyId);
                    if (!selectedCompanyResult.IsSucced)
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = selectedCompanyResult.Message });
                    }
                    ViewBag.SelectedElectricitySubscriber = (selectedSubscriberResult.Data, selectedCompanyResult.Data);
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
        public ActionResult DeleteElectricitySubscriber(string installationNumber, int year, int month)
        {
            try
            {
                Perm perm = _userManager.GetServicePerm(_service);
                if (perm == Perm.Admin)
                {
                    DateTime dateTime = new DateTime(year, month, 1);

                    ElectricitySubscriber electricitySubscriber;
                    try
                    {
                        electricitySubscriber = GetByInstallationNumber(installationNumber, dateTime);
                    }
                    catch (Exception ex)
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = ex.Message + ex.InnerException == null ? "" : "(" + ex.InnerException + ")" });
                    }

                    if (electricitySubscriber != null)
                    {
                        List<ElectricitySubscriber> willDeleted = new List<ElectricitySubscriber>();

                        var electricitySubscribersResult = _electricitySubscriberData.GetBy(x => x.InstallationNumber == installationNumber);
                        if (!electricitySubscribersResult.IsSucced)
                        {
                            return RedirectToAction("Index", "Eror", new { errorMessage = electricitySubscribersResult.Message });
                        }

                        foreach (ElectricitySubscriber x in electricitySubscribersResult.Data)
                        {
                            if (x.CreateDate > dateTime)
                            {
                                var electricityBillsResult = _electricityBillData.GetBy(x => x.InstallationNumber == installationNumber);
                                if (!electricityBillsResult.IsSucced)
                                {
                                    return RedirectToAction("Index", "Eror", new { errorMessage = electricityBillsResult.Message });
                                }

                                foreach (ElectricityBill electricityBill in electricityBillsResult.Data)
                                {
                                    ElectricitySubscriber z = GetByInstallationNumber(x.InstallationNumber, new DateTime(electricityBill.Period.Year, electricityBill.Period.Month, 1));
                                    if (z.Id == x.Id)
                                    {
                                        return RedirectToAction("Index", "Eror", new { errorMessage = "Bu Aboneliğe Bağlı Faturalar Olduğu İçin Silinemez, Önce Silindiği Dönem Ve Sonrasındaki Dönemlere Ait Faturaları Siliniz" });
                                    }
                                }
                                willDeleted.Add(x);
                            }
                        }

                        var tempElectricityBillResult = _electricityBillData.FirstOrDefault(k => k.InstallationNumber == installationNumber && k.Period.Year == dateTime.Year && k.Period.Month == dateTime.Month);
                        if (!tempElectricityBillResult.IsSucced)
                        {
                            return RedirectToAction("Index", "Eror", new { errorMessage = tempElectricityBillResult.Message });
                        }

                        if (tempElectricityBillResult.Data != null)
                        {
                            return RedirectToAction("Index", "Eror", new { errorMessage = "Bu Aboneliğe Bağlı Faturalar Olduğu İçin Silinemez, Önce Silindiği Dönem Ve Sonrasındaki Dönemlere Ait Faturaları Siliniz" });
                        }
                        else
                        {
                            if (electricitySubscriber.CreateDate == dateTime)
                            {
                                var deleteResult = _electricitySubscriberData.Delete(electricitySubscriber);
                                if (!deleteResult.IsSucced)
                                {
                                    return RedirectToAction("Index", "Eror", new { errorMessage = deleteResult.Message });
                                }
                            }
                            else
                            {
                                electricitySubscriber.EndDate = dateTime;
                                var updateResult = _electricitySubscriberData.Update(electricitySubscriber);
                                if (!updateResult.IsSucced)
                                {
                                    return RedirectToAction("Index", "Eror", new { errorMessage = updateResult.Message });
                                }
                            }
                            foreach (ElectricitySubscriber x in willDeleted)
                            {
                                var deleteResult = _electricitySubscriberData.Delete(x);
                                if (!deleteResult.IsSucced)
                                {
                                    return RedirectToAction("Index", "Eror", new { errorMessage = deleteResult.Message });
                                }
                            }

                            return RedirectToAction("Index", "ElectricitySubscriber");
                        }
                    }
                    else
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = "Oluşturulmamış Bir Aboneliği Silmeye Çalışıyorsunuz" });
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
        public ActionResult AddElectricitySubscriber(ElectricitySubscriber electricitySubscriber, int year, int month)
        {
            try
            {
                Perm perm = _userManager.GetServicePerm(_service);
                if (perm == Perm.Admin)
                {
                    DateTime dateTime = new DateTime(year, month, 1);
                    ElectricitySubscriber electricitySubscriberClone;
                    try
                    {
                        electricitySubscriberClone = GetByInstallationNumber(electricitySubscriber.InstallationNumber, dateTime);
                    }
                    catch (Exception ex)
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = ex.Message + ex.InnerException == null ? "" : "(" + ex.InnerException + ")" });
                    }

                    if (electricitySubscriberClone == null)
                    {
                        electricitySubscriber.CreateDate = dateTime;
                        var result = _electricitySubscriberData.Insert(electricitySubscriber);
                        if (result.IsSucced)
                        {
                            return RedirectToAction("Index", "ElectricitySubscriber");
                        }
                        else
                        {
                            return RedirectToAction("Index", "Eror", new { errorMessage = result.Message });
                        }
                    }
                    else
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = "Bu Abonelik Zaten Kayıtlı" });
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
        public ActionResult UpdateElectricitySubscriber(ElectricitySubscriber electricitySubscriber, int year, int month)
        {
            try
            {
                Perm perm = _userManager.GetServicePerm(_service);
                if (perm == Perm.Admin)
                {
                    DateTime dateTime = new DateTime(year, month, 1);
                    var result = _electricitySubscriberData.GetBy(x => x.InstallationNumber == electricitySubscriber.InstallationNumber);
                    if (!result.IsSucced)
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = result.Message });
                    }

                    foreach (ElectricitySubscriber x in result.Data)
                    {
                        if (x.CreateDate > dateTime)
                        {
                            var deleteResult = _electricitySubscriberData.Delete(x);
                            if (!deleteResult.IsSucced)
                            {
                                return RedirectToAction("Index", "Eror", new { errorMessage = deleteResult.Message });
                            }
                        }
                    }

                    var electricitySubscriberResult = _electricitySubscriberData.GetByKey(electricitySubscriber.Id);
                    if (!electricitySubscriberResult.IsSucced)
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = electricitySubscriberResult.Message });
                    }
                    electricitySubscriberResult.Data.EndDate = dateTime;

                    if (electricitySubscriberResult.Data.CreateDate == electricitySubscriberResult.Data.EndDate)
                    {
                        var deleteResult = _electricitySubscriberData.Delete(electricitySubscriberResult.Data);
                        if (!deleteResult.IsSucced)
                        {
                            return RedirectToAction("Index", "Eror", new { errorMessage = deleteResult.Message });
                        }
                    }
                    else
                    {
                        var updateResult = _electricitySubscriberData.Update(electricitySubscriberResult.Data);
                        if (!updateResult.IsSucced)
                        {
                            return RedirectToAction("Index", "Eror", new { errorMessage = updateResult.Message });
                        }
                    }

                    ElectricitySubscriber subscriber = new ElectricitySubscriber();
                    subscriber.Address = electricitySubscriber.Address;
                    subscriber.CompanyId = electricitySubscriber.CompanyId;
                    subscriber.ContractNumber = electricitySubscriber.ContractNumber;
                    subscriber.ExtraInformation = electricitySubscriber.ExtraInformation;
                    subscriber.SubscriberStatus = electricitySubscriber.SubscriberStatus;
                    subscriber.SubscriptionTypeId = electricitySubscriber.SubscriptionTypeId;
                    subscriber.InstallationNumber = electricitySubscriber.InstallationNumber;
                    subscriber.CreateDate = dateTime;
                    subscriber.EndDate = null;
                    var addResult = _electricitySubscriberData.Insert(subscriber);
                    if (!addResult.IsSucced)
                    {
                        return RedirectToAction("Index", "Eror", new { errorMessage = addResult.Message });
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
        
        private List<ElectricitySubscriber> GetAll(DateTime dateTime)
        {
            List<ElectricitySubscriber> electricitySubscribers = new List<ElectricitySubscriber>();
            foreach (string installationNumber in GetAllInstallationNumbers(dateTime, dateTime))
            {
                ElectricitySubscriber temp = GetByInstallationNumber(installationNumber, dateTime);
                if (temp != null)
                {
                    electricitySubscribers.Add(temp);
                }
            }
            return electricitySubscribers;
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
        private List<string> GetAllInstallationNumbers(DateTime startDateTime, DateTime endDateTime)
        {
            List<string> installationNumbers = new List<string>();

            var electricitySubscribersResult = _electricitySubscriberData.GetAll();
            if (!electricitySubscribersResult.IsSucced)
            {
                throw new Exception(electricitySubscribersResult.Message);
            }

            foreach (ElectricitySubscriber electricitySubscriber in electricitySubscribersResult.Data)
            {
                int curYear = startDateTime.Year;
                int curMonth = startDateTime.Month;
                while (curYear < endDateTime.Year || (curYear == endDateTime.Year && curMonth <= endDateTime.Month))
                {
                    DateTime curDate = new DateTime(curYear, curMonth, 1);
                    ElectricitySubscriber temp = GetByInstallationNumber(electricitySubscriber.InstallationNumber, curDate);
                    if (temp != null && !installationNumbers.Contains(temp.InstallationNumber))
                    {
                        installationNumbers.Add(temp.InstallationNumber);
                        break;
                    }
                    curMonth++;
                    if (curMonth == 13)
                    {
                        curYear++;
                        curMonth = 1;
                    }
                }
            }
            return installationNumbers;
        }
    }
}