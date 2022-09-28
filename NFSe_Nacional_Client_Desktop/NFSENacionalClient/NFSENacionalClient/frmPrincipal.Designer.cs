namespace NFSENacionalClient
{
    partial class frmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDecodar = new System.Windows.Forms.Button();
            this.btnEncodar = new System.Windows.Forms.Button();
            this.txtMesAno = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNumeroNFSe = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnVerificarCertificadoDigital = new System.Windows.Forms.Button();
            this.btnRecuperarDANFSe = new System.Windows.Forms.Button();
            this.btnConsultarEvento = new System.Windows.Forms.Button();
            this.btnRegistrarEvento = new System.Windows.Forms.Button();
            this.btnConcsultarNFSePelaChave = new System.Windows.Forms.Button();
            this.btnTransmitirArquivoExistente = new System.Windows.Forms.Button();
            this.btnAssinarArquivoExistente = new System.Windows.Forms.Button();
            this.btnGerarEnviarNFSE = new System.Windows.Forms.Button();
            this.btnGerarEnviarDPS = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.richGerado = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.richResultado = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::NFSENacionalClient.Properties.Resources.logo_mxm_sistemas;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1008, 240);
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDecodar);
            this.groupBox1.Controls.Add(this.btnEncodar);
            this.groupBox1.Controls.Add(this.txtMesAno);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtNumeroNFSe);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnVerificarCertificadoDigital);
            this.groupBox1.Controls.Add(this.btnRecuperarDANFSe);
            this.groupBox1.Controls.Add(this.btnConsultarEvento);
            this.groupBox1.Controls.Add(this.btnRegistrarEvento);
            this.groupBox1.Controls.Add(this.btnConcsultarNFSePelaChave);
            this.groupBox1.Controls.Add(this.btnTransmitirArquivoExistente);
            this.groupBox1.Controls.Add(this.btnAssinarArquivoExistente);
            this.groupBox1.Controls.Add(this.btnGerarEnviarNFSE);
            this.groupBox1.Controls.Add(this.btnGerarEnviarDPS);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 240);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1008, 152);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ações";
            // 
            // btnDecodar
            // 
            this.btnDecodar.Location = new System.Drawing.Point(471, 78);
            this.btnDecodar.Name = "btnDecodar";
            this.btnDecodar.Size = new System.Drawing.Size(226, 23);
            this.btnDecodar.TabIndex = 14;
            this.btnDecodar.Text = "Decodar";
            this.btnDecodar.UseVisualStyleBackColor = true;
            this.btnDecodar.Click += new System.EventHandler(this.btnDecodar_Click);
            // 
            // btnEncodar
            // 
            this.btnEncodar.Location = new System.Drawing.Point(239, 77);
            this.btnEncodar.Name = "btnEncodar";
            this.btnEncodar.Size = new System.Drawing.Size(226, 23);
            this.btnEncodar.TabIndex = 13;
            this.btnEncodar.Text = "Encodar";
            this.btnEncodar.UseVisualStyleBackColor = true;
            this.btnEncodar.Click += new System.EventHandler(this.btnEncodar_Click);
            // 
            // txtMesAno
            // 
            this.txtMesAno.Location = new System.Drawing.Point(302, 121);
            this.txtMesAno.Mask = "99/9999";
            this.txtMesAno.Name = "txtMesAno";
            this.txtMesAno.Size = new System.Drawing.Size(55, 20);
            this.txtMesAno.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(208, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Mês (MM/AAAA)";
            // 
            // txtNumeroNFSe
            // 
            this.txtNumeroNFSe.Location = new System.Drawing.Point(102, 118);
            this.txtNumeroNFSe.Name = "txtNumeroNFSe";
            this.txtNumeroNFSe.Size = new System.Drawing.Size(100, 20);
            this.txtNumeroNFSe.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Número da NFSe";
            // 
            // btnVerificarCertificadoDigital
            // 
            this.btnVerificarCertificadoDigital.Location = new System.Drawing.Point(7, 77);
            this.btnVerificarCertificadoDigital.Name = "btnVerificarCertificadoDigital";
            this.btnVerificarCertificadoDigital.Size = new System.Drawing.Size(226, 23);
            this.btnVerificarCertificadoDigital.TabIndex = 8;
            this.btnVerificarCertificadoDigital.Text = "Verificar certificado digital";
            this.btnVerificarCertificadoDigital.UseVisualStyleBackColor = true;
            this.btnVerificarCertificadoDigital.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnRecuperarDANFSe
            // 
            this.btnRecuperarDANFSe.Location = new System.Drawing.Point(703, 49);
            this.btnRecuperarDANFSe.Name = "btnRecuperarDANFSe";
            this.btnRecuperarDANFSe.Size = new System.Drawing.Size(226, 23);
            this.btnRecuperarDANFSe.TabIndex = 7;
            this.btnRecuperarDANFSe.Text = "Recuperar DANFSe";
            this.btnRecuperarDANFSe.UseVisualStyleBackColor = true;
            this.btnRecuperarDANFSe.Click += new System.EventHandler(this.btnRecuperarDANFSe_Click);
            // 
            // btnConsultarEvento
            // 
            this.btnConsultarEvento.Location = new System.Drawing.Point(471, 49);
            this.btnConsultarEvento.Name = "btnConsultarEvento";
            this.btnConsultarEvento.Size = new System.Drawing.Size(226, 23);
            this.btnConsultarEvento.TabIndex = 6;
            this.btnConsultarEvento.Text = "Consultar evento";
            this.btnConsultarEvento.UseVisualStyleBackColor = true;
            this.btnConsultarEvento.Click += new System.EventHandler(this.btnConsultarEvento_Click);
            // 
            // btnRegistrarEvento
            // 
            this.btnRegistrarEvento.Location = new System.Drawing.Point(239, 49);
            this.btnRegistrarEvento.Name = "btnRegistrarEvento";
            this.btnRegistrarEvento.Size = new System.Drawing.Size(226, 23);
            this.btnRegistrarEvento.TabIndex = 5;
            this.btnRegistrarEvento.Text = "Registrar evento";
            this.btnRegistrarEvento.UseVisualStyleBackColor = true;
            this.btnRegistrarEvento.Click += new System.EventHandler(this.btnRegistrarEvento_Click);
            // 
            // btnConcsultarNFSePelaChave
            // 
            this.btnConcsultarNFSePelaChave.Location = new System.Drawing.Point(6, 49);
            this.btnConcsultarNFSePelaChave.Name = "btnConcsultarNFSePelaChave";
            this.btnConcsultarNFSePelaChave.Size = new System.Drawing.Size(226, 23);
            this.btnConcsultarNFSePelaChave.TabIndex = 4;
            this.btnConcsultarNFSePelaChave.Text = "Consultar NFSe pela chave";
            this.btnConcsultarNFSePelaChave.UseVisualStyleBackColor = true;
            // 
            // btnTransmitirArquivoExistente
            // 
            this.btnTransmitirArquivoExistente.Location = new System.Drawing.Point(703, 20);
            this.btnTransmitirArquivoExistente.Name = "btnTransmitirArquivoExistente";
            this.btnTransmitirArquivoExistente.Size = new System.Drawing.Size(226, 23);
            this.btnTransmitirArquivoExistente.TabIndex = 3;
            this.btnTransmitirArquivoExistente.Text = "Transmitir arquivo existente";
            this.btnTransmitirArquivoExistente.UseVisualStyleBackColor = true;
            this.btnTransmitirArquivoExistente.Click += new System.EventHandler(this.btnTransmitirArquivoExistente_Click);
            // 
            // btnAssinarArquivoExistente
            // 
            this.btnAssinarArquivoExistente.Location = new System.Drawing.Point(471, 20);
            this.btnAssinarArquivoExistente.Name = "btnAssinarArquivoExistente";
            this.btnAssinarArquivoExistente.Size = new System.Drawing.Size(226, 23);
            this.btnAssinarArquivoExistente.TabIndex = 2;
            this.btnAssinarArquivoExistente.Text = "Assinar arquivo existente";
            this.btnAssinarArquivoExistente.UseVisualStyleBackColor = true;
            this.btnAssinarArquivoExistente.Click += new System.EventHandler(this.btnAssinarArquivoExistente_Click);
            // 
            // btnGerarEnviarNFSE
            // 
            this.btnGerarEnviarNFSE.Location = new System.Drawing.Point(239, 20);
            this.btnGerarEnviarNFSE.Name = "btnGerarEnviarNFSE";
            this.btnGerarEnviarNFSE.Size = new System.Drawing.Size(226, 23);
            this.btnGerarEnviarNFSE.TabIndex = 1;
            this.btnGerarEnviarNFSE.Text = "Gerar e enviar lote de DPS";
            this.btnGerarEnviarNFSE.UseVisualStyleBackColor = true;
            this.btnGerarEnviarNFSE.Click += new System.EventHandler(this.btnGerarEnviarNFSE_Click);
            // 
            // btnGerarEnviarDPS
            // 
            this.btnGerarEnviarDPS.Location = new System.Drawing.Point(7, 20);
            this.btnGerarEnviarDPS.Name = "btnGerarEnviarDPS";
            this.btnGerarEnviarDPS.Size = new System.Drawing.Size(226, 23);
            this.btnGerarEnviarDPS.TabIndex = 0;
            this.btnGerarEnviarDPS.Text = "Gerar e enviar DPS";
            this.btnGerarEnviarDPS.UseVisualStyleBackColor = true;
            this.btnGerarEnviarDPS.Click += new System.EventHandler(this.btnGerarEnviarDPS_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.richGerado);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 392);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1008, 124);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Gerado";
            // 
            // richGerado
            // 
            this.richGerado.Dock = System.Windows.Forms.DockStyle.Top;
            this.richGerado.Location = new System.Drawing.Point(3, 16);
            this.richGerado.Name = "richGerado";
            this.richGerado.Size = new System.Drawing.Size(1002, 106);
            this.richGerado.TabIndex = 0;
            this.richGerado.Text = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.richResultado);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 516);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1008, 140);
            this.groupBox3.TabIndex = 27;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Resultado";
            // 
            // richResultado
            // 
            this.richResultado.Dock = System.Windows.Forms.DockStyle.Top;
            this.richResultado.Location = new System.Drawing.Point(3, 16);
            this.richResultado.Name = "richResultado";
            this.richResultado.Size = new System.Drawing.Size(1002, 118);
            this.richResultado.TabIndex = 2;
            this.richResultado.Text = "";
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 668);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPrincipal";
            this.Text = "MXM Sistemas - exclusivo para a MXM, proibido o uso sem autorização";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRecuperarDANFSe;
        private System.Windows.Forms.Button btnConsultarEvento;
        private System.Windows.Forms.Button btnRegistrarEvento;
        private System.Windows.Forms.Button btnConcsultarNFSePelaChave;
        private System.Windows.Forms.Button btnTransmitirArquivoExistente;
        private System.Windows.Forms.Button btnAssinarArquivoExistente;
        private System.Windows.Forms.Button btnGerarEnviarNFSE;
        private System.Windows.Forms.Button btnGerarEnviarDPS;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox richGerado;
        private System.Windows.Forms.Button btnVerificarCertificadoDigital;
        private System.Windows.Forms.TextBox txtNumeroNFSe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox txtMesAno;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDecodar;
        private System.Windows.Forms.Button btnEncodar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox richResultado;
    }
}

