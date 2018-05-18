using System;
using System.Collections.Generic;
using System.Text;
using Bamboo.Core.Validators;
using FluentValidation.Attributes;

namespace Bamboo.Core.Models
{
    [Validator(typeof(ProjectCategoryModelValidator.CreateProjectCategoryModelValidator))]
    public class CreateProjectCategoryModel
    {
        public string Name { get; set; }
    }

    [Validator(typeof(ProjectCategoryModelValidator.EditProjectCategoryModelValidator))]
    public class EditProjectCategoryModel : CreateProjectCategoryModel
    {
        public int Id { get; set; }
    }

    public class ProjectCategoryModel : EditProjectCategoryModel
    {

    }
}
