using Tydbits.DressingUp.Clothing;
using Tydbits.DressingUp.State;

namespace Tydbits.DressingUp.Rules
{
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