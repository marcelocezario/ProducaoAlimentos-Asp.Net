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

        public ActionResult Create()
        {
            ViewBag.EnderecoCidadeID = new SelectList(db.Cidades, "CidadeID", "Nome");
            return PartialView();
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
            FornecedorViewModel fornecedorViewModel = new FornecedorViewModel()
            {
                FornecedorID = fornecedor.ID,
                FornecedorNome = fornecedor.Nome,
                FornecedorCpf_Cnpj = fornecedor.Cpf_Cnpj,
                FornecedorTelefone = fornecedor.Telefone,
                FornecedorEmail = fornecedor.Email,
                EnderecoID = fornecedor.EnderecoID,
                EnderecoLogradouro = fornecedor._Endereco.Logradouro,
                EnderecoNumero = fornecedor._Endereco.Numero,
                EnderecoComplemento = fornecedor._Endereco.Complemento,
                EnderecoBairro = fornecedor._Endereco.Bairro,
                EnderecoCep = fornecedor._Endereco.Cep,
                EnderecoCidadeID = fornecedor._Endereco.CidadeID
            };
            ViewBag.EnderecoCidadeID = new SelectList(db.Cidades, "CidadeID", "Nome");

            return PartialView(fornecedorViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FornecedorID,FornecedorNome,FornecedorCpf_Cnpj,FornecedorTelefone,FornecedorEmail,EnderecoID,EnderecoLogradouro,EnderecoNumero,EnderecoComplemento,EnderecoBairro,EnderecoCep,EnderecoCidadeID")] FornecedorViewModel fornecedorViewModel)
        {
            Endereco endereco = new Endereco()
            {
                EnderecoID = fornecedorViewModel.EnderecoID,
                Logradouro = fornecedorViewModel.EnderecoLogradouro,
                Numero = fornecedorViewModel.EnderecoNumero,
                Complemento = fornecedorViewModel.EnderecoComplemento,
                Bairro = fornecedorViewModel.EnderecoBairro,
                Cep = fornecedorViewModel.EnderecoCep,
                CidadeID = fornecedorViewModel.EnderecoCidadeID
            };
            EnderecosController ec = new EnderecosController();
            endereco = ec.Edit(endereco);
            if (endereco != null)
            {
                Fornecedor fornecedor = db.Fornecedores.Find(fornecedorViewModel.FornecedorID);
                fornecedor.Nome = fornecedorViewModel.FornecedorNome;
                fornecedor.Cpf_Cnpj = fornecedorViewModel.FornecedorCpf_Cnpj;
                fornecedor.Telefone = fornecedorViewModel.FornecedorTelefone;
                fornecedor.Email = fornecedorViewModel.FornecedorEmail;
                fornecedor.EnderecoID = endereco.EnderecoID;

                if (ModelState.IsValid)
                {
                    db.Entry(fornecedor).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            ViewBag.EnderecoCidadeID = new SelectList(db.Cidades, "CidadeID", "Nome");
            return View(fornecedorViewModel);
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
