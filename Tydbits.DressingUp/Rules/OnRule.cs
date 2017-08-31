using Tydbits.DressingUp.Clothing;
using Tydbits.DressingUp.State;

namespace Tydbits.DressingUp.Rules
{
    // Allows PutOn transitions if State IS "wearing" the Clothing items.
    // E.g. if Clothinig is Footwear, then the transition is only allowed
    // if Footwear is currently "On".
    public class OnRule : IRule
    {
        public OnRule(ClothingType clothing)
        {
            Clothing = clothing;
        }

        public ClothingType Clothing { get; }
   
        public bool IsSatisfied(IState state)
        {
            return state.IsOn(Clothing);
        }
    }
}