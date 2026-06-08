using GLMS.API.Models;
using GLMS.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLMS_Tests
{
    public class GetAllClients
    {
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
