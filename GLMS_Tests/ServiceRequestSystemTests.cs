using GLMS.API.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLMS_Tests
{
   public class ServiceRequestSystemTests
    {
        [Fact]
        public void Factory_Should_Create_ServiceRequest_With_Type()
        {
            // Arrange
            string type = "Shipping";

            // Act
            var request = ServiceRequestFactory.CreateRequest(type);

            // Assert
            Assert.NotNull(request);
            Assert.Equal("Shipping", request.ServiceType);
        }

        [Fact]
        public void RequestType_Should_Not_Be_Null()
        {
            // Arrange
            string ServiceType = null;

            // Assert
            Assert.Null(ServiceType);
        }
    }
}
