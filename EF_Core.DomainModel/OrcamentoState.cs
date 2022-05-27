using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core.DomainModel
{
    public enum OrcamentoState
    {
        Novo,
        EmAprovacao,
        Aprovado,
        Cancelado,
        Reprovado
    }

    public abstract class AbstractOrcamentoState : EntityBase
    {
        public abstract AbstractOrcamentoState Proximo();
        public abstract AbstractOrcamentoState Anterior();

        [NotMapped]
        public OrcamentoState Status { get; set; }
        public int OrcamentoId { get; set; }

        public static class Factory
        {
            public static AbstractOrcamentoState Obter(OrcamentoState statusAtual)
            {
                switch (statusAtual)
                {
                    case OrcamentoState.Novo:
                        return new Novo();
                    case OrcamentoState.EmAprovacao:
                        return new EmAprovacao();
                    case OrcamentoState.Aprovado:
                        return new Aprovado();
                    case OrcamentoState.Cancelado:
                        return new Cancelado();
                    case OrcamentoState.Reprovado:
                        return new Reprovado();                       
                    default:
                        throw new ApplicationException("Não existe status para o orçamento.");
                }
            }
        }
    }

    public class Novo:AbstractOrcamentoState
    {
        public Novo()
        {
            Status = OrcamentoState.Novo;
        }

        public override AbstractOrcamentoState Anterior()
        {
            throw new ApplicationException("Não existe status anterior a Novo.");
        }

        public override AbstractOrcamentoState Proximo()
        {
            return new EmAprovacao();
        }
    }

    public class EmAprovacao:AbstractOrcamentoState
    {
        public EmAprovacao()
        {
            Status = OrcamentoState.EmAprovacao;
        }

        public override AbstractOrcamentoState Anterior()
        {
            return new Novo();
        }

        public override AbstractOrcamentoState Proximo()
        {
            return new Aprovado();
        }
    }

    public class Aprovado:AbstractOrcamentoState
    {
        public Aprovado()
        {
            Status = OrcamentoState.Aprovado;
        }

        public override AbstractOrcamentoState Anterior()
        {
            return new EmAprovacao();
        }

        public override AbstractOrcamentoState Proximo()
        {
            return new Cancelado();
        }
    }

    public class Reprovado:AbstractOrcamentoState
    {
        public Reprovado()
        {
            Status = OrcamentoState.Reprovado;
        }

        public override AbstractOrcamentoState Anterior()
        {
            return new EmAprovacao();
        }

        public override AbstractOrcamentoState Proximo()
        {
            throw new ApplicationException("Não é permitido alterar o status.");
        }
    }

    public class Cancelado:AbstractOrcamentoState
    {
        public Cancelado()
        {
            Status = OrcamentoState.Cancelado;
        }

        public override AbstractOrcamentoState Anterior()
        {
            return new EmAprovacao();
        }

        public override AbstractOrcamentoState Proximo()
        {
            throw new ApplicationException("Não é permitido alterar o status.");
        }
    }
}
