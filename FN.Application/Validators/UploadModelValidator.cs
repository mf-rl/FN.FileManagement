using FN.Entities;
using FN.Business.Abstractions;
using FN.Common.Core;
using System;

namespace FluentValidation.Application.Validators
{
    public class UploadModelValidator : AbstractValidator<UploadModel>
    {
        public UploadModelValidator(IUploadDataService uploadDataService)
        {
            if (uploadDataService == null)
                throw new ArgumentNullException(nameof(uploadDataService));
            RuleFor(x => x.File).NotNullConfigured();
        }
    }
}
