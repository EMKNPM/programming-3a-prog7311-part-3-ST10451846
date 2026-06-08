using GLMS.Models;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Headers;
using GLMS.Shared.DTOs;

namespace GLMS.Services
{
    public class ApiService
    {
        private readonly HttpClient _http;

        public ApiService(HttpClient http)
        {
            _http = http;
        }

        // CLIENTS
     

        public async Task<List<ClientDto>> GetClients()
        {
            var response = await _http.GetAsync("api/clients");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ClientDto>>(json) ?? new List<ClientDto>();
        }

        public async Task<ClientDto> GetClient(int id)
        {
            var response = await _http.GetAsync($"api/clients/{id}");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ClientDto>(json) ?? new ClientDto();
        }

        public async Task CreateClient(ClientDto client)
        {
            var json = JsonConvert.SerializeObject(client);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _http.PostAsync("api/clients", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateClient(int id, ClientDto client)
        {
            var json = JsonConvert.SerializeObject(client);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _http.PutAsync($"api/clients/{id}", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteClient(int id)
        {
            var response = await _http.DeleteAsync($"api/clients/{id}");
            response.EnsureSuccessStatusCode();
        }

       
        // CONTRACTS
     

        public async Task<List<ContractDto>> GetContracts()
        {
            var response = await _http.GetAsync("api/contracts");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ContractDto>>(json) ?? new List<ContractDto>();
        }

        public async Task<ContractDto> GetContract(int id)
        {
            var response = await _http.GetAsync($"api/contracts/{id}");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ContractDto>(json) ?? new ContractDto();
        }


        // FIXED FILE UPLOAD (IMPORTANT)
      

        public async Task CreateContractWithFile(ContractDto model)
        {
            using var content = new MultipartFormDataContent();

            content.Add(new StringContent(model.ClientId.ToString()), "ClientId");
            content.Add(new StringContent(model.Status ?? ""), "Status");
            content.Add(new StringContent(model.ServiceLevel ?? ""), "ServiceLevel");
            content.Add(new StringContent(model.StartDate.ToString("o")), "StartDate");
            content.Add(new StringContent(model.EndDate.ToString("o")), "EndDate");

            
            if (model.File != null && model.File.Length > 0)
            {
                using var stream = model.File.OpenReadStream();

                var fileContent = new StreamContent(stream);
                fileContent.Headers.ContentType =
                    new MediaTypeHeaderValue(model.File.ContentType);

                content.Add(fileContent, "file", model.File.FileName);
            }

            var response = await _http.PostAsync("api/contracts", content);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"API ERROR: {error}");
            }
        }

        public async Task UpdateContract(int id, ContractDto contract)
        {
            var json = JsonConvert.SerializeObject(contract);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _http.PutAsync($"api/contracts/{id}", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteContract(int id)
        {
            var response = await _http.DeleteAsync($"api/contracts/{id}");
            response.EnsureSuccessStatusCode();
        }

       
        // SERVICE REQUESTS
       

        public async Task<List<ServiceRequestDto>> GetServiceRequests()
        {
            var response = await _http.GetAsync("api/servicerequests");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ServiceRequestDto>>(json) ?? new List<ServiceRequestDto>();
        }

        public async Task<ServiceRequestDto> GetServiceRequest(int id)
        {
            var json = await _http.GetStringAsync($"api/servicerequests/{id}");
            return JsonConvert.DeserializeObject<ServiceRequestDto>(json) ?? new ServiceRequestDto();
        }

        public async Task CreateServiceRequest(ServiceRequestDto model)
        {
            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _http.PostAsync("api/servicerequests", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateServiceRequest(int id, ServiceRequestDto model)
        {
            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _http.PutAsync($"api/servicerequests/{id}", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteServiceRequest(int id)
        {
            var response = await _http.DeleteAsync($"api/servicerequests/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}