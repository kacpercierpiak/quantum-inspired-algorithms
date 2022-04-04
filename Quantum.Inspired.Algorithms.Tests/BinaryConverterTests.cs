using NUnit.Framework;
using Quantum.Inspired.Algorithms.Core;
using System;
using System.Collections.Generic;
namespace Quantum.Inspired.Algorithms.Tests
{
    public class BinaryConverterTests
    {
        [Test]
        [TestCase("0000", "0000")]
        [TestCase("0001", "0001")]
        [TestCase("0011", "0010")]
        [TestCase("1111", "1010")]
        [TestCase("1000", "1111")]
        [TestCase("01101", "01001")]
        public void GrayToBinaryTest(string gray, string binary)
        {
            Assert.AreEqual(binary, BinaryConverter.RBCtoBinary(gray));
        }

        [Test]
        [TestCase("0000", "0000")]
        [TestCase("0001", "0001")]
        [TestCase("0010", "0011")]
        [TestCase("1010", "1111")]
        [TestCase("1111", "1000")]   
        [TestCase("01001", "01101")]
        public void BinaryToGrayTest(string binary, string gray)
        {
            Assert.AreEqual(gray, BinaryConverter.BinaryToRBC(binary));
        }
    }
}
