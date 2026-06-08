
using GLMS.Models;
using GLMS.Services;
using GLMS.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace GLMS.Controllers
{
   
    public class ServiceRequestsController : Controller
    {
        private readonly ApiService _api;

        public ServiceRequestsController(ApiService api)
        {
            _api = api;
        }

        // LIST
        public async Task<IActionResult> Index()
        {
            var requests = await _api.GetServiceRequests();
            return View(requests);
        }

        // DETAILS
        public async Task<IActionResult> Details(int id)
        {
            var request = await _api.GetServiceRequest(id);
            return View(request);
        }

        // CREATE (GET)
        public async Task<IActionResult> Create()
        {
            ViewBag.Contracts = await _api.GetContracts();

            ViewBag.ServiceTypes = new List<string>
        {
            "Maintenance",
            "Installation",
            "Repair",
            "Consultation"
        };

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ServiceRequestDto model)
        {
            await _api.CreateServiceRequest(model);
            return RedirectToAction(nameof(Index));
        }

        // EDIT (GET)
        public async Task<IActionResult> Edit(int id)
        {
            var request = await _api.GetServiceRequest(id);

            ViewBag.Contracts = await _api.GetContracts();

            ViewBag.ServiceTypes = new List<string>
        {
            "Maintenance",
            "Installation",
            "Repair",
            "Consultation"
        };

            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ServiceRequestDto model)
        {
            await _api.UpdateServiceRequest(id, model);
            return RedirectToAction(nameof(Index));
        }

        // DELETE
        public async Task<IActionResult> Delete(int id)
        {
            var request = await _api.GetServiceRequest(id);
            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _api.DeleteServiceRequest(id);
            return RedirectToAction(nameof(Index));
        }
    }
}