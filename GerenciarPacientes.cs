using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vetor
{
    internal class GerenciadorDePacientes : Paciente
    {
       
            private Paciente[] pacientes;
            private Queue<Paciente> filaDeEspera;
            private int contador;
            private int capacidade;

            public GerenciadorDePacientes(int capacidade)
            {
                this.capacidade = capacidade;
                pacientes = new Paciente[capacidade];
                filaDeEspera = new Queue<Paciente>();
                contador = 0;
            }

            public void CadastrarPaciente()
            {
                if (contador < capacidade)
                {
                    Paciente novoPaciente = new Paciente();

                    Console.Write("Nome do paciente: ");
                    novoPaciente.Nome = Console.ReadLine();

                    Console.Write("Idade do paciente: ");
                    novoPaciente.Idade = int.Parse(Console.ReadLine());

                    Console.Write("Telefone de um responsável: ");
                    novoPaciente.Telefone = Console.ReadLine();

                    pacientes[contador] = novoPaciente;
                    contador++;

                    Console.WriteLine("Paciente cadastrado com sucesso!");

                    if (novoPaciente.Idade < 12 || novoPaciente.Idade > 45)
                    {
                        filaDeEspera.Enqueue(novoPaciente);
                        Console.WriteLine("Paciente prioritário adicionado à fila de espera.");
                    }
                }
                else
                {
                    Console.WriteLine("Capacidade máxima de pacientes cadastrados atingida.");
                }
            }

            public void AtenderPaciente()
            {
                Console.Write("Atender um paciente? Digite o número do paciente (ou '0' para sair): ");
                int indice = int.Parse(Console.ReadLine());

                if (indice == 0)
                {
                    return; 
                }

                if (indice > 0 && indice <= contador)
                {
                    Console.WriteLine($"Atendendo o paciente: {pacientes[indice - 1].Nome}");
                    for (int i = indice - 1; i < contador - 1; i++)
                    {
                        pacientes[i] = pacientes[i + 1];
                    }
                    contador--;
                    Console.WriteLine("Paciente atendido com sucesso!");
                }
                else
                {
                    Console.WriteLine("Número inválido. Tente novamente.");
                }
            }

            public void MostrarPacientes()
            {
                Console.WriteLine("\nPacientes Cadastrados:");
                for (int i = 0; i < contador; i++)
                {
                    Console.WriteLine($"Paciente {i + 1}:");
                    Console.WriteLine($"Nome: {pacientes[i].Nome}");
                    Console.WriteLine($"Idade: {pacientes[i].Idade}");
                    Console.WriteLine($"Telefone: {pacientes[i].Telefone}");
                    Console.WriteLine();
                }
            }

            public void MostrarFilaDeEspera()
            {
                Console.WriteLine("\nFila de Espera:");
                if (filaDeEspera.Count == 0)
                {
                    Console.WriteLine("Não há pacientes na fila de espera.");
                }
                else
                {
                    foreach (var paciente in filaDeEspera)
                    {
                        Console.WriteLine($"Nome: {paciente.Nome}, Idade: {paciente.Idade}, Telefone: {paciente.Telefone}");
                    }
                }
            }
        }
    }
