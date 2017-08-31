using Tydbits.DressingUp.State;

namespace Tydbits.DressingUp.Rules
{
    // Used by Policy to implement checks for whether state transitions are acceptable.
    public interface IRule
    {
        bool IsSatisfied(IState state);
    }
}