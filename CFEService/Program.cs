using System;

namespace CFEService
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instancia o serviço de consulta de CF-e
            var cfeService = new Services.CFeService();

            // Define os parâmetros para a consulta
            string cnpj = "12345678000195";
            string serie = "001";
            string dataConsulta = DateTime.Now.AddDays(-2).ToString("yyyyMMdd"); // Data de consulta deve ser dois dias atrás
            string chave = "ABCDEFG123456789";

            // Realiza a consulta
            var response = cfeService.ConsultarCFe(cnpj, serie, dataConsulta, chave);

            // Verifica e exibe o resultado da consulta
            if (response != null)
            {
                Console.WriteLine("Consulta realizada com sucesso!");
                Console.WriteLine($"Status: {response.Status}");
                Console.WriteLine($"Mensagem: {response.Mensagem}");
                // Exibir outros detalhes conforme necessário
            }
            else
            {
                Console.WriteLine("Falha na consulta de CF-e.");
            }
        }
    }
}
