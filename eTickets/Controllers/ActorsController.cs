using eTickets.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {
        private readonly AppDbContext _context;
        public ActorsController(AppDbContext context)
        {
            _context=context;
        }
        public async Task<IActionResult> Index()
        {
            //var data=_context.Actors.ToList();

            return View(await _context.Actors.ToListAsync());
        }
        public ActionResult Delete(int id)
        {
            var actor=_context.Actors.Find(id);
            if (actor == null)
            {
                return NotFound();
            }
            _context.Actors.Remove(actor);
            _context.SaveChanges();
            TempData["DeleteSuccess"] = true;
            return RedirectToAction("Index");
        }
    }
}
