using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EvalRpgLib.Beings;

namespace EvalRpgTests
{   
    [TestClass]
    public class SkillTest
    {
        [TestMethod]
        public void TestSkillConstructorOk(){
            Unit unit = new Unit("test");
            Skill skill = new Skill(unit);

            Assert.AreEqual(unit, skill.Caster);
           
        }

        //[TestMethod]
        //public void TestSkillConstructorKo()
        //{
        //    Skill skill = new Skill(null);

        //    Assert.AreEqual(skill, skill.Caster);

        [TestMethod]
        public void TestSkillCastOk()
        {
            Unit unit = new Unit("Falcorn");
            unit.StatManager.CurrentStatistics[StatisticsEnum.Health] = 50;
            unit.StatManager.CurrentStatistics[StatisticsEnum.MagicalResistance] = 0;
            unit.StatManager.CurrentStatistics[StatisticsEnum.PhysicalResistance] = 0;
            unit.StatManager.CurrentStatistics[StatisticsEnum.Stamina] = 50;

            Skill skill = new Skill(unit);
            unit.Skills.Add(skill);
            skill.StatisticReference = StatisticsEnum.Stamina;
            skill.BasePower = 10;
            skill.Cost = 20;
            skill.Ability = ((Unit target) => {
                target.TakeDamage(skill.BasePower, false, skill.Caster);
                return true;
            });

            Unit mtarget = new Unit("Kenny");
            mtarget.StatManager.CurrentStatistics[StatisticsEnum.Health] = 50;
            mtarget.StatManager.CurrentStatistics[StatisticsEnum.MagicalResistance] = 0;
            mtarget.StatManager.CurrentStatistics[StatisticsEnum.PhysicalResistance] = 0;
            mtarget.StatManager.CurrentStatistics[StatisticsEnum.Stamina] = 50;

            Assert.IsTrue(skill.Cast(mtarget));
            Assert.AreEqual(40, mtarget.GetCurrentStat(StatisticsEnum.Health));
            Assert.AreEqual(30, unit.GetCurrentStat(StatisticsEnum.Stamina));
        }

        [TestMethod]
        public void TestSkillCastKo()
        {
            Unit unit = new Unit("Falcorn");
            unit.StatManager.CurrentStatistics[StatisticsEnum.Health] = 50;
            unit.StatManager.CurrentStatistics[StatisticsEnum.MagicalResistance] = 0;
            unit.StatManager.CurrentStatistics[StatisticsEnum.PhysicalResistance] = 0;
            unit.StatManager.CurrentStatistics[StatisticsEnum.Stamina] = 50;

            Skill skill = new Skill(unit);
            unit.Skills.Add(skill);
            skill.StatisticReference = StatisticsEnum.Stamina;
            skill.BasePower = 10;
            skill.Ability = ((Unit target) => {
                target.TakeDamage(skill.BasePower, false, skill.Caster);
                return true;
            });

            Unit mtarget = new Unit("Kenny");
            mtarget.StatManager.CurrentStatistics[StatisticsEnum.Health] = 50;
            mtarget.StatManager.CurrentStatistics[StatisticsEnum.MagicalResistance] = 0;
            mtarget.StatManager.CurrentStatistics[StatisticsEnum.PhysicalResistance] = 0;
            mtarget.StatManager.CurrentStatistics[StatisticsEnum.Stamina] = 50;

            Assert.IsFalse(skill.Cast(null));
           
        }

        [TestMethod]
        public void TestComputePower()
        {
            Unit unit = new Unit("unit");
            unit.StatManager.CurrentAttributes[AttributeEnum.Strength] = 10;

            Weapon weapon = new Weapon("arme", false);
            weapon.Damage = 15;

            unit.Weapon = weapon;
            Skill skill = new Skill(unit);
            skill.AttributeReference = AttributeEnum.Strength;
            unit.Skills.Add(skill);
            skill.BasePower = 50;

            Assert.AreEqual(75, skill.ComputePower());

        }

    }
}
