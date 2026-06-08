using GLMS.API.Models;
using GLMS.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace GLMS_Tests
{
    public class GetAllClients
    {
        private readonly HttpClient _client;

       
        public GetAllClients()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:8080/");
        }

        [Fact]
        public async Task GetClients_ShouldReturnOk_AndNotEmptyOrNull()
        {
            var response = await _client.GetAsync("api/clients");
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadFromJsonAsync<List<ClientDto>>();

            Assert.NotNull(data);
        }
    }
}
