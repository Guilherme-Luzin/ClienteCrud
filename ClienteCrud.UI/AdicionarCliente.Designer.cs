using System.Windows.Forms;

namespace ClienteCrud.UI
{
    partial class AdicionarCliente
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
            this.btnCancelar1 = new System.Windows.Forms.Button();
            this.btnSalvar1 = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtIdade = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar1.Location = new System.Drawing.Point(260, 189);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(84, 26);
            this.btnCancelar1.TabIndex = 19;
            this.btnCancelar1.Text = "Cancelar";
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnSalvar1
            // 
            this.btnSalvar1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalvar1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalvar1.Location = new System.Drawing.Point(16, 189);
            this.btnSalvar1.Name = "btnSalvar1";
            this.btnSalvar1.Size = new System.Drawing.Size(81, 26);
            this.btnSalvar1.TabIndex = 18;
            this.btnSalvar1.Text = "Salvar";
            this.btnSalvar1.UseVisualStyleBackColor = true;
            this.btnSalvar1.Click += new System.EventHandler(this.btnSalvar1_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(58, 152);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PlaceholderText = "Exemplo@exemplo.exemplo";
            this.txtEmail.Size = new System.Drawing.Size(286, 23);
            this.txtEmail.TabIndex = 17;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            // 
            // txtIdade
            // 
            this.txtIdade.Location = new System.Drawing.Point(58, 115);
            this.txtIdade.Name = "txtIdade";
            this.txtIdade.Size = new System.Drawing.Size(286, 23);
            this.txtIdade.TabIndex = 16;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(58, 66);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(286, 23);
            this.txtNome.TabIndex = 15;
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(90, 28);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(254, 23);
            this.txtId.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "Id do cliente";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "Idade";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Nome";
            // 
            // AdicionarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 227);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnSalvar1);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtIdade);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AdicionarCliente";
            this.Text = "AdicionarCliente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnCancelar1;
        private Button btnSalvar1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtEmail;
        private TextBox txtIdade;
        private TextBox txtNome;
        private TextBox txtId;
    }
}