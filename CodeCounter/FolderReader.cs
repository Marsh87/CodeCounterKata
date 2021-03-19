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
            if (!DirectoryExists(path)) return new List<string>();
            filePaths = Directory.GetFiles(path).ToList();

            return filePaths.Count > 0 ? filePaths : new List<string>();
        }

        public bool DirectoryExists(string path)
        {
            return Directory.Exists(path);
        }
    }
}
