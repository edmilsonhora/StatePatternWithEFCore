using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core.DomainModel
{
   public class Orcamento :EntityBase 
    {
        public Orcamento()
        {
            HistoricoStatus = new List<AbstractOrcamentoState>();
        }
        public DateTime Data { get; set; }
        public string Cliente { get; set; }
        public decimal Valor { get; set; }
        public OrcamentoState  StatusAtual { get; set; }
        public List<AbstractOrcamentoState> HistoricoStatus { get; set; }

        public void DefinirStatus(OrcamentoState status)
        {
            var statusDefinido = AbstractOrcamentoState.Factory.Obter(status);
            RegistrarStatus(statusDefinido);
        }

        public void StatusInicial()
        {
            if(Id.Equals(0))
            {
                var statusInicial = AbstractOrcamentoState.Factory.Obter(OrcamentoState.Novo);
                RegistrarStatus(statusInicial);
            }
        }

        public void ProximoStatus()
        {
            var proximoStatus = AbstractOrcamentoState.Factory.Obter(StatusAtual).Proximo();
            RegistrarStatus(proximoStatus);
        }

        public void AnteriorStatus()
        {
            var anteriorStatus = AbstractOrcamentoState.Factory.Obter(StatusAtual).Anterior();
            RegistrarStatus(anteriorStatus);
              
        }

        private void RegistrarStatus(AbstractOrcamentoState status)
        {
            status.AtualizadoPor = this.AtualizadoPor;
            status.RegistraAlteracao();
            status.Validar();
            HistoricoStatus.Add(status);
            StatusAtual = status.Status;
        }
        public override void Validar()
        {
            CampoTextoObrigatorio(nameof(Cliente), Cliente);
            CampoNumericoMaiorQueZero(nameof(Valor), Valor);
            CampoDataNaoPodeEstarNoPassado(nameof(Data), Data);
            base.Validar();
        }
    }

    public interface IOrcamentoRepository : IRepositoryBase<Orcamento> { }
}
