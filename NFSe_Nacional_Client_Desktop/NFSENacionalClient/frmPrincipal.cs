using NFSENacionalClient.Classes2;
using NFSENacionalClient.Util;
using RestSharp;
using System;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace NFSENacionalClient
{
    public partial class frmPrincipal : Form
    {        
        public frmPrincipal()
        {
            InitializeComponent();

            txtCNPJPrestador.Text = string.Empty;
            txtCaminhoCertificado.Text = string.Empty;
            txtSenhaCertificado.Text = string.Empty;
            txtURLDANFSe.Text = string.Empty;
            txtURLDFe.Text = string.Empty;
            txtURLDPS.Text = "https://sefin.producaorestrita.nfse.gov.br/SefinNacional";
            txtURLEventos.Text = string.Empty;
            txtURLNFSe.Text = string.Empty;
            txtNumeroDPS.Text = string.Empty;
            txtMesAno.Text = string.Empty;
        }

        private String ObterIdDPs(bool VBRetornarIDEvento = false, string tipoEvento = "", string nPedRegEvento = "")
        {
            if (VBRetornarIDEvento)
            {
                //O identificador do pedido de registro do evento é formado conforme a concatenação dos seguintes campos:
                //"PRE" + Chave de Acesso NFS - e + Tipo do evento + Número do Pedido de Registro do Evento(nPedRegEvento)
                return "PRE" + richGerado.Text + tipoEvento + nPedRegEvento;
            }
            else
            {
                // Informar o identificador precedido do literal ‘DPS’. A regra de formação do identificador de 45 posições da DPS é:
                // "DPS" + Cód.Mun(7) + Tipo de Inscrição Federal(1) + Inscrição Federal(14 - CPF completar com 000 à esquerda) + Série DPS(5) + Núm.DPS(15)
                return "DPS" + "1400159" + "2" + txtCNPJPrestador.Text + "00900" + txtNumeroDPS.Text.PadLeft(15, '0');
            }
        }

        private String obterCompetenciaDPS()
        {

            return String.Format("{0:yyyy-MM-dd}", DateTime.Now);
        }

        private String obterDataDPS()
        {

            return String.Format("{0:yyyy-MM-ddTHH:mm:ss}", DateTime.Now) + "-03:00";
        }

        public static Byte[] ComprimirGZIP(string xml)
        {
            var gziped = new MemoryStream();

            using (var gzip = new GZipStream(gziped, CompressionMode.Compress))
            {
                gzip.Write(Encoding.UTF8.GetBytes(xml), 0, xml.Length);
                gzip.Close();

                return gziped.ToArray();
            }
        }

        public static void CopiarBytes(Stream src, Stream dest)
        {
            byte[] bytes = new byte[4096];

            int cnt;

            while ((cnt = src.Read(bytes, 0, bytes.Length)) != 0)
            {
                dest.Write(bytes, 0, cnt);
            }
        }

        public static string DescomprimirGZIP(byte[] bytes)
        {
            var retorno = String.Empty;
            var texto = Encoding.UTF8.GetString(bytes);
            byte[] inputBytes = Convert.FromBase64String(texto);

            using (var inputStream = new MemoryStream(inputBytes))
            using (var gZipStream = new GZipStream(inputStream, CompressionMode.Decompress))
            using (var streamReader = new StreamReader(gZipStream))
            {
                retorno = streamReader.ReadToEnd();
            }

            return retorno;
        }

        public string base64_decodeFromString(String data)
        {
            if (data == null)
                throw new ArgumentNullException("data");

            byte[] data2 = Convert.FromBase64String(data);
            return Encoding.UTF8.GetString(data2);
        }

        public string base64_decode(byte[] data)
        {
            if (data == null)
                throw new ArgumentNullException("data");

            var qq = Encoding.UTF8.GetString(data);
            byte[] data2 = Convert.FromBase64String(qq);
            return Encoding.UTF8.GetString(data2);
        }

        public string base64_encode(byte[] data)
        {
            if (data == null)
                throw new ArgumentNullException("data");
            return Convert.ToBase64String(data);
        }

        private void btnEncodar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(richGerado.Text))
            {
                MessageBox.Show("Informe o texto para encodar na memo gerado.");
                return;
            }

            byte[] comprimido = ComprimirGZIP(richGerado.Text);
            string XMLBase64 = base64_encode(comprimido);

            richResultado.Text = XMLBase64;
        }

        private void btnDecodar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(richGerado.Text))
            {
                MessageBox.Show("Informe o texto para decodar no memo gerado.");
                return;
            }

            if (!IsBase64String(richGerado.Text))
            {
                MessageBox.Show("String não é um valor base 64 válido.");
                return;
            }

            String descomprimido = DescomprimirGZIP(System.Text.Encoding.UTF8.GetBytes(richGerado.Text));

            richResultado.Text = descomprimido;
        }

        public static bool IsBase64String(string base64String)
        {
            base64String = base64String.Trim();
            return (base64String.Length % 4 == 0) &&
                   Regex.IsMatch(base64String, @"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None);
        }


        private void btnCancelarDPS_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(richGerado.Text))
            {
                MessageBox.Show("A chave do DPS a ser cancelado deverá ser informada no campo \"Arquivo enviado\".");
                return;
            }

            try
            {
                var xmlCancelamento = GerarXMLEventoCancelamentoNFSe();

                if (!string.IsNullOrEmpty(xmlCancelamento))
                {
                    var pathCancelamento = Application.StartupPath + "\\" + "DPS" + "\\" + "Cancelamento" + "\\";

                    RealizaConsumoAPI(false, false, false, true, pathCancelamento, xmlCancelamento, richGerado.Text, "pedRegEvento", "infPedReg", "/nfse/" + richGerado.Text + "/eventos");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu o seguinte erro: " + ex.Message);
            }
        }

        public string GerarXMLEventoCancelamentoNFSe()
        {
            var xmlCancelamento = new StringBuilder();

            var nameSpace = "http://www.sped.fazenda.gov.br/nfse";
            var chaveNFSE = richGerado.Text;

            xmlCancelamento.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            xmlCancelamento.AppendFormat("<pedRegEvento versao=\"1.00\" xmlns=\"{0}\">", nameSpace);
            xmlCancelamento.AppendFormat("<infPedReg Id=\"{0}\">", ObterIdDPs(true, "101101", "001"));
            xmlCancelamento.Append("<tpAmb>2</tpAmb>");
            xmlCancelamento.Append("<verAplic>Testes_0.1.0</verAplic>");
            xmlCancelamento.AppendFormat("<dhEvento>{0}</dhEvento>", obterDataDPS());
            xmlCancelamento.AppendFormat("<CNPJAutor>{0}</CNPJAutor>", txtCNPJPrestador.Text);
            xmlCancelamento.AppendFormat("<chNFSe>{0}</chNFSe>", chaveNFSE);
            xmlCancelamento.Append("<nPedRegEvento>001</nPedRegEvento>");
            xmlCancelamento.Append("<e101101>");
            xmlCancelamento.Append("<xDesc>Cancelamento de NFS-e</xDesc>");
            xmlCancelamento.Append("<cMotivo>1</cMotivo>");
            xmlCancelamento.Append("<xMotivo>Exemplo de cancelamento NFSe</xMotivo>");
            xmlCancelamento.Append("</e101101>");
            xmlCancelamento.Append("</infPedReg>");
            xmlCancelamento.Append("</pedRegEvento>");

            return Convert.ToString(xmlCancelamento);
        }

        private void btnRegistrarEvento_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Não implementado");
        }

        private void btnConsultarEvento_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Não implementado");
        }

        private void btnRecuperarDANFSe_Click(object sender, EventArgs e)
        {
            ConsultarDANFSePelaChave(richGerado.Text);
        }

        private void btnAssinarArquivoExistente_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarCertificado();

                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Title = "Selecione um arquivo XML de DPS";

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    var arquivo = openFileDialog1.FileName;

                    var xml = File.ReadAllText(arquivo);
                    
                    var certificado = Assinador.GetCertificate(txtCaminhoCertificado.Text, txtSenhaCertificado.Text);

                    var xmlnovo = Assinador.ObterAssinatura(xml, txtCaminhoCertificado.Text, txtSenhaCertificado.Text, "DPS", "infDPS");
                    var fileName = Path.GetFileNameWithoutExtension(arquivo);
                    var diretorio = Path.GetDirectoryName(arquivo);
                    fileName = diretorio + "\\" + fileName + "_ASSINADO.xml";

                    FuncoesXml.SalvarStringXmlParaArquivoXml(xmlnovo, fileName);
                    MessageBox.Show("Arquivo assinado gerado com sucesso: " + fileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void btnTransmitirArquivoExistente_Click(object sender, EventArgs e)
        {
            richResultado.Clear();
            try
            {
                var arquivoExistente = String.Empty;
                try
                {
                    ValidarCertificado();

                    OpenFileDialog openFileDialog1 = new OpenFileDialog();
                    openFileDialog1.Title = "Selecione um arquivo XML de DPS";
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        arquivoExistente = openFileDialog1.FileName;
                    }
                    else
                    {
                        return;
                    }

                    var dps = File.ReadAllText(arquivoExistente);

                    RealizarEnvioDPS(dps);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu o seguinte erro: " + ex.Message);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnLimparMemos_Click(object sender, EventArgs e)
        {
            richGerado.Clear();
            richResultado.Clear();
        }

        private void btnConsultarNFSePelaChave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(richGerado.Text))
            {
                MessageBox.Show("A chave do DPS a ser consultada deverá ser informada no campo \"Arquivo enviado\".");
                return;
            }

            try
            {
                ConsultarNFSePelaChave(richGerado.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu o seguinte erro: " + ex.Message);
            }
        }

        public void RealizarEnvioDPS(string xml)
        {
            var caminhoArquivoEnviado = Application.StartupPath + "\\" + "DPS" + "\\" + "Envio";

            RealizaConsumoAPI(true, false, false, false, caminhoArquivoEnviado, xml, string.Empty, "DPS", "infDPS", "/nfse");
        }

        public void ConsultarNFSePelaChave(string chaveDPS)
        {
            var caminhoArquivoRetornado = Application.StartupPath + "\\" + "DPS" + "\\" + "Retorno";

            RealizaConsumoAPI(false, true, false, false, caminhoArquivoRetornado, string.Empty, chaveDPS, string.Empty, string.Empty, "/nfse/" + chaveDPS);
        }

        public void ConsultarDANFSePelaChave(string chaveDPS)
        {
            var caminhoArquivoRetornado = Application.StartupPath + "\\" + "DPS" + "\\" + "Retorno";

            RealizaConsumoAPI(false, false, true, false, caminhoArquivoRetornado, string.Empty, richGerado.Text, string.Empty, string.Empty, "/danfse/" + chaveDPS);
        }

        public void ValidarCertificado()
        {
            if (String.IsNullOrEmpty(txtCaminhoCertificado.Text))
            {
                MessageBox.Show("O campo Caminho certificado (.pfx) não foi informado.");
                return;
            }

            if (String.IsNullOrEmpty(txtSenhaCertificado.Text))
            {
                MessageBox.Show("O campo Senha certificado não foi informado.");
                return;
            }
        }

        public void ValidarNumeroNFSe()
        {
            if (String.IsNullOrEmpty(txtNumeroDPS.Text))
            {
                MessageBox.Show("Informe o número que deverá ser gerado para a NFSe/DPS");
                return;
            }
        }

        public void ValidarMesAno()
        {
            if (String.IsNullOrEmpty(txtMesAno.Text))
            {
                MessageBox.Show("Informe o mês/ano em que o arquivo deve ser gerado");
                return;
            }
        }

        private void btnEnviarDPSManual_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(richGerado.Text))
            {
                MessageBox.Show("O XML com DPS de envio (Sem assinatura e com a tag UTF-8) deverá ser informado no Arquivo enviado");
                return;
            }

            try
            {
                RealizarEnvioDPS(richGerado.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu o seguinte erro: " + ex.Message);
            }

        }

        public void RealizaConsumoAPI(bool VBRealizaEnvioDPSManual = false, bool VBRealizaConsultaNFSePelaChave = false, bool VBConsultaDANFSe = false, bool VBRealizaPedidoEvento = false, string pathArquivo = "", string xml = "",
            string chaveNFSe = "", string signTagName = "", string referenceTagName = "", string resourceRequest = "")
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                //Realiza validação das informações do certificado digital
                ValidarCertificado();

                //Método responsável por criar repositório onde serão gerados os arquivos
                CriaDiretorioDestino(pathArquivo);

                var XmlGZipB64 = string.Empty;

                if ((!VBRealizaConsultaNFSePelaChave) && (!VBConsultaDANFSe))
                {
                    //Método responsável por assinar xml
                    var xmlAssinado = RealizaAssinaturaXML(xml, signTagName, referenceTagName);

                    //Método resonsável por salvar arquivo que será enviado
                    SalvaArquivosEnviados(VBRealizaEnvioDPSManual, VBRealizaConsultaNFSePelaChave, VBConsultaDANFSe, VBRealizaPedidoEvento, xmlAssinado, pathArquivo, chaveNFSe);

                    //Método responsável por realizar validação de Schemas
                    if (VBRealizaEnvioDPSManual)
                    {
                        ValidaSchemas(VBRealizaEnvioDPSManual, VBRealizaConsultaNFSePelaChave, VBConsultaDANFSe, VBRealizaPedidoEvento, xmlAssinado);
                    }

                    //Comprimindo o XML em arquivo de extenção .gzip
                    byte[] arquivoComprimido = ComprimirGZIP(xmlAssinado);

                    //Codificando o arquivo .gzip em base 64
                    XmlGZipB64 = base64_encode(arquivoComprimido);
                }

                //Camada de requisição para enviar o documento via json para o ambiente nacional
                nfsePostRequest postRequest = new nfsePostRequest();

                if (VBRealizaEnvioDPSManual)
                {
                    postRequest.dpsXmlGZipB64 = XmlGZipB64;
                }

                if (VBRealizaPedidoEvento)
                {
                    postRequest.pedidoRegistroEventoXmlGZipB64 = XmlGZipB64;
                }

                var client = new RestClient(txtURLDPS.Text);
                var certificado = Assinador.GetCertificate(txtCaminhoCertificado.Text, txtSenhaCertificado.Text);

                client.ClientCertificates = new X509CertificateCollection();
                client.ClientCertificates.Add(certificado);

                var request = VBRealizaConsultaNFSePelaChave == true ? new RestRequest($"{resourceRequest}", Method.GET) : new RestRequest($"{resourceRequest}", Method.POST);

                if ((!VBRealizaConsultaNFSePelaChave) && (!VBConsultaDANFSe))
                {
                    //Salvando o json com o documento a ser enviado
                    SalvarJsonEnviado(VBRealizaEnvioDPSManual, VBRealizaConsultaNFSePelaChave, VBConsultaDANFSe, VBRealizaPedidoEvento, XmlGZipB64, pathArquivo);

                    request.RequestFormat = DataFormat.Json;
                    request.AddJsonBody(postRequest);
                }

                IRestResponse response = client.Execute(request);
                var respondeContent = response.Content;

                //Método responsável por realizar o tratamento do retorno da API
                RealizaTratamentoRetornoAPI(VBRealizaEnvioDPSManual, VBRealizaConsultaNFSePelaChave, VBConsultaDANFSe, VBRealizaPedidoEvento, respondeContent, certificado, chaveNFSe);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        public void CriaDiretorioDestino(string pathArquivo)
        {
            if (!Directory.Exists(pathArquivo))
            {
                Directory.CreateDirectory(pathArquivo);
            }

        }

        public string RealizaAssinaturaXML(string xml = "", string signTagName = "", string referenceTagName = "")
        {
            return Assinador.ObterAssinatura(xml, txtCaminhoCertificado.Text, txtSenhaCertificado.Text, signTagName, referenceTagName);
        }

        public void SalvaArquivosEnviados(bool VBRealizaEnvioDPSManual = false, bool VBRealizaConsultaNFSePelaChave = false, bool VBConsultaDANFSe = false, bool VBRealizaPedidoEvento = false, string xml = "", string pathArquivo = "", string chaveNFSe = "")
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

            var caminhoArquivoEnviado = string.Empty;

            if (VBRealizaEnvioDPSManual)
            {
                caminhoArquivoEnviado = pathArquivo + "\\" + "Env_DPS" + "_" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".xml";
            }

            if (VBRealizaPedidoEvento)
            {
                caminhoArquivoEnviado = pathArquivo + "\\" + "PedCanc_DPS" + "_" + chaveNFSe + ".xml";
            }

            if (!string.IsNullOrEmpty(caminhoArquivoEnviado))
            {
                doc.Save(caminhoArquivoEnviado);
            }
        }

        public void ValidaSchemas(bool VBRealizaEnvioDPSManual = false, bool VBRealizaConsultaNFSePelaChave = false, bool VBConsultaDANFSe = false, bool VBRealizaPedidoEvento = false, string xml = "")
        {
            var caminhoXSD = Application.StartupPath + "\\" + "XSD" + "\\";
            var arquivoXSD = string.Empty;

            if (VBRealizaEnvioDPSManual)
            {
                arquivoXSD = "DPS_v1.00.xsd";
            }

            if (VBRealizaPedidoEvento)
            {
                arquivoXSD = "evento_v1.00.xsd";
            }

            if (Directory.Exists(caminhoXSD))
            {
                var statusValidacaoXML = FuncoesXml.XMLDPSEEhValido(xml, caminhoXSD, arquivoXSD);

                if (!statusValidacaoXML.Valido)
                {
                    MessageBox.Show("Erro na validação do Schemas: " + statusValidacaoXML.Mensagem);
                }
            }
        }

        public void SalvarJsonEnviado(bool VBRealizaEnvioDPSManual = false, bool VBRealizaConsultaNFSePelaChave = false, bool VBConsultaDANFSe = false, bool VBRealizaPedidoEvento = false, string xmlBase64 = "", string pathArquivo = "")
        {
            if (VBRealizaEnvioDPSManual)
            {
                var caminhoJsonDPS = pathArquivo + "\\";

                var json = $"{{\"dpsXmlGZipB64\":\"{xmlBase64}\"}}";
                File.WriteAllText($@" {caminhoJsonDPS + "Env_DPS_Json_" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".json"}", json);

                //Gerando informações da tela da POC com o json que será enviado
                richGerado.Clear();
                richGerado.AppendText("Arquivo json de envio do DPS: " + json);
            }

            if (VBRealizaPedidoEvento)
            {
                var caminhoJsonCancelamento = pathArquivo + "\\" + "PedCanc_DPS_Json_" + richGerado.Text + ".json";

                //Criando o json com o arquivo DPS a ser enviado                
                var json = $"{{\"pedidoRegistroEventoXmlGZipB64\":\"{xmlBase64}\"}}";
                File.WriteAllText($@" {caminhoJsonCancelamento}", json);

                //Gerando informações da tela da POC com o json que será enviado
                richGerado.Clear();
                richGerado.AppendText("Arquivo json de pedido de registro do evento de cancelamento do DPS: " + json);
            }
        }

        public void RealizaTratamentoRetornoAPI(bool VBRealizaEnvioDPSManual = false, bool VBRealizaConsultaNFSePelaChave = false, bool VBConsultaDANFSe = false, bool VBRealizaPedidoEvento = false, string responseAPI = "", X509Certificate2 certificado = null, string chaveNFSe = "")
        {
            if (VBRealizaEnvioDPSManual)
            {
                //Gerando informações da tela da POC com o resultado da requisição
                richResultado.Clear();
                richResultado.AppendText("Retorno do envio do DPS: " + responseAPI);

                //Tratamento da resposta da emissão
                var jsonResponseEnvio = SimpleJson.DeserializeObject<NFSePostResponseSucesso>(responseAPI);

                if (jsonResponseEnvio != null)
                {
                    if (jsonResponseEnvio.erros == null)
                    {
                        var caminhoArquivoRetornado = Application.StartupPath + "\\" + "DPS" + "\\" + "Retorno" + "\\";

                        CriaDiretorioDestino(caminhoArquivoRetornado);

                        caminhoArquivoRetornado = caminhoArquivoRetornado + "Ret_DPS" + "_" + jsonResponseEnvio.idDps + ".xml";

                        if (File.Exists(caminhoArquivoRetornado))
                        {
                            File.Delete(caminhoArquivoRetornado);
                        }

                        // gravação do xml da nfse caso tenha sido emitida com sucesso
                        var rgziped = new MemoryStream(Encoding.UTF8.GetBytes(jsonResponseEnvio.nfseXmlGZipB64));
                        var cryptoStream = new CryptoStream(rgziped, new FromBase64Transform(), CryptoStreamMode.Read);
                        var gzip = new GZipStream(cryptoStream, CompressionMode.Decompress);
                        var ungziped = new FileStream($@" {caminhoArquivoRetornado}", FileMode.Create);
                        gzip.CopyTo(ungziped);


                        //Consulta da NFS-e pela chave
                        ConsultarNFSePelaChave(jsonResponseEnvio.chaveAcesso);

                        MessageBox.Show(String.Format("Arquivo {0} enviado com sucesso, confira o resultado na aba de resultado.", caminhoArquivoRetornado + jsonResponseEnvio.idDps + ".xml"));
                        return;
                    }

                    MessageBox.Show("Arquivo enviado com erros, confira o resultado na aba de resultado.");
                }
            }

            if (VBRealizaConsultaNFSePelaChave)
            {
                if (!String.IsNullOrEmpty(richResultado.Text))
                {
                    richResultado.AppendText("\n " + "\n " + "\n " + "Retorno da consulta do DPS: " + responseAPI);
                }
                else
                {
                    richResultado.AppendText("Retorno da consulta do DPS: " + responseAPI);
                }

                var jsonResponse = SimpleJson.DeserializeObject<NFSePostResponseSucesso>(responseAPI);

                if (jsonResponse != null)
                {
                    if (jsonResponse.erros == null)
                    {
                        var caminhoArquivoRetornado = Application.StartupPath + "\\" + "DPS" + "\\" + "Retorno";

                        CriaDiretorioDestino(caminhoArquivoRetornado);

                        caminhoArquivoRetornado = caminhoArquivoRetornado + "\\" + "Ret_Cons_DPS" + "_" + chaveNFSe + ".xml";

                        if (File.Exists(caminhoArquivoRetornado))
                        {
                            File.Delete(caminhoArquivoRetornado);
                        }

                        // gravação do xml da nfse caso tenha sido emitida com sucesso
                        var rgziped = new MemoryStream(Encoding.UTF8.GetBytes(jsonResponse.nfseXmlGZipB64));
                        var cryptoStream = new CryptoStream(rgziped, new FromBase64Transform(), CryptoStreamMode.Read);
                        var gzip = new GZipStream(cryptoStream, CompressionMode.Decompress);
                        var ungziped = new FileStream($@"{caminhoArquivoRetornado}", FileMode.Create);
                        gzip.CopyTo(ungziped);

                        MessageBox.Show(String.Format("Consulta do DPS {0} realizada com sucesso, confira o resultado na aba de resultado.", caminhoArquivoRetornado + jsonResponse.idDps + ".xml"));
                        return;
                    }
                }
            }

            if (VBRealizaPedidoEvento)
            {
                //Gerando informações da tela da POC com o resultado da requisição                
                if (!String.IsNullOrEmpty(richResultado.Text))
                {
                    richResultado.AppendText("\n " + "\n " + "\n " + "Retorno do evento do pedido de cancelamento do DPS: " + responseAPI);
                }
                else
                {
                    richResultado.AppendText("Retorno do evento do pedido de cancelamento do DPS: " + responseAPI);
                }

                // tratamento da resposta da emissão
                var jsonResponseEnvio = SimpleJson.DeserializeObject<NFSePostResponseSucesso>(responseAPI);

                if (jsonResponseEnvio != null)
                {
                    if (jsonResponseEnvio.erros == null)
                    {
                        var caminhoArquivoRetornado = Application.StartupPath + "\\" + "DPS" + "\\" + "Cancelamento" + "\\";

                        CriaDiretorioDestino(caminhoArquivoRetornado);

                        caminhoArquivoRetornado = caminhoArquivoRetornado + "Ret_PedCanc_DPS_" + "_" + chaveNFSe + ".xml";

                        if (File.Exists(caminhoArquivoRetornado))
                        {
                            File.Delete(caminhoArquivoRetornado);
                        }

                        // gravação do xml da nfse caso tenha sido emitida com sucesso
                        var rgziped = new MemoryStream(Encoding.UTF8.GetBytes(jsonResponseEnvio.eventoXmlGZipB64));
                        var cryptoStream = new CryptoStream(rgziped, new FromBase64Transform(), CryptoStreamMode.Read);
                        var gzip = new GZipStream(cryptoStream, CompressionMode.Decompress);
                        var ungziped = new FileStream($@" {caminhoArquivoRetornado}", FileMode.Create);
                        gzip.CopyTo(ungziped);


                        MessageBox.Show(String.Format("Pedido de registro do evento de cancelamento {0} enviado com sucesso, confira o resultado na aba de resultado.", caminhoArquivoRetornado + jsonResponseEnvio.idDps + ".xml"));
                        return;
                    }

                    MessageBox.Show("Arquivo enviado com erros, confira o resultado na aba de resultado.");
                }
            }
        }
    }
}
