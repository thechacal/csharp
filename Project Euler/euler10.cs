/*
O problema 10 do Project Euler é o seguinte: https://projecteuler.net/problem=10

Encontre a soma de todos os números primos abaixo de dois milhões.

Resposta: 
A soma de todos os números primos abaixo de 2000000 é: 142913828922

Aqui está uma solução em C#:
*/
using System;

namespace ProjectEuler
{
    // Classe principal do programa
    public class Problem10
    {
        // Método principal que será executado ao iniciar o programa
        public static void Main(string[] args)
        {
            // Define o limite máximo para encontrar números primos
            int limit = 2000000;

            // Cria uma instância da classe que resolverá o problema
            PrimeSumCalculator primeSumCalculator = new PrimeSumCalculator();

            // Chama o método para calcular a soma de todos os números primos abaixo do limite
            long result = primeSumCalculator.SumOfPrimesBelow(limit);

            // Exibe o resultado no console
            Console.WriteLine($"A soma de todos os números primos abaixo de {limit} é: {result}");
        }
    }

    // Classe responsável por calcular a soma de números primos
    public class PrimeSumCalculator
    {
        /**
        * Descrição: Encontre a soma de todos os números primos abaixo de um determinado limite.
        **/

        // Método para calcular a soma de todos os números primos abaixo de um limite
        public long SumOfPrimesBelow(int limit)
        {
            long sum = 0;
            bool[] isPrime = new bool[limit]; // Array para marcar números primos

            // Inicializa o array assumindo que todos os números são primos
            for (int i = 2; i < limit; i++)
            {
                isPrime[i] = true;
            }

            // Marca os múltiplos como não primos
            for (int i = 2; i < Math.Sqrt(limit); i++)
            {
                if (isPrime[i])
                {
                    for (int j = i * i; j < limit; j += i)
                    {
                        isPrime[j] = false;
                    }
                }
            }

            // Soma todos os números primos marcados como verdadeiros no array
            for (int i = 2; i < limit; i++)
            {
                if (isPrime[i])
                {
                    sum += i;
                }
            }

            return sum; // Retorna a soma dos números primos abaixo do limite
        }
    }
}
