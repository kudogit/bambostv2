using System;
using System.Collections.Generic;
using System.Text;
using Bamboo.Core.Models;
using FluentValidation;

namespace Bamboo.Core.Validators
{
    public class ProjectModelValidator
    {
        public class CreateProjectModelValidator : AbstractValidator<CreateProjectModel>
        {
            public CreateProjectModelValidator()
            {
                RuleFor(x => x.Title).NotEmpty();
                RuleFor(x => x.Investor).NotEmpty();
                RuleFor(x => x.Efficiency).NotEmpty();
                RuleFor(x => x.Standard).NotEmpty();
                RuleFor(x => x.Progress).NotEmpty();
                RuleFor(x => x.ProjectCategoryId).NotNull();
            }
        }

        public class EditProjectModelValidator : AbstractValidator<EditProjectModel>
        {
            public EditProjectModelValidator()
            {
                RuleFor(x => x.Title).NotEmpty();
                RuleFor(x => x.Investor).NotEmpty();
                RuleFor(x => x.Efficiency).NotEmpty();
                RuleFor(x => x.Standard).NotEmpty();
                RuleFor(x => x.Progress).NotEmpty();
                RuleFor(x => x.ProjectCategoryId).NotNull();
            }
        }
    }
}
