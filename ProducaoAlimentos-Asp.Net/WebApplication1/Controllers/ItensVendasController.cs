using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.DAL;

namespace WebApplication1.Controllers
{
    public class ItensVendasController : Controller
    {
        Contexto contexto = new Contexto();

        // GET: ItensVendas
        public ActionResult Index()
        {
            List<ItemVenda> itensVendas = contexto.ItensVenda.ToList();

            return View(itensVendas);
        }
    }
}