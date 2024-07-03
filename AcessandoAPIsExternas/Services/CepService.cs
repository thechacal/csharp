using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using AcessandoAPIsExternas.Models;

namespace AcessandoAPIsExternas.Services
{
    public class CepService
    {
        // Cliente HTTP para realizar requisições
        private static readonly HttpClient client = new HttpClient();

        public async Task<Endereco?> ObterEnderecoAsync(string cep)
        {
            // Monta a URL da API com o CEP informado
            string url = $"https://viacep.com.br/ws/{cep}/json/";

            try
            {
                // Envia a requisição GET para a API
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode(); // Verifica se a resposta foi bem-sucedida
                string responseBody = await response.Content.ReadAsStringAsync(); // Lê o corpo da resposta como string

                // Converte a string JSON para um objeto Endereco
                return JsonConvert.DeserializeObject<Endereco>(responseBody);
            }
            catch (HttpRequestException e) when (e.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
            {
                Console.WriteLine("Limite de solicitações excedido. Tente novamente mais tarde.");
                return null;
            }
            catch (HttpRequestException e)
            {
                // Trata exceções de requisição HTTP
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return null; // Retorna nulo em caso de erro
            }
        }
    }
}
