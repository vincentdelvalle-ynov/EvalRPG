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
    public class StateManagerTest
    {

        [TestMethod]
        public void UpdateOK()
        {
            Unit caster = new Unit("caster", null, null, null);
            StatManager stats = new StatManager(caster, new Dictionary<AttributeEnum, int>(), new Dictionary<StatisticsEnum, Func<Unit, int>>());
            caster.StatManager = stats;

            caster.Buff.Add(StatisticsEnum.MagicalResistance, 20);
            Assert.AreEqual(0, caster.GetCurrentStat(StatisticsEnum.MagicalResistance));
            caster.StatManager.Update();
            Assert.AreEqual(20, caster.GetCurrentStat(StatisticsEnum.MagicalResistance));
        }

        [TestMethod]
        public void UpdateAttributesOk()
        {
            Unit caster = new Unit("caster", null, null, null);
            StatManager stats = new StatManager(caster, new Dictionary<AttributeEnum, int>(), new Dictionary<StatisticsEnum, Func<Unit, int>>());
            caster.StatManager = stats;

            Armor dragonArmor = new Armor("dragon armor", ArmorType.Chest, 5);
            AttributEffect buffAgi = new AttributEffect();
            buffAgi.Attribute = AttributeEnum.Agility;
            buffAgi.Value = 5;
            dragonArmor.AddAttributEffects(buffAgi);

            caster.Equipement.Add(ArmorType.Chest,dragonArmor);
            
            Assert.AreEqual(0, caster.GetCurrentAttribute(AttributeEnum.Agility));
            caster.StatManager.UpdateAttributes();
            Assert.AreEqual(5, caster.GetCurrentAttribute(AttributeEnum.Agility));
        }

        [TestMethod]
        public void UpdateStatisticsOK()
        {
            Unit caster = new Unit("caster", null, null, null);
            StatManager stats = new StatManager(caster, new Dictionary<AttributeEnum, int>(), new Dictionary<StatisticsEnum, Func<Unit, int>>());
            caster.StatManager = stats;

            caster.Buff.Add(StatisticsEnum.MagicalResistance, 20);
            Assert.AreEqual(0, caster.GetCurrentStat(StatisticsEnum.MagicalResistance));
            caster.StatManager.UpdateStatistics();
            Assert.AreEqual(20, caster.GetCurrentStat(StatisticsEnum.MagicalResistance));
        }

        [TestMethod]
        public void GetCurrentStatisticOK()
        {
            Unit caster = new Unit("caster", null, null, null);
            StatManager stats = new StatManager(caster, new Dictionary<AttributeEnum, int>(), new Dictionary<StatisticsEnum, Func<Unit, int>>());
            caster.StatManager = stats;

            caster.Buff.Add(StatisticsEnum.MagicalResistance, 20);
            caster.StatManager.Update();
            Assert.AreEqual(20, caster.GetCurrentStat(StatisticsEnum.MagicalResistance));
        }

        public void GetCurrentAttributeOK()
        {
            Unit caster = new Unit("caster", null, null, null);
            StatManager stats = new StatManager(caster, new Dictionary<AttributeEnum, int>(), new Dictionary<StatisticsEnum, Func<Unit, int>>());
            caster.StatManager = stats;

            Armor dragonArmor = new Armor("dragon armor", ArmorType.Chest, 5);
            AttributEffect buffAgi = new AttributEffect();
            buffAgi.Attribute = AttributeEnum.Agility;
            buffAgi.Value = 5;
            dragonArmor.AddAttributEffects(buffAgi);

            caster.Equipement.Add(ArmorType.Chest, dragonArmor);
            caster.StatManager.UpdateAttributes();
            Assert.AreEqual(5, caster.GetCurrentAttribute(AttributeEnum.Agility));
        }
    }

}
