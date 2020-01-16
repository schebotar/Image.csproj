using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Recognizer
{
    [TestFixture]
    public class MedianFilterTaskTest
    {
        [Test]
        public void Test()
        {
            Assert.AreEqual(new double[,] { { 0.5 } }, MedianFilterTask.MedianFilter(new double[,] { {0.5} }));
        }


    }
}
