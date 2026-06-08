using GLMS.API.Models;
using System;
using System.Collections.Generic;
using System.Net.Http.Json; 
using Xunit; 

namespace GLMS_Tests
{
    public class CreateContactTest
    {
        private readonly HttpClient _client;

        
        public CreateContactTest()
        {
            _client = new HttpClient();
           
            _client.BaseAddress = new Uri("http://localhost:8080/");
        }

        [Fact]
        public async Task CreateContract_ShouldReturnSuccess()
        {
            var newContract = new ContractDto
            {
                ClientId = 1,
                Status = "Active",
                ServiceLevel = "Basic",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddMonths(1)
            };

            var response = await _client.PostAsJsonAsync("api/contracts", newContract);

            response.EnsureSuccessStatusCode();
        }
    }
}

