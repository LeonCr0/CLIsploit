﻿// Copyright Plextora 2022
// This file is licensed under GPL-3.0-or-later

using CommandLine;
using CommandLine.Text;
using KrnlAPI;
using System.Collections.Generic;
using System;
using WeAreDevs_API;

namespace CLIsploit
{
    internal class Program
    {
        public class Options
        {
            [Option("api", Required = true, HelpText = "Specify which exploit API you want to use")]
            public string api { get; set; }

            [Option('p', "scriptpath", Required = true, HelpText = "Specify the path of the script you want to use")]
            public string scriptPath { get; set; }
        }

        static void DisplayHelp<T>(ParserResult<T> result, IEnumerable<Error> errs)
        {
            var helpText = HelpText.AutoBuild(result, h =>
            {
                h.AdditionalNewLineAfterOption = false;
                h.Heading = "CLIsploit - Exploit in ROBLOX the chad way";
                h.Copyright =
                    "Copyright 2022 Plextora\n\n" +
                    "This program comes with ABSOLUTELY NO WARRANTY.\n" +
                    "This is free (as in freedom) software, and you are welcome to redistribute it under certain conditions.\n" +
                    "Visit <https://www.gnu.org/licenses/gpl-3.0.en.html> for more information.";
                return HelpText.DefaultParsingErrorsHandler(result, h);
            }, e => e);
            Console.WriteLine(helpText);
        }

        static void Main(string[] args)
        {
            var parser = new CommandLine.Parser(with => with.HelpWriter = null);
            var parserResult = parser.ParseArguments<Options>(args);
            parserResult
                .WithParsed<Options>(options => Run(options))
                .WithNotParsed(errs => DisplayHelp(parserResult, errs));
        }

        public static void Run(Options options) {}

        public static void Inject(string api) {}
    }
}
