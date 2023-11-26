using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RelacionamentoHeranca.Data;
using RelacionamentoHeranca.Models;
using System.Linq;

public class ProdutoController : Controller
{
    private readonly EstoqueContext _context;

    public ProdutoController(EstoqueContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Index()
    {
        return View(await _context.Produtos.OrderBy(i => i.Nome).ToListAsync());
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create([Bind("Nome", "Valor", "Quantidade")] Produto produto)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _context.Add(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
        }
        catch (DbUpdateException)
        {
            ModelState.AddModelError("", "Não foi possível cadastrar ");
        }
        return View(produto);
    }

    public async Task<ActionResult> Edit(long id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var produto = await _context.Produtos.SingleOrDefaultAsync(i => i.ProdutoID == id);
        if (produto == null)
        {
            return NotFound();
        }
        return View(produto);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(long? id, [Bind("ProdutoID", "Nome", "Valor", "Quantidade")] Produto produto)
    {
        if (id != produto.ProdutoID)
        {
            return NotFound();
        }
        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(produto);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (!ProdutoExists(produto.ProdutoID))
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
        return View(produto);
    }

    private bool ProdutoExists(long? produtoID)
    {
        var produto = _context.Produtos.FirstOrDefault(i => i.ProdutoID == produtoID);
        if (produto == null)
            return false;
        return true;
    }
    public async Task<ActionResult> Details(long id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var produto = await _context.Produtos.SingleOrDefaultAsync(i => i.ProdutoID == id);
        if (produto == null)
        {
            return NotFound();
        }
        return View(produto);
    }
    public async Task<IActionResult> Delete(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var produto = await _context.Produtos.SingleOrDefaultAsync(i => i.ProdutoID == id);
        if (produto == null)
        {
            return NotFound();
        }
        return View(produto);
    }
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long? id)
    {
        var produto = await _context.Produtos.SingleOrDefaultAsync(i => i.ProdutoID == id);
        _context.Produtos.Remove(produto);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }


}















/*public IActionResult Index()
{
    var produtos = _context.Produtos.Include(p => p is NaoPerecivel ? ((NaoPerecivel)p) : null)
                                    .Include(p => p is Perecivel ? ((Perecivel)p) : null)
                                    .ToList();
    return View(produtos);
}*/