using GLMS.Models;
using GLMS.Services;
using GLMS.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace GLMS.Controllers
{
    public class ContractsController : Controller
    {
        private readonly ApiService _api;

        public ContractsController(ApiService api)
        {
            _api = api;
        }

        // =========================
        // LIST
        // =========================
        public async Task<IActionResult> Index()
        {
            var contracts = await _api.GetContracts();
            return View(contracts);
        }

        // =========================
        // DETAILS
        // =========================
        public async Task<IActionResult> Details(int id)
        {
            var contract = await _api.GetContract(id);
            return View(contract);
        }

        // =========================
        // CREATE (GET)
        // =========================
        public async Task<IActionResult> Create()
        {
            ViewBag.Clients = await SafeGetClients();
            ViewBag.StatusList = GetStatusList();
            ViewBag.ServiceLevels = GetServiceLevels();

            return View();
        }

        // =========================
        // CREATE (POST)
        // =========================
        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> Create(ContractDto model, IFormFile file)
        {
            try
            {
                model.File = file; // attach file into DTO

                await _api.CreateContractWithFile(model);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

                ViewBag.Clients = await SafeGetClients();
                ViewBag.StatusList = GetStatusList();
                ViewBag.ServiceLevels = GetServiceLevels();

                return View(model);
            }
        }

        // =========================
        // EDIT (GET)
        // =========================
        public async Task<IActionResult> Edit(int id)
        {
            var contract = await _api.GetContract(id);

            ViewBag.Clients = await SafeGetClients();
            ViewBag.StatusList = GetStatusList();
            ViewBag.ServiceLevels = GetServiceLevels();

            return View(contract);
        }

        // =========================
        // EDIT (POST)
        // =========================
        [HttpPost]
        public async Task<IActionResult> Edit(int id, ContractDto model)
        {
            await _api.UpdateContract(id, model);
            return RedirectToAction("Index");
        }

        // =========================
        // DELETE
        // =========================
        public async Task<IActionResult> Delete(int id)
        {
            var contract = await _api.GetContract(id);
            return View(contract);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _api.DeleteContract(id);
            return RedirectToAction("Index");
        }

        // =========================
        // HELPERS
        // =========================
        private async Task<List<ClientDto>> SafeGetClients()
        {
            try
            {
                return await _api.GetClients();
            }
            catch
            {
                return new List<ClientDto>();
            }
        }

        private List<string> GetStatusList() => new()
        {
            "Draft",
            "Active",
            "On Hold",
            "Expired"
        };

        private List<string> GetServiceLevels() => new()
        {
            "Basic",
            "Standard",
            "Premium"
        };
    }
}