using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileTransform.Domain
{
    public class FileTransformModel
    {
        public string Name { get; set; }
        public int VersionId { get; set; }
        public bool IsFileRevise { get; set; }
    }
}
