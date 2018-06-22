using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.DAL;

namespace WebApplication1.Controllers
{
    public class EnderecosController : Controller
    {
        Contexto contexto = new Contexto();

        // GET: Enderecos
        public ActionResult Index()
        {
            List<Endereco> enderecos = contexto.Enderecos.ToList();

            return View(enderecos);
        }
    }
}