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
    public class AttributeTest
    {
        [TestMethod]
        public void TestAddAttributeEffectOK()
        {
            Armor dragonBoots = new Armor("Botte d'écaille de dragon", ArmorType.Legs, 3);
            AttributEffect attribute = new AttributEffect
            {
                Value = 8,
                Attribute = AttributeEnum.Agility
            };
            dragonBoots.AddAttributEffects(attribute);

            Assert.AreEqual(1, dragonBoots.StatusEffects.Count);
        }

        [TestMethod]
        public void TestAddAttributeEffectKO()
        {
            Armor dragonBoots = new Armor("Botte d'écaille de dragon", ArmorType.Legs, 3);
            dragonBoots.AddAttributEffects(null);

            Assert.IsNotNull(dragonBoots.StatusEffects);
            Assert.AreEqual(0, dragonBoots.StatusEffects.Count);
        }  
    }
}
