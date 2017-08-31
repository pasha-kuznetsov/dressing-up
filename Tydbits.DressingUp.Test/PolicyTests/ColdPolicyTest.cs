using NUnit.Framework;
using Tydbits.DressingUp.Clothing;
using Tydbits.DressingUp.Policies;

namespace Tydbits.DressingUp.Tests.PolicyTests
{
    [TestFixture]
    public class ColdPolicyTest : CommonPolicyTest
    {
        protected override IPolicy CreatePolicy()
        {
            return new ColdPolicy();
        }

        // Socks must be put on before shoes
        // Pants must be put on before shoes
        [TestCase(ClothingType.Socks, ClothingType.Pants)]
        [TestCase(ClothingType.Pants, ClothingType.Socks)]
        public void SocksAndPantsBeforeShoes(ClothingType socksOrPants, ClothingType pantsOrSocks)
        {
            GetReadyToDress();
            AssertCannotPutOn(ClothingType.Footwear);
            AssertPutOn(socksOrPants);
            AssertPutOn(pantsOrSocks);
            AssertPutOn(ClothingType.Footwear);
        }

        // The shirt must be put on before the headwear or jacket
        [TestCase(ClothingType.Headwear)]
        [TestCase(ClothingType.Jacket)]
        public void ShirtBeforeHeadwear(ClothingType headwearOrJacket)
        {
            GetReadyToDress();
            AssertCannotPutOn(headwearOrJacket);
            AssertPutOn(ClothingType.Shirt);
            AssertPutOn(headwearOrJacket);
        }

        // You cannot leave the house until all items of clothing are on
        [Test]
        public void CannotLeaveUndressed()
        {
            AssertCannotLeave("taking off pajamas");
            GetReadyToDress();
            AssertCannotLeave("shirt");
            AssertPutOn(ClothingType.Shirt);
            AssertCannotLeave("hat");
            AssertPutOn(ClothingType.Headwear);
            AssertCannotLeave("jacket");
            AssertPutOn(ClothingType.Jacket);
            AssertCannotLeave("socks");
            AssertPutOn(ClothingType.Socks);
            AssertCannotLeave("pants");
            AssertPutOn(ClothingType.Pants);
            AssertCannotLeave("shoes");
            AssertPutOn(ClothingType.Footwear);
            AssertLeave();
        }
    }
}