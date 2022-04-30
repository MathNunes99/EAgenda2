using EAgenda2.WinApp.Entidades;
using EAgenda2.WinApp.Repositorios;
using EAgenda2.WinApp.Telas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EAgenda2.WinApp
{
    public partial class MenuInicial : Form
    {
        RepositorioTarefa repositorioTarefa;
        RepositorioContato repositorioContato;
        RepositorioCompromisso repositorioCompromisso;
        public MenuInicial()
        {
            repositorioTarefa = new RepositorioTarefa();
            InitializeComponent();
            CarregarTarefas();
        }

        private void CarregarTarefas()
        {
            List<Tarefa> tarefas = repositorioTarefa.SelecionarTodos();

            listTarefasPendentes.Items.Clear();

            foreach (Tarefa t in tarefas)
            {
                if (t.CalcularPercentualConcluido() < 100)
                {
                    listTarefasPendentes.Items.Add(t);
                }
                else if (t.CalcularPercentualConcluido() == 100)
                {
                    listTarefasConcluidas.Items.Add(t);
                }
            }
        }
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabTarefas)
            {
                if (tabControl2.SelectedTab == tabTarefasPendentes)
                {
                    TelaCadastroTarefas tela = new TelaCadastroTarefas();

                    DialogResult result = tela.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        repositorioTarefa.Inserir(tela.Tarefa);
                        CarregarTarefas();
                    }
                }
            }
        }

        private void btnAdicionarItens_Click(object sender, EventArgs e)
        {
            Tarefa tarefaSelecionada = (Tarefa)listTarefasPendentes.SelectedItem;
            if(tarefaSelecionada == null)
            tarefaSelecionada = (Tarefa)listTarefasConcluidas.SelectedItem;

            if (tarefaSelecionada == null)
            {
                MessageBox.Show("Selecione uma tarefa primeiro",
                "Edição de Tarefas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroItens tela = new TelaCadastroItens(tarefaSelecionada);

            if (tela.ShowDialog() == DialogResult.OK)
            {
                List<ItemTarefa> itens = tela.ItensAdicionados;

                repositorioTarefa.AdicionarItens(tarefaSelecionada, itens);

                CarregarTarefas();
            }
        }

        private void btnConcluirItens_Click(object sender, EventArgs e)
        {
            Tarefa tarefaSelecionada = (Tarefa)listTarefasPendentes.SelectedItem;

            if (tarefaSelecionada == null)
            {
                MessageBox.Show("Selecione uma tarefa primeiro",
                "Edição de Tarefas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            AtualizacaoItensTarefa tela = new AtualizacaoItensTarefa(tarefaSelecionada);

            if (tela.ShowDialog() == DialogResult.OK)
            {
                List<ItemTarefa> itensConcluidos = tela.ItensConcluidos;

                List<ItemTarefa> itensPendentes = tela.ItensPendentes;

                repositorioTarefa.AtualizarItens(tarefaSelecionada, itensConcluidos, itensPendentes);
                CarregarTarefas();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Tarefa tarefaSelecionada = (Tarefa)listTarefasPendentes.SelectedItem;

            if (tarefaSelecionada == null)
            {
                MessageBox.Show("Selecione uma tarefa primeiro",
                "Edição de Tarefas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroTarefas tela = new TelaCadastroTarefas();

            tela.Tarefa = tarefaSelecionada;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                repositorioTarefa.Editar(tela.Tarefa);
                CarregarTarefas();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Tarefa tarefaSelecionada = (Tarefa)listTarefasPendentes.SelectedItem;
            if (tarefaSelecionada == null)
            {
                tarefaSelecionada = (Tarefa)listTarefasConcluidas.SelectedItem;
            }

            if (tarefaSelecionada == null)
            {
                MessageBox.Show("Selecione uma tarefa primeiro",
                "Exclusão de Tarefas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir a tarefa?",
                "Exclusão de Tarefas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioTarefa.Excluir(tarefaSelecionada);
                CarregarTarefas();
            }
        }
    }
}
