using System.ComponentModel.DataAnnotations;

namespace ResumeScanner.CustomValidations
{
    public class DepartmentValidationAttribute : ValidationAttribute
    {
        // Here we added constructor to initilize the _allowedDepartments with values of our choice.
        public readonly string[] _allowedDepartments;    
        public DepartmentValidationAttribute(string[] allowedDepartments)
        {
            _allowedDepartments = allowedDepartments;
        }


        // Value here will be the values that we restrict user to enter in their departments
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value != null)  {
                if (_allowedDepartments.Contains(value.ToString()))
                {
                    return ValidationResult.Success;
                }
                return new ValidationResult($"A user can only have departments:{string.Join(",", _allowedDepartments)} ");

            }
            return null;

        }

    }
}
