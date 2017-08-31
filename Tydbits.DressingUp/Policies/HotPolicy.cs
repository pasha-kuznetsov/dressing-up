using Tydbits.DressingUp.Clothing;

namespace Tydbits.DressingUp.Policies
{
    // HOT Policy specifics.
    public class HotPolicy : CommonPolicy
    {
        public override bool IsApplicable(ClothingType clothing)
        {
            return clothing != ClothingType.Socks &&
                   clothing != ClothingType.Jacket;
        }
    }
}
