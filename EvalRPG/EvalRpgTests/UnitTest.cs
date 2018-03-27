using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EvalRpgLib.Beings;
using EvalRpgLib.Exemples;
using EvalRpgLib;
using EvalRpgLib.Helpers;

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


        //N°1
        [TestMethod]
        public void TestUnitAttaqueOK()
        {
            Unit A = new Unit("SirMocheté", null, null, new BasicSword());
            Unit B = new Unit("LeRoiDesRats", null, null, new BasicSword());
            A.StatManager = new StatManager(A, StatHelper.GetDefaultAttributes(), StatHelper.GetDefaultComputer());
            B.StatManager = new StatManager(B, StatHelper.GetDefaultAttributes(), StatHelper.GetDefaultComputer());
            A.StatManager.Update();
            B.StatManager.Update();
            Assert.IsTrue(A.Attack(B));
        }
        //N°2
        [TestMethod]
        public void TestUnitTakeDmgs()
        {
            Unit A = new Unit("SirMocheté", null, null, new BasicSword());
            Unit B = new Unit("LeRoiDesRats", null, null, new BasicSword());
            A.StatManager = new StatManager(A, StatHelper.GetDefaultAttributes(), StatHelper.GetDefaultComputer());
            B.StatManager = new StatManager(B, StatHelper.GetDefaultAttributes(), StatHelper.GetDefaultComputer());
            A.StatManager.Update();
            B.StatManager.Update();
            Assert.AreEqual(9, A.TakeDamage(10, false, A));
        }

 

        //N°3
        [TestMethod]
        public void TestGetCurrentStat()
        {
            //errror
            Unit A = new Unit("SirMocheté", null, null, new BasicSword());
            Unit B = new Unit("LeRoiDesRats", null, null, new BasicSword());
            A.StatManager = new StatManager(A, StatHelper.GetDefaultAttributes(), StatHelper.GetDefaultComputer());
            B.StatManager = new StatManager(B, StatHelper.GetDefaultAttributes(), StatHelper.GetDefaultComputer());
            A.StatManager.CurrentAttributes.Add(AttributeEnum.Strength, 10);

            A.StatManager.Update();
            B.StatManager.Update();
            Assert.AreEqual(101, A.GetCurrentStat(StatisticsEnum.Health));
            A.TakeDamage(10, false, A);
            Assert.AreEqual(91, A.GetCurrentStat(StatisticsEnum.Health));
        }


        //N°4
        [TestMethod]
        public void TestCritAttack()
        {
            //tester une attaque Skill Critique
            Unit Hero = new Unit("SirMocheté", null, null, new BasicSword());
            Unit Rat = new Unit("LeRoiDesRats", null, null, new BasicSword());
            Hero.StatManager = new StatManager(Hero, StatHelper.GetDefaultAttributes(), StatHelper.GetDefaultComputer());
            Hero.UpdateStats();
            Rat.StatManager = new StatManager(Rat, StatHelper.GetDefaultAttributes(), StatHelper.GetDefaultComputer());
            Rat.UpdateStats();

            //Idée n°1
            //Skill strike = new Skill(Hero);
            //Assert.IsTrue(
            //    Hero.UseSkill(strike, Rat)
            //);

            //idée n°2
            //Assert.IsTrue(
            //Hero.UseSkill(HeavyStrike(Hero), Rat)
            //);
        }

        //N°5
        [TestMethod]
        public void TestMagic()
        {
            Weapon MagicStaff = new Weapon("Baguette de sureau", true);
            Unit A = new Unit("SirMocheté", null, null, new BasicSword());
            Unit B = new Unit("LeRoiDesRats", null, null, new BasicSword());
            A.StatManager = new StatManager(A, StatHelper.GetDefaultAttributes(), StatHelper.GetDefaultComputer());
            B.StatManager = new StatManager(B, StatHelper.GetDefaultAttributes(), StatHelper.GetDefaultComputer());
            A.StatManager.Update();
            B.StatManager.Update();
            Assert.IsTrue(A.Attack(B));
        }
    }
}
