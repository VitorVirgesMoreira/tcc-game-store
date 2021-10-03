using System.Collections.Generic;
using TCC.GameStore.Domain.Exceptions;

namespace TCC.GameStore.Domain.Validations.ServiceValidation
{
    public static class ValidationResult
    {
        public static void HandleValidationResult(this FluentValidation.Results.ValidationResult result)
        {
            if (!result.IsValid)
            {
                var validationExceptionList = new HashSet<CustomValidationException>();
                foreach (var validationError in result.Errors)
                {
                    validationExceptionList.Add(new CustomValidationException(validationError.ErrorMessage));
                }
                throw new CustomValidationException(validationExceptionList);
            }
        }
    }
}
