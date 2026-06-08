using GLMS.API.Models;
using GLMS.Models;

namespace GLMS_Tests
{
    public class UnitTest1
    {
        private HttpClient _client;

        [Fact]
        public void Test1()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://glms-backend-api:8080");
        }
    }
}