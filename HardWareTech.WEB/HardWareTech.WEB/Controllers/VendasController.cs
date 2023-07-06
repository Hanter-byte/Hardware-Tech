﻿using HardWareTech.DATA.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using HardWareTech.WEB.Models;

namespace HardWareTech.WEB.Controllers
{
    public class VendasController : Controller
    {
        private readonly VendaService oVendaService = new VendaService();
        public IActionResult Index(string cpf = null)
        {

            // Produtos
            var produtosSelect = new List<SelectListItem>();
            produtosSelect.Add(new SelectListItem { Text = "Selecione o produto", Value = "" });
            var produtos = oVendaService.oRepositoryProduto.SelecionarTodos();
            produtosSelect.AddRange(produtos.Select(c => new SelectListItem()
            { Text = c.NomeProduto, Value = c.Id.ToString() }).ToList());

            ViewBag.produtos = produtosSelect;

            if (cpf != null)
            {
                var cliente = oVendaService.oRepositoryCliente.SelecionarClienteByCPF(cpf);
                if (cliente != null)
                {
                    ViewBag.cpf = cpf;
                    return View();
                }
            }
            return View();
        }

        [HttpGet]
        public JsonResult SelecionarCliente(string cpf)
        {
            var cliente = oVendaService.oRepositoryCliente.SelecionarClienteByCPF(cpf);

            if (cliente == null)
            {
                return Json(new { sucesso = false });
            }

            return Json(new { retorno = cliente, sucesso = true });
        }

        [HttpGet]
        public JsonResult SelecionarProduto(int idProduto)
        {
            var produto = oVendaService.oRepositoryProduto.SelecionarPk(idProduto);

            if (produto == null)
            {
                return Json(new { sucesso = false });
            }

            return Json(new { retorno = produto, sucesso = true });
        }

        [HttpPost]
        public JsonResult EfetuarVenda(string cpf, List<ProdutoViewModel> produtos)
        {
            if (produtos == null)
            {
                return Json(new { sucesso = false, mensagem = "Não há produtos para finalizar esta venda." });
            }

            if (produtos.Count == 0)
            {
                return Json(new { sucesso = false, mensagem = "Não há produtos para finalizar esta venda." });
            }
            var cliente = oVendaService.oRepositoryCliente.SelecionarClienteByCPF(cpf);

            if (cliente == null)
            {
                return Json(new { sucesso = false, mensagem = "Não foi possível encontrar o cliente." });
            }

            decimal total = produtos.Sum(p => p.Preco * p.Quantidade);
            var vendaIncluida = oVendaService.oRepositoryVenda.Incluir(new DATA.Models.Venda
            {
                DataVenda = DateTime.Now,
                ValorTotal = total,
                IdCliente = cliente.Id
            });

            if (vendaIncluida == null)
            {
                return Json(new { sucesso = false, mensagem = "Ocorreu um erro ao incluir a venda." });
            }

            // adição dos produtos na venda
            List<DATA.Models.ProdutoVenda> produtosVendas = new List<DATA.Models.ProdutoVenda>();
            foreach (var produto in produtos)
            {
                produtosVendas.Add(new DATA.Models.ProdutoVenda
                {
                    IdProduto = produto.Id,
                    IdVenda = vendaIncluida.Id,
                    Quantidade = produto.Quantidade,
                    ValorUnitario = produto.Preco
                });
            }

            try
            {
                oVendaService.oRepositoryProdutoVenda.IncluirProdutosDaVenda(produtosVendas);
            }
            catch (Exception Ex)
            {
                return Json(new { sucesso = false, mensagem = "Ocorreu um erro ao tentar incluir os produtos da venda." });
            }

            return Json(new { sucesso = true, mensagem = "Venda realizada com sucesso!" });
        }
    }
}