using System;

class Program
{
    const double MEDIA_APROVACAO = 7.0;
    const double MEDIA_RECUPERACAO = 5.0;
    const double NOTA_MINIMA = 0.0;
    const double NOTA_MAXIMA = 10.0;
    const int QUANTIDADE_NOTAS = 3;

    static string nomeAluno = "";
    static double[] notas = new double[QUANTIDADE_NOTAS];
    static bool notasLancadas = false;

    static void Main()
    {
        bool executando = true; // flag: o break do switch só sai do switch, não do while

        while (executando)
        {
            ExibirMenu();
            int opcao = LerOpcaoMenu();

            switch (opcao)
            {
                case 1:
                    CadastrarAluno();
                    break;
                case 2:
                    LancarNotas();
                    break;
                case 3:
                    CalcularMedia();
                    break;
                case 4:
                    Console.WriteLine("\nEncerrando o programa. Até logo!");
                    executando = false;
                    break;
                default:
                    Console.WriteLine("\nOpção inválida! Escolha um número de 1 a 4.");
                    break;
            }

            if (!executando)
            {
                continue; // pula a pausa e volta à condição do while (que agora é falsa)
            }

            Console.WriteLine("\nPressione ENTER para continuar...");
            Console.ReadLine();
        }
    }

    static void ExibirMenu()
    {
        Console.Clear();
        Console.WriteLine("========================================");
        Console.WriteLine("          CALCULADORA DE NOTAS          ");
        Console.WriteLine("========================================");
        Console.WriteLine(string.IsNullOrEmpty(nomeAluno)
            ? "Aluno: (não cadastrado)"
            : $"Aluno: {nomeAluno}");
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("1 - Cadastrar aluno");
        Console.WriteLine("2 - Lançar notas");
        Console.WriteLine("3 - Calcular média");
        Console.WriteLine("4 - Sair");
        Console.WriteLine("----------------------------------------");
    }

    static int LerOpcaoMenu()
    {
        Console.Write("Escolha uma opção: ");
        string entrada = Console.ReadLine();

        if (!int.TryParse(entrada, out int opcao))
        {
            return 0; // early return: entrada inválida cai no default do switch
        }

        return opcao;
    }

    // Métodos provisórios, serão implementados nos próximos commits
    static void CadastrarAluno()
    {
        Console.WriteLine("\n(Cadastro de aluno em desenvolvimento)");
    }

    static void LancarNotas()
    {
        Console.WriteLine("\n(Lançamento de notas em desenvolvimento)");
    }

    static void CalcularMedia()
    {
        Console.WriteLine("\n(Cálculo de média em desenvolvimento)");
    }

    static void CadastrarAluno()
    {
        Console.WriteLine("\n--- Cadastrar aluno ---");

        while (true) // sai pelo break quando o nome for válido
        {
            Console.Write("Digite o nome do aluno: ");
            string entrada = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(entrada))
            {
                Console.WriteLine("Nome inválido! O nome não pode ficar vazio.");
                continue; // volta a pedir o nome
            }

            nomeAluno = entrada.Trim();
            Console.WriteLine($"Aluno \"{nomeAluno}\" cadastrado com sucesso!");
            break; // condição de saída garantida: evita loop infinito
        }
    }
}