using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.DAL;

namespace WebApplication1.Controllers
{
    public class UnidadesDeMedidaController : Controller
    {
        Contexto contexto = new Contexto();

        // GET: UnidadesDeMedida
        public ActionResult Index()
        {
            List<UnidadeDeMedida> unidadesDeMedida = contexto.UnidadesDeMedida.ToList();

            return View(unidadesDeMedida);
        }
    }
}