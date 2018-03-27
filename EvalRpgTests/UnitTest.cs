using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EvalRpgLib.Beings;
using EvalRpgLib.Exemples;

namespace EvalRpgTests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestUnitContructorOK(){
            Unit unit = new Unit("Cartman");

            Assert.IsNotNull(unit.Equipement);
            Assert.IsNotNull(unit.StatManager);
            Assert.IsNull(unit.Weapon);
            Assert.IsNotNull(unit.Bag);
            Assert.IsNotNull(unit.Skills);
            Assert.AreEqual(1, unit.Level);
        }

        [TestMethod]
        public void TestUnitUseSkillOK(){
            Unit unit = CreateUnit("Falcorn");

            Skill skill = new Skill(unit);
            unit.Skills.Add(skill);
            skill.StatisticReference = StatisticsEnum.Stamina;
            skill.BasePower = 10;
            skill.Ability = ((Unit target) => { 
                target.TakeDamage(skill.BasePower, false, skill.Caster);
                return true; 
            });

            Unit mtarget = CreateUnit("Kenny");
  
            Assert.IsTrue(unit.UseSkill(skill, mtarget));
            Assert.AreEqual(40, mtarget.GetCurrentStat(StatisticsEnum.Health));
        }

        [TestMethod]
        public void TestUnitUseSkillKO()
        {
            Unit unit = CreateUnit("Falcorn");

            Skill skill = new Skill(unit);
            //unit.Skills.Add(skill);
            skill.StatisticReference = StatisticsEnum.Stamina;
            skill.BasePower = 10;
            skill.Ability = ((Unit target) => {
                target.TakeDamage(skill.BasePower, false, skill.Caster);
                return true;
            });

            Unit mtarget = CreateUnit("Kenny");

            Assert.IsFalse(unit.UseSkill(skill, mtarget));
            Assert.AreEqual(50, mtarget.GetCurrentStat(StatisticsEnum.Health));
        }


        [TestMethod]
        public void TestUnitAttaqueOK()
        {
            Unit A = CreateUnit("test_A");
            Unit B = CreateUnit("test_B");

            Weapon weapon = new Weapon("L'épee des milles vérités", false);
            A.Weapon = weapon;
            weapon.Damage = 20;

            Assert.IsTrue(A.Attack(B));
            Assert.AreEqual(10, B.GetCurrentStat(StatisticsEnum.Health));
        }

        [TestMethod]
        public void TestUnitAttaqueKO()
        {
            Unit A = CreateUnit("test_A");
            Unit B = CreateUnit("test_B");

            Assert.IsFalse(A.Attack(B));
        }

        [TestMethod]
        public void TestUnitTakeDamegeOK()
        {
            Unit unit = CreateUnit("Cartman");
            Unit target = CreateUnit("Falcorn");

            Assert.AreEqual(20, target.TakeDamage(20, false, unit));
            Assert.AreEqual(30, target.GetCurrentStat(StatisticsEnum.Health));

            target.StatManager.CurrentStatistics[StatisticsEnum.PhysicalResistance] = 50;
            Assert.AreEqual(10, target.TakeDamage(60, false, unit));
            Assert.AreEqual(20, target.GetCurrentStat(StatisticsEnum.Health));

            target.StatManager.CurrentStatistics[StatisticsEnum.MagicalResistance] = 90;
            Assert.AreEqual(10, target.TakeDamage(100, true, unit));
            Assert.AreEqual(10, target.GetCurrentStat(StatisticsEnum.Health));
        }

        [TestMethod]
        public void TestUnitTakeDamegeKO()
        {
            Unit unit = CreateUnit("Cartman");
            Unit target = CreateUnit("Falcorn");

            Assert.AreEqual(0, target.TakeDamage(-20, false, unit));
            Assert.AreEqual(50, target.GetCurrentStat(StatisticsEnum.Health));

            Assert.AreEqual(20000, target.TakeDamage(20000, false, unit));
            Assert.AreEqual(0, target.GetCurrentStat(StatisticsEnum.Health));
        }

        public Unit CreateUnit(string name = "Falcorn"){
            Unit unit = new Unit(name);
            unit.StatManager.CurrentStatistics[StatisticsEnum.Health] = 50;
            unit.StatManager.CurrentStatistics[StatisticsEnum.MagicalResistance] = 0;
            unit.StatManager.CurrentStatistics[StatisticsEnum.PhysicalResistance] = 0;
            unit.StatManager.CurrentStatistics[StatisticsEnum.Stamina] = 50;
            unit.StatManager.CurrentStatistics[StatisticsEnum.Mana] = 50;
            unit.StatManager.CurrentStatistics[StatisticsEnum.MagicalDamage] = 10;
            unit.StatManager.CurrentStatistics[StatisticsEnum.PhysicalDamage] = 20;

            return unit;
        }
    }
}
