using System;
using System.Collections.Generic;
using System.Text;
using Bamboo.Core.Models;
using FluentValidation;

namespace Bamboo.Core.Validators
{
    public class ProjectCategoryModelValidator
    {
        public class CreateProjectCategoryModelValidator : AbstractValidator<CreateProjectCategoryModel>
        {
            public CreateProjectCategoryModelValidator()
            {
                RuleFor(x => x.Name).NotEmpty();
            }
        }

        public class EditProjectCategoryModelValidator : AbstractValidator<EditProjectCategoryModel>
        {
            public EditProjectCategoryModelValidator()
            {
                RuleFor(x => x.Name).NotEmpty();
            }
        }
    }
}
