using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.DAL;

namespace WebApplication1.Controllers
{
    public class InsumosController : Controller
    {
        Contexto contexto = new Contexto();

        // GET: Insumos
        public ActionResult Index()
        {
            List<Insumo> insumos = contexto.Insumos.ToList();
            
            return View(insumos);
        }
    }
}