using NUnit.Framework;
using Tydbits.DressingUp.Clothing;
using Tydbits.DressingUp.Policies;
using Tydbits.DressingUp.State;

namespace Tydbits.DressingUp.Tests.PolicyTests
{
    public abstract class CommonPolicyTest
    {
        private IPolicy _policy;
        private IState _state;

        [SetUp]
        public void SetUp()
        {
            _policy = CreatePolicy();
            _state = new State.State { Policy = _policy };
        }

        protected abstract IPolicy CreatePolicy();

        // Initial state is in your house with your pajamas on
        [Test]
        public void InitialState()
        {
            Assert.That(_state.IsOn(ClothingType.Pajamas));
            Assert.That(_state.Inside);
            Assert.That(_state.Leave(), Is.False);
        }

        // Pajamas must be taken off before anything else can be put on
        [Test]
        public void PajamasMustBeTakenOff()
        {
            foreach (var clothing in ClothingSet.All)
            {
                Assert.That(_state.PutOn(clothing), Is.False);
                if (clothing != ClothingType.Pajamas)
                    Assert.That(_state.IsOn(clothing), Is.False);
            }
        }

        protected void GetReadyToDress()
        {
            Assume.That(_state.TakeOffPJs());
            Assume.That(_state.IsOn(ClothingType.Pajamas), Is.False);
        }

        protected void AssertCannotPutOn(ClothingType clothing)
        {
            Assert.That(_state.PutOn(clothing), Is.False, "shouldn't put on " + clothing);
            Assert.That(_state.IsOn(clothing), Is.False, "shouldn't be on " + clothing);
        }

        protected virtual void AssertPutOn(ClothingType clothing)
        {
            Assume.That(_state.PutOn(clothing), "should put on " + clothing);
            Assume.That(_state.IsOn(clothing), "should be on " + clothing);

            // Only 1 piece of each type of clothing may be put on
            Assume.That(_state.PutOn(clothing), Is.False, "shouldn't put 2nd " + clothing);
        }

        protected void AssertCannotLeave(string without)
        {
            Assert.That(_state.Leave(), Is.False, "shouldn't leave without " + without);
        }

        protected void AssertLeave()
        {
            Assert.That(_state.Leave(), "should leave");
        }
    }
}