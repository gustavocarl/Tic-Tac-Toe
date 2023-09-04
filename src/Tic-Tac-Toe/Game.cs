namespace Tic_Tac_Toe;

public class Game
{
    private static char[] Board = new char[9] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    private static string FirstPlayerName;
    private static string SecondPlayerName;
    private static int NumberOfMoves;

    public static void NewGame()
    {
        FirstPlayerName = PlayerName();
        SecondPlayerName = PlayerName();
        InsertPlay();
        File.SaveGameStatistics();
    }

    private static void SaveGameStatistics()
    {
        throw new NotImplementedException();
    }

    public static string PlayerName()
    {
        Console.WriteLine("Digite o nome do jogador: ");
        return Console.ReadLine()!;
    }

    public static void PrintBoard()
    {
        Console.Clear();
        Console.WriteLine("     |     |     ");
        Console.WriteLine("  1  |  2  |  3  ");
        Console.WriteLine("_____|_____|_____");
        Console.WriteLine("     |     |     ");
        Console.WriteLine("  4  |  5  |  6  ");
        Console.WriteLine("_____|_____|_____");
        Console.WriteLine("     |     |     ");
        Console.WriteLine("  7  |  8  |  9  ");
        Console.WriteLine("     |     |     ");
        GameInstructions();
    }

    public static void GenerateNewBoard(int position, char simbol)
    {
        Board[position - 1] = simbol;
        Console.Clear();
        Console.WriteLine("     |     |     ");
        Console.WriteLine($"  {Board[0]}  |  {Board[1]}  |  {Board[2]}");
        Console.WriteLine("_____|_____|_____");
        Console.WriteLine("     |     |     ");
        Console.WriteLine($"  {Board[3]}  |  {Board[4]}  |  {Board[5]}");
        Console.WriteLine("_____|_____|_____");
        Console.WriteLine("     |     |     ");
        Console.WriteLine($"  {Board[6]}  |  {Board[7]}  |  {Board[8]}");
        Console.WriteLine("     |     |     ");
        GameInstructions();
    }

    public static void GameInstructions()
    {
        Console.WriteLine("==========================================================================");
        Console.WriteLine("Insira a jogada na posição desejada: ");
        Console.WriteLine("As posições devem ser selecionadas pelo número representado no tabuleiro: ");
        Console.WriteLine("Os número vão de 1 até 9: ");
        Console.WriteLine("Caso o número já esteja ocupado selecione um número diferente: ");
        Console.WriteLine("==========================================================================");
    }

    public static void InsertPlay()
    {
        Board = new char[9] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        Console.Clear();

        PrintBoard();
        var firstPlayerTurn = true;
        NumberOfMoves = 0;
        do
        {
            int position;
            if (firstPlayerTurn)
            {
                do
                {
                    Console.WriteLine("Jogada do primeiro player");
                    Console.WriteLine($"Faça sua jogada: {FirstPlayerName} ");
                    position = int.Parse(Console.ReadLine()!);
                } while (position is < 1 or > 9);

                if ((Board[position].CompareTo('X') != 0) && (Board[position].CompareTo('O') != 0))
                {
                    GenerateNewBoard(position, 'X');
                    NumberOfMoves++;
                    Console.WriteLine(NumberOfMoves);
                    firstPlayerTurn = false;
                }
            }
            else
            {
                do
                {
                    Console.WriteLine("Jogada do primeiro player");
                    Console.WriteLine($"Faça sua jogada: {SecondPlayerName} ");
                    position = int.Parse(Console.ReadLine()!);
                } while (position is < 1 or > 9);

                if ((Board[position].CompareTo('X') != 0) && (Board[position].CompareTo('O') != 0))
                {
                    GenerateNewBoard(position, 'O');
                    NumberOfMoves++;
                    Console.WriteLine(NumberOfMoves);
                    firstPlayerTurn = true;
                }
            }

            if (NumberOfMoves < 5)
                continue;
            var victory = CheckVictory();
            if (victory)
                break;
        } while (NumberOfMoves < 9);
    }

    public static bool CheckVictory()
    {
        var firstPlayerLineVictory =
            (Board[0] == 'X' && Board[1] == 'X' && Board[2] == 'X') ||
            (Board[3] == 'X' && Board[4] == 'X' && Board[5] == 'X') ||
            (Board[6] == 'X' && Board[7] == 'X' && Board[8] == 'X');

        var firstPlayerCollumnVictory =
            (Board[0] == 'X' && Board[3] == 'X' && Board[6] == 'X') ||
            (Board[1] == 'X' && Board[4] == 'X' && Board[7] == 'X') ||
            (Board[2] == 'X' && Board[5] == 'X' && Board[8] == 'X');

        var firstPlayerMainDiagonalVictory =
            Board[0] == 'X' && Board[4] == 'X' && Board[8] == 'X';

        var firstPlayerSecondaryDiagonalVictory =
            Board[2] == 'X' && Board[4] == 'X' && Board[6] == 'X';

        var secondPlayerLineVictory =
            (Board[0] == 'O' && Board[1] == 'O' && Board[2] == 'O') ||
            (Board[3] == 'O' && Board[4] == 'O' && Board[5] == 'O') ||
            (Board[6] == 'O' && Board[7] == 'O' && Board[8] == 'O');

        var secondPlayerCollumnVictory =
            (Board[0] == 'O' && Board[3] == 'O' && Board[6] == 'O') ||
            (Board[1] == 'O' && Board[4] == 'O' && Board[7] == 'O') ||
            (Board[2] == 'O' && Board[5] == 'O' && Board[8] == 'O');

        var secondPlayerMainDiagonalVictory =
            Board[0] == 'O' && Board[4] == 'O' && Board[8] == 'O';

        var secondPlayerSecondaryDiagonalVictory =
            Board[2] == 'O' && Board[4] == 'O' && Board[6] == 'O';

        if (
            firstPlayerLineVictory ||
            firstPlayerCollumnVictory ||
            firstPlayerMainDiagonalVictory ||
            firstPlayerSecondaryDiagonalVictory
            )
        {
            Console.WriteLine($"Vitória do Jogador: {FirstPlayerName}");
            return true;
        }
        else if (
            secondPlayerLineVictory ||
            secondPlayerCollumnVictory ||
            secondPlayerMainDiagonalVictory ||
            secondPlayerSecondaryDiagonalVictory
            )
        {
            Console.WriteLine($"Vitória do Jogador: {SecondPlayerName}");
            return true;
        }

        if (NumberOfMoves == 9)
            Console.WriteLine("Não houve Jogador vencedor: ");
        return false;
    }
}