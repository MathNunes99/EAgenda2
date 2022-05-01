using EAgenda2.WinApp.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EAgenda2.WinApp.Telas
{
    public partial class TelaCadastroTarefas : Form
    {
        private Tarefa tarefa = new Tarefa();
        private int contadorTarefa;


        public TelaCadastroTarefas()
        {            
            InitializeComponent();
        }

        public Tarefa Tarefa
        {
            get
            {
                return tarefa;
            }
            set
            {
                tarefa = value;
                txtTitulo.Text = tarefa.Titulo;
                if (tarefa.Prioridade == 3)
                {
                    checkAlta.Checked = true;
                }
                else if (tarefa.Prioridade == 2)
                {
                    checkMedia.Checked = true;
                }
                else if (tarefa.Prioridade == 1)
                {
                    checkBaixa.Checked = true;
                }
            }
        }
        //Botoes e Check Tela ------------------------------------------------
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            tarefa.Titulo = txtTitulo.Text;
            tarefa.Numero = ++contadorTarefa;            
        }

        private void checkAlta_CheckedChanged(object sender, EventArgs e)
        {
            tarefa.Prioridade = 3;
        }

        private void checkMedia_CheckedChanged(object sender, EventArgs e)
        {
            tarefa.Prioridade = 2;
        }

        private void checkBaixa_CheckedChanged(object sender, EventArgs e)
        {
            tarefa.Prioridade = 1;
        }
    }
}
