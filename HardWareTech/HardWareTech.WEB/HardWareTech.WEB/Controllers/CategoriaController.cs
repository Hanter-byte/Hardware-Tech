using FastReport.Export.PdfSimple;
using HardWareTech.DATA.Models;
using HardWareTech.DATA.Services;
using Microsoft.AspNetCore.Mvc;

namespace HardWareTech.WEB.Controllers
{
    public class CategoriaController : Controller
    {
        //private CategoriaService oCategoriaService = new CategoriaService();
        private CategoriaService oCategoriaService;
        public readonly IWebHostEnvironment _webHostEnv;

        public CategoriaController(IWebHostEnvironment webHostEnvironment) 
        {
            oCategoriaService = new CategoriaService();
            _webHostEnv = webHostEnvironment;
        }

        public IActionResult Index()
        {
            List<Categoria> oListCategoria = oCategoriaService.oRepositoryCategoria.SelecionarTodos();
            return View(oListCategoria);
        }

        [Route("CategoriasReport")]
        public IActionResult CategoriasReport()
        {
            var caminhoReport = Path.Combine(_webHostEnv.WebRootPath, @"reports\Categoria.frx");
            var reportFile = caminhoReport;
            var freport = new FastReport.Report();
            var productList = oCategoriaService.oRepositoryCategoria.SelecionarTodos();

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
            return View();
        }
        [HttpPost]
        public IActionResult Create(Categoria model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                oCategoriaService.oRepositoryCategoria.Incluir(model);
                TempData["MensagemSucesso"] = $"Categoria cadastrada com sucesso!";
                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar sua categoria, tente novamente, detalhe do erro: {erro.Message} ";
                return RedirectToAction("Index");
            }
        }
        public IActionResult Details(int id)
        {
            Categoria oCategoria = oCategoriaService.oRepositoryCategoria.SelecionarPk(id);
            return View(oCategoria);
        }
        public IActionResult Edit(int id)
        {
            Categoria oCategoria = oCategoriaService.oRepositoryCategoria.SelecionarPk(id);
            return View(oCategoria);
        }
        [HttpPost]
        public IActionResult Edit(Categoria model)
        {
            try
            {
                Categoria oCategoria = oCategoriaService.oRepositoryCategoria.Alterar(model);
                int id = oCategoria.Id;
                TempData["MensagemSucesso"] = $"Categoria alterada com sucesso!";
                return RedirectToAction("Index");
                //return RedirectToAction("Details", new { id });
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos alterar sua categoria, tente novamente, detalhe do erro: {erro.Message} ";
                return RedirectToAction("Index");
            }
        }
        public IActionResult Delete(int id)
        {
            try
            {
                oCategoriaService.oRepositoryCategoria.Excluir(id);
                TempData["MensagemSucesso"] = $"Categoria excluida com sucesso!";
                return RedirectToAction("index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos excluir sua categoria, tente novamente, detalhe do erro: {erro.Message} ";
                return RedirectToAction("Index");
            }
        }
    }
}