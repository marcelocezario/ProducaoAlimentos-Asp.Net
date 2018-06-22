using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.DAL;

namespace WebApplication1.Controllers
{
    public class ClientesController : Controller
    {
        Contexto contexto = new Contexto();

        // GET: Clientes
        public ActionResult Index()
        {
            List<Cliente> clientes = contexto.Clientes.ToList();

            return View(clientes);
        }
    }
}