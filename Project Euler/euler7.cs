/*
O problema 7 do Project Euler é o seguinte: https://projecteuler.net/problem=7

Qual é o 10001º número primo?
Resposta: O 10001º número primo é: 104743

Aqui está uma solução em C#:
*/
using System;

namespace ProjectEuler
{
    // Classe principal do programa
    public class Problem7
    {
        // Método principal que será executado ao iniciar o programa
        public static void Main(string[] args)
        {
            // Define o índice do número primo desejado
            int index = 10001;

            // Cria uma instância da classe que resolverá o problema
            PrimeFinder primeFinder = new PrimeFinder();
            
            // Chama o método para encontrar o 10001º número primo
            long result = primeFinder.FindNthPrime(index);
            
            // Exibe o resultado no console
            Console.WriteLine($"O {index}º número primo é: {result}");
        }
    }

    // Classe responsável por encontrar números primos
    public class PrimeFinder
    {
        // Método para verificar se um número é primo
        private bool IsPrime(long number)
        {
            // Verifica números menores que 2
            if (number <= 1)
            {
                return false;
            }

            // Verifica divisibilidade por 2
            if (number == 2)
            {
                return true;
            }
            if (number % 2 == 0)
            {
                return false;
            }

            // Verifica divisibilidade por números ímpares até a raiz quadrada do número
            for (long i = 3; i <= Math.Sqrt(number); i += 2)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true; // É primo
        }

        // Método para encontrar o n-ésimo número primo
        public long FindNthPrime(int n)
        {
            int count = 0; // Contador de números primos encontrados
            long candidate = 2; // Inicia com o primeiro número primo conhecido

            while (count < n)
            {
                if (IsPrime(candidate))
                {
                    count++; // Incrementa o contador se o número é primo
                }

                candidate++; // Testa o próximo número candidato
            }

            return candidate - 1; // Retorna o último número testado, que é o n-ésimo número primo
        }
    }
}
