using System;
using NUnit.Framework;

using CarParking;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void EscapedAtVeryLeftFromLv1()
        {
            int[][] _carParking = new int[][] {new int[] {2, 0, 0, 0, 0, 0}};
            var theRoute = new EscapeRoute().FindRoute(_carParking);
            Assert.AreEqual("R5", theRoute[0]);
        }

        [Test]
        public void EscapedAtVeryLeftFromLv2()
        {
            int[][] _carParking = new int[][] {new int[] { 2, 0, 0, 0, 0, 1 }, new int[] { 0, 0, 0, 0, 0, 0 } };
            var theRoute = new EscapeRoute().FindRoute(_carParking);
            Assert.AreEqual("R5", theRoute[0]);
            Assert.AreEqual("D1", theRoute[1]);
        }

        [Test]
        public void EscapedAtVeryLeftFromLv3()
        {
            int[][] _carParking =
                new int[][]
                {
                    new int[] { 2, 0, 0, 1, 0, 0 },
                    new int[] { 1, 0, 0, 0, 0, 0 },
                    new int[] { 0, 0, 0, 0, 0, 0 }
                };
            var theRoute = new EscapeRoute().FindRoute(_carParking);
            Assert.AreEqual("R3", theRoute[0]);
            Assert.AreEqual("D1", theRoute[1]);
            Assert.AreEqual("L3", theRoute[2]);
            Assert.AreEqual("D1", theRoute[3]);
            Assert.AreEqual("R5", theRoute[4]);
        }
    }
}