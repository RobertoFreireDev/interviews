using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TreasuryChallenge.Interface;
using TreasuryChallenge.utils;

namespace TreasuryChallenge.Services
{
    public class ContentService : IContentService
    {
        public int LengthContent { get; private set; }
        private int NumberOfLines;
        public IStringBuilderService StringBuilderService { get; private set; }

        public int GetNumberOfLines() {
            return NumberOfLines;
        }
        public ContentService(int lengthContent, int numberOfLines) {
            LengthContent = lengthContent;
            NumberOfLines = numberOfLines;
        }

        public StringBuilder Generate() {
            StringBuilderService = new StringBuilderService();

            int numProcs = Environment.ProcessorCount;
            int numberOfTimes = numProcs;
            Dictionary<int, int> linesPerTasklist = getListLinesPerTask(numberOfTimes);

            Parallel.For(0, numberOfTimes, i =>
            {
                for (int y = 0; y < linesPerTasklist.GetValueOrDefault(i); y++)
                {
                    AddCodeToContent();
                };
            });

            return StringBuilderService.GetStringContent();
        }

        private Dictionary<int, int> getListLinesPerTask(int numberOfTimes)
        {
            int lines = NumberOfLines / numberOfTimes;
            int rest = NumberOfLines % numberOfTimes;

            Dictionary<int, int> list = new Dictionary<int, int>();

            for (int i = 0; i < numberOfTimes; i++)
            {
                if (i == numberOfTimes - 1)
                {
                    list.Add(i, lines + rest);
                    continue;
                }
                list.Add(i, lines);
            }

            return list;
        }

        private void AddCodeToContent()
        {
            bool saved = false;
            while (!saved)
            {
                saved = StringBuilderService.Append(CodeUtils.Generate(this.LengthContent));
            }
        }
    }
}
