using Microsoft.AspNetCore.Mvc;
using RelacionamentoHeranca.Data;
using RelacionamentoHeranca.Models;
using Microsoft.EntityFrameworkCore;

namespace RelacionamentoHeranca.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ConfeitariaContext _context;
        public ProdutoController(ConfeitariaContext context)
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
                ModelState.AddModelError("", "Não foi possível cadastrar a instituição.");
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
        public async Task<IActionResult> Edit(long? id, [Bind("ProdutoID", "Nome", "Valor","quantidade")] Produto produto)
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
                    if (!InstituicaoExists(produto.ProdutoID))
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

        private bool InstituicaoExists(long? produtoID)
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
}