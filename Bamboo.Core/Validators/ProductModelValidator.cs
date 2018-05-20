using Bamboo.Core.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bamboo.Core.Validators
{
    public class ProductModelValidator
    {
        public class CreateProductModelValidator : AbstractValidator<CreateProductModel>
        {
            public CreateProductModelValidator()
            {
                RuleFor(x => x.Title).NotEmpty();
                RuleFor(x => x.Investor).NotEmpty();
                RuleFor(x => x.Efficiency).NotEmpty();
                RuleFor(x => x.Standard).NotEmpty();
                RuleFor(x => x.Progress).NotEmpty();
                RuleFor(x => x.ProductCategoryId).NotNull();
            }
        }

        public class EditProductModelValidator : AbstractValidator<EditProductModel>
        {
            public EditProductModelValidator()
            {
                RuleFor(x => x.Title).NotEmpty();
                RuleFor(x => x.Investor).NotEmpty();
                RuleFor(x => x.Efficiency).NotEmpty();
                RuleFor(x => x.Standard).NotEmpty();
                RuleFor(x => x.Progress).NotEmpty();
                RuleFor(x => x.ProductCategoryId).NotNull();
            }
        }
    }
}
