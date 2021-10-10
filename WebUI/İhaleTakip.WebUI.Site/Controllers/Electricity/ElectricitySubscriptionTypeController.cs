namespace FaturaTakip.Controllers
{
    using İhaleTakip.Data;
    using İhaleTakip.Model;
    using Microsoft.AspNetCore.Mvc;

    public class ElectricitySubscriptionTypeController : Controller
    {
        ElectricitySubscriptionTypeData _electricitySubscriptionTypeData;

        public ElectricitySubscriptionTypeController(ElectricitySubscriptionTypeData electricitySubscriptionTypeData)
        {

            _electricitySubscriptionTypeData = electricitySubscriptionTypeData;
        }

        public ActionResult Index()
        {
            

            var electricitySubscriptionTypesResult = _electricitySubscriptionTypeData.GetAll();
            if (!electricitySubscriptionTypesResult.IsSucced)
            {
                return RedirectToAction("Index", "Eror", new { errorMessage = electricitySubscriptionTypesResult.Message });
            }
            ViewBag.ElectricitySubscriptionTypes = electricitySubscriptionTypesResult.Data;
            return View();
        }

        public ActionResult AddElectricitySubscriptionType()
        {
            

            return View();
        }

        public ActionResult UpdateElectricitySubscriptionType(int id)
        {
            var selectedSubscriptionTypeResult = _electricitySubscriptionTypeData.GetByKey(id);
            if (!selectedSubscriptionTypeResult.IsSucced)
            {
                return RedirectToAction("Index", "Eror", new { errorMessage = selectedSubscriptionTypeResult.Message });
            }

            if(selectedSubscriptionTypeResult.Data == null)
            {
                return RedirectToAction("Index", "Eror", new { errorMessage = "Var Olmayan Bir Abonelik Türünü Güncellemeye Çalıştınız" });
            }

            ViewBag.SelectedSubscriptionType = selectedSubscriptionTypeResult.Data;
            return View();
        }

        public ActionResult DeleteElectricitySubscriptionType(int id)
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

        [HttpPost]
        public ActionResult AddElectricitySubscriptionType(ElectricitySubscriptionType electricitySubscriptionType)
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
        
        [HttpPost]
        public ActionResult UpdateElectricitySubscriptionType(ElectricitySubscriptionType electricitySubscriptionType)
        {
            var checkResult = _electricitySubscriptionTypeData.FirstOrDefault(x => x.Name == electricitySubscriptionType.Name && x.Id != electricitySubscriptionType.Id);
            if (!checkResult.IsSucced)
            {
                return RedirectToAction("Index", "Eror", new { errorMessage = checkResult.Message });
            }

            if(checkResult.Data != null)
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
    }
}