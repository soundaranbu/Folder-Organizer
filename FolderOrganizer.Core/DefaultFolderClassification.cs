using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FolderOrganizer.Core
{
    public class DefaultFolderClassification
    {
        public static List<FolderClassification> GetDefaults()
        {
            var classifications = new List<FolderClassification>();

            classifications.Add(CreateClassification("Picures", new string[] { ".jpeg", ".jpg" }));
            classifications.Add(CreateClassification("Documents", new string[] { ".pdf", ".docx", ".doc", ".sql",".xlsx", ".csv", ".json" }));
            classifications.Add(CreateClassification("Softwares", new string[] { ".exe", ".msi" }));
            classifications.Add(CreateClassification("Archives", new string[] { ".zip", ".7z", ".rar" }));

            return classifications;
        }

        protected static FolderClassification CreateClassification(string classificationName, string[] extensions)
        {
            return new FolderClassification
            {
                ClassificationName = classificationName,
                FileExtensions = extensions
            };
        }
    }
}
