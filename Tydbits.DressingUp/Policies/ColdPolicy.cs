using Tydbits.DressingUp.Clothing;

namespace Tydbits.DressingUp.Policies
{
    // COLD Policy specifics.
    public class ColdPolicy : CommonPolicy
    {
        public override bool IsApplicable(ClothingType clothing)
        {
            return true;
        }
    }
}