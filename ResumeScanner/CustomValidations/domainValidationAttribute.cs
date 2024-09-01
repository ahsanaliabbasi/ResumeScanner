using System.ComponentModel.DataAnnotations;

namespace ResumeScanner.CustomValidations
{
    public class domainValidationAttribute : ValidationAttribute
    {

        public readonly string[] _allowedDomainNames;
        public domainValidationAttribute(params string[] allowedDomainNames)
        {
            _allowedDomainNames = allowedDomainNames;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null) { 
                
                if(_allowedDomainNames.Contains(value.ToString())) {
                    return ValidationResult.Success;
                }
                return new ValidationResult($"{value.ToString()} is not allowed!");
            }
            return null;
            

        }
    }
}
