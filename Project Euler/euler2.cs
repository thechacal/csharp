/*
O problema 2 do Project Euler é o seguinte: https://projecteuler.net/problem=2

Cada novo termo na sequência de Fibonacci é gerado pela adição dos dois termos anteriores.
Começando com 1 e 2, os 10 primeiros termos serão: 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...
Encontre a soma de todos os termos pares da sequência de Fibonacci que são menores
que 4 milhões.
Resposta: 4613732

Aqui está uma solução em C#:
*/

using System;

namespace ProjectEuler
{
    // Classe principal do programa
    public class Problem2
    {
        // Método principal que será executado ao iniciar o programa
        public static void Main(string[] args)
        {
            // Cria uma instância da classe que resolverá o problema
            EvenFibonacciSum evenFibonacciSum = new EvenFibonacciSum(4000000);
            
            // Chama o método para calcular a soma dos termos pares da sequência de Fibonacci e armazena o resultado
            int result = evenFibonacciSum.CalculateSum();
            
            // Exibe o resultado no console
            Console.WriteLine($"A soma de todos os termos pares da sequência de Fibonacci abaixo de 4 milhões é: {result}");
        }
    }

    // Classe responsável por calcular a soma dos termos pares da sequência de Fibonacci
    public class EvenFibonacciSum
    {
        // Atributo para armazenar o limite
        private int limit;

        // Construtor que inicializa o atributo
        public EvenFibonacciSum(int limit)
        {
            this.limit = limit;
        }

        // Método que calcula a soma dos termos pares da sequência de Fibonacci
        public int CalculateSum()
        {
            int sum = 0; // Variável para armazenar a soma
            int a = 1;   // Primeiro termo da sequência de Fibonacci
            int b = 2;   // Segundo termo da sequência de Fibonacci

            // Loop enquanto os termos da sequência forem menores que o limite
            while (a <= limit)
            {
                // Verifica se o termo atual é par
                if (a % 2 == 0)
                {
                    sum += a; // Adiciona o termo à soma
                }

                // Atualiza os termos da sequência de Fibonacci
                int temp = a + b;
                a = b;
                b = temp;
            }

            return sum; // Retorna a soma calculada
        }
    }
}
