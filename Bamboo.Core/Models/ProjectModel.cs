using System;
using System.Collections.Generic;
using System.Text;
using Bamboo.Core.Models.File;
using Bamboo.Core.Validators;
using FluentValidation.Attributes;
using Microsoft.AspNetCore.Http;

namespace Bamboo.Core.Models
{
    [Validator(typeof(ProjectModelValidator.CreateProjectModelValidator))]
    public class CreateProjectModel
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

        public FileBase64Model File { get; set; }

        public int ProjectCategoryId { get; set; }
    }


    [Validator(typeof(ProjectModelValidator.EditProjectModelValidator))]
    public class EditProjectModel : CreateProjectModel
    {
        public int Id { get; set; }

        public string ProjectCategoryName { get; set; }
    }
}
