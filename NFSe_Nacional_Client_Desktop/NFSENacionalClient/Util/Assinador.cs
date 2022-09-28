using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Xml;

namespace NFSENacionalClient.Util
{
    public static class Assinador
    {
        public static string ObterAssinatura(string xml = "", string caminhoCertificado = "", string senhaCertificado = "", string signTagName = "", string referenceTagName = "")
        {
            if (xml == null)
                throw new Exception("Erro ao realizar a assinatura do documento, o XML encontra-se vazio.");

            if (caminhoCertificado == null)
                throw new Exception("Erro ao realizar a assinatura do documento, o caminho do certificado (.pfx) não foi informado.");

            if (senhaCertificado == null)
                throw new Exception("Erro ao realizar a assinatura do documento, a senha do certificado não foi informada.");

            try
            {
                var documento = new XmlDocument();
                documento.LoadXml(xml);

                XmlNode signTag = signTagName != null ? documento.GetElementsByTagName(signTagName)[0] : documento.FirstChild;
                XmlNode referenceTag = referenceTagName != null ? documento.GetElementsByTagName(referenceTagName)[0] : null;

                var referenceUri = referenceTag != null
                ? '#' + (referenceTag.Attributes["Id"] ?? referenceTag.Attributes["id"]).Value : string.Empty;

                var keyInfo = new KeyInfo();
                var certicado = new X509Certificate2(caminhoCertificado, senhaCertificado);
                keyInfo.AddClause(new KeyInfoX509Data(certicado));

                var reference = new Reference(uri: referenceUri) { DigestMethod = SignedXml.XmlDsigSHA1Url };
                reference.AddTransform(new XmlDsigEnvelopedSignatureTransform());
                reference.AddTransform(new XmlDsigC14NTransform());

                var signedXml = new SignedXml(signTag as XmlElement) { SigningKey = certicado.PrivateKey, KeyInfo = keyInfo };
                signedXml.SignedInfo.SignatureMethod = SignedXml.XmlDsigRSASHA1Url;
                signedXml.AddReference(reference);
                signedXml.ComputeSignature();

                var signature = signedXml.GetXml();
                signTag.AppendChild(documento.ImportNode(signature, true));

                return documento.OuterXml;
            }
            finally
            {
                
            }
        }

        public static X509Certificate2 GetCertificate(string caminhoCertificado, string senhaCertificado)
        {
            return new X509Certificate2(caminhoCertificado, senhaCertificado);
        }
    }
}
