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
    public partial class VwProdutoClienteManutencao
    {
        [Required]
        [Column("CPF")]
        [StringLength(14)]
        [Unicode(false)]
        public string Cpf { get; set; }
        [Column("nome_produto")]
        [StringLength(100)]
        [Unicode(false)]
        public string NomeProduto { get; set; }
        [Column("id")]
        public int Id { get; set; }
        [Column("idCliente")]
        public int IdCliente { get; set; }
        [Column("idProduto")]
        public int IdProduto { get; set; }
        [Column("dataCadastro", TypeName = "datetime")]
        public DateTime DataCadastro { get; set; }
        [Required]
        [Column("nome_cliente")]
        [StringLength(50)]
        [Unicode(false)]
        public string NomeCliente { get; set; }
        [Column("dataFinalizacao", TypeName = "datetime")]
        public DateTime DataFinalizacao { get; set; }
        public bool Feito { get; set; }
    }
}