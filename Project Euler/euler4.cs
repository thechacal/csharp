/*
O problema 4 do Project Euler é o seguinte: https://projecteuler.net/problem=4

Um número palíndromo lê o mesmo tanto da esquerda para a direita quanto da direita para a esquerda. 
O maior número palíndromo feito pelo produto de dois números de 2 dígitos é 9009 = 91 × 99. 
Encontre o maior número palíndromo feito pelo produto de dois números de 3 dígitos.
Resposta: 906609

Aqui está uma solução em C#:
*/
using System;

namespace ProjectEuler
{
    // Classe principal do programa
    public class Problem4
    {
        // Método principal que será executado ao iniciar o programa
        public static void Main(string[] args)
        {
            // Cria uma instância da classe que resolverá o problema
            LargestPalindromeProduct largestPalindromeProduct = new LargestPalindromeProduct();
            
            // Chama o método para encontrar o maior número palíndromo e armazena o resultado
            int result = largestPalindromeProduct.FindLargestPalindrome();
            
            // Exibe o resultado no console
            Console.WriteLine($"O maior número palíndromo feito pelo produto de dois números de 3 dígitos é: {result}");
        }
    }

    // Classe responsável por encontrar o maior número palíndromo
    public class LargestPalindromeProduct
    {
        // Método para verificar se um número é palíndromo
        private bool IsPalindrome(int number)
        {
            string numStr = number.ToString(); // Converte o número para string
            int left = 0; // Início do índice da esquerda
            int right = numStr.Length - 1; // Início do índice da direita

            // Loop até que os índices se cruzem
            while (left < right)
            {
                // Verifica se os caracteres correspondentes são iguais
                if (numStr[left] != numStr[right])
                {
                    return false; // Não é palíndromo
                }
                left++; // Move para o próximo caractere da esquerda
                right--; // Move para o próximo caractere da direita
            }

            return true; // É palíndromo
        }

        // Método para encontrar o maior número palíndromo feito pelo produto de dois números de 3 dígitos
        public int FindLargestPalindrome()
        {
            int largestPalindrome = 0; // Variável para armazenar o maior palíndromo encontrado

            // Loop pelos números de 3 dígitos
            for (int i = 100; i < 1000; i++)
            {
                for (int j = 100; j < 1000; j++)
                {
                    int product = i * j; // Calcula o produto dos números

                    // Verifica se o produto é um palíndromo e se é maior que o maior palíndromo encontrado até agora
                    if (IsPalindrome(product) && product > largestPalindrome)
                    {
                        largestPalindrome = product; // Atualiza o maior palíndromo encontrado
                    }
                }
            }

            return largestPalindrome; // Retorna o maior número palíndromo encontrado
        }
    }
}
