using Microsoft.AspNetCore.Mvc;
using GlobalAddressNavigatorServer.Models;
using GlobalAddressNavigatorServer.Data;


namespace GlobalAddressNavigatorServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GANApi : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly GANClass _addresses;
        private static string PathToAppSettings = "appsettings.json";
        private static string PathToDataDirectory = Path.Combine("Data", "address.json");
        private List<GANClass> _database;

        public GANApi(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("getrecipient")]
        public IActionResult GetRecipient(string recipient)
        {
            string path = Path.Combine(Environment.CurrentDirectory, PathToDataDirectory);
            GANClass allAdresses = new GANClass();
            List<GANClass> list = allAdresses.LoadAddressesFromJson(path);
            var result = list.Where(a => a.Recipient?.IndexOf(recipient, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();

            if (result == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(Ok(result));
        }

        [HttpGet]
        [Route("getstreet")]
        public JsonResult GetStreet(string street)
        {
            string path = Path.Combine(Environment.CurrentDirectory, PathToDataDirectory);
            GANClass allAdresses = new GANClass();
            List<GANClass> list = allAdresses.LoadAddressesFromJson(path);
            var result = list.Where(a => a.StreetName.IndexOf(street, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();

            if (result == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(Ok(result));
        }

        //[HttpGet("byhousenumber/{housnumber}")]
        //public JsonResult GetHouseNumber(int housenumber)
        //{
        // string path = Path.Combine(Environment.CurrentDirectory, PathToDataDirectory);
        //    GANClass allAdresses = new GANClass();
        //    List<GANClass> list = allAdresses.LoadAddressesFromJson(path);
        //    var result = list.Where(a => a.HouseNumber.Equals(housenumber)).ToList();

        //    if (result == null)
        //    {
        //        return new JsonResult(NotFound());
        //    }
        //    return new JsonResult(Ok(result));
        //}

        [HttpGet]
        [Route("getcity")]
        public JsonResult GetCity(string city)
        {
            string path = Path.Combine(Environment.CurrentDirectory, PathToDataDirectory);
            GANClass allAdresses = new GANClass();
            List<GANClass> list = allAdresses.LoadAddressesFromJson(path);
            var result = list.Where(a => a.City?.IndexOf(city, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

            if (result == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(Ok(result));
        }

        [HttpGet]
        [Route("getstate")]
        public JsonResult GetState(string state)
        {
            string path = Path.Combine(Environment.CurrentDirectory, PathToDataDirectory);
            GANClass allAdresses = new GANClass();
            List<GANClass> list = allAdresses.LoadAddressesFromJson(path);
            var result = list.Where(a => a.State?.IndexOf(state, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

            if (result == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(Ok(result));
        }

        [HttpGet]
        [Route("getcountry")]
        public JsonResult GetCountry(string country)
        {
            string path = Path.Combine(Environment.CurrentDirectory, PathToDataDirectory);
            GANClass allAdresses = new GANClass();
            List<GANClass> list = allAdresses.LoadAddressesFromJson(path);
            var result = list.Where(a => a.Country?.IndexOf(country, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

            if (result == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(Ok(result));
        }

        [HttpGet]
        [Route("getzipcode")]
        public JsonResult GetZipCode(string zipcode)
        {
            string path = Path.Combine(Environment.CurrentDirectory, PathToDataDirectory);
            GANClass allAdresses = new GANClass();
            List<GANClass> list = allAdresses.LoadAddressesFromJson(path);
            var result = list.Where(a => a.ZipCode.Contains(zipcode)).ToList();

            if (result == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(Ok(result));
        }


        [HttpGet]
        [Route("getalldata")]
        public JsonResult GetAllData()
        {
            string path = Path.Combine(Environment.CurrentDirectory, PathToDataDirectory);
            GANClass allAdresses = new GANClass();
            List<GANClass> list = allAdresses.LoadAddressesFromJson(path);
            var result = list.ToList();

            if (result == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(Ok(result));

        }

        [HttpGet("search")]
        public IActionResult SearchData([FromQuery] List<string> countries, [FromQuery] string name = null,
            [FromQuery] string partialAddress = null)
        {
            string path = Path.Combine(Environment.CurrentDirectory, PathToDataDirectory);
            GANClass allAddresses = new GANClass();
            List<GANClass> list = allAddresses.LoadAddressesFromJson(path);

            // Filter the list based on the selected countries
            if (countries != null && countries.Any())
            {
                // Create a new list to store filtered results
                List<GANClass> filteredList = new List<GANClass>();

                foreach (var country in countries)
                {
                    var countryAddresses =
                        list.Where(a => string.Equals(a.Country, country, StringComparison.OrdinalIgnoreCase)).ToList();
                    filteredList.AddRange(countryAddresses);
                }

                list = filteredList;
            }

            // Filter by name if provided
            if (!string.IsNullOrWhiteSpace(name))
            {
                list = list.Where(a => a.Recipient?.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            }

            // Filter by partial address if provided
            if (!string.IsNullOrWhiteSpace(partialAddress))
            {
                list = list.Where(a =>
                    (a.StreetName?.IndexOf(partialAddress, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (a.City?.IndexOf(partialAddress, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (a.State?.IndexOf(partialAddress, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (a.ZipCode?.Contains(partialAddress) ?? false)
                ).ToList();
            }

            // Check if either name or partialAddress filter is applied
            if ((string.IsNullOrWhiteSpace(name) && string.IsNullOrWhiteSpace(partialAddress)) || list == null ||
                list.Count == 0)
            {
                return NotFound("No matching records found.");
            }

            return Ok(list);
        }
    }
}

