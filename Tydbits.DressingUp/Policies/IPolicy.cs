using Tydbits.DressingUp.Clothing;
using Tydbits.DressingUp.State;

namespace Tydbits.DressingUp.Policies
{
    // Provides HOT/COLD policy decisions for State transitions.
    public interface IPolicy
    {
        // True if the specified piece of clothing can be worn according to the current policy.
        // E.g. HOT Policy would return false for Socks here.
        bool IsApplicable(ClothingType clothing);

        // True if State is allowed to PutOn this piece of clothing.
        bool CanPutOn(IState state, ClothingType clothing);

        // True if State is allowed to Leave the house.
        bool CanLeave(IState state);
    }
}