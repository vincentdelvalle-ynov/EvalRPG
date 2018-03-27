using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EvalRpgLib.Beings;

namespace EvalRpgTests
{   
    [TestClass]
    public class ArmorTest
    {
        [TestMethod]
        public void TestArmorConstructorOk(){
            Armor armor = new Armor("bouclier", ArmorType.Chest, 2);

            Assert.AreEqual(ArmorType.Chest, armor.Type);
            Assert.AreEqual(2, armor.Amount);
        }

        [TestMethod]
        public void TestArmorConstructorKo()
        {
            Armor armor = new Armor(null, ArmorType.Chest , -1);

            Assert.AreEqual(0, armor.Amount);
        }
    }
}
