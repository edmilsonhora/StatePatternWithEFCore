using EF_Core.DataAccess.Contexts;
using EF_Core.DataAccess.Repositories;
using EF_Core.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core.DataAccess
{
    public class Repository : IRepository
    {
        private MyContext _context;
        public Repository()
        {
            this._context = new MyContext();
        }

        private IOrcamentoRepository _orcamentos;


        public IOrcamentoRepository Orcamentos => _orcamentos ?? (_orcamentos = new OrcamentoRepository(_context));

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
            _orcamentos = null;
        }
    }
}
