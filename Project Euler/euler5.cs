/*
O problema 5 do Project Euler é o seguinte: https://projecteuler.net/problem=5

2520 é o menor número que pode ser dividido por cada um dos números de 1 a 10 sem sobrar resto.
Qual é o menor número positivo que é divisível por todos os números de 1 a 20?
Resposta: 232792560

Aqui está uma solução em C#:
*/

using System;

namespace ProjectEuler
{
    // Classe principal do programa
    public class Problem5
    {
        // Método principal que será executado ao iniciar o programa
        public static void Main(string[] args)
        {
            // Cria uma instância da classe que resolverá o problema
            SmallestMultiple smallestMultiple = new SmallestMultiple();
            
            // Chama o método para encontrar o menor número positivo divisível por todos os números de 1 a 20
            long result = smallestMultiple.FindSmallestMultiple();
            
            // Exibe o resultado no console
            Console.WriteLine($"O menor número positivo divisível por todos os números de 1 a 20 é: {result}");
        }
    }

    // Classe responsável por encontrar o menor número positivo divisível por todos os números de 1 a 20
    public class SmallestMultiple
    {
        // Método para calcular o MDC (Máximo Divisor Comum) de dois números
        private long GCD(long a, long b)
        {
            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        // Método para calcular o MMC (Mínimo Múltiplo Comum) de dois números
        private long LCM(long a, long b)
        {
            return (a / GCD(a, b)) * b;
        }

        // Método para encontrar o menor número positivo divisível por todos os números de 1 a 20
        public long FindSmallestMultiple()
        {
            long lcm = 1; // Inicializa o MMC como 1

            // Loop para calcular o MMC de todos os números de 1 a 20
            for (int i = 1; i <= 20; i++)
            {
                lcm = LCM(lcm, i); // Calcula o MMC entre o valor atual de lcm e o número i
            }

            return lcm; // Retorna o menor número positivo divisível por todos os números de 1 a 20
        }
    }
}
