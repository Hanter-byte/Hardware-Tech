using FastReport.Export.PdfSimple;
using HardWareTech.DATA.Services;
using HardWareTech.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HardWareTech.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly VwProdutoClienteManutencaoService ovwProdutoClienteManutencaoService;
        private readonly ProdutoService oprodutoService;
        private readonly VendaService ovendaService;

        public HomeController()
        {
            ovwProdutoClienteManutencaoService = new VwProdutoClienteManutencaoService();
            oprodutoService = new ProdutoService();
            ovendaService = new VendaService();
        }

        public IActionResult Index()
        {
            var totalProdutos = ovwProdutoClienteManutencaoService.oRepositoryProduto.SelecionarTodos().Count;
            var totalClientes = ovwProdutoClienteManutencaoService.oRepositoryCliente.SelecionarTodos().Count;
            var totalManutencoes = ovwProdutoClienteManutencaoService.oRepositoryProdutoClienteManutencao.SelecionarTodos().Count;
            var totalCategorias = ovwProdutoClienteManutencaoService.oRepositoryCategoria.SelecionarTodos().Count;
            var totalVenda = ovendaService.oRepositoryVenda.SelecionarTodos().Count;
            ViewBag.TotalClientes = totalClientes;
            ViewBag.TotalProdutos = totalProdutos;
            ViewBag.TotalManutencoes = totalManutencoes;
            ViewBag.TotalCategorias = totalCategorias;
            ViewBag.totalVendas = totalVenda;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}