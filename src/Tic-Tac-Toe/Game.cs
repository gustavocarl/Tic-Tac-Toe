using static System.String;

namespace Tic_Tac_Toe;

public class Game
{
    private static char[]? _board = new char[9] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    private static string? _firstPlayerName;
    private static string? _secondPlayerName;
    private static int? _numberOfMoves;

    public static void NewGame()
    {
        _firstPlayerName = PlayerName();
        _secondPlayerName = PlayerName();
        InsertPlay();
    }

    public static string PlayerName()
    {
        string player;
        do
        {
            Console.WriteLine("Digite o nome do jogador: ");
            player = Console.ReadLine()!;
        } while (IsNullOrWhiteSpace(player));

        return player;
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
        _board[position - 1] = simbol;
        Console.Clear();
        Console.WriteLine("     |     |     ");
        Console.WriteLine($"  {_board[0]}  |  {_board[1]}  |  {_board[2]}");
        Console.WriteLine("_____|_____|_____");
        Console.WriteLine("     |     |     ");
        Console.WriteLine($"  {_board[3]}  |  {_board[4]}  |  {_board[5]}");
        Console.WriteLine("_____|_____|_____");
        Console.WriteLine("     |     |     ");
        Console.WriteLine($"  {_board[6]}  |  {_board[7]}  |  {_board[8]}");
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
        _board = new char[9] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        Console.Clear();

        PrintBoard();
        var firstPlayerTurn = true;
        _numberOfMoves = 0;
        do
        {
            int position;
            if (firstPlayerTurn)
            {
                do
                {
                    Console.WriteLine("Jogada do primeiro player");
                    Console.WriteLine($"Faça sua jogada: {_firstPlayerName} ");
                    position = int.Parse(Console.ReadLine()!);
                } while (position is < 1 or > 9);

                if ((_board[position].CompareTo('X') != 0) || (_board[position].CompareTo('O') != 0))
                {
                    GenerateNewBoard(position, 'X');
                    _numberOfMoves++;
                    Console.WriteLine(_numberOfMoves);
                    firstPlayerTurn = false;
                }
            }
            else
            {
                do
                {
                    Console.WriteLine("Jogada do primeiro player");
                    Console.WriteLine($"Faça sua jogada: {_secondPlayerName} ");
                    position = int.Parse(Console.ReadLine()!);
                } while (position is < 1 or > 9);

                if ((_board[position].CompareTo('X') != 0) || (_board[position].CompareTo('O') != 0))
                {
                    GenerateNewBoard(position, 'O');
                    _numberOfMoves++;
                    Console.WriteLine(_numberOfMoves);
                    firstPlayerTurn = true;
                }
            }

            if (_numberOfMoves < 5)
                continue;
            var victory = CheckVictory();
            if (victory)
                break;
        } while (_numberOfMoves < 9);
    }

    public static bool CheckVictory()
    {
        var firstPlayerLineVictory =
            _board != null && ((_board[0] == 'X' && _board[1] == 'X' && _board[2] == 'X') ||
                               (_board[3] == 'X' && _board[4] == 'X' && _board[5] == 'X') ||
                               (_board[6] == 'X' && _board[7] == 'X' && _board[8] == 'X'));

        var firstPlayerCollumnVictory =
            _board != null && ((_board[0] == 'X' && _board[3] == 'X' && _board[6] == 'X') ||
                               (_board[1] == 'X' && _board[4] == 'X' && _board[7] == 'X') ||
                               (_board[2] == 'X' && _board[5] == 'X' && _board[8] == 'X'));

        var firstPlayerMainDiagonalVictory =
            _board != null && _board[0] == 'X' && _board[4] == 'X' && _board[8] == 'X';

        var firstPlayerSecondaryDiagonalVictory =
            _board != null && _board[2] == 'X' && _board[4] == 'X' && _board[6] == 'X';

        var secondPlayerLineVictory =
            _board != null && ((_board[0] == 'O' && _board[1] == 'O' && _board[2] == 'O') ||
                               (_board[3] == 'O' && _board[4] == 'O' && _board[5] == 'O') ||
                               (_board[6] == 'O' && _board[7] == 'O' && _board[8] == 'O'));

        var secondPlayerCollumnVictory =
            _board != null && ((_board[0] == 'O' && _board[3] == 'O' && _board[6] == 'O') ||
                               (_board[1] == 'O' && _board[4] == 'O' && _board[7] == 'O') ||
                               (_board[2] == 'O' && _board[5] == 'O' && _board[8] == 'O'));

        var secondPlayerMainDiagonalVictory =
            _board != null && _board[0] == 'O' && _board[4] == 'O' && _board[8] == 'O';

        var secondPlayerSecondaryDiagonalVictory =
            _board != null && _board[2] == 'O' && _board[4] == 'O' && _board[6] == 'O';

        if (
            firstPlayerLineVictory ||
            firstPlayerCollumnVictory ||
            firstPlayerMainDiagonalVictory ||
            firstPlayerSecondaryDiagonalVictory
            )
        {
            Console.WriteLine($"Vitória do Jogador: {_firstPlayerName}");
            File.SaveGameStatistics(_firstPlayerName);
            return true;
        }
        else if (
            secondPlayerLineVictory ||
            secondPlayerCollumnVictory ||
            secondPlayerMainDiagonalVictory ||
            secondPlayerSecondaryDiagonalVictory
            )
        {
            Console.WriteLine($"Vitória do Jogador: {_secondPlayerName}");
            File.SaveGameStatistics(_secondPlayerName);
            return true;
        }

        if (_numberOfMoves == 9)
            Console.WriteLine("Não houve Jogador vencedor: ");
        return false;
    }
}