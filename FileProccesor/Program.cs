using System;
using CodeCounter;
using CodeCounter.Interfaces;

namespace FileProccesor
{
    class Program
    {
        private static readonly IFolderReader _folderReader = new FolderReader();
        private static readonly ICodeCounter _codeCounter = new CodeCounter.CodeCounter();

        static void Main(string[] args)
        {
            var useCase = new GetFileLineCountUseCase(_codeCounter, _folderReader);

            var results = useCase.GetLineCountList("C:\\Users\\nqobani\\Documents\\Chillisoft\\CodeCounterKata\\CodeCounterTests\\bin\\Debug\\Files");

            foreach (var item in results)
            {
                Console.WriteLine($"File name: {item.FileName},  Number of code lines: {item.Count}");
            }

            Console.Read();
        }
    }
}
