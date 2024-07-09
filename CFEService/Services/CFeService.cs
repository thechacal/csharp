using CFEService.Models;
using CFEService.Utils;
using Newtonsoft.Json;
using System;

namespace CFEService.Services
{
    public class CFeService
    {
        // URL do web service de consulta de CF-e
        private const string ServiceUrl = "https://cfews.sefaz.ce.gov.br/integracaows/cfe/cupom/listacfes";

        // Método para realizar a consulta de CF-e
        public CFeResponse? ConsultarCFe(string cnpj, string serie, string dataConsulta, string chave)
        {
            // Monta a URL de consulta com os parâmetros fornecidos
            string requestUrl = $"{ServiceUrl}?cnpj={cnpj}&numSerie={serie}&dataConsulta={dataConsulta}&chaveServico={chave}";

            try
            {
                // Usa o HttpClientHelper para fazer a requisição HTTP GET
                var jsonResponse = HttpClientHelper.Get(requestUrl);

                // Deserializa a resposta JSON para o modelo CFeResponse
                var response = JsonConvert.DeserializeObject<CFeResponse>(jsonResponse);

                return response ?? new CFeResponse();  // Retorna uma nova instância se a resposta for nula
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao consultar CF-e: {ex.Message}");
                return null;
            }
        }
    }
}
