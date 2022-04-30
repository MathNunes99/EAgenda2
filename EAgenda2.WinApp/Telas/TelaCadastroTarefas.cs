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
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            tarefa.Titulo = txtTitulo.Text;
            tarefa.Numero = ++contadorTarefa;
        }
    }
}
