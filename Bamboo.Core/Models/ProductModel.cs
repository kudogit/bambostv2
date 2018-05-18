using Bamboo.Core.Validators;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bamboo.Core.Models
{
    [Validator(typeof(ProjectModelValidator.CreateProjectModelValidator))]
    public class CreateProductModel
    {
        //  Tên dự án
        public string Title { get; set; }

        //  Chủ đầu tư
        public string Investor { get; set; }

        //  Hiệu suất, công suất thiết kế
        public string Efficiency { get; set; }

        //  Tiêu chuẩn xả thải
        public string Standard { get; set; }

        // Tiến độ
        public string Progress { get; set; }

        // Miêu tả
        public string Description { get; set; }

        public int ProductCategoryId { get; set; }
    }


    [Validator(typeof(ProjectModelValidator.EditProjectModelValidator))]
    public class EditProductModel : CreateProductModel
    {
        public int Id { get; set; }
    }
}
