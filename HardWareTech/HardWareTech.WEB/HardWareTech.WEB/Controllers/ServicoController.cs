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
    }
}