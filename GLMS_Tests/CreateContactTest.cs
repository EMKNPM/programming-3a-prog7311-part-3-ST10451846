using GLMS.API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
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
            var json = JsonConvert.SerializeObject(new
            {
                name = "Test",
                email = "test@test.com",
                phone = "12345"
            });

            var content = new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}

