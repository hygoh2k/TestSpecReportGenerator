using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyTestSandCastle;

namespace ModelTest
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
        /// test process method
        /// </summary>
        [TestMethod]
        public void TestProcess()
        {
            ProcessModel model = new ProcessModel(1);
            var result = model.Process();
            Helper();
            Assert.AreEqual(2, 2);
        }
    }

    /// <summary>
    /// test process model
    /// </summary>
    [TestClass]
    public class ProcessModelTest2
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
        /// kjhkjhkhk kjhkjh kjhkjh kjhkh jkhgjhg jhgjhkg kjhg
        /// hgjkhgjkhg kjhg jkhg jkhgjkhg jhgkjhg kjhgkjhg jkhgkjh g
        /// jkhgkjhgjhg jkhgjhkgjhkg jhgjkhg jkhgjkhgjkhgliuyiuy jhgjhgj khg 
        /// 'hjgkjhgkjhg kjhgkjhg kjhg iu7y hg h
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
