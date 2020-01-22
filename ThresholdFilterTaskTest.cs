using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Recognizer
{
    [TestFixture]
    public class ThresholdFilterTaskTest
    {
        [Test]
        public void Test()
        {
            Assert.AreEqual(new double[,] { { 0 } }, ThresholdFilterTask.ThresholdFilter(new double[,] { { 123 } }, 0));
        }
            
    }
}
