﻿using System;
using CodeCounter;
using NUnit.Framework;

namespace CodeCounterTests
{
    [TestFixture]
    public class FilePath
    {
        [Test]
        public void GivenExistingFolderPathShouldReturnTrue()
        {
            //Arrange
            var currentDirectory = $"{AppDomain.CurrentDomain.BaseDirectory}\\Files";
            var folderReader = new FolderReader();
            //Act
            var results = folderReader.DirectoryExists(currentDirectory);
            //Assert
            Assert.IsTrue(results);
            Assert.IsNotNull(results);
        }

        [Test]
        public void GivenNonExistingFolderPathShouldReturnFalse()
        {
            //Arrange
            var currentDirectory = $"{AppDomain.CurrentDomain.BaseDirectory}\\Files\\test";
            var folderReader = new FolderReader();
            //Act
            var results = folderReader.DirectoryExists(currentDirectory);
            //Assert
            Assert.IsFalse(results);
        }

        [Test]
        public void GivenValidFolderPathWithSixFilesShouldReturnSixFilePaths()
        {
            //Arrange
            var currentDirectory = $"{AppDomain.CurrentDomain.BaseDirectory}\\Files";
            var folderReader = new FolderReader();
            var expected = 6;
            //Act
            var results = folderReader.GetFilePath(currentDirectory);
            //Assert
            Assert.IsNotNull(results);
            Assert.AreEqual(expected, results.Count);
        }

        [Test]
        public void GivenValidFolderPathWithNoFilesShouldReturnEmptyListFilePaths()
        {
            //Arrange
            var currentDirectory = $"{AppDomain.CurrentDomain.BaseDirectory}\\Files\\test";
            var folderReader = new FolderReader();
            var expected = 0;
            //Act
            var results = folderReader.GetFilePath(currentDirectory);
            //Assert
            Assert.IsEmpty(results);
            Assert.AreEqual(expected, results.Count);
        }
    }
}
