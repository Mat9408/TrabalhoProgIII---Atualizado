using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsECommerce.Data;
using SportsECommerce.Models;

namespace SportsECommerce.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly SportsECommerceContext _context;

        public ProdutoController(SportsECommerceContext context)
        {
            _context = context;
        }

        public async Task <IActionResult> Index()
        {
            return View(await _context.Produtos.OrderBy(i => i.ProdutoNome).ToListAsync());
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Create([Bind("ProdutoNome", "ProdutoModelo", "ProdutoPreco")] Produto produto)
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
            catch(DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível realizar o cadastro do produto.");
            }
            return View(produto);
        }

        public async Task<ActionResult> Edit(long id)
        {
            if(id == null)
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

        public async Task<IActionResult> Edit(long? id, [Bind("ProdutoID", "ProdutoNome", "ProdutoModelo", "ProdutoPreco")] Produto produto)
        {
            if(id!= produto.ProdutoID)
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
            throw new NotImplementedException();
        }

        public async Task<IActionResult> Details(long? id)
        {
            if(id == null)
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

        public async Task<ActionResult> DeleteConfirmed(long? id)
        {
            var produto = await _context.Produtos.SingleOrDefaultAsync(i => i.ProdutoID == id);
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");   
        }
    }
}
