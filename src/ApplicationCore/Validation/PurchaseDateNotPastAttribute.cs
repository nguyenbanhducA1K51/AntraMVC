namespace ApplicationCore.Validation;

using System;
using System.ComponentModel.DataAnnotations;

public class PurchaseDateNotPastAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value == null)
        {
            // If no date provided, assume valid or return error based on your requirement
            return ValidationResult.Success;
        }

        if (value is DateTime purchaseDate)
        {
            var today = DateTime.Today;
            if (purchaseDate < today)
            {
                return new ValidationResult("Purchase date cannot be earlier than today.");
            }
            return ValidationResult.Success;
        }

        return new ValidationResult("Invalid date format.");
    }
}