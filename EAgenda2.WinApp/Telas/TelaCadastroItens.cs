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
    public partial class TelaCadastroItens : Form
    {
        private readonly Tarefa tarefa;

        public TelaCadastroItens(Tarefa tarefaSelecionada)
        {
            InitializeComponent();

            this.tarefa = tarefaSelecionada;

            labelTituloTarefa.Text = tarefa.Titulo;

            foreach (ItemTarefa item in tarefa.Itens)
            {
                listItensTarefa.Items.Add(item);
            }
        }
        public List<ItemTarefa> ItensAdicionados
        {
            get
            {
                return listItensTarefa.Items.Cast<ItemTarefa>().ToList();
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            List<string> titulos = ItensAdicionados.Select(x => x.Titulo).ToList();

            if (titulos.Count == 0 || titulos.Contains(txtTituloItem.Text) == false)
            {
                ItemTarefa itemTarefa = new ItemTarefa();

                itemTarefa.Titulo = txtTituloItem.Text;

                listItensTarefa.Items.Add(itemTarefa);
            }
        }        
    }
}
