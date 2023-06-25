using FastReport.Export.PdfSimple;
using HardWareTech.DATA.Models;
using HardWareTech.DATA.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HardWareTech.WEB.Controllers
{
    public class ProdutoController : Controller
    {
        //private ProdutoService oProdutoService = new();
        //private CategoriaService oCategoriaService = new();
        private readonly ProdutoService oProdutoService;
        private readonly CategoriaService oCategoriaService;
        public readonly IWebHostEnvironment _webHostEnv;

        public ProdutoController(IWebHostEnvironment webHostEnv)
        {
            oProdutoService = new ProdutoService();
            oCategoriaService = new CategoriaService();
            _webHostEnv = webHostEnv;
        }
        public IActionResult Index()
        {
            List<Produto> oListProduto = oProdutoService.oRepositoryProduto.SelecionarTodos();
            return View(oListProduto);
        }

        [Route("ProductsReport")]
        public IActionResult ProductsReport()
        {
            var caminhoReport = Path.Combine(_webHostEnv.WebRootPath, @"reports\Produto.frx");
            var reportFile = caminhoReport;
            var freport = new FastReport.Report();
            var productList = oProdutoService.oRepositoryProduto.SelecionarTodos();

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

        public IActionResult Create()
        {
            List<Categoria> oListCategoria = oCategoriaService.oRepositoryCategoria.SelecionarTodos();

            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var produto in oListCategoria)
            {
                items.Add(new SelectListItem
                {
                    Text = produto.NomeCategoria,
                    Value = produto.Id.ToString()
                });
            }
            ViewBag.Categorias = items;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Produto model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                model.Datacadastro = DateTime.Now;
                oProdutoService.oRepositoryProduto.Incluir(model);
                TempData["MensagemSucesso"] = $"Produto cadastrado com sucesso!";
                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu produto, tente novamente, detalhe do erro: {erro.Message} ";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Details(int id)
        {

            List<Categoria> oListCategoria = oCategoriaService.oRepositoryCategoria.SelecionarTodos();

            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var produto in oListCategoria)
            {
                items.Add(new SelectListItem
                {
                    Text = produto.NomeCategoria,
                    Value = produto.Id.ToString()
                });
            }
            ViewBag.Categorias = items;

            Produto oProduto = oProdutoService.oRepositoryProduto.SelecionarPk(id);
            return View(oProduto);
        }

        public IActionResult Edit(int id)
        {
            List<Categoria> oListCategoria = oCategoriaService.oRepositoryCategoria.SelecionarTodos();

            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var produto in oListCategoria)
            {
                items.Add(new SelectListItem
                {
                    Text = produto.NomeCategoria,
                    Value = produto.Id.ToString()
                });
            }
            ViewBag.Categorias = items;

            Produto oProduto = oProdutoService.oRepositoryProduto.SelecionarPk(id);
            return View(oProduto);
        }

        [HttpPost]
        public IActionResult Edit(Produto model)
        {
            try
            {
                Produto oProduto = oProdutoService.oRepositoryProduto.Alterar(model);
                int id = oProduto.Id;
                TempData["MensagemSucesso"] = $"Produto alterado com sucesso!";
                return RedirectToAction("Details", new { id });
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos alterar seu produto, tente novamente, detalhe do erro: {erro.Message} ";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Delete(int id)
        {
            try
            {
                oProdutoService.oRepositoryProduto.Excluir(id);
                TempData["MensagemSucesso"] = $"Produto excluido com sucesso!";
                return RedirectToAction("index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos excluir seu produto, tente novamente, detalhe do erro: {erro.Message} ";
                return RedirectToAction("Index");
            }
        }
    }
}