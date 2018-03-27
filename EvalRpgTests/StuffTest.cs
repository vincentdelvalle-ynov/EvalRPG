using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EvalRpgLib.Beings;

namespace EvalRpgTests
{
    [TestClass]
    public class StuffTest
    {
        [TestMethod]
        public void TestStuffContructorOK(){
            Stuff stuff = new Stuff("bonnet");

            Assert.AreEqual("bonnet", stuff.Name);
            Assert.IsNotNull(stuff.StatusEffects);
            Assert.AreEqual(0, stuff.StatusEffects.Count);
        }

        [TestMethod]
        public void TestStuffContructorKO()
        {
            Stuff stuff = new Stuff(null);

            Assert.AreEqual("", stuff.Name);
            Assert.IsNotNull(stuff.StatusEffects);
            Assert.AreEqual(0, stuff.StatusEffects.Count);
        }

        [TestMethod]
        public void TestStuffAddAttributeEffectsOK()
        {
            Stuff stuff = new Stuff("bonnet");
            AttributEffect effect = new AttributEffect();

            stuff.AddAttributEffects(effect);

            Assert.IsNotNull(stuff.StatusEffects);
            Assert.AreEqual(1, stuff.StatusEffects.Count);
        }

        [TestMethod]
        public void TestStuffAddAttributeEffectsKO()
        {
            Stuff stuff = new Stuff("bonnet");

            stuff.AddAttributEffects(null);

            Assert.IsNotNull(stuff.StatusEffects);
            Assert.AreEqual(0, stuff.StatusEffects.Count);
        }
    }
}
