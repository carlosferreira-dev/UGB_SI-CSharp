using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RelacionamentoHeranca.Data;
using RelacionamentoHeranca.Migrations;
using RelacionamentoHeranca.Models;
using System.Linq;

public class NaoPerecivelController : Controller
{
    private readonly EstoqueContext _context;

    public NaoPerecivelController(EstoqueContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Index()
    {
        return View(await _context.NaoPereciveis.OrderBy(i => i.Nome).ToListAsync());
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create([Bind("Nome", "Valor", "Quantidade", "Cor", "Tamanho", "Material")] NaoPerecivel naoperecivel)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _context.Add(naoperecivel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
        }
        catch (DbUpdateException)
        {
            ModelState.AddModelError("", "Não foi possível cadastrar ");
        }
        return View(naoperecivel);
    }

    public async Task<ActionResult> Edit(long id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var naoperecivel = await _context.NaoPereciveis.SingleOrDefaultAsync(i => i.ProdutoID == id);
        if (naoperecivel == null)
        {
            return NotFound();
        }
        return View(naoperecivel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(long? id, [Bind("ProdutoID", "Nome", "Valor", "Quantidade", "Cor", "Tamanho", "Material")] NaoPerecivel naoperecivel)
    {
        if (id != naoperecivel.ProdutoID)
        {
            return NotFound();
        }
        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(naoperecivel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (!NaoPerecivelExists(naoperecivel.ProdutoID))
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
        return View(naoperecivel);
    }

    private bool NaoPerecivelExists(long? produtoID)
    {
        var naoperecivel = _context.NaoPereciveis.FirstOrDefault(i => i.ProdutoID == produtoID);
        if (naoperecivel == null)
            return false;
        return true;
    }
    public async Task<ActionResult> Details(long id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var naoperecivel = await _context.NaoPereciveis.SingleOrDefaultAsync(i => i.ProdutoID == id);
        if (naoperecivel == null)
        {
            return NotFound();
        }
        return View(naoperecivel);
    }
    public async Task<IActionResult> Delete(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var naoperecivel = await _context.NaoPereciveis.SingleOrDefaultAsync(i => i.ProdutoID == id);
        if (naoperecivel == null)
        {
            return NotFound();
        }
        return View(naoperecivel);
    }
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long? id)
    {
        var naoperecivel = await _context.NaoPereciveis.SingleOrDefaultAsync(i => i.ProdutoID == id);
        _context.Produtos.Remove(naoperecivel);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }


}