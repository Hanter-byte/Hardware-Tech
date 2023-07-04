using HardWareTech.DATA.Interfaces;
using HardWareTech.DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardWareTech.DATA.Repositories
{
    public class RepositoryCliente : RepositoryBase<Cliente>, IRepositoryCliente
    {
        public RepositoryCliente(bool SaveChanges = true) : base(SaveChanges)
        {

        }

        public Cliente SelecionarClienteByCPF(string cpf)
        {
            return _Contexto.Cliente.Where(x => x.Cpf.Equals(cpf)).FirstOrDefault();
        }
    }
}