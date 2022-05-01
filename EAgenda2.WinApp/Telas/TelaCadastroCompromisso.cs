using EAgenda2.WinApp.Entidades;
using EAgenda2.WinApp.Repositorios;
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
    public partial class TelaCadastroCompromisso : Form
    {
        Compromisso compromisso = new Compromisso();        


        public TelaCadastroCompromisso(List<Contato> contatos)
        {            
            InitializeComponent();
            foreach (Contato contato in contatos)
            {
                cBoxContato.Items.Add(contato.Nome);
            }
        }        

        public Compromisso Compromisso
        {
            get
            {
                return compromisso;
            }
            set
            {
                compromisso = value;                
                txtAssunto.Text = compromisso.Assunto;
                txtLocal.Text = compromisso.Local;
                txtDia.Text = compromisso.Dia.ToString();
                txtMes.Text = compromisso.Mes.ToString();
                txtInicio.Text = compromisso.Inicio.ToString();
                txtTermino.Text = compromisso.Termino.ToString();
                cBoxContato.Text = compromisso.ContatoNome;
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            compromisso.Assunto = txtAssunto.Text;
            compromisso.Local = txtLocal.Text;
            string dia = txtDia.Text;
            compromisso.Dia = Convert.ToInt32(dia);
            string mes = txtMes.Text;
            compromisso.Mes = Convert.ToInt32(mes);
            string inicio = txtInicio.Text;
            compromisso.Inicio = Convert.ToInt32(inicio);
            string termino = txtTermino.Text;
            compromisso.Termino = Convert.ToInt32(termino);
            compromisso.ContatoNome = cBoxContato.Text;
        }
    }
}
