namespace FaturaTakip.Controllers
{
    using İhaleTakip.Data;
    using İhaleTakip.Model;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Dynamic;

    public class ElectricityTenderReportController : Controller
    {
        ElectricitySubscriberData _electricitySubscriberData;
        ElectricityUnitPriceData _electricityUnitPriceData;
        ElectricityBillData _electricityBillData;
        ElectricityRateData _rateData;

        public ElectricityTenderReportController(ElectricitySubscriberData electricitySubscriberData, ElectricityUnitPriceData electricityUnitPriceData, ElectricityBillData electricityBillData, ElectricityRateData rateData)
        {
            _electricitySubscriberData = electricitySubscriberData;
            _electricityUnitPriceData = electricityUnitPriceData;
            _electricityBillData = electricityBillData;
            _rateData = rateData;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateTenderReport(int tenderLimit, int startYear, int startMonth, int endYear, int endMonth)
        {
            DateTime startDate = new DateTime(startYear, startMonth, 1);
            DateTime endDate = new DateTime(endYear, endMonth, 1);
            if (startDate <= endDate)
            {
                ViewBag.IsReportCreated = true;
                ViewBag.Subsribers = new List<dynamic>();

                List<string> installationNumbers;
                try
                {
                    installationNumbers = GetAllInstallationNumbers(startDate, endDate);
                }
                catch(Exception ex)
                {
                    return RedirectToAction("Index", "Eror", new { errorMessage = ex.Message + ex.InnerException == null ? "" : "(" + ex.InnerException + ")" });
                }

                var rateResult = _rateData.GetByKey(1);
                if (!rateResult.IsSucced)
                {
                    return RedirectToAction("Index", "Eror", new { errorMessage = rateResult.Message });
                }

                foreach (string installationNumber in installationNumbers)
                {
                    dynamic subscriber = new ExpandoObject();
                    subscriber.InstallationNumber = installationNumber;
                    subscriber.Faturalar = new List<dynamic>();
                    int borçÜzerindenHesaplamaCount = 0;
                    int birimFiyatÜzerindenHesaplamaCount = 0;

                    double borçÜzerindenHesaplamaSum = 0;
                    double birimFiyatÜzerindenHesaplamaSum = 0;

                    int curYear = startYear;
                    int curMonth = startMonth;

                    while (curYear < endYear || (curYear == endYear && curMonth <= endMonth))
                    {
                        DateTime curDate = new DateTime(curYear, curMonth, 1);
                        ElectricitySubscriber electricitySubscriber;
                        try
                        {
                            electricitySubscriber = GetByInstallationNumber(installationNumber, curDate);
                        }
                        catch (Exception ex)
                        {
                            return RedirectToAction("Index", "Eror", new { errorMessage = ex.Message + ex.InnerException == null ? "" : "(" + ex.InnerException + ")" });
                        }

                        var electricityBillResult = _electricityBillData.FirstOrDefault(x => x.InstallationNumber == installationNumber && x.Period.Year == curDate.Year && x.Period.Month == curDate.Month);
                        if (!electricityBillResult.IsSucced)
                        {
                            return RedirectToAction("Index", "Eror", new { errorMessage = electricityBillResult.Message });
                        }

                        if (electricityBillResult.Data != null)
                        {
                            var unitPriceResult = _electricityUnitPriceData.FirstOrDefault(x => x.SubscriptionTypeId == electricitySubscriber.SubscriptionTypeId && x.Period.Year == curDate.Year && x.Period.Month == curDate.Month);
                            if (!unitPriceResult.IsSucced)
                            {
                                return RedirectToAction("Index", "Eror", new { errorMessage = unitPriceResult.Message });
                            }
                           
                            dynamic bill = new ExpandoObject();
                            bill.BorçÜzerindenHesaplamayaKatıldıMı = false;
                            bill.BirimFiyatÜzerindenHesaplamayaKatıldıMı = false;
                            bill.Dönem = curYear + "/" + curMonth;
                            if (electricityBillResult.Data.Debt != 0)
                            {
                                bill.Borç = "" + electricityBillResult.Data.Debt;
                                bill.BorçÜzerindenHesaplamayaKatıldıMı = true;
                                borçÜzerindenHesaplamaCount++;
                                borçÜzerindenHesaplamaSum += electricityBillResult.Data.Debt;
                            }
                            else
                            {
                                bill.Borç = "Borç Bilgisine Ulaşılamadı";
                            }

                            if (unitPriceResult.Data != null)
                            {
                                double EnergyFund = unitPriceResult.Data.OneTimeEnergyCost * rateResult.Data.EnergyFund / 100;
                                double TRTShare = unitPriceResult.Data.OneTimeEnergyCost * rateResult.Data.TRTShare / 100;
                                double ElectricityConsumptionTax = unitPriceResult.Data.OneTimeEnergyCost * rateResult.Data.ElectricityConsumptionTax / 100;
                                double SubTotal = unitPriceResult.Data.OneTimeEnergyCost + unitPriceResult.Data.DistributionCost + EnergyFund + TRTShare + ElectricityConsumptionTax;
                                double KDV = SubTotal * rateResult.Data.KDV / 100;
                                bill.BirimFiyat = SubTotal + KDV;
                            }
                            else
                            {
                                bill.BirimFiyat = "Birim Fiyat Bilgisine Ulaşılamadı";
                            }

                            if (unitPriceResult.Data != null && electricityBillResult.Data.Amount != 0)
                            {
                                bill.BirimFiyatÜzerindenHesaplanmışBorç = bill.BirimFiyat * electricityBillResult.Data.Amount;
                                bill.BirimFiyatÜzerindenHesaplamayaKatıldıMı = true;
                                birimFiyatÜzerindenHesaplamaCount++;
                                birimFiyatÜzerindenHesaplamaSum += unitPriceResult.Data.DistributionCost * electricityBillResult.Data.Amount;
                            }
                            else if (unitPriceResult.Data == null && electricityBillResult.Data.Amount == 0)
                            {
                                bill.BirimFiyatÜzerindenHesaplanmışBorç = "Birim Fiyat ve Harcama Verilerine Ulaşılamadığından Hesaplanamadı";
                            }
                            else if (unitPriceResult.Data == null)
                            {
                                bill.BirimFiyatÜzerindenHesaplanmışBorç = "Birim Fiyat Verisine Ulaşılamadığından Hesaplanamadı";
                            }
                            else if (electricityBillResult.Data.Amount == 0)
                            {
                                bill.BirimFiyatÜzerindenHesaplanmışBorç = "Harcama Verisine Ulaşılamadığından Hesaplanamadı";
                            }

                            subscriber.Faturalar.Add(bill);
                        }

                        curMonth++;
                        if (curMonth == 13)
                        {
                            curYear++;
                            curMonth = 1;
                        }
                    }

                    subscriber.BorçÜzerindenİhaleDurumu = new ExpandoObject();
                    subscriber.BorçÜzerindenİhaleDurumu.HesabaKatılanFaturaSayısı = borçÜzerindenHesaplamaCount;
                    subscriber.BorçÜzerindenİhaleDurumu.ToplamTüketimMiktarı = borçÜzerindenHesaplamaSum;

                    if (borçÜzerindenHesaplamaSum >= tenderLimit)
                    {
                        subscriber.BorçÜzerindenİhaleDurumu.İhaleDurumu = "İhale";
                    }
                    else
                    {
                        subscriber.BorçÜzerindenİhaleDurumu.İhaleDurumu = "Doğrudan Temin";
                    }

                    subscriber.BirimFiyatÜzerindenİhaleDurumu = new ExpandoObject();
                    subscriber.BirimFiyatÜzerindenİhaleDurumu.HesabaKatılanFaturaSayısı = birimFiyatÜzerindenHesaplamaCount;
                    subscriber.BirimFiyatÜzerindenİhaleDurumu.ToplamTüketimMiktarı = birimFiyatÜzerindenHesaplamaSum;

                    if (birimFiyatÜzerindenHesaplamaSum >= tenderLimit)
                    {
                        subscriber.BirimFiyatÜzerindenİhaleDurumu.İhaleDurumu = "İhale";
                    }
                    else
                    {
                        subscriber.BirimFiyatÜzerindenİhaleDurumu.İhaleDurumu = "Doğrudan Temin";
                    }
                    ViewBag.Subsribers.Add(subscriber);
                }
            }
            return View();
        }

        public List<string> GetAllInstallationNumbers(DateTime startDateTime, DateTime endDateTime)
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
        public ElectricitySubscriber GetByInstallationNumber(string installationNumber, DateTime dateTime)
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