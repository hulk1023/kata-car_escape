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

        [Test]
        public void EscapedAt3FromLv5()
        {
            int[][] _carParking =
                new int[][]
                {
                    new int[] { 0, 0, 2, 1, 0, 0 },
                    new int[] { 0, 1, 0, 0, 0, 0 },
                    new int[] { 0, 0, 0, 0, 1, 0 },
                    new int[] { 0, 1, 0, 0, 0, 0 },
                    new int[] { 0, 0, 0, 0, 0, 0 }
                };
            var theRoute = new EscapeRoute().FindRoute(_carParking);
            Assert.AreEqual("R1", theRoute[0]);
            Assert.AreEqual("D1", theRoute[1]);
            Assert.AreEqual("L2", theRoute[2]);
            Assert.AreEqual("D1", theRoute[3]);
            Assert.AreEqual("R3", theRoute[4]);
            Assert.AreEqual("D1", theRoute[5]);
            Assert.AreEqual("L3", theRoute[6]);
            Assert.AreEqual("D1", theRoute[7]);
            Assert.AreEqual("R4", theRoute[8]);
        }
    }
}