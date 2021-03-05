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
            var filePath = @"HasOneLineOfText.txt";
            var sut = new CodeCounter.CodeCounter();
            //Act
            var result = sut.CountLines(filePath);
            //Assert
            var expected = 1;
            Assert.AreEqual(expected,result);
        } 
        
        [Test]
        public void CountLines_GivenFileWithOneLineOneEmptyLine_ShouldReturnOne()
        {
            //Arrange 
            var filePath = @"HasOneLineOfTextWithEmptyLine.txt";
            var sut = new CodeCounter.CodeCounter();
            //Act
            var result = sut.CountLines(filePath);
            //Assert
            var expected = 1;
            Assert.AreEqual(expected,result);
        }
        
        [Test]
        public void CountLines_GivenFileWithNoLines_ShouldReturnZero()
        {
            //Arrange 
            var filePath = @"HasNoLines.txt";
            var sut = new CodeCounter.CodeCounter();
            //Act
            var result = sut.CountLines(filePath);
            //Assert
            var expected = 0;
            Assert.AreEqual(expected,result);
        }
        
        [Test]
        public void CountLines_GivenFileWithOneLineAndSingleLineComment_ShouldReturnOne()
        {
            //Arrange 
            var filePath = @"HasSingleLineComment.txt";
            var sut = new CodeCounter.CodeCounter();
            //Act
            var result = sut.CountLines(filePath);
            //Assert
            var expected = 1;
            Assert.AreEqual(expected,result);
        } 
        
        [Test]
        public void CountLines_GivenFileWithOneLineAndMultipleSingleLineComment_ShouldReturnTwo()
        {
            //Arrange 
            var filePath = @"HasMultipleSingleLineComment.txt";
            var sut = new CodeCounter.CodeCounter();
            //Act
            var result = sut.CountLines(filePath);
            //Assert
            var expected = 2;
            Assert.AreEqual(expected,result);
        }
        
        [Test]
        public void CountLines_GivenFileWithOneLineAndMultiLineComment_ShouldReturnTwo()
        {
            //Arrange 
            var filePath = @"HasMultipleLineComment.txt";
            var sut = new CodeCounter.CodeCounter();
            //Act
            var result = sut.CountLines(filePath);
            //Assert
            var expected = 2;
            Assert.AreEqual(expected,result);
        }
    }
}