/*
O problema 8 do Project Euler é o seguinte: https://projecteuler.net/problem=8

Encontre o maior produto de treze dígitos adjacentes na série de dígitos fornecida abaixo:

73167176531330624919225119674426574742355349194934
96983520312774506326239578318016984801869478851843
85861560789112949495459501737958331952853208805511
12540698747158523863050715693290963295227443043557
66896648950445244523161731856403098711121722383113
62229893423380308135336276614282806444486645238749
30358907296290491560440772390713810515859307960866
70172427121883998797908792274921901699720888093776
65727333001053367881220235421809751254540594752243
52584907711670556013604839586446706324415722155397
53697817977846174064955149290862569321978468622482
83972241375657056057490261407972968652414535100474
82166370484403199890008895243450658541227588666881
16427171479924442928230863465674813919123162824586
17866458359124566529476545682848912883142607690042
24219022671055626321111109370544217506941658960408
07198403850962455444362981230987879927244284909188
84580156166097919133875499200524063689912560717606
05886116467109405077541002256983155200055935729725
71636269561882670428252483600823257530420752963450

Resposta: O maior produto de treze dígitos adjacentes na série é: 23514624000

Aqui está uma solução em C#:
*/
using System;

namespace ProjectEuler
{
    // Classe principal do programa
    public class Problem8
    {
        // Método principal que será executado ao iniciar o programa
        public static void Main(string[] args)
        {
            // Define a série de dígitos como uma string
            string series =
                "73167176531330624919225119674426574742355349194934" +
                "96983520312774506326239578318016984801869478851843" +
                "85861560789112949495459501737958331952853208805511" +
                "12540698747158523863050715693290963295227443043557" +
                "66896648950445244523161731856403098711121722383113" +
                "62229893423380308135336276614282806444486645238749" +
                "30358907296290491560440772390713810515859307960866" +
                "70172427121883998797908792274921901699720888093776" +
                "65727333001053367881220235421809751254540594752243" +
                "52584907711670556013604839586446706324415722155397" +
                "53697817977846174064955149290862569321978468622482" +
                "83972241375657056057490261407972968652414535100474" +
                "82166370484403199890008895243450658541227588666881" +
                "16427171479924442928230863465674813919123162824586" +
                "17866458359124566529476545682848912883142607690042" +
                "24219022671055626321111109370544217506941658960408" +
                "07198403850962455444362981230987879927244284909188" +
                "84580156166097919133875499200524063689912560717606" +
                "05886116467109405077541002256983155200055935729725" +
                "71636269561882670428252483600823257530420752963450";

            // Cria uma instância da classe que resolverá o problema
            LargestProductInSeries largestProductInSeries = new LargestProductInSeries();
            
            // Chama o método para encontrar o maior produto de treze dígitos adjacentes na série
            long result = largestProductInSeries.FindLargestProduct(series, 13);
            
            // Exibe o resultado no console
            Console.WriteLine($"O maior produto de treze dígitos adjacentes na série é: {result}");
        }
    }

    // Classe responsável por encontrar o maior produto de dígitos adjacentes em uma série
    public class LargestProductInSeries
    {
        // Método para encontrar o maior produto de dígitos adjacentes na série
        public long FindLargestProduct(string series, int numAdjacentDigits)
        {
            long maxProduct = 0;

            // Loop para percorrer a série de dígitos
            for (int i = 0; i <= series.Length - numAdjacentDigits; i++)
            {
                long product = 1;

                // Calcula o produto dos dígitos adjacentes
                for (int j = 0; j < numAdjacentDigits; j++)
                {
                    // Converte o caractere em dígito e calcula o produto
                    int digit = series[i + j] - '0';
                    product *= digit;
                }

                // Atualiza o maior produto encontrado, se necessário
                if (product > maxProduct)
                {
                    maxProduct = product;
                }
            }

            return maxProduct; // Retorna o maior produto encontrado
        }
    }
}
