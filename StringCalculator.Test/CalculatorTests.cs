using NUnit.Framework;
using System;

namespace StringCalculator.Test
{
    public class CalculatorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SingleNumberReturnsValue()
        {
            Calculator calculator = new Calculator();
            string input = "7";
            int expected = 7;

            int output = calculator.Add(input);
            Assert.AreEqual(expected, output);
        }

        [Test]
        public void EmptyStringReturnsZero()
        {
            Calculator calculator = new Calculator();
            string input = string.Empty;
            int expected = 0;

            int output = calculator.Add(input);
            Assert.AreEqual(expected, output);
        }

        [Test]
        public void TwoNumbersCommaDelimitedReturnSum()
        {
            Calculator calculator = new Calculator();
            string input = "2,9";
            int expected = 11;

            int output = calculator.Add(input);
            Assert.AreEqual(expected, output);
        }

        [Test]
        public void TwoNumbersNewlineDelimitedReturnSum()
        {
            Calculator calculator = new Calculator();
            string input = "23\n15";
            int expected = 38;

            int output = calculator.Add(input);
            Assert.AreEqual(expected, output);
        }
        [Test]
        public void ThreeNumbersReturnSum()
        {
            //version 1.0 comment
            Calculator calculator = new Calculator();
            string input = "2\n9,3";
            int expected = 14;

            int output = calculator.Add(input);
            Assert.AreEqual(expected, output);
        }
        [Test]
        public void NegativeNumberThrowsException()
        {
            Calculator calculator = new Calculator();
            string input = "-3";

            Assert.Catch(() => calculator.Add(input));
        }
        [Test]
        public void SingleCharDelimiterDefinedOnFirstLine()
        {
            Calculator calculator = new Calculator();
            string input = "//#\n1#2#3";
            int expected = 6;

            int output = calculator.Add(input);
            Assert.AreEqual(expected, output);
        }
        [Test]
        public void MultiCharDelimiterDefinedOnFirstLine()
        {
            Calculator calculator = new Calculator();
            string input = "//[###]\n1###2###3";
            int expected = 6;

            int output = calculator.Add(input);
            Assert.AreEqual(expected, output);
        }
        [Test]
        public void ManyMultiCharDelimiterDefinedOnFirstLine()
        {
            Calculator calculator = new Calculator();
            string input = "//[###][#][eee]\n1#2###3eee4";
            int expected = 10;

            int output = calculator.Add(input);
            Assert.AreEqual(expected, output);
        }
        [Test]
        public void SuperComplicatedTest()
        {
            Calculator calculator = new Calculator();
            string input = "//[###][!!][Maciek][#][eee][ ]\n1#1###1eee1!!1Maciek1 1";
            int expected = 7;

            int output = calculator.Add(input);
            Assert.AreEqual(expected, output);
        }
    }
}