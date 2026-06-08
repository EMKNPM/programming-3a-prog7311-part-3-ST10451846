using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLMS_Tests
{
    public class FileValidationTests
    {
        [Fact]
        public void Should_Reject_NonPdf_Files()
        {
            // Arrange
            string fileName1 = "contract.pdf";
            string fileName2 = "virus.exe";

            // Act
            bool isPdf1 = fileName1.EndsWith(".pdf");
            bool isPdf2 = fileName2.EndsWith(".pdf");

            // Assert
            Assert.True(isPdf1);
            Assert.False(isPdf2);
        }
    }
}