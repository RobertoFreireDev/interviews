using System;
using System.Diagnostics;
using TreasuryChallenge.Model;
using TreasuryChallenge.controller;
using TreasuryChallenge.Common;
using TreasuryChallenge.Interface;
using TreasuryChallenge.Services;

namespace TreasuryChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Constants.NUMBER_OF_LINES_TO_ENTER);
            int inputValue = int.Parse(Console.ReadLine());
            InputModel input = new InputModel(inputValue);

            var stopwatch = Stopwatch.StartNew();

            IContentService contentService = new ContentService(7, input.Value);
            IFileService fileService = new TXTFileService();
            WriteFileController write = new WriteFileController(fileService, contentService);

            write.WriteCodeInFile();

            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
        }
    }
}