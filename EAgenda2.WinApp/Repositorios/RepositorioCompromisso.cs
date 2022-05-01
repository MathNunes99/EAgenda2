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
    public class RepositorioCompromisso : RepositorioBase<Compromisso>
    {
        private const string EAgendaCompromisso = @"C:\temp\EAgendaCompromisso.bin";
        private int contador = 0;
        List<Compromisso> compromissos;

        public RepositorioCompromisso()
        {
            registros = CarregarRegistrosDoArquivo(EAgendaCompromisso);

            contador = registros.Count;
        }
        //Crud --------------------------------------------------------
        public override void Inserir(Compromisso compromisso)
        {
            compromisso.Numero = ++contador;
            registros.Add(compromisso);
            GravarRegistrosEmArquivo();
        }

        public override void Editar(Compromisso compromisso)
        {
            foreach (var item in registros)
            {
                if (item.Numero == compromisso.Numero)
                {
                    item.Local = compromisso.Local;
                    item.Assunto = compromisso.Assunto;
                    item.Dia = compromisso.Dia;
                    item.Mes = compromisso.Mes;
                    item.Inicio = compromisso.Inicio;
                    item.Termino = compromisso.Termino;
                    item.ContatoNome = compromisso.ContatoNome;
                    break;
                }
            }
            GravarRegistrosEmArquivo();
        }

        public override void Excluir(Compromisso compromisso)
        {
            registros.Remove(compromisso);
            GravarRegistrosEmArquivo();
        }

        //Metodos -----------------------------------------------------
        public List<Compromisso> SelecionarTodos()
        {
            compromissos = new List<Compromisso>();

            foreach (Compromisso c in registros)
            {
                compromissos.Add(c);
            }
            return compromissos;
        }

        public void GravarRegistrosEmArquivo()
        {
            BinaryFormatter serializador = new BinaryFormatter();

            MemoryStream ms = new MemoryStream();

            serializador.Serialize(ms, registros);

            byte[] bytes = ms.ToArray();

            File.WriteAllBytes(EAgendaCompromisso, ms.ToArray());
        }
    }
}
