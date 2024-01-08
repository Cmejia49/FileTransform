using FileTransform.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileTransform.Core
{
    public class FileTransoformService : IFileTransformService
    {
        public FileTransformModel TransformFile(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return null;
            }

            int indexOfLastDot = fileName.LastIndexOf('.');

            string baseName = indexOfLastDot > 0 ? fileName.Substring(0, indexOfLastDot) : fileName;

            bool isRevision = false;
            int verId = -1; // -1 is equals to null mean no versionID
         
            int indexOfLastUnderscore = baseName.LastIndexOf('_');
            if (indexOfLastUnderscore >= 0 && indexOfLastUnderscore < baseName.Length - 1)
            {
                string idPart = baseName.Substring(indexOfLastUnderscore + 1);
                if (int.TryParse(idPart, out verId))
                {
                    isRevision = true;
                    baseName = baseName.Substring(0, indexOfLastUnderscore);
                }
            }
            
            FileTransformModel newFileTransform = new FileTransformModel
            {
                Name = baseName,
                VersionId = verId,
                IsFileRevise = isRevision
            };

            return newFileTransform;
        }
    }
}
