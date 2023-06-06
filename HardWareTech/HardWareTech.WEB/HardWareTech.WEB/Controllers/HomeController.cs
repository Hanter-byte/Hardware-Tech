using FastReport.Export.PdfSimple;
using HardWareTech.DATA.Services;
using HardWareTech.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HardWareTech.WEB.Controllers
{
    public class HomeController : Controller
    {
        //private readonly VwProdutoClienteManutencaoService ovwProdutoClienteManutencaoService;
        private readonly ProdutoService oprodutoService;
        public readonly IWebHostEnvironment _webHostEnv;

        public HomeController(IWebHostEnvironment webHostEnv)
        {
            //ovwProdutoClienteManutencaoService = new VwProdutoClienteManutencaoService();
            oprodutoService = new ProdutoService();
            _webHostEnv = webHostEnv;
        }

        public IActionResult Index()
        {
            //var totalProdutos = ovwProdutoClienteManutencaoService.oRepositoryProduto.SelecionarTodos().Count;
            //var totalClientes = ovwProdutoClienteManutencaoService.oRepositoryCliente.SelecionarTodos().Count;
            //var totalManutencoes = ovwProdutoClienteManutencaoService.oRepositoryProdutoClienteManutencao.SelecionarTodos().Count;
            //var totalCategorias = ovwProdutoClienteManutencaoService.oRepositoryCategoria.SelecionarTodos().Count;
            //ViewBag.TotalClientes = totalClientes;
            //ViewBag.TotalProdutos = totalProdutos;
            //ViewBag.TotalManutencoes = totalManutencoes;
            //ViewBag.TotalCategorias = totalCategorias;
            return View();
        }

        [Route("CreateReport")]
        public IActionResult CreateReport()
        {
            var caminhoReport = Path.Combine(_webHostEnv.WebRootPath, @"reports\Produto.frx");
            var reportFile = caminhoReport;
            var freport = new FastReport.Report();
            var productList = oprodutoService.oRepositoryProduto.SelecionarTodos();

            freport.Dictionary.RegisterBusinessObject(productList, "productList", 10, true);
            freport.Report.Save(reportFile);

            return Ok($" Relatorio gerado : {caminhoReport}");
        }

        [Route("ProductsReport")]
        public IActionResult ProductsReport()
        {
            var caminhoReport = Path.Combine(_webHostEnv.WebRootPath, @"reports\Produto.frx");
            var reportFile = caminhoReport;
            var freport = new FastReport.Report();
            var productList = oprodutoService.oRepositoryProduto.SelecionarTodos();

            freport.Report.Load(reportFile);
            freport.Dictionary.RegisterBusinessObject(productList, "productList", 10, true);
            //freport.Report.Save(reportFile);
            freport.Prepare();

            var pdfExport = new PDFSimpleExport();

            using MemoryStream ms = new MemoryStream();
            pdfExport.Export(freport, ms);
            ms.Flush();

            return File(ms.ToArray(), "application/pdf");
            //return Ok($"Relatorio gerado: {caminhoReport}");
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}