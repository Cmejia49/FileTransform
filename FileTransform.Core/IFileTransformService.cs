using FileTransform.Domain;

namespace FileTransform.Core
{
    public interface IFileTransformService
    {
        FileTransformModel TransformFile(string fileName);
    }
}
