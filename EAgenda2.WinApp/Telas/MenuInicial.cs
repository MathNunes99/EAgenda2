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
            repositorioContato = new RepositorioContato();
            repositorioCompromisso = new RepositorioCompromisso();
            InitializeComponent();
            CarregarListas();
        }
        //Listas -----------------------------------------------------------
        private void CarregarListas()
        {
            CarregarTarefas();
            CarregarContato();
            CarregarCompromisso();
        }

        private void CarregarTarefas()
        {
            List<Tarefa> tarefas = repositorioTarefa.SelecionarTodos();

            List<Tarefa> tarefasOrdenadas = tarefas.OrderByDescending(x => x.Prioridade).ToList();

            listTarefasPendentes.Items.Clear();
            listTarefasConcluidas.Items.Clear();
            
            foreach (Tarefa t in tarefasOrdenadas)
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

        private void CarregarContato()
        {
            List<Contato> contatos = repositorioContato.SelecionarTodos();

            listContatosPorCargo.Items.Clear();
            listContatosPorID.Items.Clear();

            List<Contato> contatosOrdenadas = contatos.OrderByDescending(x => x.cargo).ToList();            

            foreach (Contato c in contatos)
            {
                listContatosPorID.Items.Add(c);
            }

            foreach (Contato c in contatosOrdenadas)
            {
                listContatosPorCargo.Items.Add(c);
            }
        }

        private void CarregarCompromisso()
        {
            List<Compromisso> compromissos = repositorioCompromisso.SelecionarTodos();

            List<Compromisso> compromissosPorData = compromissos.OrderBy(x => x.Dia).ToList();

            listCompromissosFuturos.Items.Clear();
            listCompromissosPassados.Items.Clear();

            foreach (Compromisso c in compromissos)
            {
                if (c.Mes >= DateTime.Now.Month)
                {
                    if (c.Dia > DateTime.Now.Day)
                    {
                        listCompromissosFuturos.Items.Add(c);
                        continue;
                    }
                }
                listCompromissosPassados.Items.Add(c);
            }
        }

        //Cadastros --------------------------------------------------------
        private void CadastrarTarefa()
        {
            TelaCadastroTarefas tela = new TelaCadastroTarefas();

            DialogResult result = tela.ShowDialog();

            string validar = ValidarTarefa(tela.Tarefa);

            if (validar != "")
            {
                MessageBox.Show(validar,
                "Cadastro de Tarefas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (result == DialogResult.OK)
            {
                if (tela.Tarefa.Prioridade == 0)
                {
                    tela.Tarefa.Prioridade = 1;
                }
                tela.Tarefa.DataCriacao = DateTime.Now;
                repositorioTarefa.Inserir(tela.Tarefa);
                CarregarListas();
            }

        }

        private void CadastrarContato()
        {
            TelaCadastroContatos tela = new TelaCadastroContatos();

            DialogResult result = tela.ShowDialog();

            string tipo = "Cadastrar";

            string validar = ValidarContato(tela.Contato, tipo);

            if (validar != "")
            {
                MessageBox.Show(validar,
                "Cadastro de Tarefas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (result == DialogResult.OK)
            {
                repositorioContato.Inserir(tela.Contato);
                CarregarListas();
            }
        }

        private void CadastrarCompromisso()
        {
            List<Contato> contatos = repositorioContato.SelecionarTodos();

            if (contatos.Count == 0)
            {
                MessageBox.Show("Não possui contatos cadastrados!",
                "Cadastro de Compromissos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroCompromisso tela = new TelaCadastroCompromisso(contatos);

            DialogResult result = tela.ShowDialog();            

            string validarCompromisso = ValidarCompromisso(tela.Compromisso);
            string validarDataCompromisso = ValidarDataCompromisso(tela.Compromisso);
            string validarHoraCompromisso = ValidarHorarios(tela.Compromisso);

            //validação
            if (validarCompromisso != "")
            {
                MessageBox.Show(validarCompromisso,
                "Cadastro de Compromissos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if(validarDataCompromisso != "")
            {
                MessageBox.Show(validarDataCompromisso,
                "Cadastro de Compromissos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (tela.Compromisso.Inicio > tela.Compromisso.Termino ||
                tela.Compromisso.Termino > 24)
            {
                MessageBox.Show("Hora de Inicio Maior que Hora de Termino",
                "Cadastro de Compromissos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if(validarHoraCompromisso != "")
            {
                MessageBox.Show(validarHoraCompromisso,
                "Cadastro de Compromissos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (result == DialogResult.OK)
            {
                repositorioCompromisso.Inserir(tela.Compromisso);
                repositorioContato.EditarCompromisso(tela.Compromisso.contato.Nome);
                CarregarListas();
            }
        }
        //Ediçoes ----------------------------------------------------------
        private void EditarTarefa()
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
                if (tela.Tarefa.Titulo == "")
                {
                    MessageBox.Show("A Tarefa Necessita de Titulo",
                    "Edição de Tarefas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                repositorioTarefa.Editar(tela.Tarefa);
                CarregarListas();
            }
        }

        private void EditarContato()
        {
            Contato contatoSelecionado = (Contato)listContatosPorCargo.SelectedItem;
            if (contatoSelecionado == null)
            {
                contatoSelecionado = (Contato)listContatosPorID.SelectedItem;
            }

            if (contatoSelecionado == null)
            {
                MessageBox.Show("Selecione um contato primeiro",
                "Edição de Contato", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroContatos tela = new TelaCadastroContatos();

            tela.Contato = contatoSelecionado;

            DialogResult result = tela.ShowDialog();

            string tipo = "editar";

            string validar = ValidarContato(tela.Contato,tipo);

            if (validar != "")
            {
                MessageBox.Show(validar,
                "Cadastro de Tarefas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (result == DialogResult.OK)
            {
                repositorioContato.Editar(tela.Contato);
                repositorioCompromisso.EditarContato(tela.Contato);
                CarregarListas();
            }
        }

        private void EditarCompromisso()
        {
            Compromisso compromissoSelecionado = (Compromisso)listCompromissosFuturos.SelectedItem;

            if (compromissoSelecionado == null)
            {
                MessageBox.Show("Selecione um compromisso primeiro",
                "Edição de Compromisso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            List<Contato> contatos = repositorioContato.SelecionarTodos();

            TelaCadastroCompromisso tela = new TelaCadastroCompromisso(contatos);

            tela.Compromisso = compromissoSelecionado;

            DialogResult result = tela.ShowDialog();            

            string validarCompromisso = ValidarCompromisso(tela.Compromisso);

            string validarDataCompromisso = ValidarDataCompromisso(tela.Compromisso);

            //validação
            if (validarCompromisso != "")
            {
                MessageBox.Show(validarCompromisso,
                "Cadastro de Compromissos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if(validarDataCompromisso != "")
            {
                MessageBox.Show(validarDataCompromisso,
                "Cadastro de Compromissos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (tela.Compromisso.Inicio > tela.Compromisso.Termino ||
                tela.Compromisso.Termino > 24)
            {
                MessageBox.Show("Hora de Inicio Maior que Hora de Termino",
                "Cadastro de Compromissos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //else if(
            else if (result == DialogResult.OK)
            {
                repositorioCompromisso.Editar(tela.Compromisso);
                CarregarListas();
            }
        }
        //Excluir ----------------------------------------------------------
        private void ExcluirTarefa()
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
                CarregarListas();
            }
        }

        private void ExcluirContato()
        {
            Contato contatoSelecionado = (Contato)listContatosPorCargo.SelectedItem;  
            if (contatoSelecionado == null)
            {
                contatoSelecionado = (Contato)listContatosPorID.SelectedItem;
            }

            if (contatoSelecionado == null)
            {
                MessageBox.Show("Selecione um contato primeiro",
                "Exclusão de Contatos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o Contato?",
                "Exclusão de Contatos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioContato.Excluir(contatoSelecionado);
                CarregarListas();
            }
        }

        private void ExcluirCompromisso()
        {
            Compromisso compromissoSelecionado = (Compromisso)listCompromissosFuturos.SelectedItem;
            if (compromissoSelecionado == null)
            {
                compromissoSelecionado = (Compromisso)listCompromissosPassados.SelectedItem;
            }

            if (compromissoSelecionado == null)
            {
                MessageBox.Show("Selecione um Compromisso primeiro",
                "Exclusão de Compromissos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o Contato?",
                "Exclusão de Contatos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioCompromisso.Excluir(compromissoSelecionado);
                CarregarListas();
            }
        }

        //Validações -------------------------------------------------------
        private string ValidarTarefa(Tarefa tarefa)
        {
            string validacao = "";

            List<Tarefa> tarefaValidacao = repositorioTarefa.SelecionarTodos();

            if (tarefa.Titulo == "")
            {
                validacao = "Defina um título";
            }
            foreach (Tarefa t in tarefaValidacao)
            {
                if (t.Titulo == tarefa.Titulo)
                {
                    validacao = "\nTitulo ja existe";
                    break;
                }
            }

            return validacao;
        }

        private string ValidarContato(Contato contato,string tipo)
        {
            string validar = "";
            if (contato.Nome == "")
            {
                validar = "Contato precisa de um NOME";                
            }
            if (ValidacaoEmail(contato.Email) == false)
            {
                validar += "\n E-Mail Invalido";
            }
            if (contato.DDD < 1)
            {
                validar += "\n DDD Invalido";
            }
            if (contato.Telefone.ToString().Length < 8 || contato.Telefone.ToString().Length > 9)
            {
                validar += "\n telefone Invalido";
            }

            if (tipo == "Cadastrar")
            {
                List<Contato> contatos = repositorioContato.SelecionarTodos();

                foreach (Contato c in contatos)
                {
                    if (c.Nome == contato.Nome)
                    {
                        validar += "\n Existe Contato com esse Nome";
                    }
                    if (c.Email == contato.Email)
                    {
                        validar += "\n Existe Contato com esse E-mail";
                    }
                    if (c.Telefone == contato.Telefone)
                    {
                        validar += "\n Existe Contato com esse Telefone";
                    }
                }
            }
            
            return validar;
        }

        private bool ValidacaoEmail(string email)
        {
            try
            {
                var enderecoEmail = new System.Net.Mail.MailAddress(email);
                return enderecoEmail.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private string ValidarCompromisso(Compromisso compromisso)
        {
            string validar = "";
            
            if (compromisso.Assunto == "")
            {
                validar = "Compromisso precisa de Assunto";
            }
            if (compromisso.Local == "")
            {
                validar += "\n Compromisso Necessita um Local";
            }
            if (compromisso.Dia == 0)
            {
                validar += "\n Compromisso Necessita um Dia";
            }
            if (compromisso.Mes == 0)
            {
                validar += "\n Compromisso Necessita um Mês";
            }
            if (compromisso.Inicio == 0 )
            {
                validar += "\n Compromisso Necessita um Horario de Inicio";
            }
            if (compromisso.Termino == 0)
            {
                validar += "\n Compromisso Necessita um Horario de Termino";
            }

            return validar;
        }

        private string ValidarDataCompromisso(Compromisso compromisso)
        {
            string validacao = "";

            int diaHoje = DateTime.Today.Day;
            int mesHoje = DateTime.Today.Month;

            if (compromisso.Mes < mesHoje)
            {
                validacao = "Mes invalido";
            }
            if (compromisso.Mes == mesHoje)
            {
                if (compromisso.Dia < diaHoje)
                {
                    validacao = "\n Dia Invalido";
                }
            }

            return validacao;
        }

        private string ValidarHorarios(Compromisso compromisso)
        {
            string validar = "";
            
            List<Compromisso> listValidar = new List<Compromisso>();
            listValidar.Clear();

            List<Compromisso> compromissos = repositorioCompromisso.SelecionarTodos();            

            int filtroDia = DateTime.Today.Day;
            int filtroMes = DateTime.Today.Month;
            //pega compromissos futuros
            foreach (Compromisso c in compromissos)
            {
                if (c.Mes < filtroMes)
                {
                    listValidar.Add(c);
                }
                if (c.Mes == filtroMes)
                {
                    if (c.Dia > filtroDia)
                    {
                        listValidar.Add(c);
                    }
                }
            }
            //valida pelos compromissos futuros
            foreach (Compromisso c in listValidar)
            {
                if (c.Inicio == compromisso.Inicio || c.Termino == compromisso.Termino)
                {
                    if(c.Dia == compromisso.Dia)
                    validar = "Ja possui compromissos marcados nesse Horario";
                }

            }
            return validar;
        }

        //Botões Tela ------------------------------------------------------
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabTarefas)
            {
                CadastrarTarefa();
            }
            else if (tabControl1.SelectedTab == tabContatos)
            {
                CadastrarContato();
            }
            else if (tabControl1.SelectedTab == tabCompromissos)
            {
                CadastrarCompromisso();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabTarefas)
            {
                EditarTarefa();
            }
            else if (tabControl1.SelectedTab == tabContatos)
            {
                EditarContato();
            }
            else if (tabControl1.SelectedTab == tabCompromissos)
            {
                EditarCompromisso();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabTarefas)
            {
                ExcluirTarefa();
            }
            else if (tabControl1.SelectedTab == tabContatos)
            {
                ExcluirContato();
            }
            else if (tabControl1.SelectedTab == tabCompromissos)
            {
                ExcluirCompromisso();
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

                CarregarListas();
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
                CarregarListas();
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            List<Compromisso> compromissos = repositorioCompromisso.SelecionarTodos();

            int filtroDia = dateTimePicker2.Value.Day;
            int filtroMes = dateTimePicker2.Value.Month;
            
            listCompromissosFuturos.Items.Clear();

            foreach (Compromisso c in compromissos)
            {                
                if (c.Mes < filtroMes)
                {
                    listCompromissosFuturos.Items.Add(c);
                }
                if (c.Mes >= filtroMes)
                {
                    if (c.Dia > filtroDia)
                    {
                        listCompromissosFuturos.Items.Add(c);
                    }
                }                
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            List<Compromisso> compromissos = repositorioCompromisso.SelecionarTodos();

            int filtroDia = dateTimePicker1.Value.Day;
            int filtroMes = dateTimePicker1.Value.Month;

            List<Compromisso> compromissosPorDia = compromissos.OrderBy(x => x.Dia).ToList();
            List<Compromisso> compromissosPorMes = compromissos.OrderBy(x => x.Mes).ToList();

            listCompromissosPassados.Items.Clear();

            foreach (Compromisso c in compromissos)
            {
                if (c.Mes < filtroMes)
                {
                    listCompromissosPassados.Items.Add(c);
                }
                else if (c.Mes == filtroMes)
                {
                    if (c.Dia <= filtroDia)
                    {
                        listCompromissosPassados.Items.Add(c);
                    }
                }                
            }
        }
    }
}
