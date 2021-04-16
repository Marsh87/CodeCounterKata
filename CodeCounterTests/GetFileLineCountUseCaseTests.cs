using System;
using System.Collections.Generic;
using System.Linq;
using CodeCounter;
using CodeCounterTests.TestDataBuilders;
using NUnit.Framework;

namespace CodeCounterTests
{
    [TestFixture]
    public class GetFileLineCountUseCaseTests
    {
        [Test]
        public void GivenValidFilePath_ShouldReturnOneFile()
        {
            //Arrange
            var currentDirectory = $"{AppDomain.CurrentDomain.BaseDirectory}\\OneFile";
            var expected = new List<FileLineCount>
            {
                new FileLineCount
                {
                    Count = 2,
                    FileName = currentDirectory
                }
        };
            var paths = new List<string> { currentDirectory };
            var builder = TestDataBuilder.Create()
                .WithCodeCounter(2, currentDirectory)
                .WithFilePath(paths, currentDirectory);

            var sut = builder.Build();
            //Act
            var results = sut.GetLineCountList(currentDirectory);
            //Assert
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(expected.Count, results.Count);
            Assert.IsTrue(expected.FirstOrDefault()?.FileName.Contains(results?.FirstOrDefault()?.FileName ?? string.Empty));
        }

        [Test]
        public void GivenValidFilePath_ShouldReturnMultipleFiles()
        {
            //Arrange
            var currentDirectory = $"{AppDomain.CurrentDomain.BaseDirectory}\\Files";
            var expected = new List<FileLineCount>
            {
                new FileLineCount
                {
                    Count = 10,
                    FileName = currentDirectory
                }
        };
            var paths = new List<string> { currentDirectory };
            var builder = TestDataBuilder.Create()
                .WithCodeCounter(10, currentDirectory)
                .WithFilePath(paths, currentDirectory);
            var sut = builder.Build();
            //Act
            var results = sut.GetLineCountList(currentDirectory);
            //Assert
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(expected.Count, results.Count);
            Assert.IsTrue(expected.FirstOrDefault()?.FileName.Contains(results?.FirstOrDefault()?.FileName ?? string.Empty));
        }

        [Test]
        public void GivenInvalidFilePath_ShouldReturnNoFiles()
        {
            //Arrange
            var currentDirectory = $"{AppDomain.CurrentDomain.BaseDirectory}\\OneFile";
            var expected = new List<FileLineCount>();
            var paths = new List<string>();
            var builder = TestDataBuilder.Create()
                .WithCodeCounter(2, currentDirectory)
                .WithFilePath(paths, currentDirectory);
            var sut = builder.Build();
            //Act
            var results = sut.GetLineCountList(currentDirectory);
            //Assert
            Assert.AreEqual(0, results.Count);
            Assert.AreEqual(expected.Count, results.Count);
            CollectionAssert.AreEqual(expected.FirstOrDefault()?.FileName, results.FirstOrDefault()?.FileName);
        }
    }
}
