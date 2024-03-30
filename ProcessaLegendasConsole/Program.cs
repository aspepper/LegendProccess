using ProccessTextFiles;
using System.Text;
using System.Text.RegularExpressions;

internal partial class Program
{
    private static void Main(string[] args)
    {
        string command = args.Length > 0 ? args[0] : "";
        string filelocFrom = args.Length > 1 ? args[1] : "";
        string filelocDest = args.Length > 2 ? args[2] : "";
        string filelocNew = args.Length > 3 ? args[3] : "";

        // string command = "strip";
        // string filelocFrom = @"/Users/alexpimenta/Documents/Projects/Youtube/DevForge/20240321-Poder das Aplicações Desktop - Tudo o que Você Precisa Saber/captions.sbv";
        // string filelocDest = @"captions-clear.sbv";
        // string filelocNew = @"C:\Users\Alex Pimenta\Downloads\captions-en-us-New.sbv";

        ProcessTextFiles legends = new();
        if (command == "strip")
        {
            if (filelocFrom == "" || filelocDest == "")
            {
                Console.WriteLine("Informe o arquivo fonte e o destino.");
            }
            else
            {
                legends.ReadFileSource(filelocFrom);
                legends.StripTimes(filelocDest);
            }
        }
        else if (command == "fill")
        {
            if (filelocFrom == "" || filelocDest == "" || filelocNew == "")
            {
                Console.WriteLine("Informe o arquivo fonte, o destino (sem Time) e o novo arquivo.");
            }
            else
            {
                legends.ReadFileSource(filelocFrom);
                legends.ReadFileTarget(filelocDest);
                Console.WriteLine(legends.InsertTimes(legends.FileSourceContent, legends.FileTargetContent, filelocNew));
            }
        }
        else
        {
            Console.WriteLine("Nada foi produzido.");
        }
    }
}