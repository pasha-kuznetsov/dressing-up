using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Tydbits.DressingUp.Clothing;

namespace Tydbits.DressingUp.Tests.ClothingTests
{
    [TestFixture]
    public class ClothingSetTest
    {
        [DatapointSource]
        public IEnumerable<ClothingType> Data()
        {
            return Enum.GetValues(typeof(ClothingType)).Cast<ClothingType>();
        }

        [Theory]
        public void All_Contains_Everything(ClothingType clothing)
        {
            Assert.That(ClothingSet.All.Contains(clothing));
        }

        [Theory]
        public void Street_Contains_EverythingExceptPajamas(ClothingType clothing)
        {
            Assume.That(clothing, Is.Not.EqualTo(ClothingType.Pajamas));
            
            Assert.That(ClothingSet.Street.Contains(clothing));
        }

        [Theory]
        public void Street_DoesNot_Contain_Pajamas(ClothingType clothing)
        {
            Assume.That(clothing, Is.EqualTo(ClothingType.Pajamas));

            Assert.That(ClothingSet.Street.Contains(clothing), Is.False);
        }

        [Theory]
        public void All_Is_Immutable(ClothingType clothing)
        {
            Assert.Throws<NotSupportedException>(() => ClothingSet.All.Remove(clothing));
            Assert.That(ClothingSet.All.Contains(clothing));
        }

        [Theory]
        public void Street_Is_Immutable(ClothingType clothing)
        {
            if (ClothingSet.Street.Contains(clothing))
            {
                Assert.Throws<NotSupportedException>(() => ClothingSet.Street.Remove(clothing));
                Assert.That(ClothingSet.Street.Contains(clothing));
            }
            else
            {
                Assert.Throws<NotSupportedException>(() => ClothingSet.Street.Add(clothing));
                Assert.That(ClothingSet.Street.Contains(clothing), Is.False);
            }
        }
    }
}