using HardWareTech.DATA.Services;
using HardWareTech.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HardWareTech.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly VwProdutoClienteManutencaoService ovwProdutoClienteManutencaoService = new();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var totalProdutos = ovwProdutoClienteManutencaoService.oRepositoryProduto.SelecionarTodos().Count;
            var totalClientes = ovwProdutoClienteManutencaoService.oRepositoryCliente.SelecionarTodos().Count;
            var totalManutencoes = ovwProdutoClienteManutencaoService.oRepositoryProdutoClienteManutencao.SelecionarTodos().Count;
            var totalCategorias = ovwProdutoClienteManutencaoService.oRepositoryCategoria.SelecionarTodos().Count;
            ViewBag.TotalClientes = totalClientes;
            ViewBag.TotalProdutos = totalProdutos;
            ViewBag.TotalManutencoes = totalManutencoes;
            ViewBag.TotalCategorias = totalCategorias;
            return View();

            //das
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}