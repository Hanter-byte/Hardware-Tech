using FastReport.Export.PdfSimple;
using HardWareTech.DATA.Models;
using HardWareTech.DATA.Services;
using Microsoft.AspNetCore.Mvc;

namespace HardWareTech.WEB.Controllers
{
    public class ClienteController : Controller
    {

        private ClienteService oClienteService;
        public readonly IWebHostEnvironment _webHostEnv;

        public ClienteController(IWebHostEnvironment webHostEnvironment)
        {
            oClienteService = new ClienteService();
            _webHostEnv = webHostEnvironment;
        }

        public IActionResult Index()
        {
            List<Cliente> oListCliente = oClienteService.oRepositoryCliente.SelecionarTodos();
            return View(oListCliente);
        }

        [Route("ClientesReport")]
        public IActionResult ClientesReport()
        {
            var caminhoReport = Path.Combine(_webHostEnv.WebRootPath, @"reports\Cliente.frx");
            var reportFile = caminhoReport;
            var freport = new FastReport.Report();
            var clienteList = oClienteService.oRepositoryCliente.SelecionarTodos();

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
        public IActionResult Create(Cliente model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                var cliente = new Cliente();
                if (!cliente.ValidarCPF(model.Cpf))
                {
                    TempData["MensagemErro"] = $"CPF inválido!";
                    return RedirectToAction("Create");
                }

                oClienteService.oRepositoryCliente.Incluir(model);
                TempData["MensagemSucesso"] = $"Cliente cadastrado com sucesso!";
                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu cliente, tente novamente, detalhe do erro: {erro.Message} ";
                return RedirectToAction("Index");
            }
        }


        public IActionResult Details(int id)
        {
            Cliente oCliente = oClienteService.oRepositoryCliente.SelecionarPk(id);
            return View(oCliente);
        }

        public IActionResult Edit(int id)
        {
            Cliente oCliente = oClienteService.oRepositoryCliente.SelecionarPk(id);
            return View(oCliente);
        }

        [HttpPost]
        public IActionResult Edit(Cliente model)
        {
            try
            {
                var cliente = new Cliente();
                if (!cliente.ValidarCPF(model.Cpf))
                {
                    TempData["MensagemErro"] = $"CPF inválido!";
                    return RedirectToAction("Edit");
                }

                Cliente oCliente = oClienteService.oRepositoryCliente.Alterar(model);
                int id = oCliente.Id;
                TempData["MensagemSucesso"] = $"Cliente alterado com sucesso!";
                return RedirectToAction("Details", new { id });
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos alterar seu cliente, tente novamente, detalhe do erro: {erro.Message} ";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Delete(int id)
        {
            try
            {
                oClienteService.oRepositoryCliente.Excluir(id);
                TempData["MensagemSucesso"] = $"Cliente excluido com sucesso!";
                return RedirectToAction("index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos excluir seu cliente, tente novamente, detalhe do erro: {erro.Message} ";
                return RedirectToAction("Index");
            }
        }
    }
}