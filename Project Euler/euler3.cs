/*
O problema 3 do Project Euler é o seguinte: https://projecteuler.net/problem=3

O maior fator primo de 13195 é 29. Qual é o maior fator primo do número 600851475143?
Resposta: 6857

Aqui está uma solução em C#:
*/

using System;

namespace ProjectEuler
{
    // Classe principal do programa
    public class Problem3
    {
        // Método principal que será executado ao iniciar o programa
        public static void Main(string[] args)
        {
            // Define o número para o qual queremos encontrar o maior fator primo
            long number = 600851475143;

            // Cria uma instância da classe que resolverá o problema
            PrimeFactor primeFactor = new PrimeFactor(number);
            
            // Chama o método para encontrar o maior fator primo e armazena o resultado
            long result = primeFactor.LargestPrimeFactor();
            
            // Exibe o resultado no console
            Console.WriteLine($"O maior fator primo do número {number} é: {result}");
        }
    }

    // Classe responsável por encontrar o maior fator primo
    public class PrimeFactor
    {
        // Atributo para armazenar o número
        private long number;

        // Construtor que inicializa o atributo
        public PrimeFactor(long number)
        {
            this.number = number;
        }

        // Método que encontra o maior fator primo
        public long LargestPrimeFactor()
        {
            long n = number; // Variável para manipular o número
            long largestFactor = 1; // Variável para armazenar o maior fator primo

            // Remove os fatores de 2
            while (n % 2 == 0)
            {
                largestFactor = 2;
                n /= 2;
            }

            // Testa os fatores ímpares a partir de 3
            for (long i = 3; i <= Math.Sqrt(n); i += 2)
            {
                while (n % i == 0)
                {
                    largestFactor = i;
                    n /= i;
                }
            }

            // Se n ainda for maior que 2, então ele mesmo é um fator primo
            if (n > 2)
            {
                largestFactor = n;
            }

            return largestFactor; // Retorna o maior fator primo encontrado
        }
    }
}
