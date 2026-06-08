using GLMS.API.Models;
using GLMS.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit; 

namespace GLMS_Tests
{
    public class GetServiceRequests
    {
        private readonly HttpClient _client;

      
        public GetServiceRequests()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:8080/");
        }

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
