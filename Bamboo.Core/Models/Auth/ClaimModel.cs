using Bamboo.Core.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bamboo.Core.Models.Auth
{
    public class ClaimModel
    {
        public bool IsSelected { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
    }
}
