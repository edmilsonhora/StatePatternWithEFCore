using EF_Core.DataAccess.Contexts;
using EF_Core.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core.DataAccess
{
   public abstract class AbstractRepository<T> : IRepositoryBase<T> where T : EntityBase
    {

        public AbstractRepository(MyContext context)
        {
            Context = context;
        }

        public MyContext Context { get; }

        public void Excluir(T entity)
        {
            Context.Remove(entity);
        }

        public T ObterPor(int id)
        {
            return Context.Set<T>().FirstOrDefault(p => p.Id.Equals(id));
        }

        public List<T> ObterTodos()
        {
            return Context.Set<T>().ToList();
        }

        public void Salvar(T entity)
        {
            if (entity.Id.Equals(0))
                Context.Set<T>().Add(entity);
        }
    }
}
