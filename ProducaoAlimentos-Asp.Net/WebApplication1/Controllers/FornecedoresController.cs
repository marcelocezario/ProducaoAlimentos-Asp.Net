using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.DAL;

namespace WebApplication1.Controllers
{
    public class FornecedoresController : Controller
    {
        Contexto contexto = new Contexto();

        // GET: Fornecedores
        public ActionResult Index()
        {
            List<Fornecedor> fornecedores = contexto.Fornecedores.ToList();

            return View(fornecedores);
        }
    }
}