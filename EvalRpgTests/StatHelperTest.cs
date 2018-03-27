using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using EvalRpgLib.Helpers;

namespace EvalRpgTests
{
    [TestClass]
    public class StatHelperTest
    {

        [TestMethod]
        public void TestFuncLinear10()
        {
            Assert.AreEqual(11, StatHelper.FuncLinear10(1, 1));
            Assert.AreEqual(51, StatHelper.FuncLinear10(5, 1));
            Assert.AreEqual(-9, StatHelper.FuncLinear10(-1, 1));

        }

        public void TestFuncLinear2()
        {
            Assert.AreNotEqual(297, StatHelper.FuncLinear2(99 , 99));
            Assert.AreNotEqual(11, StatHelper.FuncLinear2(5, 1));
            Assert.AreNotEqual(-1, StatHelper.FuncLinear2(-1, 1));
        }

    }
}
