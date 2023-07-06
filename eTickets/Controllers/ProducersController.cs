using eTickets.Data;
using eTickets.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducersService _service;
        public ProducersController(IProducersService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Delete(int id)
        {         
            await _service.DeleteAsync(id);
            TempData["DeleteSuccess"] = true;
            return RedirectToAction(nameof(Index));
        }

        public async Task <IActionResult> Index()
        {var data=await _service.GetAllAsync();
          
            return View(data);
        }

        public async Task<IActionResult> Details(int id)
        {
            var data = await _service.GetByIdAsync(id);
            return View(data);
        }
    }
}
