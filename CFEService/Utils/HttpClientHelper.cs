using System.Net.Http;

namespace CFEService.Utils
{
    public static class HttpClientHelper
    {
        // Método para realizar uma requisição HTTP GET
        public static string Get(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                // Realiza a requisição GET e obtém a resposta
                HttpResponseMessage response = client.GetAsync(url).Result;

                // Verifica se a requisição foi bem-sucedida
                if (response.IsSuccessStatusCode)
                {
                    // Lê e retorna o conteúdo da resposta
                    return response.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    throw new HttpRequestException($"Falha na requisição: {response.StatusCode}");
                }
            }
        }
    }
}
