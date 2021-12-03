using System;
using System.IO;
using System.Text;
using CommandLine;

namespace QuotationMarkTool
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandLineOptions commandLineOptions = new CommandLineOptions();
            if (args.Length == 0)
            {
                Console.WriteLine(commandLineOptions.GetUsage());
                return;
            }
            if (!CommandLine.Parser.Default.ParseArguments(args, commandLineOptions))
            {
                return;
            }

            string[] files = Directory.GetFiles(commandLineOptions.pathToInputFolder, "*.txt");
            string fileName;

            for (int i = 0; i < files.Length; i++)
            {
                fileName = Path.GetFileName(files[i]);
                string absoluteOutputPath = commandLineOptions.pathToOutputFolder + fileName;
                absoluteOutputPath = absoluteOutputPath.Replace("\"", "\\");

                foreach (string line in File.ReadLines(files[i]))
                {
                    File.AppendAllText(absoluteOutputPath, $"\"«{line.Substring(0, line.LastIndexOf(","))}»\",{line.Substring(line.LastIndexOf(",") + 1)}\n");
                }

                Console.WriteLine($"\nФайл \"{fileName}\" перезаписан в {absoluteOutputPath}");
            }
        }
    }
}
