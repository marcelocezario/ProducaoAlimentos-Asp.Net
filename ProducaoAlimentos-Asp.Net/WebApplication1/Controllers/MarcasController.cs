using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.DAL;

namespace WebApplication1.Controllers
{
    public class MarcasController : Controller
    {
        Contexto contexto = new Contexto();

        // GET: Marcas
        public ActionResult Index()
        {
            List<Marca> marcas = contexto.Marcas.ToList();

            return View(marcas);
        }
    }
}