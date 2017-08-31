using System.Collections.Generic;
using NUnit.Framework;
using Tydbits.DressingUp.Clothing;

namespace Tydbits.DressingUp.Tests.StateTests
{
    [TestFixture]
    public class StateTest
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

        [Test]
        public void InitialState()
        {
            Assert.That(_state.IsOn(ClothingType.Pajamas));

            foreach (var item in ClothingSet.All)
                if (item != ClothingType.Pajamas)
                    Assert.That(_state.IsOn(item), Is.False);
        }

        [Theory]
        public void NonEmptyState(ClothingType clothing)
        {
            foreach (var item in ClothingSet.Street)
            {
                if (item == clothing)
                    continue;
                _state.PutOn(item);
                Assert.That(_state.IsOn(clothing), Is.False);
            }

            _state.PutOn(clothing);
            Assert.That(_state.IsOn(clothing));
        }
    }
}