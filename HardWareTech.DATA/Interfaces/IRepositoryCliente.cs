using HardWareTech.DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardWareTech.DATA.Interfaces
{
    public interface IRepositoryCliente : IRepositoryModel<Cliente>
    {
        Cliente SelecionarClienteByCPF(string cpf);
    }
}