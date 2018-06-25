using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.DAL;

namespace WebApplication1.Controllers
{
    public class MovimentacoesEstoqueProdutosController : Controller
    {
        Contexto contexto = new Contexto();

        // GET: MovimentacoesEstoqueProdutos
        public ActionResult Index()
        {
            List<MovimentacaoEstoqueProduto> movimentacoesEstoqueProdutos = contexto.MovimentacoesEstoqueProdutos.ToList();

            return View(movimentacoesEstoqueProdutos);
        }
    }
}