using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FolderOrganizer.Core
{
    public class FolderClassification
    {
        public string ClassificationName { get; set; }
        public List<string> FileExtensions { get; set; }

        public string SubFolderName { get; set; }
    }
}
