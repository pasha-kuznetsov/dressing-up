using System;
using Tydbits.DressingUp.Clothing;

namespace Tydbits.DressingUp.Responses
{
    // COLD command line responses for Interpreter.
    public class ColdResponses : CommonResponses
    {
        public override string PutOn(ClothingType clothing)
        {
            switch (clothing)
            {
                case ClothingType.Pajamas: throw new InvalidOperationException();
                case ClothingType.Footwear: return "boots";
                case ClothingType.Headwear: return "hat";
                case ClothingType.Socks: return "socks";
                case ClothingType.Shirt: return "shirt";
                case ClothingType.Jacket: return "jacket";
                case ClothingType.Pants: return "pants";
                default: throw new ArgumentOutOfRangeException(nameof(clothing), clothing, null);
            }
        }
    }
}