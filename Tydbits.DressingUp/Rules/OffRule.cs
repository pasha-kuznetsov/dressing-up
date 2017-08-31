using Tydbits.DressingUp.Clothing;
using Tydbits.DressingUp.State;

namespace Tydbits.DressingUp.Rules
{
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