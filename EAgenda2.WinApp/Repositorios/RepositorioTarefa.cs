using EAgenda2.WinApp.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAgenda2.WinApp.Repositorios
{
    public class RepositorioTarefa : RepositorioBase<Tarefa>
    {
        List<Tarefa> tarefasPendentes;
        List<Tarefa> tarefasConcluidas;
        public List<Tarefa> SelecionarTodos()
        {
            tarefasPendentes = new List<Tarefa>();

            foreach (Tarefa t in registros)
            {
                tarefasPendentes.Add(t);
            }
            return tarefasPendentes;
        }
        public void AdicionarItens(Tarefa tarefaSelecionada, List<ItemTarefa> itens)
        {
            foreach (var item in itens)
            {
                tarefaSelecionada.AdicionarItem(item);
            }            
        }
        public void AtualizarItens(Tarefa tarefaSelecionada,
            List<ItemTarefa> itensConcluidos, List<ItemTarefa> itensPendentes)
        {
            foreach (var item in itensConcluidos)
            {
                tarefaSelecionada.ConcluirItem(item);
            }

            foreach (var item in itensPendentes)
            {
                tarefaSelecionada.MarcarPendente(item);
            }            
        }
        public override void Editar(Tarefa tarefa)
        {
            foreach (var item in registros)
            {
                if (item.Numero == tarefa.Numero)
                {
                    item.Titulo = tarefa.Titulo;
                    break;
                }
            }
        }
        public override void Excluir(Tarefa tarefa)
        {
            registros.Remove(tarefa);            
        }
    }
}
