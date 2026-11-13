using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LaboratoryWork9;

namespace LaboratoryWork9.Tests
{
    [TestClass]
    public class TimeTests
    {
        [TestMethod]
        public void Constructor_ValidValues_NormalizesMinutes()
        {
            Time t = new Time(2, 75);
            Assert.AreEqual(3, t.Hours);
            Assert.AreEqual(15, t.Minutes);
        }

        [TestMethod]
        public void Constructor_NegativeValues_ThrowsArgumentException()
        {
            try
            {
                Time t = new Time(-1, 20);
                Assert.Fail("Ожидалось исключение ArgumentException, но оно не было выброшено.");
            }
            catch (ArgumentException)
            {
                // Тест пройден успешно
            }
        }

        [TestMethod]
        public void AddMinutes_OverflowMinutes_ConvertsToHours()
        {
            Time t = new Time(1, 50);
            Time result = t.AddMinutes(25);
            Assert.AreEqual(2, result.Hours);
            Assert.AreEqual(15, result.Minutes);
        }

        [TestMethod]
        public void AddMinutesStatic_ValidInput_ReturnsExpectedTime()
        {
            Time t = new Time(0, 45);
            Time result = Time.AddMinutesStatic(t, 30);
            Assert.AreEqual(1, result.Hours);
            Assert.AreEqual(15, result.Minutes);
        }

        [TestMethod]
        public void IncrementAndDecrement_BoundaryValues_HandlesCorrectly()
        {
            Time t1 = new Time(0, 59);
            t1++;
            Assert.AreEqual(1, t1.Hours);
            Assert.AreEqual(0, t1.Minutes);

            Time t2 = new Time(0, 0);
            t2--;
            Assert.AreEqual(0, t2.Hours);
            Assert.AreEqual(0, t2.Minutes);
        }

        [TestMethod]
        public void TypeCasts_ValidTime_ReturnsExpectedValues()
        {
            Time t1 = new Time(3, 45);
            Time t2 = new Time(3, 0);

            int hours = (int)t1;
            bool check1 = t1;
            bool check2 = t2;

            Assert.AreEqual(3, hours);
            Assert.IsTrue(check1);
            Assert.IsFalse(check2);
        }

        [TestMethod]
        public void BinaryOperators_PlusAndMinus_BothSidesWork()
        {
            Time t = new Time(2, 0);
            Assert.AreEqual(new Time(2, 30), t + 30);
            Assert.AreEqual(new Time(2, 30), 30 + t);
            Assert.AreEqual(new Time(1, 30), t - 30);
            Assert.AreEqual(new Time(0, 30), 150 - t);
            Assert.AreEqual(new Time(0, 0), 50 - t);
        }

        [TestMethod]
        public void Indexer_OutOfBounds_ThrowsArgumentException()
        {
            TimeArray arr = new TimeArray(2);
            try
            {
                Time item = arr[-1];
                Assert.Fail("Ожидалось исключение ArgumentException, но оно не было выброшено.");
            }
            catch (ArgumentException)
            {
                // Тест пройден успешно
            }
        }

        [TestMethod]
        public void CalculateAverageTime_ValidCollection_ReturnsCorrectAverage()
        {
            Time[] items = { new Time(1, 0), new Time(2, 0), new Time(3, 0) };
            TimeArray collection = new TimeArray(items);

            Time avg = Program.CalculateAverageTime(collection);
            Assert.AreEqual(2, avg.Hours);
            Assert.AreEqual(0, avg.Minutes);
        }

        [TestMethod]
        public void CalculateAverageTime_EmptyCollection_ReturnsZeroTime()
        {
            TimeArray emptyCollection = new TimeArray();
            Time avg = Program.CalculateAverageTime(emptyCollection);
            Assert.AreEqual(0, avg.Hours);
            Assert.AreEqual(0, avg.Minutes);
        }
    }
}
