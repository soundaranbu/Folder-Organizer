using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FolderOrganizer.Core
{
    public class FolderClassification
    {
        public string ClassificationName { get; set; }
        public string[] FileExtensions { get; set; }

        public string SubFolderName { get; set; }

        public string GetSubFolderName()
        {
            if (String.IsNullOrEmpty(SubFolderName))
            {
                return ClassificationName;
            }

            return SubFolderName;
        }
    }
}
