using System;
using CodeCounter;
using CodeCounter.Interfaces;
using SimpleInjector;

namespace FileProccesor
{
    class Program
    {
        private static readonly Container container = new Container();
        static Program()
        {
            container.Register<ICodeCounter, CodeCounter.CodeCounter>();
            container.Register<IFolderReader, FolderReader>();
            container.Register<IGetFileLineCountUseCase, GetFileLineCountUseCase>();

            container.Verify();
        }

        static void Main(string[] args)
        {

            var useCase = container.GetInstance<IGetFileLineCountUseCase>();

            var results = useCase.GetLineCountList("C:\\Users\\nqobani\\Documents\\Chillisoft\\CodeCounterKata\\CodeCounterTests\\bin\\Debug\\Files");

            foreach (var item in results)
            {
                Console.WriteLine($"File name: {item.FileName},  Number of code lines: {item.Count}");
            }

            Console.Read();
        }

    }
}
