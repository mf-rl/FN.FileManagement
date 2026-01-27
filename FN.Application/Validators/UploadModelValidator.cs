using FN.Entities;
using FN.Business.Abstractions;
using FN.Common.Core;
using System;
using FluentValidation;

namespace FN.Application.Validators
{
    public class UploadModelValidator : AbstractValidator<UploadModel>
    {
        public UploadModelValidator(IUploadDataService uploadDataService)
        {
            ArgumentNullException.ThrowIfNull(uploadDataService);

            RuleFor(x => x.File).NotNullConfigured();
        }
    }
}
