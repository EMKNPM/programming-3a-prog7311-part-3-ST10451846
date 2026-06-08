using GLMS.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLMS_Tests
{
    public class GetAllContracts
    {
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
