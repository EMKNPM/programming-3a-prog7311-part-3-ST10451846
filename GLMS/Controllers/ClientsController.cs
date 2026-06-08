
using GLMS.Models;
using GLMS.Services;
using GLMS.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;


namespace GLMS.Controllers
{

    
    public class ClientsController : Controller
    {
        private readonly ApiService _api;

        public ClientsController(ApiService api)
        {
            _api = api;
        }

        // LIST
        public async Task<IActionResult> Index()
        {
            var clients = await _api.GetClients();
            return View(clients);
        }

        // DETAILS
        public async Task<IActionResult> Details(int id)
        {
            var client = await _api.GetClient(id);
            return View(client);
        }

        // CREATE (GET)
        public IActionResult Create()
        {
            return View();
        }

        // CREATE (POST)
        [HttpPost]
        public async Task<IActionResult> Create(ClientDto client)
        {
            await _api.CreateClient(client);
            return RedirectToAction("Index");
        }

        // EDIT (GET)
        public async Task<IActionResult> Edit(int id)
        {
            var client = await _api.GetClient(id);
            return View(client);
        }

        // EDIT (POST)
        [HttpPost]
        public async Task<IActionResult> Edit(int id, ClientDto client)
        {
            await _api.UpdateClient(id, client);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = await _api.GetClient(id);
            return View(client);
        }

        [HttpPost]
public async Task<IActionResult> DeleteConfirmed(int id)
{
    await _api.DeleteClient(id);
    return RedirectToAction("Index");
}
    }
}
