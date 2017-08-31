using Tydbits.DressingUp.Clothing;
using Tydbits.DressingUp.State;

namespace Tydbits.DressingUp.Rules
{
    // Allows PutOn transitions if State is NOT "wearing" the Clothing items.
    // E.g. if Clothinig is Footwear, then the transition is only allowed
    // if Footwear is not currently "On".
    public class OffRule : IRule
    {
        public OffRule(ClothingType clothing)
        {
            Clothing = clothing;
        }

        public ClothingType Clothing { get; }

        public bool IsSatisfied(IState state)
        {
            return !state.IsOn(Clothing);
        }
    }
}