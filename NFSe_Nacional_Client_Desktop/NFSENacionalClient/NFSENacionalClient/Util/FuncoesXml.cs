using NFSENacionalClient.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace NFSENacionalClient.Util
{
    public static class FuncoesXml
    {
        internal static void ValidationEventHandler(object sender, ValidationEventArgs args)
        {
            throw new ValidacaoSchemaException(args.Message);
        }

        public static StatusValidacaoXML XMLNFSEEhValido(String xml, String pathSchema)
        {
            StatusValidacaoXML status = new StatusValidacaoXML();

            var arquivoSchema = pathSchema + @"\" + "NFSe_v1.00.xsd";

            // Define o tipo de validação
            var cfg = new XmlReaderSettings { ValidationType = ValidationType.Schema };

            // Carrega o arquivo de esquema
            var schemas = new XmlSchemaSet();
            cfg.Schemas = schemas;
            // Quando carregar o eschema, especificar o namespace que ele valida
            // e a localização do arquivo 
            schemas.Add(null, arquivoSchema);
            // Especifica o tratamento de evento para os erros de validacao
            cfg.ValidationEventHandler += ValidationEventHandler;
            // cria um leitor para validação
            var validator = XmlReader.Create(new StringReader(xml), cfg);
            using (XmlReader.Create(new StringReader(xml), cfg))
            {
                try
                {
                    // Faz a leitura de todos os dados XML
                    while (validator.Read())
                    {
                    }
                    status.Valido = true;
                }
                catch (XmlException err)
                {
                    // Um erro ocorre se o documento XML inclui caracteres ilegais
                    // ou tags que não estão aninhadas corretamente
                    status.Valido = false;
                    var mensagem = "Ocorreu o seguinte erro durante a validação XML:" + "\n" + err.Message;
                    status.Mensagem = mensagem;
                    throw new Exception(mensagem);

                }
            }

            return status;
        }

        public static StatusValidacaoXML XMLDPSEEhValido(String xml, String pathSchema)
        {
            StatusValidacaoXML status = new StatusValidacaoXML();

            var arquivoSchema = pathSchema + @"\" + "DPS_v1.00.xsd";

            // Define o tipo de validação
            var cfg = new XmlReaderSettings { ValidationType = ValidationType.Schema };

            // Carrega o arquivo de esquema
            var schemas = new XmlSchemaSet();
            cfg.Schemas = schemas;
            // Quando carregar o eschema, especificar o namespace que ele valida
            // e a localização do arquivo 
            schemas.Add(null, arquivoSchema);
            // Especifica o tratamento de evento para os erros de validacao
            cfg.ValidationEventHandler += ValidationEventHandler;
            // cria um leitor para validação
            var validator = XmlReader.Create(new StringReader(xml), cfg);
            using (XmlReader.Create(new StringReader(xml), cfg))
            {
                try
                {
                    // Faz a leitura de todos os dados XML
                    while (validator.Read())
                    {
                    }
                    status.Valido = true;
                }
                catch (XmlException err)
                {
                    // Um erro ocorre se o documento XML inclui caracteres ilegais
                    // ou tags que não estão aninhadas corretamente
                    status.Valido = false;
                    var mensagem = "Ocorreu o seguinte erro durante a validação XML:" + "\n" + err.Message;
                    status.Mensagem = mensagem;
                    throw new Exception(mensagem);

                }
            }

            return status;
        }

        /// <summary>
        ///     Serializa a classe passada para uma string no form
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objeto"></param>
        /// <returns></returns>
        public static string ClasseParaXmlString<T>(T objeto, Boolean UseBaseType = false)
        {
            XElement xml;
            XmlSerializer ser = null;
            if (UseBaseType)
            {
                ser = XmlSerializer.FromTypes(new[] { objeto.GetType() })[0];
            }
            else
            {
                ser = XmlSerializer.FromTypes(new[] { typeof(T) })[0];
            }


            using (var memory = new MemoryStream())
            {
                using (TextReader tr = new StreamReader(memory, Encoding.UTF8))
                {
                    ser.Serialize(memory, objeto);
                    memory.Position = 0;
                    xml = XElement.Load(tr);
                    xml.Attributes().Where(x => x.Name.LocalName.Equals("xsd") || x.Name.LocalName.Equals("xsi")).Remove();
                }
            }
            return XElement.Parse(xml.ToString()).ToString(SaveOptions.DisableFormatting);
        }

        /// <summary>
        ///     Deserializa a classe a partir de uma String contendo a estrutura XML daquela classe
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        public static T XmlStringParaClasse<T>(string input) where T : class
        {
            var ser = XmlSerializer.FromTypes(new[] { typeof(T) })[0];

            using (var sr = new StringReader(input))
                return (T)ser.Deserialize(sr);
        }

        /// <summary>
        ///     Carrega o objeto da classe com dados do arquivo XML (Deserializa a classe). Atenção o XML deve ter a mesma
        ///     estrutura da classe
        /// </summary>
        /// <typeparam name="T">Classe</typeparam>
        /// <param name="arquivo">Arquivo XML</param>
        /// <returns>Retorna a classe</returns>
        public static T ArquivoXmlParaClasse<T>(string arquivo) where T : class
        {
            if (!File.Exists(arquivo))
            {
                throw new FileNotFoundException("Arquivo " + arquivo + " não encontrado!");
            }

            var serializador = XmlSerializer.FromTypes(new[] { typeof(T) })[0];
            var stream = new FileStream(arquivo, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            try
            {
                return (T)serializador.Deserialize(stream);
            }
            finally
            {
                stream.Close();
            }
        }

        /// <summary>
        ///     Copia a estrutura e os dados da classe passada para um arquivo XML (Serializa a classe). Use try catch para tratar
        ///     a possível exceção "DirectoryNotFoundException"
        /// </summary>
        /// <typeparam name="T">Classe</typeparam>
        /// <param name="objeto">Objeto da Classe</param>
        /// <param name="arquivo">Arquivo XML</param>
        public static void ClasseParaArquivoXml<T>(T objeto, string arquivo)
        {
            var dir = Path.GetDirectoryName(arquivo);
            if (dir != null && !Directory.Exists(dir))
            {
                throw new DirectoryNotFoundException("Diretório " + dir + " não encontrado!");
            }

            var xml = ClasseParaXmlString(objeto);
            try
            {
                using (var stw = new StreamWriter(arquivo))
                {
                    stw.WriteLine(xml);
                }
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível criar o arquivo " + arquivo + "!");
            }
        }

        public static void SalvarStringXmlParaArquivoXml(string xml, string arquivo)
        {
            var dir = Path.GetDirectoryName(arquivo);
            if (dir != null && !Directory.Exists(dir))
            {
                throw new DirectoryNotFoundException("Diretório " + dir + " não encontrado!");
            }

            try
            {
                using (var stw = new StreamWriter(arquivo))
                {
                    stw.WriteLine(xml);
                }                
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível criar o arquivo " + arquivo + "!");
            }
        }

        /// <summary>
        ///     Obtém um node XML no formato string de um arquivo XML. Util por exemplo, para extrair uma NFe de um XML contendo um
        ///     nfeproc, enviNFe, etc.
        /// </summary>
        /// <param name="nomeDoNode"></param>
        /// <param name="arquivoXml"></param>
        /// <returns>Retorna a string contendo o node XML cujo nome foi passado no parâmetro nomeDoNode</returns>
        public static string ObterNodeDeArquivoXml(string nomeDoNode, string arquivoXml)
        {
            var xmlDoc = XDocument.Load(arquivoXml);
            var xmlString = (from d in xmlDoc.Descendants()
                             where d.Name.LocalName == nomeDoNode
                             select d).FirstOrDefault();

            if (xmlString == null)
                throw new Exception(String.Format("Nenhum objeto {0} encontrado no arquivo {1}!", nomeDoNode, arquivoXml));
            return xmlString.ToString();
        }

        /// <summary>
        ///     Obtém um node XML no formato string de um arquivo XML. Util por exemplo, para extrair uma NFe de um XML contendo um
        ///     nfeproc, enviNFe, etc.
        /// </summary>
        /// <param name="nomeDoNode"></param>
        /// <param name="stringXml"></param>
        /// <returns>Retorna a string contendo o node XML cujo nome foi passado no parâmetro nomeDoNode</returns>
        public static string ObterNodeDeStringXml(string nomeDoNode, string stringXml)
        {
            var s = stringXml;
            var xmlDoc = XDocument.Parse(s);
            var xmlString = (from d in xmlDoc.Descendants()
                             where d.Name.LocalName == nomeDoNode
                             select d).FirstOrDefault();

            if (xmlString == null)
                throw new Exception(String.Format("Nenhum objeto {0} encontrado no xml!", nomeDoNode));
            return xmlString.ToString();
        }
    }
}
