using System.ComponentModel.DataAnnotations;
using System.Linq;

public class ValidCountryAttribute : ValidationAttribute
{
    private readonly string[] _allowedCountries = new string[]
    {
        "Brazil", "Canada", "Germany", "India", "Japan",
        "North and South Korea", "Mexico", "Spain", "UK", "USA"
    };

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is string country && _allowedCountries.Contains(country))
        {
            return ValidationResult.Success;
        }

        return new ValidationResult(GetErrorMessage());
    }

    private string GetErrorMessage()
    {
        return $"Country is not supported. Supported countries are: {string.Join(", ", _allowedCountries)}.";
    }
}
