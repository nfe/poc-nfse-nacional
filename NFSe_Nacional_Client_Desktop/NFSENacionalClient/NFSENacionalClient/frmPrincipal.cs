using NFSENacionalClient.Classes;
using NFSENacionalClient.Util;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
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
        private String arquivoConfiguracao = "";
        public Configuracao Configuracao { get; set; }
        public frmPrincipal()
        {
            InitializeComponent();

            arquivoConfiguracao = Application.StartupPath + "\\" + "config.xml";

            if (!File.Exists(arquivoConfiguracao))
            {
                MessageBox.Show(String.Format("Arquivo de configuração não encontrado em : {0}  - o client não irá funcionar corretamente.", arquivoConfiguracao));
            }
            else
            {
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Configuracao));
                    using (StreamReader reader = new StreamReader(arquivoConfiguracao))
                    {
                        Configuracao = (Configuracao)serializer.Deserialize(reader);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao deserializar arquivo de configuração: " + ex.Message);
                }
            }
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            txtMesAno.Text = String.Format("{0:MM/yyyy}", DateTime.Now);
        }

        private Boolean CertificadoExiste()
        {
            Boolean existe = false;
            var serialCertificado = Configuracao.certificado;

            try
            {
                var store = ObterX509Store(OpenFlags.OpenExistingOnly | OpenFlags.ReadOnly);

                var collection = store.Certificates;
                var fcollection = collection.Find(X509FindType.FindBySerialNumber, serialCertificado, false);

                if (fcollection.Count == 0)
                {
                    existe = false;
                }
                else
                {
                    existe = true;
                    var certificadoEncontrado = fcollection[0].SerialNumber;
                    try
                    {
                        var subject = fcollection[0].Subject;
                        var pos = subject.IndexOf(':');
                        if (pos != -1)
                        {
                            var cnpj = subject.Substring(pos + 1, 14);
                            if (cnpj.Substring(0, 2) != "CN")
                            {
                                String cnpjEncontrado = cnpj;
                            }
                        }
                    }
                    catch (Exception) { }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return existe;
        }

        private X509Certificate2 ObterCertificadoPeloSerial(String serial)
        {
            X509Certificate2 certificado = null;
            var store = ObterX509Store(OpenFlags.ReadOnly);

            foreach (var item in store.Certificates)
            {
                if (item.SerialNumber != null && item.SerialNumber.ToUpper().Equals(serial.ToUpper(), StringComparison.InvariantCultureIgnoreCase))
                {
                    certificado = item;
                    break;
                }
            }

            if (certificado == null)
                MessageBox.Show(String.Format("Certificado digital nº {0} não encontrado!", serial));


            return certificado;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var serialCertificado = Configuracao.certificado;

            try
            {
                var store = ObterX509Store(OpenFlags.OpenExistingOnly | OpenFlags.ReadOnly);

                var collection = store.Certificates;
                var fcollection = collection.Find(X509FindType.FindBySerialNumber, serialCertificado, false);

                if (fcollection.Count == 0)
                {
                    throw new Exception("O certificado informado no arquivo de configurãção não foi encontrado!");
                }
                else
                {
                    var certificadoEncontrado = fcollection[0].SerialNumber;
                    try
                    {
                        var subject = fcollection[0].Subject;
                        var pos = subject.IndexOf(':');
                        if (pos != -1)
                        {
                            var cnpj = subject.Substring(pos + 1, 14);
                            if (cnpj.Substring(0, 2) != "CN")
                            {
                                String cnpjEncontrado = cnpj;
                            }
                        }
                    }
                    catch (Exception) { }

                    MessageBox.Show("Certificado do arquivo de configuração encontrado.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private X509Store ObterX509Store(OpenFlags openFlags)
        {
            var store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(openFlags);
            return store;
        }

        private String ObterIdDPs()
        {
            return "ID" + "3106200" + "1" + Configuracao.cnpj + "00001" + txtNumeroNFSe.Text.PadLeft(15, '0');

        }

        private String obterCompetenciaDPS()
        {

            return String.Format("{0:yyyy-MM-dd}", DateTime.Now);
        }

        private String obterDataDPS()
        {

            return String.Format("{0:yyyy-MM-ddTHH:mm:ss}", DateTime.Now) + "-03:00";
        }

        public static Byte[] ComprimirGZIP(Byte[] data)
        {
            using (var compressedStream = new MemoryStream())
            using (var zipStream = new GZipStream(compressedStream, CompressionMode.Compress))
            {
                zipStream.Write(data, 0, data.Length);
                zipStream.Close();
                return compressedStream.ToArray();
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

        private TCDPS ObterDPS()
        {
            var certificado = ObterCertificadoPeloSerial(Configuracao.certificado);
            var dps = new TCDPS();
            dps.versao = "1.00";
            dps.infDPS = new TCInfDPS();
            dps.infDPS.tpAmb = TSTipoAmbiente.Homologacao;
            dps.infDPS.dCompet = obterCompetenciaDPS();
            dps.infDPS.dhEmi = obterDataDPS();
            dps.infDPS.Id = ObterIdDPs();
            dps.infDPS.serie = "00001";
            dps.infDPS.verAplic = "1.0";
            dps.infDPS.tpEmit = TSEmitenteDPS.Prestador;
            dps.infDPS.nDPS = txtNumeroNFSe.Text;
            dps.infDPS.prest = new TCInfoAtor();
            dps.infDPS.prest.email = "vanderson.guidi@mxm.com.br";
            dps.infDPS.prest.fone = "2133113311";
          //  dps.infDPS.prest.IM = "60308470";
            dps.infDPS.prest.xNome = "MXM SISTEMAS";
            dps.infDPS.prest.CPF = "04803190658";//Configuracao.cnpj;
            dps.infDPS.prest.Endereco = new TCEnderNac();
            var endereco = dps.infDPS.prest.Endereco as TCEnderNac;
            endereco.CEP = "30110001";//"23056000";
            endereco.cMun = "3106200";// "3304557";
            endereco.nro = "123";
            endereco.UF = TSUF.MG;
            endereco.xBairro = "CENTRO";
            endereco.xCpl = "10 ANDAR - SL 101";
            endereco.xLgr = "RUA DO TESTE";

            //dps.infDPS.prest.Item = Configuracao.cnpj;

            dps.infDPS.toma = new TCInfoAtor();
            dps.infDPS.toma.email = "teste@teste.com";
            dps.infDPS.toma.Endereco = new TCEnderNac();
            var endereco2 = dps.infDPS.toma.Endereco as TCEnderNac;
            endereco2.CEP = "23056000";
            endereco2.cMun = "3304557";
            endereco2.nro = "123";
            endereco2.UF = TSUF.RJ;
            endereco2.xBairro = "CENTRO";
            endereco2.xCpl = "10 ANDAR - SL 101";
            endereco2.xLgr = "RUA DO TESTE";

            dps.infDPS.toma.CPF = "08846428790";
            dps.infDPS.toma.IM = "0000000";
            dps.infDPS.toma.xNome = "FULANO DE TAL";
            //dps.infDPS.toma.Item = "CPF";

            dps.infDPS.serv = new TCServPrest();
            dps.infDPS.serv.cMunPrestacao = "3106200";//"3304557";
            dps.infDPS.serv.cPaisPrestacao = "BR";
           // dps.infDPS.serv.cNBS = "115021000";
            dps.infDPS.serv.xDescServ = "SERVIÇO PADRÃO";
            //dps.infDPS.serv.cTribMun = "123";
            dps.infDPS.serv.cTribNac = "010201";
            dps.infDPS.serv.vServ = "1000.00";
            dps.infDPS.serv.xInfComp = "INFORMAÇÃO COMPLEMENTAR";
          //  dps.infDPS.serv.vReceb = "1000.00";

            dps.infDPS.trib = new TCInfoTributacao();
            dps.infDPS.trib.issqn = new TCTribISSQN();
            dps.infDPS.trib.issqn.exigISSQN = TSExigibISSQN.Tipo1;
            //dps.infDPS.trib.issqn.nProcesso = "123";
            dps.infDPS.trib.issqn.pAliq = "5.00";
            dps.infDPS.trib.issqn.regEspTrib = TSRegEspTrib.Item3;
     //       dps.infDPS.trib.issqn.tpImunidade = TSTipoImunidadeISSQN.Item1;
     //       dps.infDPS.trib.issqn.tpImunidadeSpecified = true;
            dps.infDPS.trib.issqn.tpRetISSQN = TSTipoRetISSQN.Item1;
            //            dps.infDPS.trib.issqn.vInfoBM = "1";

            //  dps.infDPS.trib.opLimMEI = TSOpSNLimUltrap.Item0;
            //  dps.infDPS.trib.opLimMEISpecified = true;
            // dps.infDPS.trib.opLimSimpNac = TSOpSNLimUltrap.Item0;
            //   dps.infDPS.trib.opLimSimpNacSpecified = true;
            //   dps.infDPS.trib.opSimpNac = TSOpSimpNac.Item1;
            dps.infDPS.trib.outros = new TCTribOutros();
            dps.infDPS.trib.outros.pi =
            dps.infDPS.trib.outros.CST = TSTipoCST.Item1;
            dps.infDPS.trib.outros.vBCPisCofins = "3000.00";
            dps.infDPS.trib.outros.pAliqPis ="0.65";
            dps.infDPS.trib.outros.pAliqCofins = "3.00";
            dps.infDPS.trib.outros.vPis = "19.50";
            dps.infDPS.trib.outros.vCofins = "90.00";
            dps.infDPS.trib.outros.tpRetPisConfins = TSTipoRetPISCofins.Item2;


            dps.infDPS.trib.totTrib = new TCTribTotal();
            dps.infDPS.trib.totTrib.Item = new TCTribTotalPercent();
            var totalTrib = dps.infDPS.trib.totTrib.Item as TCTribTotalPercent;
            totalTrib.pTotTribEst = "1.00";
            totalTrib.pTotTribFed = "1.00";
            totalTrib.pTotTribMun = "1.00";

            dps.Signature = Assinador.ObterAssinatura(dps, dps.infDPS.Id, certificado);

            return dps;
        }

        private void btnGerarEnviarDPS_Click(object sender, EventArgs e)
        {
            if (!CertificadoExiste())
            {
                MessageBox.Show("Certificado não encontrado");
                return;
            }

            if (String.IsNullOrEmpty(txtNumeroNFSe.Text))
            {
                MessageBox.Show("Informe o número que deverá ser gerado para a NFSe/DPS");
                return;
            }

            if (String.IsNullOrEmpty(txtMesAno.Text))
            {
                MessageBox.Show("Informe o mês/ano em que o arquivo deve ser gerado");
                return;
            }

            richGerado.Clear();


            try
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    var certificado = ObterCertificadoPeloSerial(Configuracao.certificado);
                    var diretorio = Application.StartupPath;
                    var nomeArquivo = txtNumeroNFSe.Text.PadLeft(15, '0') + ".xml";
                    var dps = ObterDPS();
                    //richTextBoxResultado.Clear();
                    var xmlnovo = FuncoesXml.ClasseParaXmlString<TCDPS>(dps);
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(xmlnovo);
                    var fullfilename = diretorio + "\\" + nomeArquivo;
                    doc.Save(fullfilename);

                    var statusValidacaoXML = FuncoesXml.XMLDPSEEhValido(xmlnovo, diretorio);

                    if (!statusValidacaoXML.Valido)
                    {
                        MessageBox.Show("Erro: " + statusValidacaoXML.Mensagem);
                    }

                    Dictionary<String, String> dict = new Dictionary<string, string>();
                    byte[] arq = File.ReadAllBytes(fullfilename);
                    byte[] comprimido = ComprimirGZIP(arq);
                    string XMLBase64 = base64_encode(comprimido);

                    dict.Add("dpsXmlGZipB64", XMLBase64);
                    var json = SimpleJson.SerializeObject(dict);
                    richGerado.AppendText(json);
                    nfsePostRequest postRequest = new nfsePostRequest();
                    postRequest.dpsXmlGZipB64 = XMLBase64;
                    var client = new RestClient(Configuracao.url);
                    client.ClientCertificates = new X509CertificateCollection();
                    client.ClientCertificates.Add(certificado);
                    var request = new RestRequest("/nfse", Method.POST);

                    request.RequestFormat = DataFormat.Json;
                    request.AddJsonBody(postRequest);

                    IRestResponse response = client.Execute(request);
                    var content = response.Content;

                    //if (response.ResponseStatus == ResponseStatus.Completed && response.StatusCode == HttpStatusCode.OK)
                    //{
                    //    NFSePostResponseSucesso obj = SimpleJson.DeserializeObject<NFSePostResponseSucesso>(content);
                    //    if (obj != null)
                    //    {
                    //        richResultado.AppendText("\n Tipo de ambiente: " + obj.tipoAmbiente);
                    //        richResultado.AppendText("\n Versão do aplicativo: " + obj.versaoAplicativo);
                    //        richResultado.AppendText("\n Chave de acesso: " + obj.chaveAcesso);
                    //        richResultado.AppendText("\n Data/Hora do processamento: " + obj.dataHoraProcessamento);
                    //        richResultado.AppendText("\n Id da DPS: " + obj.idDps);
                    //        if (obj.erros != null && obj.erros.Count > 0)
                    //        {
                    //            richResultado.AppendText("----------------- ERROS -----------------");
                    //            foreach (var al in obj.erros)
                    //            {
                    //                richResultado.AppendText("\n " + al.codigo + " - " + al.mensagem + " - " + al.descricao);
                    //            }
                    //        }

                    //       // richResultado.AppendText(content);
                    //    }
                    //}

                    richResultado.AppendText(content);

                    MessageBox.Show(String.Format("Arquivo {0} enviado com sucesso, confira o resultado na aba de resultado.", fullfilename));
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

        private void btnEncodar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(richGerado.Text))
            {
                MessageBox.Show("Informe o texto para encodar na memo gerado.");
                return;
            }

            byte[] arq = System.Text.Encoding.UTF8.GetBytes(richGerado.Text);

            byte[] comprimido = ComprimirGZIP(arq);
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

        private void btnGerarEnviarNFSE_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Não implementado");
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
            MessageBox.Show("Não implementado");
        }

        private void btnAssinarArquivoExistente_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CertificadoExiste())
                {
                    MessageBox.Show("Certificado não encontrado");
                    return;
                }

                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Title = "Selecione um arquivo XML de DPS";

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    var arquivo = openFileDialog1.FileName;

                    var xml = File.ReadAllText(arquivo);

                    var dps = FuncoesXml.XmlStringParaClasse<TCDPS>(xml);
                    var certificado = ObterCertificadoPeloSerial(Configuracao.certificado);
                    dps.Signature = Assinador.ObterAssinatura(dps, dps.infDPS.Id, certificado);

                    var xmlnovo = FuncoesXml.ClasseParaXmlString<TCDPS>(dps);
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
                    if (!CertificadoExiste())
                    {
                        MessageBox.Show("Certificado não encontrado");
                        return;
                    }

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
                    var xml = File.ReadAllText(arquivoExistente);
                    this.Cursor = Cursors.WaitCursor;
                    var certificado = ObterCertificadoPeloSerial(Configuracao.certificado);
                    var diretorio = Application.StartupPath;
                   // var nomeArquivo = txtNumeroNFSe.Text.PadLeft(15, '0') + ".xml";
                    var dps = FuncoesXml.XmlStringParaClasse<TCDPS>(xml);
                    var xmlnovo = FuncoesXml.ClasseParaXmlString<TCDPS>(dps);
                    //XmlDocument doc = new XmlDocument();
                    //doc.LoadXml(xmlnovo);
                    //var fullfilename = diretorio + "\\" + nomeArquivo;
                    //doc.Save(fullfilename);

                    var statusValidacaoXML = FuncoesXml.XMLDPSEEhValido(xmlnovo, diretorio);

                    if (!statusValidacaoXML.Valido)
                    {
                        MessageBox.Show("Erro: " + statusValidacaoXML.Mensagem);
                    }

                    Dictionary<String, String> dict = new Dictionary<string, string>();
                    byte[] arq = File.ReadAllBytes(arquivoExistente);
                    byte[] comprimido = ComprimirGZIP(arq);
                    string XMLBase64 = base64_encode(comprimido);

                    dict.Add("dpsXmlGZipB64", XMLBase64);
                    var json = SimpleJson.SerializeObject(dict);
                    richGerado.AppendText(json);
                    nfsePostRequest postRequest = new nfsePostRequest();
                    postRequest.dpsXmlGZipB64 = XMLBase64;
                    var client = new RestClient(Configuracao.url);
                    client.ClientCertificates = new X509CertificateCollection();
                    client.ClientCertificates.Add(certificado);
                    var request = new RestRequest("/nfse", Method.POST);


                    //Retorno erro RNG6159" - Não foi possível identificar a mensagem de requisição
                    //request.AddJsonBody(json);


                    //Retorna erro inesperado
                    //request.RequestFormat = DataFormat.Json;
                    //request.AddJsonBody(postRequest);

                    IRestResponse response = client.Execute(request);
                    var content = response.Content;

                    //if (response.ResponseStatus == ResponseStatus.Completed && response.StatusCode == HttpStatusCode.OK)
                    //{
                    //    NFSePostResponseSucesso obj = SimpleJson.DeserializeObject<NFSePostResponseSucesso>(content);
                    //    if (obj != null)
                    //    {
                    //        richResultado.AppendText("\n Tipo de ambiente: " + obj.tipoAmbiente);
                    //        richResultado.AppendText("\n Versão do aplicativo: " + obj.versaoAplicativo);
                    //        richResultado.AppendText("\n Chave de acesso: " + obj.chaveAcesso);
                    //        richResultado.AppendText("\n Data/Hora do processamento: " + obj.dataHoraProcessamento);
                    //        richResultado.AppendText("\n Id da DPS: " + obj.idDps);
                    //        if (obj.erros != null && obj.erros.Count > 0)
                    //        {
                    //            richResultado.AppendText("----------------- ERROS -----------------");
                    //            foreach (var al in obj.erros)
                    //            {
                    //                richResultado.AppendText("\n " + al.codigo + " - " + al.mensagem + " - " + al.descricao);
                    //            }
                    //        }

                    //       // richResultado.AppendText(content);
                    //    }
                    //}

                    richResultado.AppendText(content);

                    MessageBox.Show(String.Format("Arquivo {0} enviado com sucesso, confira o resultado na aba de resultado.", arquivoExistente));
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
    }
}
