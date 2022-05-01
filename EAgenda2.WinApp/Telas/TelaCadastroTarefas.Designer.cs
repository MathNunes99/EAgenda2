namespace EAgenda2.WinApp.Telas
{
    partial class TelaCadastroTarefas
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
            this.labelTitulo = new System.Windows.Forms.Label();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.checkAlta = new System.Windows.Forms.CheckBox();
            this.checkMedia = new System.Windows.Forms.CheckBox();
            this.checkBaixa = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tela Cadastro de Tarefas";
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Location = new System.Drawing.Point(14, 43);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(37, 15);
            this.labelTitulo.TabIndex = 3;
            this.labelTitulo.Text = "Titulo";
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(57, 39);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(257, 23);
            this.txtTitulo.TabIndex = 4;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnConfirmar.Location = new System.Drawing.Point(186, 128);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmar.TabIndex = 5;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(267, 128);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // checkAlta
            // 
            this.checkAlta.AutoSize = true;
            this.checkAlta.Location = new System.Drawing.Point(14, 99);
            this.checkAlta.Name = "checkAlta";
            this.checkAlta.Size = new System.Drawing.Size(47, 19);
            this.checkAlta.TabIndex = 7;
            this.checkAlta.Text = "Alta";
            this.checkAlta.UseVisualStyleBackColor = true;
            this.checkAlta.CheckedChanged += new System.EventHandler(this.checkAlta_CheckedChanged);
            // 
            // checkMedia
            // 
            this.checkMedia.AutoSize = true;
            this.checkMedia.Location = new System.Drawing.Point(67, 99);
            this.checkMedia.Name = "checkMedia";
            this.checkMedia.Size = new System.Drawing.Size(59, 19);
            this.checkMedia.TabIndex = 8;
            this.checkMedia.Text = "Média";
            this.checkMedia.UseVisualStyleBackColor = true;
            this.checkMedia.CheckedChanged += new System.EventHandler(this.checkMedia_CheckedChanged);
            // 
            // checkBaixa
            // 
            this.checkBaixa.AutoSize = true;
            this.checkBaixa.Location = new System.Drawing.Point(129, 99);
            this.checkBaixa.Name = "checkBaixa";
            this.checkBaixa.Size = new System.Drawing.Size(54, 19);
            this.checkBaixa.TabIndex = 9;
            this.checkBaixa.Text = "Baixa";
            this.checkBaixa.UseVisualStyleBackColor = true;
            this.checkBaixa.CheckedChanged += new System.EventHandler(this.checkBaixa_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "Prioridade";
            // 
            // TelaCadastroTarefas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 163);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkBaixa);
            this.Controls.Add(this.checkMedia);
            this.Controls.Add(this.checkAlta);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.txtTitulo);
            this.Controls.Add(this.labelTitulo);
            this.Controls.Add(this.label1);
            this.Name = "TelaCadastroTarefas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TelaCadastroTarefas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.CheckBox checkAlta;
        private System.Windows.Forms.CheckBox checkMedia;
        private System.Windows.Forms.CheckBox checkBaixa;
        private System.Windows.Forms.Label label2;
    }
}