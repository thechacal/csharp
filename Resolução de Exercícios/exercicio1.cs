/*
Exercício 1
Uma empresa comercial possui um programa para controle das receitas e despesas em seus 10 projetos. 
Os projetos são numerados de 0 até 9. 
Faça um programa C que controle a entrada e saída de recursos dos projetos. 
O programa deverá ler um conjunto de informações contendo: 
Número do projeto, valor, tipo despesa ("R" - Receita e "D" - Despesa). 
O programa termina quando o valor do código do projeto for igual a -1. 
Sabe-se que Receita deve ser somada ao saldo do projeto e despesa subtraída do saldo do projeto. 
Ao final do programa, imprirmir o saldo final de cada projeto.

Dica: Usar uma estrutura do tipo vetor para controlar os saldos dos projetos. 
Usar o conceito de struct para agrupar as informações lidas.
*/
using System;
using System.Collections.Generic;

namespace ControleProjetos
{
    // Definindo a classe Projeto para agrupar as informações do projeto
    class Projeto
    {
        public int numero;
        public float saldo;

        public Projeto(int num)
        {
            numero = num;
            saldo = 0;
        }

        public void AtualizarSaldo(float valor, char tipoDespesa)
        {
            if (tipoDespesa == 'R' || tipoDespesa == 'r')
            {
                saldo += valor;
            }
            else if (tipoDespesa == 'D' || tipoDespesa == 'd')
            {
                saldo -= valor;
            }
            else
            {
                Console.WriteLine("Tipo de despesa inválido! Use 'R' para Receita ou 'D' para Despesa.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            const int NUM_PROJETOS = 10;

            // Criando uma lista para armazenar os objetos Projeto
            List<Projeto> projetos = new List<Projeto>();

            // Inicializando a lista de projetos com objetos Projeto
            for (int i = 0; i < NUM_PROJETOS; i++)
            {
                projetos.Add(new Projeto(i));
            }

            int numeroProjeto;
            float valor;
            char tipoDespesa;

            // Loop para ler as informações até que o número do projeto seja -1
            while (true)
            {
                Console.Write("Digite o número do projeto (-1 para encerrar): ");
                numeroProjeto = int.Parse(Console.ReadLine());

                if (numeroProjeto == -1)
                {
                    break; // Encerra o loop caso seja digitado -1
                }

                Console.Write("Digite o valor: ");
                valor = float.Parse(Console.ReadLine());

                Console.Write("Digite o tipo de despesa (R - Receita, D - Despesa): ");
                tipoDespesa = char.ToUpper(Console.ReadLine()[0]);

                if (numeroProjeto >= 0 && numeroProjeto < NUM_PROJETOS)
                {
                    projetos[numeroProjeto].AtualizarSaldo(valor, tipoDespesa);
                }
                else
                {
                    Console.WriteLine("Projeto não encontrado!");
                }
            }

            // Imprimindo o saldo final de cada projeto
            Console.WriteLine("\nSaldo final de cada projeto:");
            foreach (Projeto projeto in projetos)
            {
                Console.WriteLine($"Projeto {projeto.numero}: R$ {projeto.saldo}");
            }
        }
    }
}
