using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAgenda2.WinApp.Entidades
{
    [Serializable]
    public class Tarefa : EntidadeBase
    {
        public string Titulo { get; set; }

        private List<ItemTarefa> itens = new List<ItemTarefa>();
        public List<ItemTarefa> Itens { get { return itens; } }

        public DateTime DataCriacao;
        public DateTime? DataConclusao { get; set; }
        public int Prioridade { get; set; }

        public Tarefa()
        {
        }
        public Tarefa(string t, int n) : this()
        {
            Titulo = t;
            Numero = n;
        }

        //Métodos --------------------------------------------------
        public override string ToString()
        {
            var percentual = CalcularPercentualConcluido();

            if (DataConclusao.HasValue)
            {
                return $"Tarefa {Numero} - Título: {Titulo} / Prioridade: {prioridadeStr()}" +
                $" / Conclusão: {DataConclusao.Value.ToShortDateString()}";
            }

            return $"Tarefa {Numero} - Título: {Titulo} / Prioridade: {prioridadeStr()}" +
                $" / Criação: {DataCriacao.ToShortDateString()}" +
                $" / Conclusão: {percentual} %";
        }

        private string prioridadeStr()
        {
            string prioridadeStr = "";
            if (Prioridade == 3)
            {
                prioridadeStr = "ALTA";
            }
            else if (Prioridade == 2)
            {
                prioridadeStr = "MÉDIA";
            }
            else if (Prioridade == 1)
            {
                prioridadeStr = "BAIXA";
            }

            return prioridadeStr;
        }

        public decimal CalcularPercentualConcluido()
        {
            if (itens.Count == 0)
                return 0;

            int qtdConcluidas = itens.Count(x => x.Concluido);

            var percentualConcluido = (qtdConcluidas / (decimal)itens.Count()) * 100;

            return Math.Round(percentualConcluido, 2);
        }

        //Itens ------------------------------------------------------------------
        public void AdicionarItem(ItemTarefa item)
        {
            if (Itens.Exists(x => x.Equals(item)) == false)
                itens.Add(item);
        }

        public void ConcluirItem(ItemTarefa item)
        {
            ItemTarefa itemTarefa = itens.Find(x => x.Equals(item));

            itemTarefa?.Concluir();

            var percentual = CalcularPercentualConcluido();

            if (percentual == 100)
                DataConclusao = DateTime.Now;
        }

        public void MarcarPendente(ItemTarefa item)
        {
            ItemTarefa itemTarefa = itens.Find(x => x.Equals(item));

            itemTarefa?.MarcarPendente();
        }
    }    
}
