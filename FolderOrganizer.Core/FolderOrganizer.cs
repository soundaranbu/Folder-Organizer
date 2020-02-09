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

        public FileInfo[] FilesInFolder { get; set; }

        public List<FolderClassification> FolderClassifications { get; set; }

        public List<FolderArrangement> FolderArrangements { get; set; }


        public FolderOrganizer(string folderPath, List<FolderClassification> folderClassifications)
        {
            if (string.IsNullOrEmpty(folderPath))
            {
                throw new ArgumentNullException("folderClassifications");
            }

            if (folderClassifications is null)
            {
                throw new ArgumentNullException("folderClassifications");
            }

            FolderPath = folderPath;
            FolderClassifications = folderClassifications;
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
            FilesInFolder = FolderPathInfo.GetFiles();
        }

        public bool Organize()
        {
            Arrange();

            foreach (var folderArrangement in FolderArrangements)
            {
                if (folderArrangement.HasAnyFilesToOrganize())
                {
                    if (folderArrangement.CreateTargetDirectory(FolderPathInfo))
                    {
                        folderArrangement.MoveFilesToTargetDirectory();
                    }
                }
            }

            FolderArrangements = null;

            return true;
        }

        protected void Arrange()
        {
            if (FolderArrangements is null)
            {
                FolderArrangements = new List<FolderArrangement>();
            }

            foreach (var folderClassification in FolderClassifications)
            {
                var folderArrangement = new FolderArrangement(folderClassification);

                folderArrangement.LoadFiles(FilesInFolder);

                FolderArrangements.Add(folderArrangement);
            }
        }
    }
}
