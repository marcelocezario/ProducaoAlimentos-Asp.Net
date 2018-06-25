using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.DAL;

namespace WebApplication1.Controllers
{
    public class LotesInsumosProducaoController : Controller
    {
        Contexto contexto = new Contexto();

        // GET: LotesInsumosProducao
        public ActionResult Index()
        {
            List<LoteInsumoProducao> lotesInsumosProducao = contexto.LotesInsumosProducao.ToList();

            return View(lotesInsumosProducao);
        }
    }
}