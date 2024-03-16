using Newtonsoft.Json;

namespace UI.Model
{
    public class GANClass
    {
        public int Id { get; set; }
        public string Recipient { get; set; }
        public string StreetName { get; set; }
        public string HouseNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }

        public GANClass() 
        {
        }

        public List<GANClass> LoadAddressesFromJson(string filePath)
        {
            // Read the file content
            string jsonContent = File.ReadAllText(filePath);
            // Deserialize the JSON content to a list of GANClass objects
            List<GANClass> addresses = JsonConvert.DeserializeObject<List<GANClass>>(jsonContent);
            // Return the list of addresses
            return addresses;
        }

        public bool Validate()
        {
            // Check if the required fields are not empty
            bool isValid = !string.IsNullOrWhiteSpace(Recipient) &&
                           !string.IsNullOrWhiteSpace(StreetName) &&
                           !string.IsNullOrWhiteSpace(HouseNumber) &&
                           !string.IsNullOrWhiteSpace(City) &&
                           !string.IsNullOrWhiteSpace(ZipCode) &&
                           !string.IsNullOrWhiteSpace(Country);
            return isValid;
        }

        // Method to format the address as a single string
        public string FormatAddress()
        {
            return $"{Recipient}, {HouseNumber} {StreetName}, {City}, {State}, {ZipCode}, {Country}";
        }

        // Method to check if the address is complete
        public bool IsComplete()
        {
            return Validate();
        }

        public override string ToString()
        {
            return FormatAddress(); 
        }

        public void Normalize()
        {
            City = City?.Trim();
            State = State?.Trim();
            Country = Country?.Trim();
            Recipient = Recipient?.Trim();
            StreetName = StreetName?.Trim();
            HouseNumber = HouseNumber?.Trim();
        }
        // List<GANClass> allAddresses
        //public List<GANClass> FindAddressesByZipCode(string zipCode, List<GANClass> allAddresses)
        //{
        //    List<GANClass> matchedAddresses = new List<GANClass>();

        //    // search by zipcode
        //    foreach (var address in allAddresses)
        //    {
        //        if (address.ZipCode == zipCode)
        //        {
        //            matchedAddresses.Add(address);
        //        }
        //    }

        //    return matchedAddresses;
        //}
        // List<GANClass> allAddresses
        public List<GANClass> FindAddressesByCountry(string country, List<GANClass> allAddresses)
        {
            List<GANClass> matchedAddresses = new List<GANClass>();

            foreach (var address in allAddresses)
            {
                if (address.Country.Equals(country, StringComparison.OrdinalIgnoreCase)) 
                {
                    matchedAddresses.Add(address);
                }
            }
            return matchedAddresses;
        }
        //List<GANClass> allAddresses = GANClass.LoadAddressesFromJson(@"Data\address.json");
        //List<string> allCountries = GANClass.GetAllCountries(allAddresses);
        public static List<string> GetAllCountries(List<GANClass> allAddresses)
        {
            // Use a HashSet to avoid duplicates and collect all unique country names
            HashSet<string> countries = new HashSet<string>();

            // Iterate through all addresses and add their country to the set
            foreach (var address in allAddresses)
            {
                countries.Add(address.Country);
            }

            // Convert the set to a list and return it
            return countries.ToList();
        }


    }



}
