using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace WeatherAPITest.Controllers
{
    public class APIController : Controller
    {
        private const string _userAgent = "Mozilla / 5.0(Windows NT 6.1; Win64; x64; rv: 47.0) Gecko / 20100101 Firefox / 47.0";
        public IActionResult Index()
        {
            HttpWebRequest request = WebRequest.CreateHttp("https://forecast.weather.gov/MapClick.php?lat=38.4247341&lon=-86.9624086&FcstType=json");

            request.UserAgent = _userAgent;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                StreamReader data = new StreamReader(response.GetResponseStream());
                ViewBag.RawData = data.ReadToEnd();
            }

            return View();
        }
        public IActionResult ShowDetroitWeatherData()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ShowDetroitWeatherData(string latitude, string longitude)
        {
            HttpWebRequest request = WebRequest.CreateHttp("https://forecast.weather.gov/MapClick.php?lat=38.4247341&lon=-86.9624086&FcstType=json");
            //HttpWebRequest request = WebRequest.CreateHttp($"https://forecast.weather.gov/MapClick.php?lat={latitude}&lon={longitude}&FcstType=json");

            request.UserAgent = _userAgent;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if(response.StatusCode == HttpStatusCode.OK)
            {
                StreamReader data = new StreamReader(response.GetResponseStream());

                JObject dataObject = JObject.Parse(data.ReadToEnd());

                ViewBag.WeatherData = dataObject["data"]["temperature"];
                ViewBag.WeatherLabels = dataObject["time"]["startPeriodName"];
            }
            return View();
        }
    }
}