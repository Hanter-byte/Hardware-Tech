using HardWareTech.DATA.Models;
using HardWareTech.DATA.Services;
using Microsoft.AspNetCore.Mvc;

namespace HardWareTech.WEB.Controllers
{
    public class UsuarioController : Controller
    {
        //private UsuarioService oUsuarioService= new UsuarioService();
        private UsuarioService oUsuarioService;

        public UsuarioController()
        {
            oUsuarioService= new UsuarioService();
        }

        public IActionResult Index()
        {
            List<Usuario> oListUsuario = oUsuarioService.oRepositoryUsuario.SelecionarTodos();
            return View(oListUsuario);
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