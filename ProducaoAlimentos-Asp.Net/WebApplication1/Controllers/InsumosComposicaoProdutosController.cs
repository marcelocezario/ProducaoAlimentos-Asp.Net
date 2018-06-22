using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.DAL;

namespace WebApplication1.Controllers
{
    public class InsumosComposicaoProdutosController : Controller
    {
        Contexto contexto = new Contexto();

        // GET: InsumosComposicaoProdutos
        public ActionResult Index()
        {
            List<InsumoComposicaoProduto> insumosComposicaoProdutos = contexto.InsumosComposicaoProdutos.ToList();

            return View(insumosComposicaoProdutos);
        }
    }
}