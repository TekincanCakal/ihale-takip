namespace FaturaTakip.Controllers
{
    using İhaleTakip.Data;
    using İhaleTakip.Model;
    using Microsoft.AspNetCore.Mvc;

    public class ElectricityCompanyController : Controller
    {
        ElectricityCompanyData _electricityCompanyData;

        public ElectricityCompanyController(ElectricityCompanyData electricityCompanyData)
        {
            _electricityCompanyData = electricityCompanyData;
        }

        public ActionResult Index()
        {
            var companiesResult = _electricityCompanyData.GetAll();
            if (!companiesResult.IsSucced)
            {
                return RedirectToAction("Index", "Eror", new { errorMessage = companiesResult.Message });
            }
            ViewBag.Companies = companiesResult.Data;
            return View();
        }

        public ActionResult AddElectricityCompany()
        {
            return View();
        }

        public ActionResult UpdateElectricityCompany(int id)
        {
            var selectedCompanyResult = _electricityCompanyData.GetByKey(id);
            if (!selectedCompanyResult.IsSucced)
            {
                return RedirectToAction("Index", "Eror", new { errorMessage = selectedCompanyResult.Message });
            }

            if(selectedCompanyResult.Data == null)
            {
                return RedirectToAction("Index", "Eror", new { errorMessage = "Var Olmayan Bir Firmayı Güncellemeye Çalıştınız" });
            }

            ViewBag.SelectedCompany = selectedCompanyResult.Data;
            return View();
        }

        public ActionResult DeleteElectricityCompany(int id)
        {
            var checkResult = _electricityCompanyData.GetByKey(id);
            if (!checkResult.IsSucced)
            {
                return RedirectToAction("Index", "Eror", new { errorMessage = checkResult.Message });
            }

            if(checkResult.Data == null)
            {
                return RedirectToAction("Index", "Eror", new { errorMessage = "Var Olmayan Bir Firmayı Silmeye Çalıştınız"});
            }

            var result = _electricityCompanyData.Delete(checkResult.Data);
            if (!result.IsSucced)
            {
                return RedirectToAction("Index", "Eror", new { errorMessage = result.Message });
            }

            return RedirectToAction("Index", "ElectricityCompany");
        }

        [HttpPost]
        public ActionResult AddElectricityCompany(ElectricityCompany electricityCompany)
        {
            var checkResult = _electricityCompanyData.FirstOrDefault(x => x.Name == electricityCompany.Name);
            if (!checkResult.IsSucced)
            {
                return RedirectToAction("Index", "Eror", new { errorMessage = checkResult.Message });
            }

            if(checkResult.Data != null)
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
        [HttpPost]
        public ActionResult UpdateElectricityCompany(ElectricityCompany electricityCompany)
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
    }
}