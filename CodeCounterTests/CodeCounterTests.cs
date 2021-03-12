using System.IO;
using NUnit.Framework;

namespace CodeCounterTests
{
    [TestFixture]
    public class CodeCounterTests
    {
        [Test]
        public void CountLines_GivenFileWithOneLine_ShouldReturnOne()
        {
            //Arrange 
            var directory = TestContext.CurrentContext.TestDirectory;
            var filePath = Path.Combine(directory, "Files\\HasOneLineOfText.txt");
            var sut = new CodeCounter.CodeCounter();
            //Act
            var result = sut.CountLines(filePath);
            //Assert
            var expected = 1;
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void CountLines_GivenFileWithOneLineOneEmptyLine_ShouldReturnOne()
        {
            //Arrange 
            var directory = TestContext.CurrentContext.TestDirectory;
            var filePath = Path.Combine(directory, "Files\\HasOneLineOfTextWithEmptyLine.txt");
            var sut = new CodeCounter.CodeCounter();
            //Act
            var result = sut.CountLines(filePath);
            //Assert
            var expected = 1;
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void CountLines_GivenFileWithNoLines_ShouldReturnZero()
        {
            //Arrange 
            var directory = TestContext.CurrentContext.TestDirectory;
            var filePath = Path.Combine(directory, "Files\\HasNoLines.txt");
            var sut = new CodeCounter.CodeCounter();
            //Act
            var result = sut.CountLines(filePath);
            //Assert
            var expected = 0;
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void CountLines_GivenFileWithOneLineAndSingleLineComment_ShouldReturnOne()
        {
            //Arrange 
            var directory = TestContext.CurrentContext.TestDirectory;
            var filePath = Path.Combine(directory, "Files\\HasSingleLineComment.txt");
            var sut = new CodeCounter.CodeCounter();
            //Act
            var result = sut.CountLines(filePath);
            //Assert
            var expected = 1;
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void CountLines_GivenFileWithOneLineAndMultipleSingleLineComment_ShouldReturnTwo()
        {
            //Arrange 
            var directory = TestContext.CurrentContext.TestDirectory;
            var filePath = Path.Combine(directory, "Files\\HasMultipleSingleLineComment.txt");
            var sut = new CodeCounter.CodeCounter();
            //Act
            var result = sut.CountLines(filePath);
            //Assert
            var expected = 2;
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void CountLines_GivenFileWithOneLineAndMultiLineComment_ShouldReturnTwo()
        {
            //Arrange 
            var directory = TestContext.CurrentContext.TestDirectory;
            var filePath = Path.Combine(directory, "Files\\HasMultipleLineComment.txt");
            var sut = new CodeCounter.CodeCounter();
            //Act
            var result = sut.CountLines(filePath);
            //Assert
            var expected = 2;
            Assert.AreEqual(expected, result);
        }

    }
}