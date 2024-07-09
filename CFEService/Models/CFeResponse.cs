namespace CFEService.Models
{
    public class CFeResponse
    {
        public string Status { get; set; } = string.Empty;  // Inicializa com uma string vazia
        public string Mensagem { get; set; } = string.Empty;  // Inicializa com uma string vazia
        public int Quantidade { get; set; }
        public CFe[] CFeDetalhes { get; set; } = Array.Empty<CFe>();  // Inicializa com um array vazio

        // Construtor sem parâmetros para assegurar que as propriedades sejam inicializadas
        public CFeResponse() { }
    }

    public class CFe
    {
        public string NumeroSequencial { get; set; } = string.Empty;  // Inicializa com uma string vazia
        public string DataHoraEmissao { get; set; } = string.Empty;  // Inicializa com uma string vazia
        public string Chave { get; set; } = string.Empty;  // Inicializa com uma string vazia

        // Construtor sem parâmetros para assegurar que as propriedades sejam inicializadas
        public CFe() { }
    }
}
