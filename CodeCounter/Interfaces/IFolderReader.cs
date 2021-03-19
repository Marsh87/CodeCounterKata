using System.Collections.Generic;

namespace CodeCounter.Interfaces
{
    public interface IFolderReader
    {
        List<string> GetFilePaths(string path);
    }
}
