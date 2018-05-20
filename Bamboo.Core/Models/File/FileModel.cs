using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bamboo.Core.Models.File
{
    public class AddFileModel
    {
        public string Name { get; set; }

        public string Url { get; set; }
    }

    public class EditFileModel : AddFileModel
    {
        public int Id { get; set; }
    }

    public class FileModel : EditFileModel { }

    public class FileBase64Model
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
