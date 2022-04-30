using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAgenda2.WinApp.Entidades
{
    public class Tarefa : EntidadeBase
    {
        public string Titulo { get; set; }

        private List<ItemTarefa> itens = new List<ItemTarefa>();
        public List<ItemTarefa> Itens { get { return itens; } }
        public DateTime? DataConclusao { get; set; }

        public Tarefa()
        {
        }
        public Tarefa(string t, int n) : this()
        {
            Titulo = t;
            Numero = n;
        }
        public override string ToString()
        {                      
            return $"Número: {Numero}, Título: {Titulo}";
        }
        public decimal CalcularPercentualConcluido()
        {
            if (itens.Count == 0)
                return 0;

            int qtdConcluidas = itens.Count(x => x.Concluido);

            var percentualConcluido = (qtdConcluidas / (decimal)itens.Count()) * 100;

            return Math.Round(percentualConcluido, 2);
        }

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
