using System;
using System.Collections.Generic;
using System.Text;

namespace Bamboo.Core.Entities
{
    public class ProductEntity : BaseEntity
    {
        //  Tên sản phẩm
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

        public virtual ProductCategoryEntity ProductCategory { get; set; }

        public virtual IEnumerable<FileEntity> Files { get; set; }
    }
}
