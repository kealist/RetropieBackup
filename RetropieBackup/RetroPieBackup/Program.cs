using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroPieBackup
{
    // Define a class to receive parsed values
    class Options
    {
        [Option('p', "path", Required = true,
          HelpText = "Rom path to be scanned.")]
        public string Path { get; set; }

        [Option('e', "extension", Required = true,
          HelpText = "Extensions to scan for.")]
        public string Extension { get; set; }

        [Option('r', "recursive", DefaultValue = true,
          HelpText = "Scan subdirectories (default=true).")]
        public bool IncludeSubdirectories { get; set; }

        [Option('v', "verbose", DefaultValue = false,
          HelpText = "Prints all messages to standard output.")]
        public bool Verbose { get; set; }

        [ParserState]
        public IParserState LastParserState { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this,
              (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var options = new Options();
            if (CommandLine.Parser.Default.ParseArguments(args, options))
            {
                // Values are available here
                if (options.Verbose)
                    Console.WriteLine("Filename: {0}" + Environment.NewLine + 
                                        "Extension: {1}", options.Path, options.Extension);
            }
            
        }
    }
}
