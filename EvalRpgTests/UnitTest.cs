using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EvalRpgLib.Beings;
using EvalRpgTests.TestHelpers;

namespace EvalRpgTests
{
    [TestClass]
    public class UnitTest
    {

        [TestMethod]
        public void TestConstructor()
        {
            Dictionary<ArmorType, Armor> equipement = new Dictionary<ArmorType, Armor>();
            equipement.Add(ArmorType.Chest, new Armor("Cotte de maille rouillée", ArmorType.Chest, 1000));
            Weapon dagueDeMerde = new Weapon("Dague de merde", false);

            Unit unit = new Unit("test", null, equipement, dagueDeMerde);

            Assert.AreEqual(equipement, unit.Equipement);
            Assert.AreEqual(dagueDeMerde, unit.Weapon);
            Assert.IsNotNull(unit.StatManager);
            Assert.AreEqual(1, unit.Level);
        }

        [TestMethod]
        public void TestUnitAttaqueKO()
        {
            Unit A = new Unit("test_A");
            Unit B = new Unit("test_B");

            Assert.IsFalse(A.Attack(B));
        }

        [TestMethod]
        public void TestGetCurrentAttribute()
        {
            Unit A = new Unit("test_A");
            A.UpdateStats();
            int Strength = A.GetCurrentAttribute(AttributeEnum.Strength);
            Assert.AreEqual(10, Strength);
    }

        [TestMethod]
        public void TestCurrentStat()
        {
            Unit A = new Unit("test_A");
            A.UpdateStats();
            int Health = A.GetCurrentStat(StatisticsEnum.Health);
            Assert.AreEqual(101, Health);
        }

        [TestMethod]
        public void TestUseSkill()
        {
            Unit A = new Unit("A");
            A.UpdateStats();
            int health = A.GetCurrentStat(StatisticsEnum.Health);
            int mana = A.GetCurrentStat(StatisticsEnum.Mana);
            Skill skill = new MockSkill(A);
            A.Skills.Add(skill);
            A.UseSkill(skill, A);
            Assert.AreEqual(health + 10, A.GetCurrentStat(StatisticsEnum.Health));
            Assert.AreEqual(mana - 10, A.GetCurrentStat(StatisticsEnum.Mana));
        }





        [TestMethod]
        public void TestUnitTakeDamage()
        {
            Unit A = new Unit("test_A");
            Unit B = new Unit("test_B");
            A.UpdateStats();
            int damage = 30;
            A.TakeDamage(damage, false, B);
            damage -= A.GetCurrentStat(StatisticsEnum.PhysicalResistance);
            Assert.AreEqual(A.StatManager.BaseStatistics[StatisticsEnum.Health]-damage, A.StatManager.GetCurrentStatistic(StatisticsEnum.Health));
        }


    }
}
