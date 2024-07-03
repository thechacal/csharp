using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using AcessandoAPIsExternas.Models;

namespace AcessandoAPIsExternas.Services
{
    public class RastreamentoService
    {
        // Cliente HTTP para realizar requisições
        private static readonly HttpClient client = new HttpClient();

        private readonly string _user; // Usuário para autenticação na API
        private readonly string _token; // Token para autenticação na API

        public RastreamentoService(string user, string token)
        {
            _user = user;
            _token = token;
        }

        public async Task<Rastreamento?> ObterRastreamentoAsync(string codigo)
        {
            // Monta a URL da API com os parâmetros necessários
            string url = $"https://api.linketrack.com/track/json?user={_user}&token={_token}&codigo={codigo}";

            try
            {
                // Envia a requisição GET para a API
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode(); // Verifica se a resposta foi bem-sucedida
                string responseBody = await response.Content.ReadAsStringAsync(); // Lê o corpo da resposta como string

                // Converte a string JSON para um objeto Rastreamento
                return JsonConvert.DeserializeObject<Rastreamento>(responseBody);
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
