namespace AcessandoAPIsExternas.Models
{
    // Define a classe Evento que representa um evento de rastreamento de encomenda
    public class Evento
    {
        // Propriedade que armazena a data do evento
        public string Data { get; set; } = string.Empty;

        // Propriedade que armazena a hora do evento
        public string Hora { get; set; } = string.Empty;

        // Propriedade que armazena o local do evento
        public string Local { get; set; } = string.Empty;

        // Propriedade que armazena o status do evento
        public string Status { get; set; } = string.Empty;

        // Propriedade que armazena os substatus do evento, se houver
        public string[] SubStatus { get; set; } = Array.Empty<string>();
    }
}
