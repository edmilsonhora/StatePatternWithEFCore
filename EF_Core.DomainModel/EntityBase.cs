using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core.DomainModel
{
    public class EntityBase
    {
        protected StringBuilder RegrasQuebradas = new StringBuilder();
        public int Id { get; set; }
        public string CadastradoPor { get; set; }
        public string AtualizadoPor { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }

        public virtual void Validar()
        {
            CampoTextoObrigatorio(nameof(AtualizadoPor), AtualizadoPor);

            if (RegrasQuebradas.Length > 0)
                throw new ApplicationException(RegrasQuebradas.ToString());
        }

        public void RegistraAlteracao()
        {
            if (Id.Equals(0))
            {
                CadastradoPor = AtualizadoPor;
                DataCadastro = DateTime.Now;
            }

            DataAtualizacao = DateTime.Now;
        }

        protected void CampoTextoObrigatorio(string nomeDoCampo, string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                RegrasQuebradas.Append($"O campo {nomeDoCampo} é obrigatório.{Environment.NewLine}");
        }

        protected void CampoNumericoMaiorQueZero(string nomeDoCampo, decimal valor)
        {
            if (valor < 1m)
                RegrasQuebradas.Append($"O campo {nomeDoCampo} deve ter valor maior que zero.{Environment.NewLine}");
        }

        protected void CampoDataNaoPodeEstarNoPassado(string nomeDoCampo, DateTime valor)
        {
            if (DateTime.Today > valor)
                RegrasQuebradas.Append($"O campo {nomeDoCampo} só aceita datas futuras.{Environment.NewLine}");
        }
    }

    public interface IRepositoryBase<T> where T : EntityBase
    {
        public void Salvar(T entity);
        public void Excluir(T entity);
        public T ObterPor(int id);
        public List<T> ObterTodos();
    }

    public interface IRepository
    {
        public IOrcamentoRepository Orcamentos { get;}
        void SaveChanges();
        void Rollback();
    }
}
