using System.Collections.Generic;
using System.IO;
using System.Linq;
using CodeCounter.Interfaces;

namespace CodeCounter
{
    public class FolderReader : IFolderReader
    {
        private List<string> filePaths;

        public List<string> GetFilePaths(string path)
        {
            return Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).ToList();
        }

        public bool DirectoryExists(string path)
        {
            return Directory.Exists(path);
        }
    }
}
