using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Net;
using System.Reflection.PortableExecutable;
using System.Text.Json;
using System.Text.RegularExpressions;
using UI.Model;

namespace UI.Pages
{
    /// <summary>
    /// PageModel for the Address Input page.
    /// </summary>
    public class AddressInputModel : PageModel
    {
        private readonly ILogger<AddressInputModel> _logger;

        //USA SECTION
        [BindProperty]
        [Required(ErrorMessage = "Name is required.")]
        public string nameUSA { get; set; }

        [BindProperty]
        public string streetNameUSA { get; set; }

        [BindProperty]
        public string streetNumberUSA { get; set; }
        [BindProperty]
        public int houseAptNumberUSA { get; set; }
        [BindProperty]
        public string cityUSA { get; set; }
        [BindProperty]
        public string stateUSA { get; set; }
        [BindProperty]
        public string zipCodeUSA { get; set; }
        //------------------------------------------------------------------------------//

        //UK SECTION
        [BindProperty]
        [Required(ErrorMessage = "Name is required.")]
        public string nameUK { get; set; }

        [BindProperty]
        public string streetNameUK { get; set; }

        [BindProperty]
        public string streetNumberUK { get; set; }
        [BindProperty]
        public int houseAptNumberUK { get; set; }
        [BindProperty]
        public string cityUK { get; set; }
        [BindProperty]
        public string stateUK { get; set; }
        [BindProperty]
        public string zipCodeUK { get; set; }
        //------------------------------------------------------------------------------//

        //BRAZIL SECTION
        [BindProperty]
        [Required(ErrorMessage = "Name is required.")]
        public string nameBR { get; set; }

        [BindProperty]
        public string streetNameBR { get; set; }

        [BindProperty]
        public string streetNumberBR { get; set; }
        [BindProperty]
        public int houseAptNumberBR { get; set; }
        [BindProperty]
        public string cityBR { get; set; }
        [BindProperty]
        public string stateBR { get; set; }
        [BindProperty]
        public string zipCodeBR { get; set; }
        [BindProperty]
        public string neighborhoodBR {  get; set; }
        //------------------------------------------------------------------------------//

        //CANADA SECTION
        [BindProperty]
        [Required(ErrorMessage = "Name is required.")]
        public string nameCA { get; set; }

        [BindProperty]
        public string streetNameCA { get; set; }

        [BindProperty]
        public string streetNumberCA { get; set; }
        [BindProperty]
        public int houseAptNumberCA { get; set; }
        [BindProperty]
        public string cityCA { get; set; }
        [BindProperty]
        public string stateCA { get; set; }
        [BindProperty]
        public string zipCodeCA { get; set; }
        //------------------------------------------------------------------------------//

        //GERMANY SECTION
        [BindProperty]
        [Required(ErrorMessage = "Name is required.")]
        public string nameGER { get; set; }

        [BindProperty]
        public string streetNameGER { get; set; }
        [BindProperty]
        public int houseAptNumberGER { get; set; }
        [BindProperty]
        public string cityGER { get; set; }
        [BindProperty]
        public string zipCodeGER { get; set; }
        //------------------------------------------------------------------------------//

        //INDIA SECTION
        [BindProperty]
        [Required(ErrorMessage = "Name is required.")]
        public string nameAddresseeIN { get; set; }
        [BindProperty]
        public string sendersNameIN { get; set; }
        [BindProperty]
        public string nameBuildingIN { get; set; }
        [BindProperty]
        public int houseAptNumberIN { get; set; }
        [BindProperty]
        public string streetNameID { get; set; }
        [BindProperty]
        public string stateIN { get; set; }
        [BindProperty]
        public string zipCodeIN { get; set; }
        //------------------------------------------------------------------------------//


        //JAPAN SECTION
        [BindProperty]
        [Required(ErrorMessage = "Name is required.")]
        public string nameJP { get; set; }
        [BindProperty]
        public string buildingNameJP { get; set; }
        [BindProperty]
        public string districJP { get; set; }

        [BindProperty]
        public int houseAptNumberJP{ get; set; }
        [BindProperty]
        public string cityJP { get; set; }
        [BindProperty]
        public string zipCodeJP { get; set; }
        //------------------------------------------------------------------------------//

        //MEXICO SECTION
        [BindProperty]
        [Required(ErrorMessage = "Name is required.")]
        public string nameMX { get; set; }
        [BindProperty]
        public string streetNameMX { get; set; }
        [BindProperty]
        public string streetNumberMX { get; set; }
        [BindProperty]
        public int houseAptNumberMX { get; set; }
        [BindProperty]
        public string cityMX { get; set; }
        [BindProperty]
        public string stateMX { get; set; }
        [BindProperty]
        public string zipCodeMX { get; set; }
        [BindProperty]
        public string neighborhoodMX { get; set; }
        //------------------------------------------------------------------------------//

        //SPAIN SECTION
        [BindProperty]
        [Required(ErrorMessage = "Name is required.")]
        public string nameSP { get; set; }
        [BindProperty]
        public string streetNameSP { get; set; }
        [BindProperty]
        public int houseAptNumberSP { get; set; }
        [BindProperty]
        public string appartmentBlockNumberSP { get; set; }
        [BindProperty]
        public string zipCodeSP { get; set; }
        [BindProperty]
        public string citySP { get; set; }
        [BindProperty]
        public string provinceSP { get; set; }
        //------------------------------------------------------------------------------//


        [BindProperty]
        public string country { get; set; }
        public string fullAddress {  get; set; }

