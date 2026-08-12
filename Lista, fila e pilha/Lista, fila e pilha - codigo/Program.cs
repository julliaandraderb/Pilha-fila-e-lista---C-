using System;
using System.Collections.Generic;

class Program
{
    static List<string> tarefas = new List<string>();
    static Queue<string> filaAtendimento = new Queue<string>();
    static Stack<string> historicoNavegacao = new Stack<string>();
    static string paginaAtual = "Página Inicial";

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nSISTEMA INTEGRADO - MENU PRINCIPAL");
            Console.WriteLine("1. Gerenciador de Tarefas");
            Console.WriteLine("2. Atendimento em Clínica");
            Console.WriteLine("3. Navegador Web");
            Console.WriteLine("4. Sair");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine() ?? ""; 
            switch (opcao)
            {
                case "1":
                    MenuTarefas();
                    break;
                case "2":
                    MenuClinica();
                    break;
                case "3":
                    MenuNavegador();
                    break;
                case "4":
                    Console.WriteLine("Saindo do sistema...");
                    return;
                default:
                    Console.WriteLine("Opção inválida! Tente novamente.");
                    break;
            }
        }
    }

 
    static void MenuTarefas()
    {
        while (true)
        {
            Console.WriteLine("\nGERENCIADOR DE TAREFAS");
            Console.WriteLine("1. Adicionar tarefa");
            Console.WriteLine("2. Remover tarefa");
            Console.WriteLine("3. Listar tarefas");
            Console.WriteLine("4. Voltar ao menu principal");
            Console.Write("Escolha: ");

            string cmd = Console.ReadLine() ?? "";

            switch (cmd)
            {
                case "1":
                    Console.Write("Digite a nova tarefa: ");
                    string novaTarefa = Console.ReadLine() ?? "";
                    if (!string.IsNullOrEmpty(novaTarefa))
                    {
                        tarefas.Add(novaTarefa);
                        Console.WriteLine("Tarefa adicionada!");
                    }
                    else
                    {
                        Console.WriteLine("Tarefa não pode ser vazia!");
                    }
                    break;
                    
                case "2":
                    if (tarefas.Count == 0)
                    {
                        Console.WriteLine("Não há tarefas para remover!");
                        break;
                    }
                    
                    Console.WriteLine("Lista de Tarefas:");
                    for (int i = 0; i < tarefas.Count; i++)
                    {
                        Console.WriteLine($"{i+1}. {tarefas[i]}");
                    }
                    
                    Console.Write("Digite o número da tarefa a remover: ");
                    if (int.TryParse(Console.ReadLine(), out int indice) && indice > 0 && indice <= tarefas.Count)
                    {
                        tarefas.RemoveAt(indice - 1);
                        Console.WriteLine("Tarefa removida!");
                    }
                    else
                    {
                        Console.WriteLine("Número inválido!");
                    }
                    break;
                    
                case "3":
                    if (tarefas.Count == 0)
                    {
                        Console.WriteLine("Nenhuma tarefa cadastrada!");
                        break;
                    }
                    
                    Console.WriteLine("Tarefas:");
                    for (int i = 0; i < tarefas.Count; i++)
                    {
                        Console.WriteLine($"{i+1}. {tarefas[i]}");
                    }
                    break;
                    
                case "4":
                    return;
                    
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
    }


    static void MenuClinica()
    {
        while (true)
        {
            Console.WriteLine("\nATENDIMENTO EM CLÍNICA");
            Console.WriteLine("1. Adicionar paciente");
            Console.WriteLine("2. Chamar próximo paciente");
            Console.WriteLine("3. Ver fila de espera");
            Console.WriteLine("4. Voltar ao menu principal");
            Console.Write("Escolha: ");

            string cmd = Console.ReadLine() ?? "";

            switch (cmd)
            {
                case "1":
                    Console.Write("Nome do paciente: ");
                    string paciente = Console.ReadLine() ?? "";
                    if (!string.IsNullOrEmpty(paciente))
                    {
                        filaAtendimento.Enqueue(paciente);
                        Console.WriteLine("Paciente adicionado à fila!");
                    }
                    else
                    {
                        Console.WriteLine("Nome não pode ser vazio!");
                    }
                    break;
                    
                case "2":
                    if (filaAtendimento.Count == 0)
                    {
                        Console.WriteLine("Não há pacientes na fila!");
                        break;
                    }
                    Console.WriteLine($"Paciente atendido: {filaAtendimento.Dequeue()}");
                    break;
                    
                case "3":
                    if (filaAtendimento.Count == 0)
                    {
                        Console.WriteLine("Fila vazia!");
                        break;
                    }
                    
                    Console.WriteLine("Fila de atendimento:");
                    int posicao = 1;
                    foreach (var p in filaAtendimento)
                    {
                        Console.WriteLine($"{posicao++}. {p}");
                    }
                    break;
                    
                case "4":
                    return;
                    
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
    }

    static void MenuNavegador()
    {
        

        while (true)
        {
            Console.WriteLine("\nNAVEGADOR WEB");
            Console.WriteLine($"Página atual: {paginaAtual}");
            Console.WriteLine("1. Acessar nova página");
            Console.WriteLine("2. Voltar para página anterior");
            Console.WriteLine("3. Mostrar página atual");
            Console.WriteLine("4. Voltar ao menu principal");
            Console.Write("Escolha: ");

            string cmd = Console.ReadLine() ?? "";

            switch (cmd)
            {
                case "1":
                    Console.Write("Digite o nome da página: ");
                    string novaPagina = Console.ReadLine() ?? "";
                    if (!string.IsNullOrEmpty(novaPagina))
                    {
                        paginaAtual = novaPagina;
                        historicoNavegacao.Push(paginaAtual);
                        Console.WriteLine("Página acessada!");
                    }
                    else
                    {
                        Console.WriteLine("Nome da página não pode ser vazio!");
                    }
                    break;
                    
                case "2":
                    if (historicoNavegacao.Count > 1)
                    {
                        historicoNavegacao.Pop();
                        paginaAtual = historicoNavegacao.Peek();
                        Console.WriteLine("Voltando para página anterior...");
                    }
                    else
                    {
                        Console.WriteLine("Não há páginas anteriores!");
                    }
                    break;
                    
                case "3":
                    Console.WriteLine($"Página atual: {paginaAtual}");
                    break;
                    
                case "4":
                    return;
                    
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
    }
}