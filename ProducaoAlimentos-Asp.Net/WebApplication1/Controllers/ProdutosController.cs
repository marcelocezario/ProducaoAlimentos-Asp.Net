using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.DAL;

namespace WebApplication1.Controllers
{
    public class ProdutosController : Controller
    {
        Contexto contexto = new Contexto();

        // GET: Produtos
        public ActionResult Index()
        {
            List<Produto> produtos = contexto.Produtos.ToList();

            return View(produtos);
        }
    }
}