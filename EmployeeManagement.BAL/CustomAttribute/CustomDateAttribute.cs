using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.BAL.CustomAttribute;

public class CustomDateAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value != null)
        {
            DateTime joinDate;
            bool isValidDate = DateTime.TryParse(value.ToString(), out joinDate);

            if (isValidDate)
            {
                if (joinDate > DateTime.Now)
                {
                    return new ValidationResult("Join date cannot be in the future.");
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
            else
            {
                return new ValidationResult("Invalid date format.");
            }
        }
        return new ValidationResult("Join date is required.");
    }
}
