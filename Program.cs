using System;
using System.Collections.Generic;
using Vetor;

class Program 
{
    static void Main()
    {
        GerenciadorDePacientes gerenciador = new GerenciadorDePacientes(2);

        while (true)
        {
            Console.WriteLine("     Menu ");
            Console.WriteLine("1. Cadastrar Paciente");
            Console.WriteLine("2. Atender Paciente");
            Console.WriteLine("3. Ver Pacientes Cadastrados");
            Console.WriteLine("4. Ver Fila de Espera");
            Console.WriteLine("Q. Sair");
            Console.Write("Escolha uma opção: ");
            char escolha = Console.ReadKey().KeyChar;
            Console.WriteLine();

            switch (escolha)
            {
                case '1':
                    gerenciador.CadastrarPaciente();
                    break;

                case '2':
                    gerenciador.AtenderPaciente();
                    break;

                case '3':
                    gerenciador.MostrarPacientes();
                    break;

                case '4':
                    gerenciador.MostrarFilaDeEspera();
                    break;

                case 'q':
                    Console.WriteLine("Saindo...");
                    return;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }

        Console.ReadKey();
    }

}

