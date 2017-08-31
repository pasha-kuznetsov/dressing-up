using Tydbits.DressingUp.Clothing;

namespace Tydbits.DressingUp.State
{
    // Main business logic entry point.
    // Maintains the execution State.
    // Processes state transitions.
    public interface IState
    {
        // True if inside the house.
        bool Inside { get; }

        // True if the specified piece of clothing is on.
        bool IsOn(ClothingType clothing);

        // Put on the specified piece of clothing.
        // True if the state transition is accepted.
        bool PutOn(ClothingType clothing);

        // Take off PJs.
        // True if the state transition is accepted.
        bool TakeOffPJs();

        // Leave the house.
        // True if the state transition is accepted.
        bool Leave();
    }
}