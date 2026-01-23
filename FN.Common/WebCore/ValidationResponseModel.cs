using FN.Common.Contract;
using FN.Common.Core;
using System.Collections.Generic;

namespace FN.Common.WebCore
{
    public class ValidationResponseModel
    {
        private readonly List<ValidationUploadModel> _failures = new List<ValidationUploadModel>();

        public IEnumerable<ValidationUploadModel> Failures => _failures;

        public void AddFailures(IEnumerable<ValidationUploadModel> failures)
        {
            _failures.AddRange(failures);
        }

        public void AddError(
            string field,
            string validationKey)
        {
            _failures.Add(new ValidationUploadModel
            {
                FailureType = FailureType.Error.ToString().ToCamelCase(),
                Field = field.ToCamelCase(),
                Key = validationKey.ToCamelCase(),
            });
        }
    }
}
