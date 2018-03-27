using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using EvalRpgLib.Beings;
using EvalRpgTests.TestHelpers;

namespace EvalRpgTests
{
    [TestClass]
    public class skillTest
    {
        [TestMethod]
        public void TestCastOK()
        {
            Unit A = new Unit("A");
            A.UpdateStats();
            int health = A.GetCurrentStat(StatisticsEnum.Health);
            int mana = A.GetCurrentStat(StatisticsEnum.Mana);
            Skill skill = new MockSkill(A);
            skill.Cast(A);
            Assert.AreEqual(health + 10, A.GetCurrentStat(StatisticsEnum.Health));
            Assert.AreEqual(mana - 10, A.GetCurrentStat(StatisticsEnum.Mana));
        }

        [TestMethod]
        public void TestComputePower()
        {
            Unit A = new Unit("A");
            A.UpdateStats();
            Skill skill = new MockSkill(A);
            int result = skill.ComputePower();
            Assert.AreEqual(11, result);
        }
    }
}
