using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFSENacionalClient.Classes2
{
    public class NFSePostResponseSucesso
    {
        public int tipoAmbiente { get; set; }
        public string versaoAplicativo { get; set; }
        public string dataHoraProcessamento { get; set; }
        public string idDps { get; set; }
        public string chaveAcesso { get; set; }
        public string nfseXmlGZipB64 { get; set; }
        public string eventoXmlGZipB64 { get; set; }
        public List<Alerta> erros { get; set; }
    }

    public class Alerta
    {
        public int mensagem { get; set; }
        public string codigo { get; set; }
        public string descricao { get; set; }
        public string correcao { get; set; }
        public string complemento { get; set; }
    }
}
