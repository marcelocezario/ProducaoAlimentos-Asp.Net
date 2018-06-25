using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.DAL;

namespace WebApplication1.Controllers
{
    public class MovimentacoesEstoqueInsumosController : Controller
    {
        Contexto contexto = new Contexto();

        // GET: MovimentacoesEstoqueInsumos
        public ActionResult Index()
        {
            List<MovimentacaoEstoqueInsumo> movimentacoesEstoqueInsumos = contexto.MovimentacoesEstoqueInsumos.ToList();

            return View(movimentacoesEstoqueInsumos);
        }
    }
}