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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEnviarDPSManual = new System.Windows.Forms.Button();
            this.btnDecodar = new System.Windows.Forms.Button();
            this.btnEncodar = new System.Windows.Forms.Button();
            this.txtMesAno = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNumeroDPS = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRecuperarDANFSe = new System.Windows.Forms.Button();
            this.btnConsultarEvento = new System.Windows.Forms.Button();
            this.btnRegistrarEvento = new System.Windows.Forms.Button();
            this.btnConsultaNFSePelaChave = new System.Windows.Forms.Button();
            this.btnTransmitirArquivoExistente = new System.Windows.Forms.Button();
            this.btnAssinarArquivoExistente = new System.Windows.Forms.Button();
            this.btnCancelarDPS = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.richGerado = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.richResultado = new System.Windows.Forms.RichTextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtURLNFSe = new System.Windows.Forms.TextBox();
            this.lblURLNFSe = new System.Windows.Forms.Label();
            this.txtURLEventos = new System.Windows.Forms.TextBox();
            this.lblURLEVentos = new System.Windows.Forms.Label();
            this.txtURLDPS = new System.Windows.Forms.TextBox();
            this.lblURLDPS = new System.Windows.Forms.Label();
            this.txtURLDFe = new System.Windows.Forms.TextBox();
            this.lblURLDFe = new System.Windows.Forms.Label();
            this.txtURLDANFSe = new System.Windows.Forms.TextBox();
            this.lblURLDANFSe = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtSenhaCertificado = new System.Windows.Forms.TextBox();
            this.lblSenhaCertificado = new System.Windows.Forms.Label();
            this.txtCaminhoCertificado = new System.Windows.Forms.TextBox();
            this.lblCaminhoCertificado = new System.Windows.Forms.Label();
            this.txtCNPJPrestador = new System.Windows.Forms.TextBox();
            this.lblCNPJPrestador = new System.Windows.Forms.Label();
            this.btnLimparMemos = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnEnviarDPSManual);
            this.groupBox1.Controls.Add(this.btnDecodar);
            this.groupBox1.Controls.Add(this.btnEncodar);
            this.groupBox1.Controls.Add(this.txtMesAno);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtNumeroDPS);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnRecuperarDANFSe);
            this.groupBox1.Controls.Add(this.btnConsultarEvento);
            this.groupBox1.Controls.Add(this.btnRegistrarEvento);
            this.groupBox1.Controls.Add(this.btnConsultaNFSePelaChave);
            this.groupBox1.Controls.Add(this.btnTransmitirArquivoExistente);
            this.groupBox1.Controls.Add(this.btnAssinarArquivoExistente);
            this.groupBox1.Controls.Add(this.btnCancelarDPS);
            this.groupBox1.Location = new System.Drawing.Point(0, 372);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1008, 131);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ações";
            // 
            // btnEnviarDPSManual
            // 
            this.btnEnviarDPSManual.Location = new System.Drawing.Point(7, 20);
            this.btnEnviarDPSManual.Name = "btnEnviarDPSManual";
            this.btnEnviarDPSManual.Size = new System.Drawing.Size(226, 23);
            this.btnEnviarDPSManual.TabIndex = 0;
            this.btnEnviarDPSManual.Text = "Enviar DPS de forma manual";
            this.btnEnviarDPSManual.UseVisualStyleBackColor = true;
            this.btnEnviarDPSManual.Click += new System.EventHandler(this.btnEnviarDPSManual_Click);
            // 
            // btnDecodar
            // 
            this.btnDecodar.Location = new System.Drawing.Point(471, 49);
            this.btnDecodar.Name = "btnDecodar";
            this.btnDecodar.Size = new System.Drawing.Size(226, 23);
            this.btnDecodar.TabIndex = 7;
            this.btnDecodar.Text = "Decodar XML (Gzip e Base64)";
            this.btnDecodar.UseVisualStyleBackColor = true;
            this.btnDecodar.Click += new System.EventHandler(this.btnDecodar_Click);
            // 
            // btnEncodar
            // 
            this.btnEncodar.Location = new System.Drawing.Point(471, 20);
            this.btnEncodar.Name = "btnEncodar";
            this.btnEncodar.Size = new System.Drawing.Size(226, 23);
            this.btnEncodar.TabIndex = 6;
            this.btnEncodar.Text = "Encodar XML (Gzip e Base64)";
            this.btnEncodar.UseVisualStyleBackColor = true;
            this.btnEncodar.Click += new System.EventHandler(this.btnEncodar_Click);
            // 
            // txtMesAno
            // 
            this.txtMesAno.Enabled = false;
            this.txtMesAno.Location = new System.Drawing.Point(302, 108);
            this.txtMesAno.Mask = "99/9999";
            this.txtMesAno.Name = "txtMesAno";
            this.txtMesAno.Size = new System.Drawing.Size(55, 20);
            this.txtMesAno.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(214, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Mês (MM/AAAA)";
            // 
            // txtNumeroDPS
            // 
            this.txtNumeroDPS.Enabled = false;
            this.txtNumeroDPS.Location = new System.Drawing.Point(98, 106);
            this.txtNumeroDPS.Name = "txtNumeroDPS";
            this.txtNumeroDPS.Size = new System.Drawing.Size(100, 20);
            this.txtNumeroDPS.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Número da DPS";
            // 
            // btnRecuperarDANFSe
            // 
            this.btnRecuperarDANFSe.Enabled = false;
            this.btnRecuperarDANFSe.Location = new System.Drawing.Point(239, 78);
            this.btnRecuperarDANFSe.Name = "btnRecuperarDANFSe";
            this.btnRecuperarDANFSe.Size = new System.Drawing.Size(226, 23);
            this.btnRecuperarDANFSe.TabIndex = 5;
            this.btnRecuperarDANFSe.Text = "Recuperar DANFSe";
            this.btnRecuperarDANFSe.UseVisualStyleBackColor = true;
            this.btnRecuperarDANFSe.Click += new System.EventHandler(this.btnRecuperarDANFSe_Click);
            // 
            // btnConsultarEvento
            // 
            this.btnConsultarEvento.Enabled = false;
            this.btnConsultarEvento.Location = new System.Drawing.Point(471, 78);
            this.btnConsultarEvento.Name = "btnConsultarEvento";
            this.btnConsultarEvento.Size = new System.Drawing.Size(226, 23);
            this.btnConsultarEvento.TabIndex = 8;
            this.btnConsultarEvento.Text = "Consultar evento";
            this.btnConsultarEvento.UseVisualStyleBackColor = true;
            this.btnConsultarEvento.Click += new System.EventHandler(this.btnConsultarEvento_Click);
            // 
            // btnRegistrarEvento
            // 
            this.btnRegistrarEvento.Enabled = false;
            this.btnRegistrarEvento.Location = new System.Drawing.Point(703, 20);
            this.btnRegistrarEvento.Name = "btnRegistrarEvento";
            this.btnRegistrarEvento.Size = new System.Drawing.Size(226, 23);
            this.btnRegistrarEvento.TabIndex = 9;
            this.btnRegistrarEvento.Text = "Registrar evento";
            this.btnRegistrarEvento.UseVisualStyleBackColor = true;
            this.btnRegistrarEvento.Click += new System.EventHandler(this.btnRegistrarEvento_Click);
            // 
            // btnConsultaNFSePelaChave
            // 
            this.btnConsultaNFSePelaChave.Location = new System.Drawing.Point(6, 49);
            this.btnConsultaNFSePelaChave.Name = "btnConsultaNFSePelaChave";
            this.btnConsultaNFSePelaChave.Size = new System.Drawing.Size(226, 23);
            this.btnConsultaNFSePelaChave.TabIndex = 1;
            this.btnConsultaNFSePelaChave.Text = "Consultar NFSe pela chave";
            this.btnConsultaNFSePelaChave.UseVisualStyleBackColor = true;
            this.btnConsultaNFSePelaChave.Click += new System.EventHandler(this.btnConsultarNFSePelaChave_Click);
            // 
            // btnTransmitirArquivoExistente
            // 
            this.btnTransmitirArquivoExistente.Location = new System.Drawing.Point(239, 49);
            this.btnTransmitirArquivoExistente.Name = "btnTransmitirArquivoExistente";
            this.btnTransmitirArquivoExistente.Size = new System.Drawing.Size(226, 23);
            this.btnTransmitirArquivoExistente.TabIndex = 4;
            this.btnTransmitirArquivoExistente.Text = "Transmitir arquivo DPS existente";
            this.btnTransmitirArquivoExistente.UseVisualStyleBackColor = true;
            this.btnTransmitirArquivoExistente.Click += new System.EventHandler(this.btnTransmitirArquivoExistente_Click);
            // 
            // btnAssinarArquivoExistente
            // 
            this.btnAssinarArquivoExistente.Location = new System.Drawing.Point(239, 20);
            this.btnAssinarArquivoExistente.Name = "btnAssinarArquivoExistente";
            this.btnAssinarArquivoExistente.Size = new System.Drawing.Size(226, 23);
            this.btnAssinarArquivoExistente.TabIndex = 3;
            this.btnAssinarArquivoExistente.Text = "Assinar arquivo DPS existente";
            this.btnAssinarArquivoExistente.UseVisualStyleBackColor = true;
            this.btnAssinarArquivoExistente.Click += new System.EventHandler(this.btnAssinarArquivoExistente_Click);
            // 
            // btnCancelarDPS
            // 
            this.btnCancelarDPS.Location = new System.Drawing.Point(7, 78);
            this.btnCancelarDPS.Name = "btnCancelarDPS";
            this.btnCancelarDPS.Size = new System.Drawing.Size(226, 23);
            this.btnCancelarDPS.TabIndex = 2;
            this.btnCancelarDPS.Text = "Cancelar DPS";
            this.btnCancelarDPS.UseVisualStyleBackColor = true;
            this.btnCancelarDPS.Click += new System.EventHandler(this.btnCancelarDPS_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.richGerado);
            this.groupBox2.Location = new System.Drawing.Point(0, 533);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1008, 124);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Arquivo enviado";
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
            this.groupBox3.Location = new System.Drawing.Point(0, 663);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1008, 138);
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
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtURLNFSe);
            this.groupBox5.Controls.Add(this.lblURLNFSe);
            this.groupBox5.Controls.Add(this.txtURLEventos);
            this.groupBox5.Controls.Add(this.lblURLEVentos);
            this.groupBox5.Controls.Add(this.txtURLDPS);
            this.groupBox5.Controls.Add(this.lblURLDPS);
            this.groupBox5.Controls.Add(this.txtURLDFe);
            this.groupBox5.Controls.Add(this.lblURLDFe);
            this.groupBox5.Controls.Add(this.txtURLDANFSe);
            this.groupBox5.Controls.Add(this.lblURLDANFSe);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(0, 272);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox5.Size = new System.Drawing.Size(1006, 93);
            this.groupBox5.TabIndex = 32;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "APIs para os contribuintes do ISSQN no sistema nacional NFS-e";
            // 
            // txtURLNFSe
            // 
            this.txtURLNFSe.Enabled = false;
            this.txtURLNFSe.Location = new System.Drawing.Point(556, 46);
            this.txtURLNFSe.Margin = new System.Windows.Forms.Padding(2);
            this.txtURLNFSe.Name = "txtURLNFSe";
            this.txtURLNFSe.Size = new System.Drawing.Size(432, 20);
            this.txtURLNFSe.TabIndex = 9;
            // 
            // lblURLNFSe
            // 
            this.lblURLNFSe.AutoSize = true;
            this.lblURLNFSe.Location = new System.Drawing.Point(483, 46);
            this.lblURLNFSe.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblURLNFSe.Name = "lblURLNFSe";
            this.lblURLNFSe.Size = new System.Drawing.Size(62, 13);
            this.lblURLNFSe.TabIndex = 8;
            this.lblURLNFSe.Text = "URL NFS-e";
            // 
            // txtURLEventos
            // 
            this.txtURLEventos.Enabled = false;
            this.txtURLEventos.Location = new System.Drawing.Point(556, 19);
            this.txtURLEventos.Margin = new System.Windows.Forms.Padding(2);
            this.txtURLEventos.Name = "txtURLEventos";
            this.txtURLEventos.Size = new System.Drawing.Size(432, 20);
            this.txtURLEventos.TabIndex = 7;
            // 
            // lblURLEVentos
            // 
            this.lblURLEVentos.AutoSize = true;
            this.lblURLEVentos.Location = new System.Drawing.Point(483, 21);
            this.lblURLEVentos.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblURLEVentos.Name = "lblURLEVentos";
            this.lblURLEVentos.Size = new System.Drawing.Size(71, 13);
            this.lblURLEVentos.TabIndex = 6;
            this.lblURLEVentos.Text = "URL Eventos";
            // 
            // txtURLDPS
            // 
            this.txtURLDPS.Enabled = false;
            this.txtURLDPS.Location = new System.Drawing.Point(85, 69);
            this.txtURLDPS.Margin = new System.Windows.Forms.Padding(2);
            this.txtURLDPS.Name = "txtURLDPS";
            this.txtURLDPS.Size = new System.Drawing.Size(395, 20);
            this.txtURLDPS.TabIndex = 5;
            // 
            // lblURLDPS
            // 
            this.lblURLDPS.AutoSize = true;
            this.lblURLDPS.Location = new System.Drawing.Point(7, 69);
            this.lblURLDPS.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblURLDPS.Name = "lblURLDPS";
            this.lblURLDPS.Size = new System.Drawing.Size(54, 13);
            this.lblURLDPS.TabIndex = 4;
            this.lblURLDPS.Text = "URL DPS";
            // 
            // txtURLDFe
            // 
            this.txtURLDFe.Enabled = false;
            this.txtURLDFe.Location = new System.Drawing.Point(85, 44);
            this.txtURLDFe.Margin = new System.Windows.Forms.Padding(2);
            this.txtURLDFe.Name = "txtURLDFe";
            this.txtURLDFe.Size = new System.Drawing.Size(395, 20);
            this.txtURLDFe.TabIndex = 3;
            // 
            // lblURLDFe
            // 
            this.lblURLDFe.AutoSize = true;
            this.lblURLDFe.Location = new System.Drawing.Point(6, 44);
            this.lblURLDFe.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblURLDFe.Name = "lblURLDFe";
            this.lblURLDFe.Size = new System.Drawing.Size(55, 13);
            this.lblURLDFe.TabIndex = 2;
            this.lblURLDFe.Text = "URL DF-e";
            // 
            // txtURLDANFSe
            // 
            this.txtURLDANFSe.Enabled = false;
            this.txtURLDANFSe.Location = new System.Drawing.Point(85, 17);
            this.txtURLDANFSe.Margin = new System.Windows.Forms.Padding(2);
            this.txtURLDANFSe.Name = "txtURLDANFSe";
            this.txtURLDANFSe.Size = new System.Drawing.Size(395, 20);
            this.txtURLDANFSe.TabIndex = 1;
            // 
            // lblURLDANFSe
            // 
            this.lblURLDANFSe.AutoSize = true;
            this.lblURLDANFSe.Location = new System.Drawing.Point(6, 20);
            this.lblURLDANFSe.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblURLDANFSe.Name = "lblURLDANFSe";
            this.lblURLDANFSe.Size = new System.Drawing.Size(77, 13);
            this.lblURLDANFSe.TabIndex = 0;
            this.lblURLDANFSe.Text = "URL DANFS-e";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtSenhaCertificado);
            this.groupBox4.Controls.Add(this.lblSenhaCertificado);
            this.groupBox4.Controls.Add(this.txtCaminhoCertificado);
            this.groupBox4.Controls.Add(this.lblCaminhoCertificado);
            this.groupBox4.Controls.Add(this.txtCNPJPrestador);
            this.groupBox4.Controls.Add(this.lblCNPJPrestador);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(0, 226);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(1006, 46);
            this.groupBox4.TabIndex = 31;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Parametrizações do Prestador";
            // 
            // txtSenhaCertificado
            // 
            this.txtSenhaCertificado.Location = new System.Drawing.Point(771, 17);
            this.txtSenhaCertificado.Margin = new System.Windows.Forms.Padding(2);
            this.txtSenhaCertificado.Name = "txtSenhaCertificado";
            this.txtSenhaCertificado.PasswordChar = '*';
            this.txtSenhaCertificado.Size = new System.Drawing.Size(216, 20);
            this.txtSenhaCertificado.TabIndex = 5;
            // 
            // lblSenhaCertificado
            // 
            this.lblSenhaCertificado.AutoSize = true;
            this.lblSenhaCertificado.Location = new System.Drawing.Point(676, 20);
            this.lblSenhaCertificado.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSenhaCertificado.Name = "lblSenhaCertificado";
            this.lblSenhaCertificado.Size = new System.Drawing.Size(91, 13);
            this.lblSenhaCertificado.TabIndex = 4;
            this.lblSenhaCertificado.Text = "Senha Certificado";
            // 
            // txtCaminhoCertificado
            // 
            this.txtCaminhoCertificado.Location = new System.Drawing.Point(360, 17);
            this.txtCaminhoCertificado.Margin = new System.Windows.Forms.Padding(2);
            this.txtCaminhoCertificado.Name = "txtCaminhoCertificado";
            this.txtCaminhoCertificado.Size = new System.Drawing.Size(313, 20);
            this.txtCaminhoCertificado.TabIndex = 3;
            // 
            // lblCaminhoCertificado
            // 
            this.lblCaminhoCertificado.AutoSize = true;
            this.lblCaminhoCertificado.Location = new System.Drawing.Point(230, 20);
            this.lblCaminhoCertificado.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCaminhoCertificado.Name = "lblCaminhoCertificado";
            this.lblCaminhoCertificado.Size = new System.Drawing.Size(126, 13);
            this.lblCaminhoCertificado.TabIndex = 2;
            this.lblCaminhoCertificado.Text = "Caminho certificado (.pfx)";
            // 
            // txtCNPJPrestador
            // 
            this.txtCNPJPrestador.Location = new System.Drawing.Point(43, 17);
            this.txtCNPJPrestador.Margin = new System.Windows.Forms.Padding(2);
            this.txtCNPJPrestador.Name = "txtCNPJPrestador";
            this.txtCNPJPrestador.Size = new System.Drawing.Size(180, 20);
            this.txtCNPJPrestador.TabIndex = 1;
            // 
            // lblCNPJPrestador
            // 
            this.lblCNPJPrestador.AutoSize = true;
            this.lblCNPJPrestador.Location = new System.Drawing.Point(6, 20);
            this.lblCNPJPrestador.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCNPJPrestador.Name = "lblCNPJPrestador";
            this.lblCNPJPrestador.Size = new System.Drawing.Size(34, 13);
            this.lblCNPJPrestador.TabIndex = 0;
            this.lblCNPJPrestador.Text = "CNPJ";
            // 
            // btnLimparMemos
            // 
            this.btnLimparMemos.Location = new System.Drawing.Point(9, 509);
            this.btnLimparMemos.Margin = new System.Windows.Forms.Padding(2);
            this.btnLimparMemos.Name = "btnLimparMemos";
            this.btnLimparMemos.Size = new System.Drawing.Size(127, 19);
            this.btnLimparMemos.TabIndex = 33;
            this.btnLimparMemos.Text = "Limpar Memos";
            this.btnLimparMemos.UseVisualStyleBackColor = true;
            this.btnLimparMemos.Click += new System.EventHandler(this.btnLimparMemos_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::NFSENacionalClient.Properties.Resources.logo_mxm_nfe1;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1006, 226);
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 812);
            this.Controls.Add(this.btnLimparMemos);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPrincipal";
            this.Text = "MXM Sistemas - Exclusivo para a MXM, proibido o uso sem autorização";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRecuperarDANFSe;
        private System.Windows.Forms.Button btnConsultarEvento;
        private System.Windows.Forms.Button btnRegistrarEvento;
        private System.Windows.Forms.Button btnConsultaNFSePelaChave;
        private System.Windows.Forms.Button btnTransmitirArquivoExistente;
        private System.Windows.Forms.Button btnAssinarArquivoExistente;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox richGerado;
        private System.Windows.Forms.TextBox txtNumeroDPS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox txtMesAno;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDecodar;
        private System.Windows.Forms.Button btnEncodar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox richResultado;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtURLNFSe;
        private System.Windows.Forms.Label lblURLNFSe;
        private System.Windows.Forms.TextBox txtURLEventos;
        private System.Windows.Forms.Label lblURLEVentos;
        private System.Windows.Forms.TextBox txtURLDPS;
        private System.Windows.Forms.Label lblURLDPS;
        private System.Windows.Forms.TextBox txtURLDFe;
        private System.Windows.Forms.Label lblURLDFe;
        private System.Windows.Forms.TextBox txtURLDANFSe;
        private System.Windows.Forms.Label lblURLDANFSe;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtCaminhoCertificado;
        private System.Windows.Forms.Label lblCaminhoCertificado;
        private System.Windows.Forms.TextBox txtCNPJPrestador;
        private System.Windows.Forms.Label lblCNPJPrestador;
        private System.Windows.Forms.TextBox txtSenhaCertificado;
        private System.Windows.Forms.Label lblSenhaCertificado;
        private System.Windows.Forms.Button btnLimparMemos;
        private System.Windows.Forms.Button btnCancelarDPS;
        private System.Windows.Forms.Button btnEnviarDPSManual;
    }
}

