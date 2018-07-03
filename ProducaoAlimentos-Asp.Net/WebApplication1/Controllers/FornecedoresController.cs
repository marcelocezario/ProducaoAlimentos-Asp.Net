using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.DAL;
using WebApplication1.Models.ViewModel;

namespace WebApplication1.Controllers
{
    public class FornecedoresController : Controller
    {
        private Contexto db = new Contexto();

        public ActionResult Index()
        {
            var fornecedores = db.Fornecedores.OrderBy(f => f.Nome).ToList();
            return View(fornecedores);
        }

        // GET: Fornecedores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fornecedor fornecedor = db.Fornecedores.Find(id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            return PartialView(fornecedor);
        }

        // GET: Fornecedores/Create
        public ActionResult Create()
        {
            ViewBag.EnderecoCidadeID = new SelectList(db.Cidades, "CidadeID", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ID,Nome,Cpf_Cnpj,Telefone,Email,EnderecoID")] Fornecedor fornecedor)
        public ActionResult Create([Bind(Include = "ID,FornecedorNome,FornecedorCpf_Cnpj,FornecedorTelefone,FornecedorEmail,EnderecoLogradouro,EnderecoNumero,EnderecoComplemento,EnderecoBairro,EnderecoCep,EnderecoCidadeID")] FornecedorViewModel fornecedorViewModel)
        {
            Endereco endereco = new Endereco
            {
                Logradouro = fornecedorViewModel.EnderecoLogradouro,
                Numero = fornecedorViewModel.EnderecoNumero,
                Complemento = fornecedorViewModel.EnderecoComplemento,
                Bairro = fornecedorViewModel.EnderecoBairro,
                Cep = fornecedorViewModel.EnderecoCep,
                CidadeID = fornecedorViewModel.EnderecoCidadeID
            };

            EnderecosController ec = new EnderecosController();
            endereco = ec.Create(endereco);
            if (endereco != null)
            {
                Fornecedor fornecedor = new Fornecedor
                {
                    Nome = fornecedorViewModel.FornecedorNome,
                    Cpf_Cnpj = fornecedorViewModel.FornecedorCpf_Cnpj,
                    Telefone = fornecedorViewModel.FornecedorTelefone,
                    Email = fornecedorViewModel.FornecedorEmail,
                    EnderecoID = endereco.EnderecoID
                };
                if (ModelState.IsValid)
                {
                    db.Fornecedores.Add(fornecedor);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.EnderecoCidadeID = new SelectList(db.Cidades, "CidadeID", "Nome");
            return View(fornecedorViewModel);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fornecedor fornecedor = db.Fornecedores.Find(id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            List<Endereco> enderecos = new List<Endereco>();
            Endereco endereco = db.Enderecos.Find(fornecedor.EnderecoID);

            enderecos.Add(endereco);

            ViewBag.EnderecoID = new SelectList(db.Enderecos, "EnderecoID", "Logradouro", fornecedor.EnderecoID);
            return PartialView(fornecedor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Cpf_Cnpj,Telefone,Email,EnderecoID")] Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fornecedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EnderecoCidadeID = new SelectList(db.Cidades, "CidadeID", "Nome");
            return PartialView(fornecedor);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fornecedor fornecedor = db.Fornecedores.Find(id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            return PartialView(fornecedor);
        }

        // POST: Fornecedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fornecedor fornecedor = db.Fornecedores.Find(id);
            db.Fornecedores.Remove(fornecedor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
