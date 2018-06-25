using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.DAL;

namespace WebApplication1.Controllers
{
    public class VendasController : Controller
    {
        Contexto contexto = new Contexto();

        // GET: Vendas
        public ActionResult Index()
        {
            List<Venda> vendas = contexto.Vendas.ToList();

            return View(vendas);
        }
    }
}