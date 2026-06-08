using GLMS.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLMS_Tests
{
    public class CreateContactTest
    {
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
