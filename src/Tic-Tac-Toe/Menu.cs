using static Tic_Tac_Toe.File;
using static Tic_Tac_Toe.Game;

namespace Tic_Tac_Toe;

public class Menu
{
    public static void Show()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("===================================");
            Console.WriteLine("Bem vindo ao jogo da velha");
            Console.WriteLine("===================================");
            Console.WriteLine("Selecione uma opção: ");
            Console.WriteLine("===================================");
            Console.WriteLine("1 - Jogar ");
            Console.WriteLine("2 - Ver estatísticas de vitórias ");
            Console.WriteLine("3 - Zerar estatísticas de vitórias ");
            Console.WriteLine("===================================");
            Console.WriteLine("0 - Sair");
            Console.WriteLine("===================================");
            switch (_ = Console.ReadLine()!)
            {
                case "0":
                    Environment.Exit(0);
                    break;

                case "1":
                    Console.WriteLine("Iniciar jogo");
                    NewGame();
                    Console.ReadLine();
                    continue;

                case "2":
                    Console.WriteLine("Ver Estatísticas de vitórias");
                    ViewGameStatistics();
                    Console.ReadLine();
                    continue;

                case "3":
                    Console.WriteLine("Zerar estatísticas do jogo ");
                    ResetGameStatistics();
                    Console.ReadLine();
                    continue;

                default:
                    Console.WriteLine("Opção inválida, pressione ENTER para continuar...");
                    Console.ReadLine();
                    continue;
            }

            break;
        }
    }
}