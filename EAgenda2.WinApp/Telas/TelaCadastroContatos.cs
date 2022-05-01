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
    public partial class TelaCadastroContatos : Form
    {
        private Contato contato = new Contato();


        public TelaCadastroContatos()
        {
            InitializeComponent();
        }


        public Contato Contato
        {
            get
            {
                return contato;
            }
            set
            {
                contato = value;
                txtNome.Text = contato.Nome;
                txtEmail.Text = contato.Email;                
                txtDDD.Text = contato.DDD.ToString();
                txtTelefone.Text = contato.Telefone.ToString();
                txtEmpresa.Text = contato.Empresa;
                if (contato.cargo == 3)
                {
                    checkDiretor.Checked = true;
                }
                else if (contato.cargo == 2)
                {
                    checkGerente.Checked = true;
                }
                else if (contato.cargo == 1)
                {
                    checkAssistente.Checked = true;
                }
            }
        }

        //Botões e Checks Tela ----------------------------------------------------
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            contato.Nome = txtNome.Text;
            contato.Email = txtEmail.Text;

            string ddd = txtDDD.Text;
            int.TryParse(ddd, out int testeDDD);
            contato.DDD = testeDDD;

            string telefone = txtTelefone.Text;
            int.TryParse(telefone, out int testeTelefone);
            contato.Telefone = testeTelefone;

            contato.Empresa = txtEmpresa.Text;
        }

        private void checkDiretor_CheckedChanged(object sender, EventArgs e)
        {
            contato.cargo = 3;
        }

        private void checkGerente_CheckedChanged(object sender, EventArgs e)
        {
            contato.cargo = 2;
        }

        private void checkAssistente_CheckedChanged(object sender, EventArgs e)
        {
            contato.cargo = 1;
        }
    }
}
