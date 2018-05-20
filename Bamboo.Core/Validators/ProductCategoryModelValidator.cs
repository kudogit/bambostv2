using Bamboo.Core.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bamboo.Core.Validators
{
    public class ProductCategoryModelValidator
    {
        public class CreateProductCategoryModelValidator : AbstractValidator<CreateProductCategoryModel>
        {
            public CreateProductCategoryModelValidator()
            {
                RuleFor(x => x.Name).NotEmpty();
            }
        }

        public class EditProductCategoryModelValidator : AbstractValidator<EditProductCategoryModel>
        {
            public EditProductCategoryModelValidator()
            {
                RuleFor(x => x.Name).NotEmpty();
            }
        }
    }
}
