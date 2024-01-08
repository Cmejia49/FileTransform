using FileTransform.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FileTransform.Core.UnitTest.Services
{

    public class TransformServiceTest
    {

        [Theory]
        [InlineData("file.pdf", "file", 0, false)]
        [InlineData("file_1.pdf", "file_1", 1, true)]
        [InlineData("file_99.pdf", "file_99", 99, true)]
        public void TransformFile_WithVariousFileNames_ParsesCorrectly(string input, string expectedName, int expectedVersionId, bool expectedIsRevision)
        {

               //Arrange
               var expectedResult = new FileTransformModel()
               {
                  Name = expectedName,
                  VersionId = expectedVersionId,
                  IsFileRevise = expectedIsRevision
               };

            var _mocFileTransformService = new Mock<IFileTransformService>();
            _mocFileTransformService.Setup(x => x.TransformFile(It.IsAny<string>())).Returns(expectedResult);
          
            //Act
            var result =  _mocFileTransformService.Object.TransformFile(input);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedResult.Name, result.Name);
            Assert.Equal(expectedResult.VersionId, result.VersionId);
            Assert.Equal(expectedResult.IsFileRevise, result.IsFileRevise);
        }
    }
}
