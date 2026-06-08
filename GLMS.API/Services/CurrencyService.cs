using Newtonsoft.Json;

namespace GLMS.API.Services
{
    public class CurrencyService
    {
        private readonly HttpClient _http;

        public CurrencyService(HttpClient http)
        {
            _http = http;
        }

        public async Task<decimal> GetUsdToZarRate()
        {
            var response = await _http.GetStringAsync(
                "https://api.exchangerate.host/latest?base=USD&symbols=ZAR"
            );

            dynamic data = JsonConvert.DeserializeObject(response);

            return (decimal)data.rates.ZAR;
        }
    }
}
