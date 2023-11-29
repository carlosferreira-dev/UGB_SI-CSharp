using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RelacionamentoHeranca.Data;
using RelacionamentoHeranca.Migrations;
using RelacionamentoHeranca.Models;
using System.Linq;

public class PerecivelController : Controller
{
    private readonly EstoqueContext _context;

    public PerecivelController(EstoqueContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Index()
    {
        return View(await _context.Pereciveis.OrderBy(i => i.Nome).ToListAsync());
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create([Bind("Nome", "Valor", "Quantidade", "DataValidade", "Sabor", "Peso")] Perecivel perecivel)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _context.Add(perecivel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
        }
        catch (DbUpdateException)
        {
            ModelState.AddModelError("", "Não foi possível cadastrar ");
        }
        return View(perecivel);
    }

    public async Task<ActionResult> Edit(long id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var perecivel = await _context.Pereciveis.SingleOrDefaultAsync(i => i.ProdutoID == id);
        if (perecivel == null)
        {
            return NotFound();
        }
        return View(perecivel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(long? id, [Bind("ProdutoID", "Nome", "Valor", "Quantidade", "DataValidade", "Sabor", "Peso")] Perecivel perecivel)
    {
        if (id != perecivel.ProdutoID)
        {
            return NotFound();
        }
        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(perecivel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (!PerecivelExists(perecivel.ProdutoID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction("Index");
        }
        return View(perecivel);
    }

    private bool PerecivelExists(long? produtoID)
    {
        var perecivel = _context.Pereciveis.FirstOrDefault(i => i.ProdutoID == produtoID);
        if (perecivel == null)
            return false;
        return true;
    }
    public async Task<ActionResult> Details(long id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var perecivel = await _context.Pereciveis.SingleOrDefaultAsync(i => i.ProdutoID == id);
        if (perecivel == null)
        {
            return NotFound();
        }
        return View(perecivel);
    }
    public async Task<IActionResult> Delete(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var perecivel = await _context.Pereciveis.SingleOrDefaultAsync(i => i.ProdutoID == id);
        if (perecivel == null)
        {
            return NotFound();
        }
        return View(perecivel);
    }
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long? id)
    {
        var perecivel = await _context.Pereciveis.SingleOrDefaultAsync(i => i.ProdutoID == id);
        _context.Produtos.Remove(perecivel);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }


}