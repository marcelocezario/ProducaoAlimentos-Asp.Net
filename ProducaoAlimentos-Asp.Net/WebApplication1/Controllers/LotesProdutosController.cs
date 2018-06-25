using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.DAL;

namespace WebApplication1.Controllers
{
    public class LotesProdutosController : Controller
    {
        Contexto contexto = new Contexto();

        // GET: LotesProdutos
        public ActionResult Index()
        {
            List<LoteProduto> lotesProdutos = contexto.LotesProdutos.ToList();

            return View(lotesProdutos);
        }
    }
}