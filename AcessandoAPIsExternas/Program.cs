using System;
using System.Threading.Tasks;
using AcessandoAPIsExternas.Models;
using AcessandoAPIsExternas.Services;

namespace AcessandoAPIsExternas
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string user = "teste"; // Usuário para autenticação na API de rastreamento
            string token = "1abcd00b2731640e886fb41a8a9671ad1434c599dbaa0a0de9a5aa619f29a83f"; // Token para autenticação na API de rastreamento

            while (true)
            {
                // Exibe o menu de opções
                Console.WriteLine("\nMenu de Opções:");
                Console.WriteLine("[1] Consultar rastreio de encomendas");
                Console.WriteLine("[2] Consultar CEP");
                Console.WriteLine("[3] Sair");
                Console.Write("Escolha uma opção: ");
                
                // Lê a opção escolhida pelo usuário
                string? opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        // Consulta rastreamento de encomendas
                        Console.Write("Digite o código de rastreamento: ");
                        string? codigo = Console.ReadLine();

                        if (!string.IsNullOrEmpty(codigo))
                        {
                            await ConsultarRastreamentoAsync(user, token, codigo);
                        }
                        else
                        {
                            Console.WriteLine("Código de rastreamento inválido.\n");
                        }
                        break;

                    case "2":
                        // Consulta CEP
                        Console.Write("Digite o CEP: ");
                        string? cep = Console.ReadLine();

                        if (!string.IsNullOrEmpty(cep))
                        {
                            await ConsultarCepAsync(cep);
                        }
                        else
                        {
                            Console.WriteLine("CEP inválido.\n");
                        }
                        break;

                    case "3":
                        // Sai do programa
                        Console.WriteLine("Saindo do programa...");
                        return;

                    default:
                        // Opção inválida
                        Console.WriteLine("Opção inválida. Tente novamente.\n");
                        break;
                }
            }
        }

        static async Task ConsultarRastreamentoAsync(string user, string token, string codigo)
        {
            var rastreamentoService = new RastreamentoService(user, token); // Instancia o serviço de rastreamento
            Rastreamento? rastreamento = await rastreamentoService.ObterRastreamentoAsync(codigo); // Obtém o rastreamento

            if (rastreamento != null)
            {
                // Exibe os detalhes do rastreamento
                Console.WriteLine($"\nCodigo: {rastreamento.Codigo}");
                Console.WriteLine($"Servico: {rastreamento.Servico}");
                Console.WriteLine($"Ultimo Evento: {rastreamento.Ultimo}\n");
                
                if (rastreamento.Eventos != null)
                {
                    // Exibe os eventos do rastreamento
                    foreach (var evento in rastreamento.Eventos)
                    {
                        Console.WriteLine($"Data: {evento.Data}, Hora: {evento.Hora}, Local: {evento.Local}, Situação: {evento.Status}\n");
                    }
                }
                else
                {
                    Console.WriteLine("Nenhum evento encontrado.\n");
                }
            }
        }

        static async Task ConsultarCepAsync(string cep)
        {
            var cepService = new CepService(); // Instancia o serviço de consulta de CEP
            Endereco? endereco = await cepService.ObterEnderecoAsync(cep); // Obtém o endereço

            if (endereco != null)
            {
                // Exibe os detalhes do endereço
                Console.WriteLine($"\nCEP: {endereco.Cep}");
                Console.WriteLine($"Logradouro: {endereco.Logradouro}");
                Console.WriteLine($"Complemento: {endereco.Complemento}");
                Console.WriteLine($"Bairro: {endereco.Bairro}");
                Console.WriteLine($"Localidade: {endereco.Localidade}");
                Console.WriteLine($"UF: {endereco.Uf}");
            }
        }
    }
}
