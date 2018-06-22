using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.DAL;

namespace WebApplication1.Controllers
{
    public class LotesInsumosController : Controller
    {
        Contexto contexto = new Contexto();

        // GET: LotesInsumos
        public ActionResult Index()
        {
            List<LoteInsumo> lotesInsumos = contexto.LotesInsumos.ToList();

            return View(lotesInsumos);
        }
    }
}