/*
O problema 6 do Project Euler é o seguinte: https://projecteuler.net/problem=6

Encontre a diferença entre a soma dos quadrados dos primeiros 100 números naturais e o quadrado da soma.
Resposta: 25164150

Aqui está uma solução em C#:
*/
using System;

namespace ProjectEuler
{
    // Classe principal do programa
    public class Problem6
    {
        // Método principal que será executado ao iniciar o programa
        public static void Main(string[] args)
        {
            // Define o número de naturais
            int n = 100;

            // Cria uma instância da classe que resolverá o problema
            SumSquareDifference sumSquareDifference = new SumSquareDifference();
            
            // Chama o método para encontrar a diferença entre a soma dos quadrados e o quadrado da soma
            long result = sumSquareDifference.FindDifference(n);
            
            // Exibe o resultado no console
            Console.WriteLine($"A diferença entre a soma dos quadrados dos primeiros {n} números naturais e o quadrado da soma é: {result}");
        }
    }

    // Classe responsável por encontrar a diferença entre a soma dos quadrados e o quadrado da soma
    public class SumSquareDifference
    {
        // Método para calcular a soma dos quadrados dos primeiros n números naturais
        private long SumOfSquares(int n)
        {
            long sum = 0;

            // Loop para calcular o somatório dos quadrados
            for (int i = 1; i <= n; i++)
            {
                sum += i * i;
            }

            return sum;
        }

        // Método para calcular o quadrado da soma dos primeiros n números naturais
        private long SquareOfSum(int n)
        {
            long sum = 0;

            // Loop para calcular o somatório
            for (int i = 1; i <= n; i++)
            {
                sum += i;
            }

            return sum * sum;
        }

        // Método para encontrar a diferença entre a soma dos quadrados e o quadrado da soma
        public long FindDifference(int n)
        {
            long sumOfSquares = SumOfSquares(n); // Calcula a soma dos quadrados
            long squareOfSum = SquareOfSum(n);   // Calcula o quadrado da soma

            return squareOfSum - sumOfSquares;   // Retorna a diferença
        }
    }
}
