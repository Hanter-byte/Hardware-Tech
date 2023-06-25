using HardWareTech.DATA.Models;
using HardWareTech.DATA.Services;
using HardWareTech.WEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace HardWareTech.WEB.Controllers
{
    public class LoginController : Controller
    {
        //private UsuarioService oUsuarioService= new();
        private UsuarioService oUsuarioService;

        public LoginController()
        {
            oUsuarioService = new UsuarioService();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if(ModelState.IsValid)
                {
                   Usuario usuario = oUsuarioService.oRepositoryUsuario.BuscarPorLogin(loginModel.Login);

                    if (usuario != null)
                    {
                        if (usuario.SenhaValida(loginModel.Senha))
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        TempData["MensagemErro"] = $"Senha inválida, tente novamente.";
                    }

                    TempData["MensagemErro"] = $"Usuário e/ou senha inválido(s). Por favor, tente novamente.";
                }

                return View("Index");

            }catch(Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos realizar seu login, tente novamente, detalhe do erro: {erro.Message} ";
                return RedirectToAction("Index");
            }
        }
    }
}