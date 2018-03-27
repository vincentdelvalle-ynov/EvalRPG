using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EvalRpgLib.Beings;

namespace EvalRpgTests
{
    [TestClass]
    public class WeaponTest
    {
        [TestMethod]
        public void TestWeaponContructorOK(){
            Weapon weapon = new Weapon("L'épee des milles véritées", true);

            Assert.AreEqual("L'épee des milles véritées", weapon.Name);
            Assert.AreEqual(true, weapon.IsMagic);
            Assert.AreEqual(0, weapon.Damage);
        }

        [TestMethod]
        public void TestWeaponContructorKO()
        {
            Weapon weapon = new Weapon(null, false);

            Assert.AreEqual("", weapon.Name);
            Assert.IsFalse(weapon.IsMagic);
        }

    }
}
