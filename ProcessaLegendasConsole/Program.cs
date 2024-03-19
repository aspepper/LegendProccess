using System.Text;
using System.Text.RegularExpressions;

internal partial class Program
{
    private static void Main(string[] args)
    {
        string filelocFrom = @"C:\Users\Alex Pimenta\Downloads\captions-pt-br.sbv";
        string filelocTo = @"C:\Users\Alex Pimenta\Downloads\captions-en-us.sbv";
        string filelocNew = @"C:\Users\Alex Pimenta\Downloads\captions-en-us-New.sbv";

        IEnumerable<string> linesFrom = File.ReadLines(filelocFrom);
        List<string> linesTo = File.ReadLines(filelocTo).ToList();
        int l = 0;
        StringBuilder strb = new();
        foreach(string line in linesFrom){
            if(TimeLegend().IsMatch(line))
            {
                strb.AppendLine(line);
                strb.AppendLine(linesTo[l]);
                strb.AppendLine("");
                l++;
            }
        }
        using (StreamWriter file = new(filelocNew, false))
        {
            file.WriteLine(strb.ToString()); // "sb" is the StringBuilder
        }
        Console.WriteLine(String.Join(Environment.NewLine, strb.ToString()));

    }

    [GeneratedRegex("(.*):(.*):(.*).(.*),(.*):(.*):(.*).(.*)")]
    private static partial Regex TimeLegend();
}