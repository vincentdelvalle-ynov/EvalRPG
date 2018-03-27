using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EvalRpgLib.Beings;

namespace EvalRpgTests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestUnitAttaqueKO()
        {
            Unit A = new Unit("test_A");
            Unit B = new Unit("test_B");

            Assert.IsFalse(A.Attack(B));
        }
        [TestMethod]
        public void TestUpdateStatsOK()
        {
            Unit caster = new Unit("caster", null, null, null);
            StatManager stats = new StatManager(caster, new Dictionary<AttributeEnum, int>(), new Dictionary<StatisticsEnum, Func<Unit, int>>());
            caster.StatManager = stats;

            caster.Buff.Add(StatisticsEnum.MagicalResistance, 20);
            Assert.AreEqual(0, caster.GetCurrentStat(StatisticsEnum.MagicalResistance));
            caster.UpdateStats();
            Assert.AreEqual(20, caster.GetCurrentStat(StatisticsEnum.MagicalResistance));
        }
        [TestMethod]
        public void TestGetCurrentStatOK()
        {
            Unit caster = new Unit("caster", null, null, null);
            Unit target = new Unit("target", null, null, null);
            StatManager stats = new StatManager(caster, new Dictionary<AttributeEnum, int>(), new Dictionary<StatisticsEnum, Func<Unit, int>>());
            stats.CurrentStatistics.Add(StatisticsEnum.Mana, 2);
            caster.StatManager = stats;

            Assert.AreEqual(2, caster.GetCurrentStat(StatisticsEnum.Mana));
        }

        [TestMethod]
        public void TestGetCurrentAtributeOK()
        {
            Unit caster = new Unit("caster", null, null, null);

            StatManager stats = new StatManager(caster, new Dictionary<AttributeEnum, int>(), new Dictionary<StatisticsEnum, Func<Unit, int>>());
            stats.CurrentAttributes.Add(AttributeEnum.Agility, 4);
            caster.StatManager = stats;

            Assert.AreEqual(4, caster.GetCurrentAttribute(AttributeEnum.Agility));
        }
        [TestMethod]
        public void TestUseSkillOK()
        {
            Unit caster = new Unit("caster", null, null, null);

            StatManager stats = new StatManager(caster, new Dictionary<AttributeEnum, int>(), new Dictionary<StatisticsEnum, Func<Unit, int>>());
            stats.CurrentStatistics.Add(StatisticsEnum.Mana, 2);
            caster.StatManager = stats;

            Skill getMana = new Skill(caster)
            {
                Cost = 0,
                StatisticReference = StatisticsEnum.Mana,
                Ability = (u) => {
                    u.StatManager.CurrentStatistics[StatisticsEnum.Mana] += 5;
                    return true;
                }
            };
            caster.UseSkill(getMana, caster);

            Assert.AreEqual(7, caster.GetCurrentStat(StatisticsEnum.Mana));
        }

        [TestMethod]
        public void TestUseSkillKO()
        {
            Unit caster = new Unit("caster", null, null, null);

            StatManager stats = new StatManager(caster, new Dictionary<AttributeEnum, int>(), new Dictionary<StatisticsEnum, Func<Unit, int>>());
            stats.CurrentStatistics.Add(StatisticsEnum.Mana, 2);
            caster.StatManager = stats;

            Skill getMana = new Skill(caster)
            {
                Cost = 0,
                StatisticReference = StatisticsEnum.Mana,
                Ability = (u) => {
                    u.StatManager.CurrentStatistics[StatisticsEnum.Mana] += 5;
                    return true;
                }
            };

            try
            {
                caster.UseSkill(null, caster);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NullReferenceException));
            }
        }

        [TestMethod]
        public void TestAttackOK()
        {
            Weapon hammer = new Weapon("hammer", false)
            {
                Damage = 50,

            };

            Unit caster = new Unit("caster", null, null, hammer);


            Unit target = new Unit("target", null, null, null);

            StatManager statsCaster = new StatManager(caster, new Dictionary<AttributeEnum, int>(), new Dictionary<StatisticsEnum, Func<Unit, int>>());
            StatManager statsTarget = new StatManager(target, new Dictionary<AttributeEnum, int>(), new Dictionary<StatisticsEnum, Func<Unit, int>>());

            statsTarget.CurrentStatistics.Add(StatisticsEnum.Health, 100);

            caster.StatManager = statsCaster;
            target.StatManager = statsTarget;
            caster.Buff.Add(StatisticsEnum.PhysicalDamage, 20);

            caster.UpdateStats();

            Assert.IsTrue(caster.Attack(target));
            Assert.AreEqual(30, target.GetCurrentStat(StatisticsEnum.Health));
        }

        [TestMethod]
        public void TestAttackKO()
        {
            Unit caster = new Unit("caster", null, null, null);
            Unit target = new Unit("target", null, null, null);

            caster.UpdateStats();

            Assert.IsFalse(caster.Attack(target));
        }

        [TestMethod]
        public void TestTakeDamageOK()
        {
            Unit caster = new Unit("caster", null, null, null);
            Unit target = new Unit("target", null, null, null);
            StatManager statsCaster = new StatManager(caster, new Dictionary<AttributeEnum, int>(), new Dictionary<StatisticsEnum, Func<Unit, int>>());
            StatManager statsTarget = new StatManager(target, new Dictionary<AttributeEnum, int>(), new Dictionary<StatisticsEnum, Func<Unit, int>>());

            statsTarget.CurrentStatistics.Add(StatisticsEnum.Health, 100);
            target.StatManager = statsTarget;
            caster.UpdateStats();
            target.TakeDamage(50, false, caster);

            Assert.AreEqual(50, target.GetCurrentStat(StatisticsEnum.Health));
        }

        [TestMethod]
        public void TestTakeDamageKO()
        {
            Unit caster = new Unit("caster", null, null, null);
            Unit target = new Unit("target", null, null, null);
            StatManager statsCaster = new StatManager(caster, new Dictionary<AttributeEnum, int>(), new Dictionary<StatisticsEnum, Func<Unit, int>>());
            StatManager statsTarget = new StatManager(target, new Dictionary<AttributeEnum, int>(), new Dictionary<StatisticsEnum, Func<Unit, int>>());

            statsTarget.CurrentStatistics.Add(StatisticsEnum.Health, 50);
            target.StatManager = statsTarget;
            caster.UpdateStats();

            Assert.AreEqual(50, target.TakeDamage(100, false, caster));
            Assert.AreEqual(0, target.GetCurrentStat(StatisticsEnum.Health));
        }
    }
}
