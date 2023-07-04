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
    public partial class ViewVenda
    {
        public int ProdutoVendaId { get; set; }
        public int ProdutoId { get; set; }
        [Required]
        [StringLength(50)]
        [Unicode(false)]
        public string NomeProduto { get; set; }
        [Required]
        [StringLength(500)]
        [Unicode(false)]
        public string Descricao { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal ValorUnitario { get; set; }
        [Column("codigoVenda")]
        public int CodigoVenda { get; set; }
        public int VendaId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DataVenda { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal ValorTotal { get; set; }
    }
}
