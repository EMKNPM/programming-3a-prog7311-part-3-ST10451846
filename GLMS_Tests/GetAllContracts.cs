using GLMS.API.Models;
using System;
using System.Collections.Generic;
using System.Net.Http.Json; 
using System.Threading.Tasks;
using Xunit; 

namespace GLMS_Tests
{
    public class GetAllContracts
    {
        private readonly HttpClient _client;

       
        public GetAllContracts()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:8080/");
        }

        [Fact]
        public async Task GetContracts_ShouldReturnOk_AndNotNull()
        {
            var response = await _client.GetAsync("api/contracts");

            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadFromJsonAsync<List<ContractDto>>();

            Assert.NotNull(data);
        }
    }
}