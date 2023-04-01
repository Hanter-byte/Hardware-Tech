using HardWareTech.DATA.Models;
using HardWareTech.DATA.Services;
using HardWareTech.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HardWareTech.WEB.Controllers
{
    public class ManutencoesController : Controller
    {
        private readonly VwProdutoClienteManutencaoService _Service = new();
        public IActionResult Index()
        {
            List<VwProdutoClienteManutencao> oVwProdutoClienteManutencao = _Service.oRepositoryVwProdutoClienteManutencao.SelecionarTodos();
            return View(oVwProdutoClienteManutencao);
        }

        public IActionResult Create()
        {
            ManutencaoViewModel oManutencaoViewModel = new();
            List<Cliente> oListCliente = _Service.oRepositoryCliente.SelecionarTodos();
            List<Produto> oListProduto = _Service.oRepositoryProduto.SelecionarTodos();

            oManutencaoViewModel.oListeCliente = oListCliente;
            oManutencaoViewModel.oListProduto = oListProduto;
            oManutencaoViewModel.dataCadastro = DateTime.Now.Date;
            oManutencaoViewModel.dataEntrega = DateTime.Now.Date.AddDays(7);

            return View(oManutencaoViewModel);
        }

        [HttpPost]
        public IActionResult Create(ManutencaoViewModel viewModel)
        {
            try
            {
                var manutencao = new ProdutoClienteManutencao
                {
                    DataCadastro = viewModel.dataCadastro,
                    DataFinalizacao = viewModel.dataEntrega,
                    IdProduto = viewModel.idProduto,
                    IdCliente = viewModel.idCliente,
                    Feito = false
                };

                if (manutencao.DataFinalizacao < manutencao.DataCadastro)
                {
                    TempData["MensagemErro"] = "Ops, não conseguimos cadastrar sua manutenção, detalhes do erro: Data de Finalização menor que a data de cadastro!";
                    return RedirectToAction(nameof(Index));
                }

                _Service.oRepositoryProdutoClienteManutencao.Incluir(manutencao);
                TempData["MensagemSucesso"] = "Manutenção cadastrada com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar sua manutenção, tente novamente, detalhe do erro: {ex.Message} ";
                return RedirectToAction(nameof(Index));
            }
        }

        public IActionResult Delete(int id)
        {
            try
            {
                ProdutoClienteManutencao oProdutoClienteManutencao = new();
                _Service.oRepositoryProdutoClienteManutencao.Excluir(id);
                TempData["MensagemSucesso"] = $"Manutenção excluida com sucesso!";
                return RedirectToAction("index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos excluir sua manutenção, tente novamente, detalhe do erro: {erro.Message} ";
                return RedirectToAction("Index");
            }
        }
    }
}