using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Tydbits.DressingUp.Clothing
{
    public struct ClothingSet
    {
        public static ICollection<ClothingType> All =
            new ReadOnlyCollection<ClothingType>(EnumAll().ToList());
        
        public static ICollection<ClothingType> Street =
            new ReadOnlyCollection<ClothingType>(EnumAll().Where(IsNotPajamas).ToList());

        private static bool IsNotPajamas(ClothingType item)
        {
            return item != ClothingType.Pajamas;
        }

        private static IEnumerable<ClothingType> EnumAll()
        {
            return Enum.GetValues(typeof(ClothingType)).OfType<ClothingType>();
        }
    }
}