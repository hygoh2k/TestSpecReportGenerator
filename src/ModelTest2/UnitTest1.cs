using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyTestSandCastle;

namespace ModelTest2
{
    /// <summary>
    /// test process model
    /// </summary>
    [TestClass]
    public class ProcessModelTest
    {
        /// <summary>
        /// do nothing
        /// </summary>
        private void Helper()
        {

        }

        /// <summary>
        /// test process methodA
        /// </summary>
        [TestMethod]
        public void TestProcess2A()
        {
            ProcessModel model = new ProcessModel(1);
            var result = model.Process();
            Helper();
            Assert.AreEqual(2, 2);
        }
    }

    /// <summary>
    /// test process modelA
    /// </summary>
    [TestClass]
    public class ProcessModelTest2A
    {
        /// <summary>
        /// do nothing
        /// </summary>
        private void Helper2()
        {

        }

        /// <summary>
        /// test process method
        /// input int
        /// output int
        /// </summary>
        [TestMethod]
        public void TestProcess2()
        {
            ProcessModel model = new ProcessModel(1);
            var result = model.Process();
            Helper2();
            Assert.AreEqual(2, 2);
        }
    }
}
