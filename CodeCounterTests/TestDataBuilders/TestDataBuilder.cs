using System.Collections.Generic;
using CodeCounter;
using CodeCounter.Interfaces;
using NSubstitute;

namespace CodeCounterTests.TestDataBuilders
{
    public class TestDataBuilder
    {
        public IFolderReader _folderReader { get; private set; }
        public ICodeCounter _codeCounter { get; private set; }

        public TestDataBuilder()
        {

        }

        public static TestDataBuilder Create()
        {
            var builder = new TestDataBuilder
            {
                _folderReader = Substitute.For<IFolderReader>(),
                _codeCounter = Substitute.For<ICodeCounter>()
            };

            return builder;
        }

        public TestDataBuilder WithFilePath(List<string> filePaths, string path)
        {
            _folderReader.GetFilePaths(path).Returns(filePaths);

            return this;
        }

        public TestDataBuilder WithCodeCounter(int counter, string filePath)
        {
            _codeCounter.CountLines(filePath).Returns(counter);

            return this;
        }

        public GetFileLineCountUseCase Build()
        {
            return new GetFileLineCountUseCase(_codeCounter, _folderReader);
        }
    }
}
