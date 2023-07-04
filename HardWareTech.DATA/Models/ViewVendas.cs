using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardWareTech.DATA.Models
{
    [Keyless]
    public partial class ViewVendas
    {
        [Required]
        [Column("nome_cliente")]
        [StringLength(100)]
        [Unicode(false)]
        public string Nome { get; set; }
        [Required]
        [Column("cpf")]
        [StringLength(14)]
        [Unicode(false)]
        public string Cpf { get; set; }
        [Column("id")]
        public int Id { get; set; }
        [Column("idProduto")]
        public int IdProduto { get; set; }
        [Column("quantidade")]
        public int Quantidade { get; set; }
        [Column("valorUnitario", TypeName = "decimal(10, 2)")]
        public decimal ValorUnitario { get; set; }
        [Column("idVenda")]
        public int IdVenda { get; set; }
        public int Expr1 { get; set; }
        [Column("idCliente")]
        public int IdCliente { get; set; }
        [Column("valorTotal", TypeName = "decimal(10, 2)")]
        public decimal ValorTotal { get; set; }
        [Column("dataVenda", TypeName = "datetime")]
        public DateTime DataVenda { get; set; }
        public int Expr2 { get; set; }
        public int Expr3 { get; set; }
        public int Expr4 { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Expr5 { get; set; }
        public int Expr6 { get; set; }
        [Required]
        [StringLength(50)]
        [Unicode(false)]
        public string Expr7 { get; set; }
        [Column("preco", TypeName = "decimal(10, 2)")]
        public decimal Preco { get; set; }
    }
}
