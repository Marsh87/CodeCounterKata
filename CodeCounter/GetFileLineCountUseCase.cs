using System;
using System.Collections.Generic;
using CodeCounter.Interfaces;

namespace CodeCounter
{
    public class GetFileLineCountUseCase : IGetFileLineCountUseCase
    {
        private readonly IFolderReader _folderReader;
        private readonly ICodeCounter _codeCounter;

        public GetFileLineCountUseCase(ICodeCounter codeCounter, IFolderReader folderReader)
        {
            _codeCounter = codeCounter;
            _folderReader = folderReader;
        }

        public List<FileLineCount> GetLineCountList(string filePath)
        {
            var filePaths = _folderReader.GetFilePaths(filePath);
            var fileCountList = new List<FileLineCount>();

            foreach (var path in filePaths)
            {
                var fileCount = new FileLineCount
                {
                    FileName = path.Substring(path.LastIndexOf("\\", StringComparison.Ordinal) + 1),
                    Count = _codeCounter.CountLines(path)
                };

                fileCountList.Add(fileCount);
            }

            return fileCountList;
        }
    }
}
