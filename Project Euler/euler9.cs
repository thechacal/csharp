/*
O problema 9 do Project Euler é o seguinte: https://projecteuler.net/problem=9

Para o problema 9 do Project Euler, vamos encontrar o conjunto de números pitagóricos (a, b, c) 
onde a + b + c = 1000 e a² + b² = c². Isso corresponde a encontrar um conjunto de números
inteiros a, b e c que formam um triângulo retângulo onde a soma dos três lados é 1000.

Resposta: 
O conjunto de números pitagóricos (a, b, c) onde a + b + c = 1000 é: (200, 375, 425)
O produto abc é: 31875000

Aqui está uma solução em C#:
*/
using System;

namespace ProjectEuler
{
    // Classe principal do programa
    public class Problem9
    {
        // Método principal que será executado ao iniciar o programa
        public static void Main(string[] args)
        {
            // Cria uma instância da classe que resolverá o problema
            PythagoreanTripletFinder tripletFinder = new PythagoreanTripletFinder();

            // Chama o método para encontrar o conjunto de números pitagóricos
            Triplet result = tripletFinder.FindPythagoreanTriplet(1000);

            // Exibe o resultado no console
            Console.WriteLine($"O conjunto de números pitagóricos (a, b, c) onde a + b + c = 1000 é: ({result.A}, {result.B}, {result.C})");
            Console.WriteLine($"O produto abc é: {result.A * result.B * result.C}");
        }
    }

    // Classe para representar um conjunto de números pitagóricos (a, b, c)
    public class Triplet
    {
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }
    }

    // Classe responsável por encontrar números pitagóricos que somam um valor específico
    public class PythagoreanTripletFinder
    {
        // Método para encontrar o conjunto de números pitagóricos (a, b, c) onde a + b + c = sum
        public Triplet FindPythagoreanTriplet(int sum)
        {
            // Loop para testar todos os valores possíveis de a
            for (int a = 1; a < sum; a++)
            {
                // Loop para testar todos os valores possíveis de b
                for (int b = a + 1; b < sum; b++)
                {
                    // Calcula c baseado em a e b
                    int c = sum - a - b;

                    // Verifica se a, b, c formam um conjunto de números pitagóricos
                    if (a * a + b * b == c * c)
                    {
                        // Retorna o conjunto encontrado
                        return new Triplet { A = a, B = b, C = c };
                    }
                }
            }

            // Caso não encontre nenhum conjunto válido, retorna null
            return null;
        }
    }
}
