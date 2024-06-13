using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WS.Context;
using WS.Models;

namespace WS.Controllers
{
    public class PesquisaController : Controller
    {
        private readonly AppDbContext _context;

        public PesquisaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Pesquisa
        public async Task<IActionResult> Index()
        {
              return View(await _context.pesquisa.ToListAsync());
        }

        // GET: Pesquisa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.pesquisa == null)
            {
                return NotFound();
            }

            var pesquisa = await _context.pesquisa
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pesquisa == null)
            {
                return NotFound();
            }

            return View(pesquisa);
        }

        // GET: Pesquisa/Create
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Teste()
        {
            
            return View();
        }

        // POST: Pesquisa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Pergunta1,Pergunta2,Pergunta3,Resultado")] Pesquisa pesquisa)
        {
            if (ModelState.IsValid)
            {
                
                int soma = pesquisa.Pergunta1 + pesquisa.Pergunta2 + pesquisa.Pergunta3;
                double resultado = (((Convert.ToDouble(soma) / 3) - 1) / 9) * 100;
                pesquisa.Resultado = resultado; 
                _context.Add(pesquisa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pesquisa);
        }

        // GET: Pesquisa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.pesquisa == null)
            {
                return NotFound();
            }

            var pesquisa = await _context.pesquisa.FindAsync(id);
            if (pesquisa == null)
            {
                return NotFound();
            }
            return View(pesquisa);
        }

        // POST: Pesquisa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Pergunta1,Pergunta2,Pergunta3,Resultado")] Pesquisa pesquisa)
        {
            if (id != pesquisa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pesquisa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PesquisaExists(pesquisa.Id))
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
            return View(pesquisa);
        }

        // GET: Pesquisa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.pesquisa == null)
            {
                return NotFound();
            }

            var pesquisa = await _context.pesquisa
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pesquisa == null)
            {
                return NotFound();
            }

            return View(pesquisa);
        }

        // POST: Pesquisa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.pesquisa == null)
            {
                return Problem("Entity set 'AppDbContext.pesquisa'  is null.");
            }
            var pesquisa = await _context.pesquisa.FindAsync(id);
            if (pesquisa != null)
            {
                _context.pesquisa.Remove(pesquisa);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PesquisaExists(int id)
        {
          return _context.pesquisa.Any(e => e.Id == id);
        }
    }
}
