using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using EvalRpgLib.Beings;

namespace EvalRpgTests
{

    [TestClass]
    public class StatManagerTest
    {
        [TestMethod]
        public void TestUpdateAttributes()
        {
            Unit A = new Unit("A");
            Assert.AreEqual(0, A.GetCurrentStat(StatisticsEnum.Health));
            Assert.AreEqual(0, A.GetCurrentAttribute(AttributeEnum.Strength));
            A.StatManager.Update();
            Assert.AreEqual(10, A.GetCurrentAttribute(AttributeEnum.Strength));
            Assert.AreEqual(101, A.GetCurrentStat(StatisticsEnum.Health));


        }

        [TestMethod]
        public void TestCurrentStats()
        {
            Unit A = new Unit("A");
            A.StatManager.Update();
            Assert.AreEqual(A.StatManager.BaseAttributes[AttributeEnum.Strength], A.GetCurrentAttribute(AttributeEnum.Strength));
            Assert.AreEqual(A.StatManager.BaseStatistics[StatisticsEnum.Health], A.GetCurrentStat(StatisticsEnum.Health));
        }

    }
}