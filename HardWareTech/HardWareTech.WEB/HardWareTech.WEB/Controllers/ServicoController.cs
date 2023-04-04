using HardWareTech.DATA.Models;
using HardWareTech.DATA.Services;
using Microsoft.AspNetCore.Mvc;

namespace HardWareTech.WEB.Controllers
{
    public class ServicoController : Controller
    {
        private ServicoService oServicoService = new ServicoService();
        public IActionResult Index()
        {
            List<Servico> oListServico = oServicoService.oRepositoryServico.SelecionarTodos();
            return View(oListServico);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Servico model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                oServicoService.oRepositoryServico.Incluir(model);
                TempData["MensagemSucesso"] = $"Serviço cadastrado com sucesso!";
                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu serviço, tente novamente, detalhe do erro: {erro.Message} ";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Edit(int id)
        {
            Servico oServico = oServicoService.oRepositoryServico.SelecionarPk(id);
            return View(oServico);
        }
        [HttpPost]
        public IActionResult Edit(Servico model)
        {
            try
            {
                Servico oServico = oServicoService.oRepositoryServico.Alterar(model);
                int id = oServico.Id;
                TempData["MensagemSucesso"] = $"Serviço alterado com sucesso!";
                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos alterar seu serviço, tente novamente, detalhe do erro: {erro.Message} ";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Delete(int id)
        {
            try
            {
                oServicoService.oRepositoryServico.Excluir(id);
                TempData["MensagemSucesso"] = $"Serviço excluido com sucesso!";
                return RedirectToAction("index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos excluir seu serviço, tente novamente, detalhe do erro: {erro.Message} ";
                return RedirectToAction("Index");
            }
        }
    }
}