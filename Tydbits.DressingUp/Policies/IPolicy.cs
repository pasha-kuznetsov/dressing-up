using Tydbits.DressingUp.Clothing;
using Tydbits.DressingUp.State;

namespace Tydbits.DressingUp.Policies
{
    public interface IPolicy
    {
        bool IsApplicable(ClothingType clothing);
        bool CanPutOn(IState state, ClothingType clothing);
        bool CanLeave(IState state);
    }
}