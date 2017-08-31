using Tydbits.DressingUp.State;

namespace Tydbits.DressingUp.Rules
{
    public interface IRule
    {
        bool IsSatisfied(IState state);
    }
}