        public AddressInputModel(ILogger<AddressInputModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// HTTP GET handler method for the Address Input page.
        /// </summary>
        public void OnGet()
        {
            
        }

        public void OnPost()
        {
            string capturedName;
            string capturedStreetName;
            string capturedStreetNumber;
            string capturedHouseAptNumber;
            string capturedCity;
            string capturedState;
            string capturedZipCode;
            string capturedCountry;
            string capturedNeighbohood;
            string capturedSendersName;
            string capturedBuildingName;
            switch (country)
            {
                case "Brazil":
                    capturedName = nameBR;
                    capturedStreetName = streetNameBR;
                    capturedHouseAptNumber = houseAptNumberBR.ToString();
                    capturedNeighbohood = neighborhoodBR;
                    capturedCity = cityBR;
                    capturedState = stateBR;
                    capturedZipCode = zipCodeBR;
                    capturedCountry = country;
                    fullAddress = capturedName + ", " + capturedStreetName + " N "+ capturedHouseAptNumber + ", " + capturedNeighbohood + ", " + capturedCity + ", " + capturedState +", " + capturedZipCode + ", " + capturedCountry;
                    break;
                case "Canada":
                    capturedName = nameCA;
                    capturedStreetName = streetNameCA;
                    capturedStreetNumber = streetNumberCA;
                    capturedHouseAptNumber = houseAptNumberCA.ToString();
                    capturedCity = cityCA;
                    capturedState = stateCA;
                    capturedZipCode = zipCodeCA;
                    capturedCountry = country;
                    fullAddress = capturedName + ", " + capturedHouseAptNumber + ", " + capturedStreetNumber + ", " + capturedStreetName + ", " + capturedCity + ", " + capturedState + ", " + capturedZipCode + ", " + country ;
                    break;
                case "Germany":
                    capturedName = nameGER;
                    capturedStreetName = streetNameGER;
                    capturedHouseAptNumber = houseAptNumberGER.ToString();
                    capturedZipCode = zipCodeGER;
                    capturedCity = cityGER;
                    fullAddress = capturedName + " " + capturedStreetName + " " + capturedHouseAptNumber + " " + capturedZipCode + " " + capturedCity + " " + country;
                    break;
                case "India":
                    capturedName = nameAddresseeIN;
                    capturedSendersName = sendersNameIN;
                    capturedBuildingName = nameBuildingIN;
                    capturedHouseAptNumber = houseAptNumberIN.ToString();
                    capturedStreetName = streetNameID;
                    capturedState = stateIN;
                    capturedZipCode = zipCodeIN;
                    fullAddress = capturedName + " " + capturedSendersName + " " + capturedBuildingName + " " + capturedHouseAptNumber + " " + capturedStreetName + " " + capturedState + " " + capturedZipCode + " " + country;
                    break;
                case "Japan":
                    capturedName = nameJP;
                    capturedBuildingName = buildingNameJP;
                    capturedHouseAptNumber = houseAptNumberJP.ToString();
                    string capturedWardDistrict = districJP;
                    capturedCity = cityJP;
                    capturedZipCode = zipCodeJP;
                    fullAddress = country + " " + capturedZipCode + " " + capturedCity + " " + capturedWardDistrict + " " + capturedHouseAptNumber + " " + capturedBuildingName + " " + capturedName;
                    break;
                case "Mexico":
                    capturedName = nameMX;
                    capturedStreetName = streetNameMX;
                    capturedHouseAptNumber = houseAptNumberMX.ToString();
                    capturedNeighbohood = neighborhoodMX;
                    capturedCity = cityMX;
                    capturedState = stateMX;
                    capturedZipCode = zipCodeMX;
                    capturedCountry = country;
                    fullAddress = capturedName + ", " + capturedStreetName + " N " + capturedHouseAptNumber + ", " + capturedNeighbohood + ", " + capturedCity + ", " + capturedState + ", " + capturedZipCode + ", " + capturedCountry;
                    break;
                case "Spain":
                    capturedName = nameSP;
                    capturedStreetName = streetNameSP;
                    capturedHouseAptNumber = houseAptNumberSP.ToString();
                    string capturedAppDetails = appartmentBlockNumberSP;
                    capturedZipCode = zipCodeSP;
                    capturedCity = citySP;
                    string province = provinceSP;
                    fullAddress = capturedName + " " + capturedStreetName + " " + capturedHouseAptNumber + " " + capturedAppDetails + " " + capturedZipCode + " " + capturedCity.ToUpper() + " (" + province + ") " + country.ToUpper();
                    break;
                case "USA":
                    capturedName = nameUSA;
                    capturedStreetName = streetNameUSA;
                    capturedStreetNumber = streetNumberUSA;
                    capturedHouseAptNumber = houseAptNumberUSA.ToString();
                    capturedCity = cityUSA;
                    capturedState = stateUSA;
                    capturedZipCode= zipCodeUSA;
                    capturedCountry = country;
                    fullAddress = capturedName + "\n" + capturedStreetNumber + " " + capturedStreetName + " " + "\n" +capturedCity + capturedState + "\n" + capturedZipCode + "\n" + capturedCountry;
                    break;
                case "UK":
                    capturedName = nameUK;
                    capturedStreetName = streetNameUK;
                    capturedStreetNumber = streetNumberUK;
                    capturedHouseAptNumber = houseAptNumberUK.ToString();
                    capturedCity = cityUK;
                    capturedState = stateUK;
                    capturedZipCode = zipCodeUK;
                    capturedCountry = country;
                    fullAddress = capturedName + "\n" + capturedHouseAptNumber + " " + capturedStreetName + " " + "\n" + capturedCity + capturedState + "\n" + capturedZipCode + " UNITED KINGDOM";
                    break;
            }

        }
    }
}