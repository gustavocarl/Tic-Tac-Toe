int row, column, quantity = 0;
char[,] board = new char[3, 3]
{
        { '1', '2', '3' },
        { '4', '5', '6' },
        { '7', '8', '9' }
};

MainMenu();

void MainMenu()
{
    Console.Clear();
    Console.WriteLine("==========================");
    Console.WriteLine("Bem vindo ao Jogo da Velha");
    Console.WriteLine("==========================");
    Console.WriteLine("1 - Jogar");
    Console.WriteLine("==========================");
    Console.WriteLine("0 - Sair");
    Console.WriteLine("==========================");
    switch (Console.ReadLine()!)
    {
        case "0":
            break;

        case "1":
            Game();
            MainMenu();
            break;

        default:
            Console.WriteLine("Opção inválida...");
            Console.WriteLine("Pressione ENTER para continuar: ");
            Console.ReadLine();
            MainMenu();
            break;
    }
}

static string FirstPlayerName()
{
    Console.WriteLine("Digite o nome do jogador 1: ");
    string firstPlayer = Console.ReadLine()!;
    return firstPlayer;
}

static string SecondPlayerName()
{
    Console.WriteLine("Digite o nome do jogador 2: ");
    string secondPlayer = Console.ReadLine()!;
    return secondPlayer;
}

void PrintBoard()
{
    Console.Clear();
    Console.WriteLine("Tabuleiro de Jogo da Velha\n");
    Console.WriteLine($"     |     |     ");
    Console.WriteLine($"  {board[0, 0]}  |  {board[0, 1]}  |  {board[0, 2]}");
    Console.WriteLine("_____|_____|_____ ");
    Console.WriteLine("     |     |      ");
    Console.WriteLine($"  {board[1, 0]}  |  {board[1, 1]}  |  {board[1, 2]}");
    Console.WriteLine("_____|_____|_____ ");
    Console.WriteLine("     |     |      ");
    Console.WriteLine($"  {board[2, 0]}  |  {board[2, 1]}  |  {board[2, 2]}");
    Console.WriteLine("     |     |      ");

    Console.WriteLine("Como devem ser realizadas as jogadas:");
    Console.WriteLine("Posições da primeira linha:");
    Console.WriteLine("1 - 0,0\n2 - 0,1\n3 - 0,2");
    Console.WriteLine("Posições da segunda linha:");
    Console.WriteLine("4 - 1,0\n5 - 1,1\n6 - 1,2");
    Console.WriteLine("Posições da terceira linha:");
    Console.WriteLine("7 - 2,0\n8 - 2,1\n9 - 2,2");
}

void Game()
{
    string firstPlayerName = FirstPlayerName();
    string secondPlayerName = SecondPlayerName();
    bool firstPlayerPlay = true;
    PrintBoard();

    do
    {
        string playerTurn = (firstPlayerPlay) ? firstPlayerName : secondPlayerName;
        Console.WriteLine($"Vez do jogador {playerTurn}");

        do
        {
            Console.WriteLine("Informe a linha a ser jogada: ");
            row = int.Parse(Console.ReadLine()!);
        } while (row < 0 || row > 2);

        do
        {
            Console.WriteLine("Informe a coluna a ser jogada: ");
            column = int.Parse(Console.ReadLine()!);
        } while (column < 0 || column > 2);

        if (firstPlayerPlay)
        {
            if (board[row, column] == 'X' || board[row, column] == 'O')
            {
                Console.WriteLine("Já existe jogada nessa posição, escolha outra posição");
                Console.ReadLine();
            }
            else
            {
                board[row, column] = 'X';
                firstPlayerPlay = false;
                quantity++;
            }
        }
        else
        {
            if (board[row, column] == 'X' || board[row, column] == 'O')
            {
                Console.WriteLine("Já existe jogada nessa posição, escolha outra posição");
                Console.ReadLine();
            }
            else
            {
                board[row, column] = 'O';
                firstPlayerPlay = true;
                quantity++;
            }
        }
        PrintBoard();
        if (quantity >= 5)
        {
            ValidateVictory(playerTurn);
        }
    } while (quantity < 9);
}

void ValidateVictory(string playerName)
{
    bool winnerFound = false;
    for (var i = 0; i < 3; i++)
    {
        if ((board[i, 0] == 'X' && board[i, 1] == 'X' && board[i, 2] == 'X') ||
            (board[i, 0] == 'O' && board[i, 1] == 'O' && board[i, 2] == 'O'))
        {
            winnerFound = true;
            break;
        }

        if ((board[0, i] == 'X' && board[1, i] == 'X' && board[2, i] == 'X') ||
            (board[0, i] == 'O' && board[1, i] == 'O' && board[2, i] == 'O'))
        {
            winnerFound = true;
            break;
        }
    }

    if (!winnerFound)
    {
        if ((board[0, 0] == 'X' && board[1, 1] == 'X' && board[2, 2] == 'X') ||
            (board[0, 2] == 'X' && board[1, 1] == 'X' && board[2, 0] == 'X') ||
            (board[0, 0] == 'O' && board[1, 1] == 'O' && board[2, 2] == 'O') ||
            (board[0, 2] == 'O' && board[1, 1] == 'O' && board[2, 0] == 'O'))
        {
            winnerFound = true;
        }
    }

    if (winnerFound)
    {
        quantity = 10;
        Console.WriteLine($"Vitória do jogador: {playerName}");
        Console.WriteLine($"Pressione ENTER para continuar...");
        Console.ReadLine();
    }
}