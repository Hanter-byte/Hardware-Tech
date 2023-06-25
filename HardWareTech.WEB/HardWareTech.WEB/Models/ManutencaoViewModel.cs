using HardWareTech.DATA.Models;

namespace HardWareTech.WEB.Models
{
    public class ManutencaoViewModel
    {
        public Produto oProduto { get; set; }
        public Cliente oCliente { get; set; }
        public Servico oServico { get; set; }
        public int idServico { get; set; }
        public int idCliente { get; set; }
        public int idProduto { get; set; }
        public DateTime dataCadastro { get; set; }
        public DateTime dataEntrega { get; set; }
        public bool Feito { get; set; }
        public string NomeManutencao { get; set; }
        public string Descricao { get; set; }
        public ProdutoClienteManutencao oProdutoClienteManutencao { get; set; }

        public List<Cliente> oListeCliente { get; set; }
        public List<Produto> oListProduto { get; set; }
        public List<Servico> oListServico { get; set; }
    }
}