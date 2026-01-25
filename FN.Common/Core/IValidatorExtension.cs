using FluentValidation.Results;
using FluentValidation;
using FN.Common.Contract;

namespace FN.Common.Core
{
    public static class IValidatorExtension
    {
        public static ValidationResult ValidateCustom<TModel>(this IValidator<TModel> validator, TModel model)
        {
            if (validator == null)
                throw new System.ArgumentNullException(nameof(validator));

            var validationResult = validator.Validate(model);
            if (validationResult.HasErrors())
                throw new ValidationResultException(validationResult);

            return validationResult;
        }
    }
}
