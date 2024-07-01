/*
O problema 1 do Project Euler é o seguinte:

Se listarmos todos os números naturais abaixo de 10 que são múltiplos de 3 ou 5,
obtemos 3, 5, 6 e 9. A soma desses múltiplos é 23.

Encontre a soma de todos os múltiplos de 3 ou 5 abaixo de 1000.

Para resolver esse problema, podemos iterar sobre todos os números abaixo de 1000
e somar aqueles que são múltiplos de 3 ou 5. Aqui está uma solução em C#:
*/
using System;

namespace ProjectEuler
{
    // Classe principal do programa
    public class Problem1
    {
        // Método principal que será executado ao iniciar o programa
        public static void Main(string[] args)
        {
            // Cria uma instância da classe que resolverá o problema
            SumMultiples sumMultiples = new SumMultiples(3, 5, 1000);
            
            // Chama o método para calcular a soma dos múltiplos e armazena o resultado
            int result = sumMultiples.CalculateSum();
            
            // Exibe o resultado no console
            Console.WriteLine($"A soma de todos os múltiplos de 3 ou 5 abaixo de 1000 é: {result}");
        }
    }

    // Classe responsável por calcular a soma dos múltiplos
    public class SumMultiples
    {
        // Atributos para armazenar os valores dos múltiplos e o limite
        private int multiple1;
        private int multiple2;
        private int limit;

        // Construtor que inicializa os atributos
        public SumMultiples(int multiple1, int multiple2, int limit)
        {
            this.multiple1 = multiple1;
            this.multiple2 = multiple2;
            this.limit = limit;
        }

        // Método que calcula a soma dos múltiplos
        public int CalculateSum()
        {
            int sum = 0; // Variável para armazenar a soma

            // Loop para iterar por todos os números abaixo do limite
            for (int i = 0; i < limit; i++)
            {
                // Verifica se o número atual é múltiplo de multiple1 ou multiple2
                if (i % multiple1 == 0 || i % multiple2 == 0)
                {
                    sum += i; // Adiciona o número à soma
                }
            }

            return sum; // Retorna a soma calculada
        }
    }
}
