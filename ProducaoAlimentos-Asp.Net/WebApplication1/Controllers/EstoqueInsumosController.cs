using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.DAL;

namespace WebApplication1.Controllers
{
    public class EstoqueInsumosController : Controller
    {
        Contexto contexto = new Contexto();

        // GET: EstoqueInsumos
        public ActionResult Index()
        {
            List<EstoqueInsumo> estoqueInsumos = contexto.EstoqueInsumos.ToList();

            return View(estoqueInsumos);
        }
    }
}