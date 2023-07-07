﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HardWareTech.DATA.Models
{
    [Keyless]
    public partial class VwProdutoClienteVenda
    {
        [Required]
        [Column("CPF")]
        [StringLength(14)]
        [Unicode(false)]
        public string Cpf { get; set; }
        [Required]
        [Column("nome_cliente")]
        [StringLength(50)]
        [Unicode(false)]
        public string NomeCliente { get; set; }
        [Column("ProdutoVendaID")]
        public int ProdutoVendaId { get; set; }
        [Column("valorUnitario", TypeName = "decimal(10, 2)")]
        public decimal ValorUnitario { get; set; }
        [Column("idVenda")]
        public int IdVenda { get; set; }
        [Column("VendaID")]
        public int VendaId { get; set; }
        [Column("dataVenda", TypeName = "datetime")]
        public DateTime DataVenda { get; set; }
        [Column("valorTotal", TypeName = "decimal(10, 2)")]
        public decimal ValorTotal { get; set; }
        public int Expr3 { get; set; }
    }
}