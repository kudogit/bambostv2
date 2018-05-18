using Bamboo.Core.Validators;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bamboo.Core.Models
{
    [Validator(typeof(ProjectCategoryModelValidator.CreateProjectCategoryModelValidator))]
    public class CreateProductCategoryModel
    {
        public string Name { get; set; }
    }

    [Validator(typeof(ProjectCategoryModelValidator.EditProjectCategoryModelValidator))]
    public class EditProductCategoryModel : CreateProductCategoryModel
    {
        public int Id { get; set; }
    }

    public class ProductCategoryModel : EditProductCategoryModel
    {

    }
}
