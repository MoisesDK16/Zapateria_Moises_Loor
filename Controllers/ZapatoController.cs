using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Zapateria.Data;
using Zapateria.Models;

namespace Zapateria.Controllers
{
    public class ZapatoController : Controller
    {

        private readonly ZapateriaDbContext _context;
        private readonly ILogger<ZapatoController> _logger;

        public ZapatoController(ZapateriaDbContext context, ILogger<ZapatoController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: ZapatoController
        public IActionResult Index()
        {
            var zapatos = _context.Zapatos
                .Include(z => z.Tipo) // Esto asegura que Tipo no sea NULL
                .ToList();

            return View(zapatos);
        }


        // GET: ZapatoController/Create
        public async Task<IActionResult> Create()
        {
            ViewData["TipoId"] = new SelectList(await _context.Tipos.ToListAsync(), "Id", "Nombre");
            return View();
        }


        // POST: ZapatoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Marca,Modelo,Color,TipoId")] Zapato zapato)
        {
            _logger.LogInformation("Entering Create POST method");

            if (zapato.TipoId == 0) 
            {
                ModelState.AddModelError("TipoId", "Debe seleccionar un tipo válido.");
            }

            if (ModelState.IsValid)
            {
                _context.Add(zapato);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Zapato guardado correctamente.");
                return RedirectToAction(nameof(Index));
            }

            _logger.LogWarning("Model state is invalid");
            foreach (var modelState in ModelState.Values)
            {
                foreach (var error in modelState.Errors)
                {
                    _logger.LogError(error.ErrorMessage);
                }
            }

            ViewData["TipoId"] = new SelectList(await _context.Tipos.ToListAsync(), "Id", "Nombre", zapato.TipoId);
            return View(zapato);
        }

        // GET: ZapatoController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var clientModel = await _context.Zapatos
                .Include(z => z.Tipo)
                .FirstOrDefaultAsync(z => z.Id == id);

            ViewData["TipoId"] = new SelectList(await _context.Tipos.ToListAsync(), "Id", "Nombre");

            return View(clientModel);
        }

        // POST: ZapatoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Marca,Modelo,Color,TipoId")] Zapato zapato)
        {
            if (ModelState.IsValid)
            {
                 var zapatoToUpdate = _context.Zapatos.Find(id);
                 if (zapatoToUpdate == null) return NotFound();
                 zapatoToUpdate.Marca = zapato.Marca;
                 zapatoToUpdate.Modelo = zapato.Modelo;
                 zapatoToUpdate.Color = zapato.Color;
                 zapatoToUpdate.TipoId = zapato.TipoId;
                 _context.Update(zapatoToUpdate);
                 await _context.SaveChangesAsync();
                 return RedirectToAction(nameof(Index));
            }
            else {
                _logger.LogWarning("Model state is invalid");
                ViewData["TipoId"] = new SelectList(await _context.Tipos.ToListAsync(), "Id", "Nombre", zapato.TipoId);
                throw new Exception("Model state is invalid");
            }
        }

        // GET: ZapatoController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var clientModel = await _context.Zapatos
                .FirstOrDefaultAsync(z => z.Id == id);

            if (clientModel == null) return NotFound();

            return View(clientModel);
        }

        // POST: ZapatoController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var zapato = _context.Zapatos.Find(id);
            if(zapato == null) return NotFound();
            _context.Zapatos.Remove(zapato);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: ZapatoController/Details/5
        public ActionResult Details(int id)
        {
            var zaptatosFound = _context.Zapatos.Include(z => z.Tipo).FirstOrDefault(z => z.Id == id);
            if(zaptatosFound == null) return NotFound();
            return View(zaptatosFound);
        }
    }
}
