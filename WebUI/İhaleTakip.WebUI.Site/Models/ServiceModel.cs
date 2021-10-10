using İhaleTakip.WebUI.Site.Managers;

namespace İhaleTakip.WebUI.Site.Models
{
    public class ServiceModel
    {
        public Service Name { get; set; }
        public string TrName { get; set; }
        public bool Enabled { get; set; }
        public string InitController { get; set; }
        public string InitAction { get; set; }
        public string MenuPartialViewName { get; set; }
    }
}
