using System;
using System.Collections.Generic;
using System.Text;
using EvalRpgLib.Beings;

namespace EvalRpgTests.TestHelpers
{
    public class MockSkill : Skill
    {
        public MockSkill(Unit caster)
            : base(caster)
        {
            Name = "Mock Skill";
            Description = "Dummy description";
            Cost = 10;
            BasePower = 1;
            StatisticReference = StatisticsEnum.Mana;
            AttributeReference = AttributeEnum.Intelligence;

            Ability = Effect;
        }

        private bool Effect(Unit dummy)
        {
            dummy.StatManager.CurrentStatistics[StatisticsEnum.Health] += 10;
            return true;
        }


    }
}
