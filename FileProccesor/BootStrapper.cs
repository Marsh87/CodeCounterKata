using CodeCounter;
using CodeCounter.Interfaces;
using SimpleInjector;

namespace FileProccesor
{
    public static class BootStraper
    {
        public static void Boot()
        {
            var container = new Container();
            container.Register<ICodeCounter, CodeCounter.CodeCounter>(Lifestyle.Scoped);
            container.Register<IFolderReader, FolderReader>(Lifestyle.Scoped);

            container.Verify();
        }
    }
}
