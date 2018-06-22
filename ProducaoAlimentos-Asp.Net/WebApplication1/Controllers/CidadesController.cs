using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.DAL;

namespace WebApplication1.Controllers
{
    public class CidadesController : Controller
    {
        Contexto contexto = new Contexto();

        // GET: Cidades
        public ActionResult Index()
        {
            List<Cidade> cidades = contexto.Cidades.ToList();

            return View(cidades);
        }
    }
}