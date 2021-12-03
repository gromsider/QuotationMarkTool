using CommandLine;
using CommandLine.Text;

namespace QuotationMarkTool
{
    class CommandLineOptions
    {
        [Option('p', "pathToInputFolder", Required = true, HelpText = "Путь к папке с входными фалами.(формат .txt)")]
        public string pathToInputFolder { get; set; }

        [Option('o', "pathToOutputFolder", Required = true, HelpText = @"Путь к результирующей папке.")]
        public string pathToOutputFolder { get; set; }

        [ParserState]
        public IParserState LastParserState { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this, (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
        }

    }
}
