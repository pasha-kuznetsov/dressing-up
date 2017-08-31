using System;
using Tydbits.DressingUp.Clothing;

namespace Tydbits.DressingUp.Responses
{
    // Common HOT/COLD command line responses for Interpreter.
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