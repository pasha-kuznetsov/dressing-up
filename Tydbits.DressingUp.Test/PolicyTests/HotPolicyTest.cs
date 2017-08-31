using NUnit.Framework;
using Tydbits.DressingUp.Clothing;
using Tydbits.DressingUp.Policies;

namespace Tydbits.DressingUp.Tests.PolicyTests
{
    [TestFixture]
    public class HotPolicyTest : CommonPolicyTest
    {
        protected override IPolicy CreatePolicy()
        {
            return new HotPolicy();
        }

        // Pants must be put on before shoes
        [Test]
        public void PantsBeforeShoes()
        {
            GetReadyToDress();
            AssertCannotPutOn(ClothingType.Footwear);
            AssertPutOn(ClothingType.Pants);
            AssertPutOn(ClothingType.Footwear);
        }

        // The shirt must be put on before the headwear (or jacket)
        [Test]
        public void ShirtBeforeHeadwear()
        {
            GetReadyToDress();
            AssertCannotPutOn(ClothingType.Headwear);
            AssertPutOn(ClothingType.Shirt);
            AssertPutOn(ClothingType.Headwear);
        }

        // You cannot leave the house until all items of clothing are on
        [Test]
        public void CannotLeaveUndressed()
        {
            AssertCannotLeave("taking off pajamas");
            GetReadyToDress();
            AssertCannotLeave("pants");
            AssertPutOn(ClothingType.Pants);
            AssertCannotLeave("shoes");
            AssertPutOn(ClothingType.Footwear);
            AssertCannotLeave("shirt");
            AssertPutOn(ClothingType.Shirt);
            AssertCannotLeave("hat");
            AssertPutOn(ClothingType.Headwear);
            AssertLeave();
        }

        protected override void AssertPutOn(ClothingType clothing)
        {
            base.AssertPutOn(clothing);

            // You cannot put on socks when it is hot
            AssertCannotPutOn(ClothingType.Socks);

            // You cannot put on a jacket when it is hot
            AssertCannotPutOn(ClothingType.Jacket);
        }

    }
}