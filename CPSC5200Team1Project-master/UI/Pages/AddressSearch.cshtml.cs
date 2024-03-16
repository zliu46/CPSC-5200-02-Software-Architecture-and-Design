using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UI.Model;

namespace UI.Pages
{
    public class AddressSearchModel : PageModel
    {
        private readonly ILogger<AddressSearchModel> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public List<AddressResponse> SearchResults { get; private set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 25;

        public AddressSearchModel(ILogger<AddressSearchModel> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            SearchResults = new List<AddressResponse>();
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(List<string> countries, string name, string address)
        {
            // Check if at least one country is selected
            if (countries == null || !countries.Any())
            {
                TempData["NoResults"] = "At least one country must be selected.";
                return Page();
            }

            // Check if at least name or address is provided
            if (string.IsNullOrWhiteSpace(name) && string.IsNullOrWhiteSpace(address))
            {
                TempData["NoResults"] = "You must provide at least a name or an address.";
                return Page();
            }

            var client = _httpClientFactory.CreateClient();

            var requestData = new Dictionary<string, string>
            {
                { "countries", string.Join(",", countries) }
            };

            // Pass an empty string if the name field is left blank
            requestData.Add("name", string.IsNullOrWhiteSpace(name) ? "" : name);

            // Pass an empty string if the address field is left blank
            requestData.Add("partialAddress", string.IsNullOrWhiteSpace(address) ? "" : address);

            requestData.Add("pageNumber", PageNumber.ToString()); // Add page number to the request
            requestData.Add("pageSize", PageSize.ToString()); // Add page size to the request

            // Construct query string
            var queryString = string.Join("&", requestData.Select(kv => $"{kv.Key}={kv.Value}"));

            // Send a GET request to the /search endpoint with the constructed query string
            var response = await client.GetAsync($"http://localhost:5135/api/GANApi/search?{queryString}");

            if (response.IsSuccessStatusCode)
            {
                SearchResults = await response.Content.ReadFromJsonAsync<List<AddressResponse>>();
                if (SearchResults == null || !SearchResults.Any())
                {
                    SearchResults = new List<AddressResponse>();
                    TempData["NoResults"] = "No matching results found.";
                }

                return Page();
            }
            else
            {
                TempData["ErrorMessage"] = "An error occurred while processing your request. Please try again later.";
                return Page();
            }
        }
    }
}
