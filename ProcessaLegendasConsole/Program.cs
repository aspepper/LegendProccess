using ProccessTextFiles;
using System.Text;
using System.Text.RegularExpressions;

internal partial class Program
{
    private static async Task Main(string[] args)
    {
        string filelocFrom = @"C:\Users\Alex Pimenta\Downloads\captions-pt-br.sbv";
        string filelocDest = @"C:\Users\Alex Pimenta\Downloads\captions-en-us-clear.sbv";
        string filelocNew = @"C:\Users\Alex Pimenta\Downloads\captions-en-us-New.sbv";

        ProcessTextFiles legends = new();
        var fileFromContent = await legends.ReadFileSBV(filelocFrom);
        var fileDestContent = await legends.ReadFileSBV(filelocDest);

        Console.WriteLine(await legends.InsertTimes(fileFromContent, fileDestContent, filelocNew));

    }

}