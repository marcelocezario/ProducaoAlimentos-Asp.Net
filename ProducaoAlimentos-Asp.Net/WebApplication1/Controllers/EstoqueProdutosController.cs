﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.DAL;

namespace WebApplication1.Controllers
{
    public class EstoqueProdutosController : Controller
    {
        Contexto contexto = new Contexto();

        // GET: EstoqueProdutos
        public ActionResult Index()
        {
            List<EstoqueProduto> estoqueProdutos = contexto.EstoqueProdutos.ToList();

            return View(estoqueProdutos);
        }
    }
}