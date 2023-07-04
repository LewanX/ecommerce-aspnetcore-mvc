using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _service;
        public ActorsController(IActorsService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            if (TempData.ContainsKey("CreateSuccess") )
            {
                ViewBag.CreateSuccess = true;
                TempData.Remove("CreateSuccess");

           
            }
            if ( TempData.ContainsKey("EditSuccess"))
            {
             

                ViewBag.EditSuccess = true;
                TempData.Remove("EditSuccess");
            }
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
        public async Task<IActionResult> Delete(int id)
        {
            /*if (!ModelState.IsValid)
             {
                 var errors = ModelState.Values.SelectMany(v => v.Errors);
                 // Puedes registrar o imprimir los errores para ver los detalles
                 foreach (var error in errors)
                 {
                     Console.WriteLine(error.ErrorMessage);
                 }
                 return View(actor);
             }*/
            await _service.DeleteAsync(id);
            TempData["DeleteSuccess"] = true;
            return RedirectToAction(nameof(Index));
        }



        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")]Actor actor)
        {
           /*if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                // Puedes registrar o imprimir los errores para ver los detalles
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                return View(actor);
            }*/
            await _service.AddAsync(actor);
            TempData["CreateSuccess"] = true;
            return RedirectToAction(nameof(Index));
        }
        //GET
    public async Task<IActionResult> Details(int id)
        {
            var actorDetails=  await _service.GetByIdAsync(id);
            if(actorDetails == null) {
                return View("Empty");

            }
            return View(actorDetails);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null)
            {
                return View("Not Found");

            }
            return View(actorDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("Id,FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            /*if (!ModelState.IsValid)
             {
                 var errors = ModelState.Values.SelectMany(v => v.Errors);
                 // Puedes registrar o imprimir los errores para ver los detalles
                 foreach (var error in errors)
                 {
                     Console.WriteLine(error.ErrorMessage);
                 }
                 return View(actor);
             }*/
            await _service.UpdateAsync(id,actor);
            TempData["EditSuccess"] = true;
            return RedirectToAction(nameof(Index));
        }


    }
}
