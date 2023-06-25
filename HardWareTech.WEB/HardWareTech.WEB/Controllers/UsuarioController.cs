using FastReport.Export.PdfSimple;
using HardWareTech.DATA.Models;
using HardWareTech.DATA.Services;
using Microsoft.AspNetCore.Mvc;

namespace HardWareTech.WEB.Controllers
{
    public class UsuarioController : Controller
    {
        //private UsuarioService oUsuarioService= new UsuarioService();
        private UsuarioService oUsuarioService;
        public readonly IWebHostEnvironment _webHostEnv;

        public UsuarioController(IWebHostEnvironment webHostEnvironment)
        {
            oUsuarioService= new UsuarioService();
            _webHostEnv = webHostEnvironment;
        }

        public IActionResult Index()
        {
            List<Usuario> oListUsuario = oUsuarioService.oRepositoryUsuario.SelecionarTodos();
            return View(oListUsuario);
        }

        [Route("UsuariosReport")]
        public IActionResult UsuariosReport()
        {
            var caminhoReport = Path.Combine(_webHostEnv.WebRootPath, @"reports\Usuario.frx");
            var reportFile = caminhoReport;
            var freport = new FastReport.Report();
            var clienteList = oUsuarioService.oRepositoryUsuario.SelecionarTodos();

            freport.Report.Load(reportFile);
            freport.Dictionary.RegisterBusinessObject(clienteList, "clienteList", 10, true);
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
        public IActionResult Create(Usuario model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                model.Datacadastro = DateTime.Now;
                oUsuarioService.oRepositoryUsuario.Incluir(model);
                TempData["MensagemSucesso"] = $"Usuario cadastrado com sucesso!";
                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu usuario, tente novamente, detalhe do erro: {erro.Message} ";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Details(int id)
        {
            Usuario oUsuario = oUsuarioService.oRepositoryUsuario.SelecionarPk(id);
            return View(oUsuario);
        }

        public IActionResult Edit(int id)
        {
            Usuario oUsuario = oUsuarioService.oRepositoryUsuario.SelecionarPk(id);
            return View(oUsuario);
        }

        [HttpPost]
        public IActionResult Edit(Usuario model)
        {
            try
            {
                Usuario oUsuario= oUsuarioService.oRepositoryUsuario.Alterar(model);
                int id = oUsuario.Id;
                TempData["MensagemSucesso"] = $"Usuario alterado com sucesso!";
                return RedirectToAction("Details", new { id });
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos alterar seu usuario, tente novamente, detalhe do erro: {erro.Message} ";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Delete(int id)
        {
            try
            {
                oUsuarioService.oRepositoryUsuario.Excluir(id);
                TempData["MensagemSucesso"] = $"Usuario excluido com sucesso!";
                return RedirectToAction("index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos excluir seu usuario, tente novamente, detalhe do erro: {erro.Message} ";
                return RedirectToAction("Index");
            }
        }
    }
}