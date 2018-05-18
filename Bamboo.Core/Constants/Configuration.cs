using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bamboo.Core.Constants
{
    public static class Configuration
    {
        public enum KeyGroup
        {
            [Display(Name = "GeneralInfo", Description = "<p>Tổng quát về công ty Bamboo:</p><ol><li>Chủ tịch: Nguyễn Trọng Chuẩn</li><li>Lao công: Lê Minh Khôi</li><li>Bảo vệ: Nguyễn Quốc Hoàng</li></ol>")]
            GeneralInfo,

            [Display(Name = "Email", Description = "Template of email")]
            Email,
        }
    }
}
