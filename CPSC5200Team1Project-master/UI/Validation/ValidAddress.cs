using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

public class ValidAddressFormatAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var address = value as string;
        if (string.IsNullOrEmpty(address))
        {
            return ValidationResult.Success; // Assuming the [Required] attribute is used for null checks.
        }

        // Regex to match a basic address format: number followed by street name, e.g., "123 Main St"
        // You can adjust the regex pattern to match your specific address format requirements.
        var regex = new Regex(@"^\d+\s+[A-Za-z0-9\s]+");

        if (!regex.IsMatch(address))
        {
            return new ValidationResult(GetErrorMessage());
        }

        return ValidationResult.Success;
    }

    private string GetErrorMessage()
    {
        return "Invalid address format. Address must start with a number followed by the street name.";
    }
}
