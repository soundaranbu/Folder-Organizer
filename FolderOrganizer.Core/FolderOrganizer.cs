using FolderOrganizer.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;

namespace FolderOrganizer.Core
{
    public class FolderOrganizer
    {
        public string FolderPath { get; set; }

        public DirectoryInfo FolderPathInfo { get; set; }

        public FileInfo[] FilesInfo { get; set; }

        public List<FolderClassification> FolderClassifications { get; set; }


        public FolderOrganizer(string folderPath)
        {
            FolderPath = folderPath;
            if (Directory.Exists(FolderPath))
            {
                FolderPathInfo = new DirectoryInfo(folderPath);

                Initialize();
            }
            else
            {
                throw new FolderNotFoundException(folderPath);
            }
        }

        protected void Initialize()
        {
            FilesInfo = FolderPathInfo.GetFiles();
        }

        public bool Organize()
        {
            return true;
        }
    }
}
