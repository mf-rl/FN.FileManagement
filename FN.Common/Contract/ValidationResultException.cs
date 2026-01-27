using FluentValidation.Results;
using System;

namespace FN.Common.Contract
{
    public class ValidationResultException : Exception
    {
        public ValidationResultException(ValidationResult validationResult)
        {
            ValidationResult = validationResult ?? throw new ArgumentNullException(nameof(validationResult));
        }
        public ValidationResult ValidationResult { get; }
    }
}
