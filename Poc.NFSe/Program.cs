using Newtonsoft.Json;
using System;
using System.IO;
using System.IO.Compression;
using System.Net.Http;
using System.Security.Authentication;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Xml;

namespace NFSe.PocLive
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testes das APIs para os contribuintes do issqn no sistema nacional NFS-e (Contribuição de https://nfe.io, https://mxm.com.br e https://iob.com.br)");

            //
            // Teste API
            // Recepciona a DPS e Gera a NFS-e de forma síncrona.
            //
            var responseContent = TesteEmissaoNFSe();
            Console.WriteLine(responseContent);
            Console.ReadLine();

            // tratamento da resposta da emissão
            var defNFSeReponse = new { idDps = string.Empty, chaveAcesso = string.Empty, nfseXmlGZipB64 = string.Empty, erros = new[] { new { Parametros = string.Empty, Codigo = string.Empty, Descricao = string.Empty, Complemento = string.Empty } } };
            var jsonResponse = JsonConvert.DeserializeAnonymousType(responseContent, defNFSeReponse);
            if (jsonResponse != null && jsonResponse.erros == null)
            {
                // gravação do xml da nfse caso tenha sido emitida com sucesso
                using var rgziped = new MemoryStream(Encoding.UTF8.GetBytes(jsonResponse.nfseXmlGZipB64));
                using var cryptoStream = new CryptoStream(rgziped, new FromBase64Transform(), CryptoStreamMode.Read);
                using var gzip = new GZipStream(cryptoStream, CompressionMode.Decompress);
                using var ungziped = new FileStream($@"post{jsonResponse.idDps}.xml", FileMode.Create);
                gzip.CopyTo(ungziped);
            }

            //
            // Teste API
            // Retorna a NFS-e a partir da consulta pela chave de acesso correspondente (50 posições).
            //
            var chaveAcesso = jsonResponse.chaveAcesso; // chave de acesso da emissão
            TesteConsultaNFSe(chaveAcesso);

            //
            // Teste API
            // Obter NFS-e pagáveis pelo contribuinte.
            //
            var responseContentGet = TesteNFSeListagem();
            Console.WriteLine(responseContentGet);
            Console.ReadLine();
        }

        private static string TesteNFSeListagem()
        {
            var responseGet = CreateHttpClient()
                            .GetAsync("nfse/47712795000124/2022-06/1400159/1")
                            .GetAwaiter().GetResult();
            var responseContentGet = responseGet.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return responseContentGet;
        }

        private static void TesteConsultaNFSe(string chaveAcesso)
        {
            var response = CreateHttpClient().GetAsync($"nfse/{chaveAcesso}")
                            .GetAwaiter().GetResult();

            var defGetNFSeReponse = new { chaveAcesso = string.Empty, nfseXmlGZipB64 = string.Empty, erro = new { Parametros = string.Empty, Codigo = string.Empty, Descricao = string.Empty, Complemento = string.Empty } };
            var jsonGetResponse = JsonConvert.DeserializeAnonymousType(response.Content.ReadAsStringAsync().GetAwaiter().GetResult(), defGetNFSeReponse);
            // tratamento da resposta da consulta do xml
            if (jsonGetResponse != null && jsonGetResponse.erro == null)
            {
                // gravação do xml da nfse caso tenha sido emitida com sucesso
                using var rgziped = new MemoryStream(Encoding.UTF8.GetBytes(jsonGetResponse.nfseXmlGZipB64));
                using var cryptoStream = new CryptoStream(rgziped, new FromBase64Transform(), CryptoStreamMode.Read);
                using var gzip = new GZipStream(cryptoStream, CompressionMode.Decompress);
                using var ungziped = new FileStream($@"{jsonGetResponse.chaveAcesso}.xml", FileMode.Create);
                gzip.CopyTo(ungziped);
            }
        }

        private static string TesteEmissaoNFSe()
        {
            // leitura do xml
            var xml = File.ReadAllText(@"..\..\..\assets\dps-teste.xml");
            var signedXml = SignSHA1(xml, GetCertificate(), "DPS", "infDPS");

            // gravação do xml assinado
            //File.WriteAllText(@"..\..\..\dps-signed.xml", signedXml);

            var gziped = new MemoryStream();
            using (var gzip = new GZipStream(gziped, CompressionMode.Compress))
                gzip.Write(Encoding.UTF8.GetBytes(signedXml));
            var dpsXmlGZipB64 = Convert.ToBase64String(gziped.ToArray());

            // gravação do json
            var json = $"{{\"dpsXmlGZipB64\":\"{dpsXmlGZipB64}\"}}";
            //File.WriteAllText(@"..\..\..\json-signed.json", json);

            // emissão da nfse
            var response = CreateHttpClient().PostAsync("nfse",
                new StringContent(json, Encoding.UTF8, "application/json"))
                .GetAwaiter().GetResult();
            
            return response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        }

        public static X509Certificate2 GetCertificate()
        {
            X509Certificate2 certificate = default;

            // carregamento do certificado via arquivo e senha
            var certificatePath = @"CAMINHO_PARA_CERTIFICADO_A1.pfx";
            var certificatePassword = "SENHA_CERTIFICADO";
            if (File.Exists(certificatePath))
                certificate = new X509Certificate2(certificatePath, certificatePassword);

            // carregamento do certificado via sistema operacional
            var certificateThumbprint = Environment.GetEnvironmentVariable("POC_NFSE_CERT_THUMBPRINT");
            var store = new X509Store(StoreName.My, StoreLocation.CurrentUser, OpenFlags.ReadOnly);
            var certificates = store.Certificates.Find(X509FindType.FindByThumbprint, certificateThumbprint, true);
            if (certificates.Count > 0)
                certificate = certificates[0];
            store.Close();

            return certificate;
        }

        public static HttpClient CreateHttpClient()
        {
            var handler = new HttpClientHandler
            {
                ClientCertificateOptions = ClientCertificateOption.Manual,
                SslProtocols = SslProtocols.Tls12
            };
            handler.ClientCertificates.Add(GetCertificate());

            return new HttpClient(handler)
            {
                BaseAddress = new System.Uri("https://sefin.producaorestrita.nfse.gov.br/sefinnacional/")
            };
        }

        public static string SignSHA1(string xml, X509Certificate2 certificate, string signTagName = null, string referenceTagName = null)
        {
            var document = new XmlDocument();
            document.LoadXml(xml);

            XmlNode signTag = signTagName is not null ? document.GetElementsByTagName(signTagName)[0] : document.FirstChild;
            XmlNode referenceTag = referenceTagName is not null ? document.GetElementsByTagName(referenceTagName)[0] : null;

            var referenceUri = referenceTag is not null
                ? '#' + (referenceTag.Attributes["Id"] ?? referenceTag.Attributes["id"]).Value : string.Empty;

            var reference = new Reference(uri: referenceUri)
            {
                DigestMethod = SignedXml.XmlDsigSHA1Url
            };
            reference.AddTransform(new XmlDsigEnvelopedSignatureTransform());
            reference.AddTransform(new XmlDsigC14NTransform());

            var signedXml = new SignedXml(signTag as XmlElement);
            signedXml.SigningKey = certificate.GetRSAPrivateKey();
            signedXml.KeyInfo = new KeyInfo();
            signedXml.KeyInfo.AddClause(new KeyInfoX509Data(certificate));
            signedXml.SignedInfo.SignatureMethod = SignedXml.XmlDsigRSASHA1Url;
            signedXml.AddReference(reference);
            signedXml.ComputeSignature();

            signTag.AppendChild(document.ImportNode(signedXml.GetXml(), true));
            return document.OuterXml;
        }
    }
}
