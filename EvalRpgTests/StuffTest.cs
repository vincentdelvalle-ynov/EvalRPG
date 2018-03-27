using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using EvalRpgLib.Beings;

namespace EvalRpgTests
{
    [TestClass]
    public class StuffTest
    {
        [TestMethod]
        public void TestAddAttributeEffect()
        {
            Stuff lunettes = new Stuff("lunettes");
            AttributEffect ae = new AttributEffect();
            ae.Attribute = AttributeEnum.Intelligence;
            ae.Value = 10;
            lunettes.AddAttributEffects(ae);

            Assert.AreEqual(lunettes.StatusEffects[0], ae);
        }
    }
}
