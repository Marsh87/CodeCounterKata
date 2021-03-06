using System.IO;
using CodeCounter.Interfaces;

namespace CodeCounter
{
    public class CodeCounter : ICodeCounter
    {
        private bool _multiLineCommentCheck = false;
        public int CountLines(string filePath)
        {
            var countLines = 0;
            var multilineCounter = 0;
            using (var reader = new StreamReader(filePath))
            {
                while (reader.Peek() > -1)
                {
                    var line = reader.ReadLine();

                    if (IsLineAComment(line) && !string.IsNullOrEmpty(line))
                    {
                        countLines--;
                    }
                    multilineCounter = CountMultiLineComment(line, multilineCounter);
                    if (!string.IsNullOrEmpty(line))
                        countLines++;
                }
            }
            return countLines - multilineCounter;
        }

        private int CountMultiLineComment(string line, int multilineCounter)
        {
            if (string.IsNullOrEmpty(line))
            {
                return multilineCounter;
            }
            if (IsMultiLineCommentStart(line))
            {
                _multiLineCommentCheck = true;
            }

            if (_multiLineCommentCheck)
            {
                multilineCounter++;
            }

            if (IsMultiLineCommentEnd(line))
            {
                _multiLineCommentCheck = false;
            }

            return multilineCounter;
        }

        private static bool IsMultiLineCommentEnd(string line)
        {
            return line != null && line.EndsWith("*/");
        }

        private static bool IsMultiLineCommentStart(string line)
        {
            return line != null && line.StartsWith("/*");
        }

        private static bool IsLineAComment(string line)
        {
            return line != null && line.StartsWith("//");
        }
    }
}