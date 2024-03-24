using System.Text;
using System.Text.RegularExpressions;

namespace ProccessTextFiles
{
    public partial class ProcessTextFiles
    {

        public IEnumerable<string>? FileSourceContent { get; set; }
        public IEnumerable<string>? FileTargetContent { get; set; }

        public async Task<IEnumerable<string>> ReadFileSBV(string filePath)
        {
            if (filePath == null)
            {
                await Task.FromException(new Exception("File is null"));
            }
            return File.ReadLines(filePath);
        }

        public void ReadFileSource(string filePath)
        {
            FileSourceContent = ReadFileSBV(filePath).Result;
        }

        public void ReadFileTarget(string filePath)
        {
            FileTargetContent = ReadFileSBV(filePath).Result;
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

        public string StripTimes(string filePathTo)
        {
            int l = 0;
            StringBuilder strb = new();
            foreach (string line in FileSourceContent!)
            {
                if (!TimeLegend().IsMatch(line) && line.Trim().Length > 0)
                {
                    strb.AppendLine(line);
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
