using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tydbits.DressingUp.Clothing;

namespace Tydbits.DressingUp.Responses
{
    // Implemntations provide HOT/COLD command line responses to Interpreter.
    public interface IResponses
    {
        string TakeOffPJs();
        string PutOn(ClothingType clothing);
        string Leave();
    }
}
