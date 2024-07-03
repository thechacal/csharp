using System.Collections.Generic;

namespace AcessandoAPIsExternas.Models
{
    // Define a classe Rastreamento que representa o rastreamento de uma encomenda
    public class Rastreamento
    {
        // Propriedade que armazena o código de rastreamento
        public string Codigo { get; set; } = string.Empty;

        // Propriedade que armazena o serviço utilizado no rastreamento
        public string Servico { get; set; } = string.Empty;

        // Propriedade que armazena a data e hora do último evento de rastreamento
        public string Ultimo { get; set; } = string.Empty;

        // Propriedade que armazena a lista de eventos de rastreamento
        public List<Evento> Eventos { get; set; } = new List<Evento>();
    }
}
