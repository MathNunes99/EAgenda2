namespace EAgenda2.WinApp
{
    partial class MenuInicial
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabTarefas = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabTarefasPendentes = new System.Windows.Forms.TabPage();
            this.listTarefasPendentes = new System.Windows.Forms.ListBox();
            this.tabTarefasConcluidas = new System.Windows.Forms.TabPage();
            this.listTarefasConcluidas = new System.Windows.Forms.ListBox();
            this.tabCompromissos = new System.Windows.Forms.TabPage();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabCompromissosPassados = new System.Windows.Forms.TabPage();
            this.listCompromissosPassados = new System.Windows.Forms.ListBox();
            this.tabCompromissosFuturos = new System.Windows.Forms.TabPage();
            this.listCompromissosFuturos = new System.Windows.Forms.ListBox();
            this.tabContatos = new System.Windows.Forms.TabPage();
            this.listContatos = new System.Windows.Forms.ListBox();
            this.btnAdicionarItens = new System.Windows.Forms.Button();
            this.btnConcluirItens = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabTarefas.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabTarefasPendentes.SuspendLayout();
            this.tabTarefasConcluidas.SuspendLayout();
            this.tabCompromissos.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.tabCompromissosPassados.SuspendLayout();
            this.tabCompromissosFuturos.SuspendLayout();
            this.tabContatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "E-Agenda 2.0";
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Location = new System.Drawing.Point(12, 45);
            this.btnCadastrar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(108, 37);
            this.btnCadastrar.TabIndex = 1;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(12, 89);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(108, 37);
            this.btnEditar.TabIndex = 2;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(12, 133);
            this.btnExcluir.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(108, 37);
            this.btnExcluir.TabIndex = 3;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabTarefas);
            this.tabControl1.Controls.Add(this.tabCompromissos);
            this.tabControl1.Controls.Add(this.tabContatos);
            this.tabControl1.Location = new System.Drawing.Point(126, 45);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(425, 324);
            this.tabControl1.TabIndex = 5;
            // 
            // tabTarefas
            // 
            this.tabTarefas.Controls.Add(this.tabControl2);
            this.tabTarefas.Location = new System.Drawing.Point(4, 24);
            this.tabTarefas.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabTarefas.Name = "tabTarefas";
            this.tabTarefas.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabTarefas.Size = new System.Drawing.Size(417, 296);
            this.tabTarefas.TabIndex = 0;
            this.tabTarefas.Text = "Tarefas";
            this.tabTarefas.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabTarefasPendentes);
            this.tabControl2.Controls.Add(this.tabTarefasConcluidas);
            this.tabControl2.Location = new System.Drawing.Point(6, 7);
            this.tabControl2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(405, 285);
            this.tabControl2.TabIndex = 0;
            // 
            // tabTarefasPendentes
            // 
            this.tabTarefasPendentes.Controls.Add(this.listTarefasPendentes);
            this.tabTarefasPendentes.Location = new System.Drawing.Point(4, 24);
            this.tabTarefasPendentes.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabTarefasPendentes.Name = "tabTarefasPendentes";
            this.tabTarefasPendentes.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabTarefasPendentes.Size = new System.Drawing.Size(397, 257);
            this.tabTarefasPendentes.TabIndex = 0;
            this.tabTarefasPendentes.Text = "Tarefas Pendentes";
            this.tabTarefasPendentes.UseVisualStyleBackColor = true;
            // 
            // listTarefasPendentes
            // 
            this.listTarefasPendentes.FormattingEnabled = true;
            this.listTarefasPendentes.ItemHeight = 15;
            this.listTarefasPendentes.Location = new System.Drawing.Point(6, 7);
            this.listTarefasPendentes.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.listTarefasPendentes.Name = "listTarefasPendentes";
            this.listTarefasPendentes.Size = new System.Drawing.Size(386, 244);
            this.listTarefasPendentes.TabIndex = 5;
            // 
            // tabTarefasConcluidas
            // 
            this.tabTarefasConcluidas.Controls.Add(this.listTarefasConcluidas);
            this.tabTarefasConcluidas.Location = new System.Drawing.Point(4, 24);
            this.tabTarefasConcluidas.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabTarefasConcluidas.Name = "tabTarefasConcluidas";
            this.tabTarefasConcluidas.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabTarefasConcluidas.Size = new System.Drawing.Size(397, 257);
            this.tabTarefasConcluidas.TabIndex = 1;
            this.tabTarefasConcluidas.Text = "Tarefas Concluídas";
            this.tabTarefasConcluidas.UseVisualStyleBackColor = true;
            // 
            // listTarefasConcluidas
            // 
            this.listTarefasConcluidas.FormattingEnabled = true;
            this.listTarefasConcluidas.ItemHeight = 15;
            this.listTarefasConcluidas.Location = new System.Drawing.Point(6, 7);
            this.listTarefasConcluidas.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.listTarefasConcluidas.Name = "listTarefasConcluidas";
            this.listTarefasConcluidas.Size = new System.Drawing.Size(386, 244);
            this.listTarefasConcluidas.TabIndex = 0;
            // 
            // tabCompromissos
            // 
            this.tabCompromissos.Controls.Add(this.tabControl3);
            this.tabCompromissos.Location = new System.Drawing.Point(4, 24);
            this.tabCompromissos.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabCompromissos.Name = "tabCompromissos";
            this.tabCompromissos.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabCompromissos.Size = new System.Drawing.Size(417, 296);
            this.tabCompromissos.TabIndex = 1;
            this.tabCompromissos.Text = "Compromissos";
            this.tabCompromissos.UseVisualStyleBackColor = true;
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tabCompromissosPassados);
            this.tabControl3.Controls.Add(this.tabCompromissosFuturos);
            this.tabControl3.Location = new System.Drawing.Point(6, 7);
            this.tabControl3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(405, 285);
            this.tabControl3.TabIndex = 0;
            // 
            // tabCompromissosPassados
            // 
            this.tabCompromissosPassados.Controls.Add(this.listCompromissosPassados);
            this.tabCompromissosPassados.Location = new System.Drawing.Point(4, 24);
            this.tabCompromissosPassados.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabCompromissosPassados.Name = "tabCompromissosPassados";
            this.tabCompromissosPassados.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabCompromissosPassados.Size = new System.Drawing.Size(397, 257);
            this.tabCompromissosPassados.TabIndex = 0;
            this.tabCompromissosPassados.Text = "Compromissos Passados";
            this.tabCompromissosPassados.UseVisualStyleBackColor = true;
            // 
            // listCompromissosPassados
            // 
            this.listCompromissosPassados.FormattingEnabled = true;
            this.listCompromissosPassados.ItemHeight = 15;
            this.listCompromissosPassados.Location = new System.Drawing.Point(6, 7);
            this.listCompromissosPassados.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.listCompromissosPassados.Name = "listCompromissosPassados";
            this.listCompromissosPassados.Size = new System.Drawing.Size(386, 244);
            this.listCompromissosPassados.TabIndex = 0;
            // 
            // tabCompromissosFuturos
            // 
            this.tabCompromissosFuturos.Controls.Add(this.listCompromissosFuturos);
            this.tabCompromissosFuturos.Location = new System.Drawing.Point(4, 24);
            this.tabCompromissosFuturos.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabCompromissosFuturos.Name = "tabCompromissosFuturos";
            this.tabCompromissosFuturos.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabCompromissosFuturos.Size = new System.Drawing.Size(397, 257);
            this.tabCompromissosFuturos.TabIndex = 1;
            this.tabCompromissosFuturos.Text = "Compromissos Futuros";
            this.tabCompromissosFuturos.UseVisualStyleBackColor = true;
            // 
            // listCompromissosFuturos
            // 
            this.listCompromissosFuturos.FormattingEnabled = true;
            this.listCompromissosFuturos.ItemHeight = 15;
            this.listCompromissosFuturos.Location = new System.Drawing.Point(6, 7);
            this.listCompromissosFuturos.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.listCompromissosFuturos.Name = "listCompromissosFuturos";
            this.listCompromissosFuturos.Size = new System.Drawing.Size(386, 244);
            this.listCompromissosFuturos.TabIndex = 0;
            // 
            // tabContatos
            // 
            this.tabContatos.Controls.Add(this.listContatos);
            this.tabContatos.Location = new System.Drawing.Point(4, 24);
            this.tabContatos.Name = "tabContatos";
            this.tabContatos.Size = new System.Drawing.Size(417, 296);
            this.tabContatos.TabIndex = 2;
            this.tabContatos.Text = "Contatos";
            this.tabContatos.UseVisualStyleBackColor = true;
            // 
            // listContatos
            // 
            this.listContatos.FormattingEnabled = true;
            this.listContatos.ItemHeight = 15;
            this.listContatos.Location = new System.Drawing.Point(3, 3);
            this.listContatos.Name = "listContatos";
            this.listContatos.Size = new System.Drawing.Size(411, 289);
            this.listContatos.TabIndex = 0;
            // 
            // btnAdicionarItens
            // 
            this.btnAdicionarItens.Location = new System.Drawing.Point(12, 176);
            this.btnAdicionarItens.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAdicionarItens.Name = "btnAdicionarItens";
            this.btnAdicionarItens.Size = new System.Drawing.Size(108, 37);
            this.btnAdicionarItens.TabIndex = 6;
            this.btnAdicionarItens.Text = "Adicionar Itens";
            this.btnAdicionarItens.UseVisualStyleBackColor = true;
            this.btnAdicionarItens.Click += new System.EventHandler(this.btnAdicionarItens_Click);
            // 
            // btnConcluirItens
            // 
            this.btnConcluirItens.Location = new System.Drawing.Point(13, 219);
            this.btnConcluirItens.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnConcluirItens.Name = "btnConcluirItens";
            this.btnConcluirItens.Size = new System.Drawing.Size(108, 37);
            this.btnConcluirItens.TabIndex = 7;
            this.btnConcluirItens.Text = "Concluir Itens";
            this.btnConcluirItens.UseVisualStyleBackColor = true;
            this.btnConcluirItens.Click += new System.EventHandler(this.btnConcluirItens_Click);
            // 
            // MenuInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 383);
            this.Controls.Add(this.btnConcluirItens);
            this.Controls.Add(this.btnAdicionarItens);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "MenuInicial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MenuInicial";
            this.tabControl1.ResumeLayout(false);
            this.tabTarefas.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabTarefasPendentes.ResumeLayout(false);
            this.tabTarefasConcluidas.ResumeLayout(false);
            this.tabCompromissos.ResumeLayout(false);
            this.tabControl3.ResumeLayout(false);
            this.tabCompromissosPassados.ResumeLayout(false);
            this.tabCompromissosFuturos.ResumeLayout(false);
            this.tabContatos.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabTarefas;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabTarefasPendentes;
        private System.Windows.Forms.ListBox listTarefasPendentes;
        private System.Windows.Forms.TabPage tabTarefasConcluidas;
        private System.Windows.Forms.ListBox listTarefasConcluidas;
        private System.Windows.Forms.TabPage tabCompromissos;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage tabCompromissosPassados;
        private System.Windows.Forms.ListBox listCompromissosPassados;
        private System.Windows.Forms.TabPage tabCompromissosFuturos;
        private System.Windows.Forms.ListBox listCompromissosFuturos;
        private System.Windows.Forms.TabPage tabContatos;
        private System.Windows.Forms.ListBox listContatos;
        private System.Windows.Forms.Button btnAdicionarItens;
        private System.Windows.Forms.Button btnConcluirItens;
    }
}