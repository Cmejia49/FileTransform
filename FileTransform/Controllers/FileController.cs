using FileTransform.Core;
using Microsoft.AspNetCore.Mvc;

namespace FileTransform.Controllers
{
    [Route("api/File")]
    [ApiController]
    public class FileController : Controller
    {
        private readonly IFileTransformService _fileTransformService;
        public FileController(IFileTransformService fileTransformService)
        {
                _fileTransformService = fileTransformService;   
        }

        [HttpPost]
        public IActionResult Index(string fileName)
        {
            var result = _fileTransformService.TransformFile(fileName);

            return Ok(result);
        }
    }
}
