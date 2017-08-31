using System.Collections.Generic;
using NUnit.Framework;
using Tydbits.DressingUp.Clothing;
using Tydbits.DressingUp.Rules;

namespace Tydbits.DressingUp.Tests.RulesTests
{
    [TestFixture]
    public class OffRuleTest
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
            return ClothingSet.All;
        }

        [Theory]
        public void OK_On_EmptySet(ClothingType clothing)
        {
            Assume.That(clothing, Is.Not.EqualTo(ClothingType.Pajamas));

            var rule = new OffRule(clothing);

            Assert.That(rule.IsSatisfied(_state));
        }

        [Theory]
        public void OK_On_AnyNonMatchingSubset(ClothingType clothing)
        {
            Assume.That(clothing, Is.Not.EqualTo(ClothingType.Pajamas));

            var rule = new OffRule(clothing);

            foreach (var item in ClothingSet.All)
            {
                if (item == clothing || item == ClothingType.Pajamas) continue;
                _state.PutOn(item);
                Assert.That(rule.IsSatisfied(_state));
            }
        }

        [Theory]
        public void Fails_On_AnyMatchingSubset(ClothingType clothing)
        {
            var rule = new OffRule(clothing);

            _state.PutOn(clothing);
            Assert.That(rule.IsSatisfied(_state), Is.False);

            foreach (var item in ClothingSet.All)
            {
                _state.PutOn(item);
                Assert.That(rule.IsSatisfied(_state), Is.False);
            }
        }
    }
}