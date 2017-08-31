using Tydbits.DressingUp.Clothing;

namespace Tydbits.DressingUp.State
{
    public interface IState
    {
        bool Inside { get; }
        bool IsOn(ClothingType clothing);
        bool PutOn(ClothingType clothing);
        bool TakeOffPJs();
        bool Leave();
    }
}