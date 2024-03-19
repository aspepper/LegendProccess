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

        public string InsertTimes(IEnumerable<string> fileSource, IEnumerable<string> fileDestination, string filePathTo)
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
            if (File.Exists(filePathTo)) { File.Delete(filePathTo); }
            using (StreamWriter file = new(filePathTo, false))
            {
                file.WriteLineAsync(strb.ToString());
            }

            return strb.ToString();
        }

        public string ListToString(IEnumerable<string> content)
        {
            return String.Join(Environment.NewLine, content);
        }

        [GeneratedRegex("(.*):(.*):(.*).(.*),(.*):(.*):(.*).(.*)")]
        private static partial Regex TimeLegend();

    }
}
