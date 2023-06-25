
#nullable disable
using HardWareTech.DATA.Interfaces;
using HardWareTech.DATA.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HardWareTech.DATA.Repositories
{
    public class RepositoryBase<T> : IRepositoryModel<T>, IDisposable where T : class
    {
        protected ControleManutencaoContext _Contexto;
        public bool _SaveChanges = true;

        public RepositoryBase(bool saveChanges = true)
        {
            _SaveChanges = saveChanges;
            _Contexto = new ControleManutencaoContext();
        }

        public T Alterar(T objeto)
        {
            _Contexto.Entry(objeto).State = EntityState.Modified;
            if (_SaveChanges)
            {
                _Contexto.SaveChanges();
            }
            return objeto;
        }

        public void Dispose()
        {
            _Contexto.Dispose();
        }

        public void Excluir(T objeto)
        {
            _Contexto.Set<T>().Remove(objeto);
            if (_SaveChanges)
            {
                _Contexto.SaveChanges();
            }
        }

        public void Excluir(params object[] variavel)
        {
           var objeto = SelecionarPk(variavel);
            Excluir(objeto);
        }

        public T Incluir(T objeto)
        {
            _Contexto.Set<T>().Add(objeto);
            if (_SaveChanges)
            {
                _Contexto.SaveChanges();
            }
            return objeto;
        }

        public void SaveChages()
        {
            _Contexto.SaveChanges();
        }

        public T SelecionarPk(params object[] variavel)
        {
            return _Contexto.Set<T>().Find(variavel);
        }

        public List<T> SelecionarTodos()
        {
            return _Contexto.Set<T>().ToList();
        }
    }
}