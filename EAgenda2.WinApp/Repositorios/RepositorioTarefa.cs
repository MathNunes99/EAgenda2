using EAgenda2.WinApp.Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace EAgenda2.WinApp.Repositorios
{
    
    public class RepositorioTarefa : RepositorioBase<Tarefa>
    {
        private const string EAgendaTarefa = @"C:\temp\EAgendaTarefa.bin";
        List<Tarefa> tarefas;
        private int contador = 0;


        public RepositorioTarefa()
        {
            registros = CarregarRegistrosDoArquivo(EAgendaTarefa);

            contador = registros.Count;
        }

        //CRUD -----------------------------------------------------------
        public override void Inserir(Tarefa tarefa)
        {
            tarefa.Numero = ++contador;
            registros.Add(tarefa);
            GravarRegistrosEmArquivo();
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
            GravarRegistrosEmArquivo();
        }

        public override void Excluir(Tarefa tarefa)
        {
            registros.Remove(tarefa);
            GravarRegistrosEmArquivo();
        }

        //Manipulacao De Itens -------------------------------------------
        public void AdicionarItens(Tarefa tarefaSelecionada, List<ItemTarefa> itens)
        {
            foreach (var item in itens)
            {
                tarefaSelecionada.AdicionarItem(item);
            }
            GravarRegistrosEmArquivo();
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
            GravarRegistrosEmArquivo();
        }

        //Metodos --------------------------------------------------------
        public List<Tarefa> SelecionarTodos()
        {
            tarefas = new List<Tarefa>();

            foreach (Tarefa t in registros)
            {
                tarefas.Add(t);
            }
            return tarefas;
        }                                

        public void GravarRegistrosEmArquivo()
        {
            BinaryFormatter serializador = new BinaryFormatter();

            MemoryStream ms = new MemoryStream();

            serializador.Serialize(ms, registros);

            byte[] bytes = ms.ToArray();

            File.WriteAllBytes(EAgendaTarefa, ms.ToArray());
        }

    }
}
