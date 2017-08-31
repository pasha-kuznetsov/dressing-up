using System;
using Tydbits.DressingUp.Clothing;

namespace Tydbits.DressingUp.Responses
{
    // HOT command line responses for Interpreter.
    public class HotResponses : CommonResponses
    {
        public override string PutOn(ClothingType clothing)
        {
            switch (clothing)
            {
                case ClothingType.Pajamas:
                case ClothingType.Socks:
                case ClothingType.Jacket: throw new InvalidOperationException();
                case ClothingType.Footwear: return "sandals";
                case ClothingType.Headwear: return "sun visor";
                case ClothingType.Shirt: return "t-shirt";
                case ClothingType.Pants: return "shorts";
                default: throw new ArgumentOutOfRangeException(nameof(clothing), clothing, null);
            }
        }
    }
}