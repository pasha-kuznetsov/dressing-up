using Tydbits.DressingUp.Clothing;

namespace Tydbits.DressingUp.Policies
{
    public class HotPolicy : CommonPolicy
    {
        public override bool IsApplicable(ClothingType clothing)
        {
            return clothing != ClothingType.Socks &&
                   clothing != ClothingType.Jacket;
        }
    }
}
