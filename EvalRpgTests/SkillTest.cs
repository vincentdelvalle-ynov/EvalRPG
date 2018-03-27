using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EvalRpgLib.World;
using EvalRpgLib.Exemples;
using EvalRpgLib.Beings;

namespace EvalRpgTests
{
    [TestClass]
    public class SkillTest
    {
        [TestMethod]
        public void TestComputePowerOK()
        {
            Weapon sword = new Weapon("sword", false)
            {
                Damage = 4
            };

            Unit caster = new Unit("caster", null, null, sword)
            {
                Level = 5
            };

            StatManager stats = new StatManager(caster, new Dictionary<AttributeEnum, int>(), new Dictionary<StatisticsEnum, Func<Unit, int>>());
            stats.CurrentAttributes.Add(AttributeEnum.Agility, 4);
            caster.StatManager = stats;
            Skill fireBall = new Skill(caster)
            {
                BasePower = 6,
                AttributeReference = AttributeEnum.Agility
            };

            Assert.AreEqual(30, fireBall.ComputePower());
        }

        [TestMethod]
        public void TestComputePowerKO()
        {
            Unit caster = new Unit("caster", null, null, null);
            Skill fireBall = new Skill(caster);

            Assert.AreEqual(0, fireBall.ComputePower());
        }
        [TestMethod]
        public void TestCastOK()
        {
            Unit caster = new Unit("caster", null, null, null);
            Unit target = new Unit("target", null, null, null);
            StatManager stats = new StatManager(caster, new Dictionary<AttributeEnum, int>(), new Dictionary<StatisticsEnum, Func<Unit, int>>());
            stats.CurrentStatistics.Add(StatisticsEnum.Mana, 50);
            caster.StatManager = stats;

            Skill fireBall = new Skill(caster)
            {
                Cost = 9,
                StatisticReference = StatisticsEnum.Mana,
                Ability = (u) =>
                {
                    return false;
                }
            };

            Assert.IsTrue(fireBall.Cast(target));
            Assert.AreEqual(41, caster.StatManager.CurrentStatistics[StatisticsEnum.Mana]);
        }

        [TestMethod]
        public void TestCastKO()
        {
            Unit caster = new Unit("caster", null, null, null);
            Unit target = new Unit("target", null, null, null);
            StatManager stats = new StatManager(caster, new Dictionary<AttributeEnum, int>(), new Dictionary<StatisticsEnum, Func<Unit, int>>());
            stats.CurrentStatistics.Add(StatisticsEnum.Mana, 2);
            caster.StatManager = stats;

            Skill fireBall = new Skill(caster)
            {
                Cost = 9,
                StatisticReference = StatisticsEnum.Mana,
                Ability = (u) =>
                {
                    return false;
                }
            };

            Assert.IsFalse(fireBall.Cast(target));
        }

    }
}
