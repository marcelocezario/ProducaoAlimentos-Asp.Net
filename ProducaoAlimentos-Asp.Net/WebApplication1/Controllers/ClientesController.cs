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
//    [Authorize]
    public class ClientesController : Controller
    {
        private Contexto db = new Contexto();

        public ActionResult Index()
        {
            var clientes = db.Clientes.OrderBy(c => c.Nome).ToList();
            return View(clientes);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return PartialView(cliente);
        }

        public ActionResult Create()
        {
            ViewBag.EnderecoCidadeID = new SelectList(db.Cidades, "CidadeID", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ID,Nome,Cpf_Cnpj,Telefone,Email,_Endereco")] Cliente cliente)
        public ActionResult Create([Bind(Include = "ID,ClienteNome,ClienteCpf_Cnpj,ClienteTelefone,ClienteEmail,EnderecoLogradouro,EnderecoNumero,EnderecoComplemento,EnderecoBairro,EnderecoCep,EnderecoCidadeID")] ClienteViewModel clienteViewModel)
        {
            Endereco endereco = new Endereco
            {
                Logradouro = clienteViewModel.EnderecoLogradouro,
                Numero = clienteViewModel.EnderecoNumero,
                Complemento = clienteViewModel.EnderecoComplemento,
                Bairro = clienteViewModel.EnderecoBairro,
                Cep = clienteViewModel.EnderecoCep,
                CidadeID = clienteViewModel.EnderecoCidadeID
            };

            EnderecosController ec = new EnderecosController();
            endereco = ec.Create(endereco);
            if (endereco != null)
            {
                Cliente cliente = new Cliente
                {
                    Nome = clienteViewModel.ClienteNome,
                    Cpf_Cnpj = clienteViewModel.ClienteCpf_Cnpj,
                    Telefone = clienteViewModel.ClienteTelefone,
                    Email = clienteViewModel.ClienteEmail,
                    EnderecoID = endereco.EnderecoID
                };
                if (ModelState.IsValid)
                {
                    db.Clientes.Add(cliente);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.EnderecoCidadeID = new SelectList(db.Cidades, "CidadeID", "Nome");
            return View(clienteViewModel);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            List<Endereco> enderecos = new List<Endereco>();
            Endereco endereco = db.Enderecos.Find(cliente.EnderecoID);

            enderecos.Add(endereco);

            ViewBag.EnderecoID = new SelectList(enderecos, "EnderecoID", "_Cidade.Nome", cliente._Endereco._Cidade.Nome);
            return PartialView(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Cpf_Cnpj,Telefone,Email,EnderecoID")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EnderecoCidadeID = new SelectList(db.Cidades, "CidadeID", "Nome");
            return PartialView(cliente);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return PartialView(cliente);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            db.Clientes.Remove(cliente);
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
