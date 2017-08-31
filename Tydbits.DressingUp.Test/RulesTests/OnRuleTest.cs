using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Tydbits.DressingUp.Clothing;
using Tydbits.DressingUp.Rules;

namespace Tydbits.DressingUp.Tests.RulesTests
{
    [TestFixture]
    public class OnRuleTest
    {
        private State.State _state;

        [SetUp]
        public void SetUp()
        {
            _state = new State.State();
        }

        [DatapointSource]
        public IEnumerable<ClothingType> Data()
        {
            return ClothingSet.Street;
        }

        [Theory]
        public void Fails_On_EmptySet(ClothingType clothing)
        {
            var rule = new OnRule(clothing);

            Assert.That(rule.IsSatisfied(_state), Is.False);
        }

        [Theory]
        public void Fails_On_AnyNonMatchingSubset(ClothingType clothing)
        {
            var rule = new OnRule(clothing);

            foreach (var item in ClothingSet.Street)
            {
                if (item == clothing) continue;
                _state.PutOn(item);
                Assert.That(rule.IsSatisfied(_state), Is.False);
            }
        }

        [Theory]
        public void Satisfied_On_AnySuperset(ClothingType clothing)
        {
            var rule = new OnRule(clothing);

            _state.PutOn(clothing);
            Assert.That(rule.IsSatisfied(_state));

            foreach (var item in ClothingSet.Street)
            {
                _state.PutOn(item);
                Assert.That(rule.IsSatisfied(_state));
            }
        }
    }
}