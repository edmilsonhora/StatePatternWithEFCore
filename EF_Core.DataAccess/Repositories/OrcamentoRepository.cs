using EF_Core.DataAccess.Contexts;
using EF_Core.DomainModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core.DataAccess.Repositories
{
   internal class OrcamentoRepository: AbstractRepository<Orcamento>, IOrcamentoRepository
    {
        public OrcamentoRepository(MyContext context):base(context)
        {

        }

        public new Orcamento ObterPor(int id)
        {
            return Context.Orcamentos.Include(p => p.HistoricoStatus).FirstOrDefault(p => p.Id.Equals(id));
        }

    }
}
