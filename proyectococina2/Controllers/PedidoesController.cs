using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using proyectococina2.Models;

namespace proyectococina2.Controllers
{
    public class PedidoesController : Controller
    {
        private readonly cocinadbContext _context;

        public PedidoesController(cocinadbContext context)
        {
            _context = context;
        }

        // GET: Pedidoes
        public async Task<IActionResult> Index()
        {
              return _context.pedido != null ? 
                          View(await _context.pedido.ToListAsync()) :
                          Problem("Entity set 'cocinadbContext.pedido'  is null.");
        }

        // GET: Pedidoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.pedido == null)
            {
                return NotFound();
            }

            var pedido = await _context.pedido
                .FirstOrDefaultAsync(m => m.Id_pedido == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // GET: Pedidoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pedidoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_pedido,Nombre_platillo,fecha,Tipo_de_orden,nombre_del_cliente,Numero_mesa,cantidad,comentarios,estado,Total")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pedido);
        }

        // GET: Pedidoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.pedido == null)
            {
                return NotFound();
            }

            var pedido = await _context.pedido.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }
            return View(pedido);
        }

        // POST: Pedidoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_pedido,Nombre_platillo,fecha,Tipo_de_orden,nombre_del_cliente,Numero_mesa,cantidad,comentarios,estado,Total")] Pedido pedido)
        {
            if (id != pedido.Id_pedido)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoExists(pedido.Id_pedido))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pedido);
        }

        // GET: Pedidoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.pedido == null)
            {
                return NotFound();
            }

            var pedido = await _context.pedido
                .FirstOrDefaultAsync(m => m.Id_pedido == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // POST: Pedidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.pedido == null)
            {
                return Problem("Entity set 'cocinadbContext.pedido'  is null.");
            }
            var pedido = await _context.pedido.FindAsync(id);
            if (pedido != null)
            {
                _context.pedido.Remove(pedido);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoExists(int id)
        {
          return (_context.pedido?.Any(e => e.Id_pedido == id)).GetValueOrDefault();
        }
    }
}
