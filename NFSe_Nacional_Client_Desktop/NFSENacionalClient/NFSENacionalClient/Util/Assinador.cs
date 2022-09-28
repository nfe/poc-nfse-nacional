using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace NFSENacionalClient.Util
{
    public static class Assinador
    {
        public static NFSENacionalClient.Classes.SignatureType ObterAssinatura<T>(T objeto, string id, X509Certificate2 certificadoDigital, string signatureMethod = "http://www.w3.org/2000/09/xmldsig#rsa-sha1", string digestMethod = "http://www.w3.org/2000/09/xmldsig#sha1") where T : class
        {
            var objetoLocal = objeto;
            if (id == null)
                throw new Exception("Não é possível assinar um objeto evento sem sua respectiva Id!");

            try
            {
                var documento = new XmlDocument { PreserveWhitespace = true };
                documento.LoadXml(FuncoesXml.ClasseParaXmlString(objetoLocal));
                var docXml = new SignedXml(documento) { SigningKey = certificadoDigital.PrivateKey };

                docXml.SignedInfo.SignatureMethod = signatureMethod;

                var reference = new Reference { Uri = "#" + id, DigestMethod = digestMethod };

                // adicionando EnvelopedSignatureTransform a referencia
                var envelopedSigntature = new XmlDsigEnvelopedSignatureTransform();
                reference.AddTransform(envelopedSigntature);

                var c14Transform = new XmlDsigC14NTransform();
                reference.AddTransform(c14Transform);

                docXml.AddReference(reference);

                // carrega o certificado em KeyInfoX509Data para adicionar a KeyInfo
                var keyInfo = new KeyInfo();
                keyInfo.AddClause(new KeyInfoX509Data(certificadoDigital));

                docXml.KeyInfo = keyInfo;
                docXml.ComputeSignature();

                //// recuperando a representação do XML assinado
                var xmlDigitalSignature = docXml.GetXml();
                var assinatura = FuncoesXml.XmlStringParaClasse<NFSENacionalClient.Classes.SignatureType>(xmlDigitalSignature.OuterXml);
                return assinatura;
            }
            finally
            {
                
            }

        }
    }
}
