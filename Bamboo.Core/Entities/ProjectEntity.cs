using System;
using System.Collections.Generic;
using System.Text;

namespace Bamboo.Core.Entities
{
    /// <summary>
    ///     Dự án thi công
    /// </summary>
    public class ProjectEntity : BaseEntity
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

        public int ProjectCategoryId { get; set; }

        public virtual ProjectCategoryEntity ProjectCategory { get; set; }

        public virtual ICollection<FileEntity> Files { get; set; }
    }
}
