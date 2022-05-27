using EF_Core.DataAccess;
using EF_Core.DomainModel;
using System;

namespace EF_Core.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {

                var repository = new Repository();
                //CriarOrcamento(repository);

                var o = repository.Orcamentos.ObterPor(3);
                o.ProximoStatus();
                repository.SaveChanges();


                foreach (var item in o.HistoricoStatus)
                {
                    Console.WriteLine(item.Status.ToString());
                }

                Console.ReadKey();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }


        static void CriarOrcamento(Repository repository)
        {
            var orcamento = new Orcamento();
            orcamento.Data = DateTime.Now;
            orcamento.Cliente = "Cliente 005";
            orcamento.Valor = 2000m;
            orcamento.AtualizadoPor = "Edmilson";
            orcamento.StatusInicial();
            orcamento.RegistraAlteracao();
            orcamento.Validar();

            repository.Orcamentos.Salvar(orcamento);
            repository.SaveChanges();
        }
    }
}
