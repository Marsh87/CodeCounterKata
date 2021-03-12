using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeCounter
{
    public class FolderReader
    {
        private List<string> filePaths;

        public List<string> GetFilePath(string path)
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
