using GLMS.API.Models;
using GLMS.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLMS_Tests
{
    public class GetServiceRequests
    {
        [Fact]
        public async Task GetServiceRequests_ShouldReturnOk()
        {
            var response = await _client.GetAsync("api/servicerequests");

            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadFromJsonAsync<List<ServiceRequestDto>>();

            Assert.NotNull(data);
        }
    }
}
