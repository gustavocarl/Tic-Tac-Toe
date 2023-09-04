using static System.IO.File;
using static System.String;

namespace Tic_Tac_Toe;

public class File
{
    public static void SaveGameStatistics(string? playerName)
    {
        Console.WriteLine("Salvando estatísticas do jogo");
        DirectoryCreation();
        const string path = @"C:\Statistics\Statistics.txt";
        using var writer = new StreamWriter(path, true);
        writer.WriteLine(playerName);
    }

    public static void ViewGameStatistics()
    {
        Console.WriteLine("Visualizando estatísticas dos jogos");
        const string path = @"C:\Statistics\Statistics.txt";
        try
        {
            using var reader = new StreamReader(path);
            string? line;
            while (!IsNullOrEmpty(line = reader.ReadLine()))
                Console.WriteLine(line);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"O processo de leitura do arquivo falhou: {ex.Message}");
        }
    }

    public static void ResetGameStatistics()
    {
        const string path = @"C:\Statistics\Statistics.txt";
        Delete(path);
        DeleteDirectory();
    }

    public static void DirectoryCreation()
    {
        var path = new DirectoryInfo(@"C:\Statistics");
        try
        {
            if (path.Exists)
                return;
            path.Create();
            Console.WriteLine("O Diretório foi criado com sucesso !!!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"O processo de criação do diretório falhou {ex.Message}");
        }
    }

    public static void DeleteDirectory()
    {
        var path = new DirectoryInfo(@"C:\Statistics");
        try
        {
            Console.WriteLine("Resetando estatísticas dos jogos");
            path.Delete();
            Console.WriteLine("As estatísticas foram resetadas com sucesso!!!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"O processo para deletar o diretório falhou: {ex.Message}");
        }
    }
}