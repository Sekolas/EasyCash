using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EasyCashProject.PresentationLayer.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        public async Task<IActionResult> Index()
        {
            // * freecurrencyapi uzerinden doviz kurlarini cekme *
            // Dolar'dan Turk lirasina cevirme
            //#region
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://api.freecurrencyapi.com/v1/latest?apikey=fca_live_Yl1pz2FJWw0gV1HLpVR7kRbpruFsnzbyDXYuYYgw&base_currency=USD"),
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                // JSON yanitini ayristir
                var json = JObject.Parse(body);

                // TRY degerini al
                var usdToTry = json["data"]?["TRY"]?.ToString();

                ViewBag.UsdToTry = Decimal.Parse(usdToTry.Replace(".", ",")).ToString("0.0000");
            }
            //#endregion

            //// Euro'dan Turk lirasına cevirme
            //#region
            var client2 = new HttpClient();
            var request2 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://api.freecurrencyapi.com/v1/latest?apikey=fca_live_Yl1pz2FJWw0gV1HLpVR7kRbpruFsnzbyDXYuYYgw&base_currency=EUR"),
            };
            using (var response2 = await client2.SendAsync(request2))
            {
                response2.EnsureSuccessStatusCode();
                var body = await response2.Content.ReadAsStringAsync();

                // JSON yanitini ayristir
                var json = JObject.Parse(body);

                // TRY degerini al
                var eurToTry = json["data"]?["TRY"]?.ToString();
                ViewBag.EurToTry = Decimal.Parse(eurToTry.Replace(".", ",")).ToString("0.0000"); ;
            }
            //#endregion

            //// Gbp'den (Sterlin) Turk lirasina cevirme
            //#region
            var client3 = new HttpClient();
            var request3 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://api.freecurrencyapi.com/v1/latest?apikey=fca_live_Yl1pz2FJWw0gV1HLpVR7kRbpruFsnzbyDXYuYYgw&base_currency=GBP"),
            };
            using (var response3 = await client3.SendAsync(request3))
            {
                response3.EnsureSuccessStatusCode();
                var body = await response3.Content.ReadAsStringAsync();

                // JSON yanitini ayristir
                var json = JObject.Parse(body);

                // TRY degerini al
                var gbpToTry = json["data"]?["TRY"]?.ToString();
                ViewBag.GbpToTry = Decimal.Parse(gbpToTry.Replace(".", ",")).ToString("0.0000"); ;
            }
            //#endregion


            //// Dolar'dan euro'ya cevirme
            //#region
            var client4 = new HttpClient();
            var request4 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://api.freecurrencyapi.com/v1/latest?apikey=fca_live_Yl1pz2FJWw0gV1HLpVR7kRbpruFsnzbyDXYuYYgw&base_currency=USD"),
            };
            using (var response4 = await client4.SendAsync(request4))
            {
                response4.EnsureSuccessStatusCode();
                var body = await response4.Content.ReadAsStringAsync();

                // JSON yanitini ayristir
                var json = JObject.Parse(body);

                // EUR degerini al
                var usdToEur = json["data"]?["EUR"]?.ToString();
                ViewBag.UsdToEur = Decimal.Parse(usdToEur.Replace(".", ",")).ToString("0.0000"); ;
            }
            //#endregion
            return View();
        }

        private static readonly string apiUrl = "https://api.freecurrencyapi.com/v1/latest?apikey=fca_live_Yl1pz2FJWw0gV1HLpVR7kRbpruFsnzbyDXYuYYgw&base_currency=USD";

        public async Task<IActionResult> Chart()
        {
            try
            {
                var exchangeRates = await GetExchangeRates();

                if (exchangeRates != null)
                {
                    return Json(new { exchangeKey = exchangeRates.Keys.ToList(), exchangeValue = exchangeRates.Values.ToList() });
                }
                else
                {
                    return Json(new { error = "Döviz kurları alınamadı." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { error = $"Hata: {ex.Message}" });
            }
        }

        private static async Task<Dictionary<string, decimal>> GetExchangeRates()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetStringAsync(apiUrl);
                var json = JObject.Parse(response);

                var rates = json["data"].ToObject<Dictionary<string, decimal>>();
                return rates;
            }
        }



        // *** Rapid API uzerinden doviz kurlarini cekme (Aylik istek siniri asildi!!)

        //public async Task<IActionResult> Index()
        //{
        // Dolar'dan Turk lirasina cevirme
        //#region
        //var client = new HttpClient();
        //var request = new HttpRequestMessage
        //{
        //    Method = HttpMethod.Get,
        //    RequestUri = new Uri("https://currency-exchange22.p.rapidapi.com/rates?base=USD"),
        //    Headers =
        //        {
        //            { "x-rapidapi-key", "3fbad29645msh80ffd96dbea7821p18ba73jsna1767cd6ef22" },
        //            { "x-rapidapi-host", "currency-exchange22.p.rapidapi.com" },
        //        },
        //};
        //using (var response = await client.SendAsync(request))
        //{
        //    response.EnsureSuccessStatusCode();
        //    var body = await response.Content.ReadAsStringAsync();

        //    // JSON yanitini ayristir
        //    var json = JObject.Parse(body);

        //    // TRY degerini al
        //    var usdToTry = json["rates"]?["TRY"]?.ToString();

        //    ViewBag.UsdToTry = Decimal.Parse(usdToTry.Replace(".", ",")).ToString("0.0000");
        //}
        //#endregion

        //// Euro'dan Turk lirasına cevirme
        //#region
        //var client2 = new HttpClient();
        //var request2 = new HttpRequestMessage
        //{
        //    Method = HttpMethod.Get,
        //    RequestUri = new Uri("https://currency-exchange22.p.rapidapi.com/rates?base=EUR"),
        //    Headers =
        //        {
        //            { "x-rapidapi-key", "3fbad29645msh80ffd96dbea7821p18ba73jsna1767cd6ef22" },
        //            { "x-rapidapi-host", "currency-exchange22.p.rapidapi.com" },
        //        },
        //};
        //using (var response2 = await client2.SendAsync(request2))
        //{
        //    response2.EnsureSuccessStatusCode();
        //    var body = await response2.Content.ReadAsStringAsync();

        //    // JSON yanitini ayristir
        //    var json = JObject.Parse(body);

        //    // TRY degerini al
        //    var eurToTry = json["rates"]?["TRY"]?.ToString();
        //    ViewBag.EurToTry = Decimal.Parse(eurToTry.Replace(".", ",")).ToString("0.0000"); ;
        //}
        //#endregion

        //// Gbp'den (Sterlin) Turk lirasina cevirme
        //#region
        //var client3 = new HttpClient();
        //var request3 = new HttpRequestMessage
        //{
        //    Method = HttpMethod.Get,
        //    RequestUri = new Uri("https://currency-exchange22.p.rapidapi.com/rates?base=GBP"),
        //    Headers =
        //        {
        //            { "x-rapidapi-key", "3fbad29645msh80ffd96dbea7821p18ba73jsna1767cd6ef22" },
        //            { "x-rapidapi-host", "currency-exchange22.p.rapidapi.com" },
        //        },
        //};
        //using (var response3 = await client3.SendAsync(request3))
        //{
        //    response3.EnsureSuccessStatusCode();
        //    var body = await response3.Content.ReadAsStringAsync();

        //    // JSON yanitini ayristir
        //    var json = JObject.Parse(body);

        //    // TRY degerini al
        //    var gbpToTry = json["rates"]?["TRY"]?.ToString();
        //    ViewBag.GbpToTry = Decimal.Parse(gbpToTry.Replace(".", ",")).ToString("0.0000"); ;
        //}
        //#endregion



        //// Dolar'dan euro'ya cevirme
        //#region
        //var client4 = new HttpClient();
        //var request4 = new HttpRequestMessage
        //{
        //    Method = HttpMethod.Get,
        //    RequestUri = new Uri("https://currency-exchange22.p.rapidapi.com/rates?base=USD"),
        //    Headers =
        //        {
        //            { "x-rapidapi-key", "3fbad29645msh80ffd96dbea7821p18ba73jsna1767cd6ef22" },
        //            { "x-rapidapi-host", "currency-exchange22.p.rapidapi.com" },
        //        },
        //};
        //using (var response4 = await client4.SendAsync(request4))
        //{
        //    response4.EnsureSuccessStatusCode();
        //    var body = await response4.Content.ReadAsStringAsync();

        //    // JSON yanitini ayristir
        //    var json = JObject.Parse(body);

        //    // EUR degerini al
        //    var usdToEur = json["rates"]?["EUR"]?.ToString();
        //    ViewBag.UsdToEur = Decimal.Parse(usdToEur.Replace(".", ",")).ToString("0.0000"); ;
        //}
        //#endregion
        //    return View();
        //}
    }
}
