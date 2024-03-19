using System.Text;
using System.Text.RegularExpressions;

namespace ProccessTextFiles
{
    public partial class ProcessTextFiles
    {

        public async Task<IEnumerable<string>> ReadFileSBV(string filePath)
        {
            if (filePath == null)
            {
                await Task.FromException(new Exception("File is null"));
            }
            return File.ReadLines(filePath);
        }

        public async Task<string> InsertTimes(IEnumerable<string> fileSource, IEnumerable<string> fileDestination, string filePathTo)
        {
            int l = 0;
            StringBuilder strb = new();
            var linesTo = fileDestination.ToList();
            foreach (string line in fileSource)
            {
                if (TimeLegend().IsMatch(line))
                {
                    strb.AppendLine(line);
                    strb.AppendLine(linesTo[l]);
                    strb.AppendLine("");
                    l++;
                }
            }
            using StreamWriter file = new(filePathTo, false);
            await file.WriteLineAsync(strb.ToString());

            return strb.ToString();
        }

        [GeneratedRegex("(.*):(.*):(.*).(.*),(.*):(.*):(.*).(.*)")]
        private static partial Regex TimeLegend();

    }
}
