using System;
using System.Collections.Generic;
using EvalRpgLib.Beings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace EvalRpgTests
{
    [TestClass]
    public class StatManagerTest
    {
        [TestMethod]
        public void TestStatConstructor(){

            Unit unit = new Unit("test");
            StatManager statManager = new StatManager(
                unit,
                new Dictionary<AttributeEnum, int>{
                    {AttributeEnum.Strength ,10 },
                    {AttributeEnum.Intelligence,20},
                    {AttributeEnum.Agility,30}
                } 
            );
            unit.StatManager = statManager;

            statManager.Update();

            Assert.AreEqual(unit, statManager.Unit);

            Assert.AreEqual(30, statManager.GetCurrentAttribute(AttributeEnum.Agility));
            Assert.AreEqual(10, statManager.GetCurrentAttribute(AttributeEnum.Strength));
            Assert.AreEqual(20, statManager.GetCurrentAttribute(AttributeEnum.Intelligence));
        }

        [TestMethod]
        public void TestUpdateNoStuff()
        {

            Unit unit = new Unit("test");
            StatManager statManager = new StatManager(
                unit,
                new Dictionary<AttributeEnum, int>{
                    {AttributeEnum.Strength ,10 },
                    {AttributeEnum.Intelligence,20},
                    {AttributeEnum.Agility,30}
                }
            );
            unit.StatManager = statManager;

            statManager.Update();

            //Attribute
            Assert.AreEqual(30, statManager.GetCurrentAttribute(AttributeEnum.Agility));
            Assert.AreEqual(10, statManager.GetCurrentAttribute(AttributeEnum.Strength));
            Assert.AreEqual(20, statManager.GetCurrentAttribute(AttributeEnum.Intelligence));

            //statistics
            Assert.AreEqual(101, statManager.GetCurrentStatistic(StatisticsEnum.Health));
            Assert.AreEqual(301, statManager.GetCurrentStatistic(StatisticsEnum.Stamina));
            Assert.AreEqual(201, statManager.GetCurrentStatistic(StatisticsEnum.Mana));

            Assert.AreEqual(61, statManager.GetCurrentStatistic(StatisticsEnum.MagicalResistance));
            Assert.AreEqual(41, statManager.GetCurrentStatistic(StatisticsEnum.MagicalDamage));
            Assert.AreEqual(61, statManager.GetCurrentStatistic(StatisticsEnum.PhysicalResistance));
            Assert.AreEqual(21, statManager.GetCurrentStatistic(StatisticsEnum.PhysicalDamage));
        }


        [TestMethod]
        public void TestUpdateWithStuff()
        {

            Unit unit = new Unit("test");
            StatManager statManager = new StatManager(
                unit,
                new Dictionary<AttributeEnum, int>{
                    {AttributeEnum.Strength ,10 },
                    {AttributeEnum.Intelligence,20},
                    {AttributeEnum.Agility,30}
                }
            );
            unit.StatManager = statManager;

            //with stuff
            Armor bouclier = new Armor("bouclier", ArmorType.Hands, 10);
            bouclier.AddAttributEffects(new AttributEffect() { Attribute = AttributeEnum.Strength, Value = 50 });

            Armor casque = new Armor("casque", ArmorType.Head, 20);
            casque.AddAttributEffects(new AttributEffect() { Attribute = AttributeEnum.Agility, Value = 10 });

            unit.Equipement.Add(ArmorType.Hands, bouclier);
            unit.Equipement.Add(ArmorType.Head, casque);

            statManager.Update();
            Assert.AreEqual(40, statManager.GetCurrentAttribute(AttributeEnum.Agility));
            Assert.AreEqual(60, statManager.GetCurrentAttribute(AttributeEnum.Strength));
            Assert.AreEqual(20, statManager.GetCurrentAttribute(AttributeEnum.Intelligence));


        }
    }
}
