using System.Collections.Generic;
using Tydbits.DressingUp.Clothing;
using Tydbits.DressingUp.Policies;

namespace Tydbits.DressingUp.State
{
    public class State : IState
    {
        private readonly ISet<ClothingType> _clothingOn;

        public State()
        {
            _clothingOn = new HashSet<ClothingType> { ClothingType.Pajamas };
            Inside = true;
        }

        public IPolicy Policy { get; set; }

        public bool Inside { get; private set; }

        public bool IsOn(ClothingType clothing)
        {
            return _clothingOn.Contains(clothing);
        }

        public bool PutOn(ClothingType clothing)
        {
            return CanPutOn(clothing) && _clothingOn.Add(clothing);
        }

        private bool CanPutOn(ClothingType clothing)
        {
            return Policy?.CanPutOn(this, clothing) ?? true;
        }

        public bool TakeOffPJs()
        {
            return _clothingOn.Remove(ClothingType.Pajamas);
        }

        public bool Leave()
        {
            if (!Inside || !CanLeave())
                return false;
            Inside = false;
            return true;
        }

        private bool CanLeave()
        {
            return Policy?.CanLeave(this) ?? true;
        }
    }
}