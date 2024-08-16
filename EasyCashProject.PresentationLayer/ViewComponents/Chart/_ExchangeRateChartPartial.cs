using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace EasyCashProject.PresentationLayer.ViewComponents.Chart
{
    public class _ExchangeRateChartPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
