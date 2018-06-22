using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.DAL;

namespace WebApplication1.Controllers
{
    public class EstadosController : Controller
    {
        Contexto contexto = new Contexto();
        
        // GET: Estados
        public ActionResult Index()
        {
            List<Estado> estados = contexto.Estados.ToList();
            return View(estados);
        }
    }
}