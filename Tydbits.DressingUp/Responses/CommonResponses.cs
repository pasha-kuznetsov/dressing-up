using System;
using Tydbits.DressingUp.Clothing;

namespace Tydbits.DressingUp.Responses
{
    public abstract class CommonResponses : IResponses
    {
        public string TakeOffPJs()
        {
            return "Removing PJs";
        }

        public abstract string PutOn(ClothingType clothing);

        public string Leave()
        {
            return "leaving house";
        }
    }
}