﻿using HardWareTech.DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardWareTech.DATA.Interfaces
{
    internal interface IRepositoryProdutoVenda : IRepositoryModel<ProdutoVenda>
    {
        void IncluirProdutosDaVenda(List<ProdutoVenda> produtosVendas);
    }
}