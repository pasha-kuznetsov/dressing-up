using System.Collections.Generic;
using Tydbits.DressingUp.Clothing;
using Tydbits.DressingUp.Policies;
using Tydbits.DressingUp.Responses;
using Tydbits.DressingUp.State;

namespace Tydbits.DressingUp
{
    // Processes command line input, applying commands to State.
    // Delegates parsing of the command line "language" to Parser.
    // Uses Responses for producing HOT/COLD command line output.
    public class Interpreter
    {
        private readonly Parser _parser;
        private IState _state;
        private IResponses _responses;

        public Interpreter(Parser parser)
        {
            _parser = parser;
        }

        public string Fail()
        {
            _parser.Fail();
            return "fail";
        }

        public IEnumerable<string> Process()
        {
            return ProcessPolicy();
        }

        private IEnumerable<string> ProcessPolicy()
        {
            switch (_parser.ParseIdentifier())
            {
                case "HOT": return ProcessHot();
                case "COLD": return ProcessCold();
                default: return new[] { Fail() };
            }
        }

        private IEnumerable<string> ProcessHot()
        {
            _state = new State.State { Policy = new HotPolicy() };
            _responses = new HotResponses();
            return ProcessCommands();
        }

        private IEnumerable<string> ProcessCold()
        {
            _state = new State.State { Policy = new ColdPolicy() };
            _responses = new ColdResponses();
            return ProcessCommands();
        }

        private IEnumerable<string> ProcessCommands()
        {
            foreach (var command in _parser.ParseCommands())
            {
                switch (command)
                {
                    case "1": yield return PutOn(ClothingType.Footwear); break;
                    case "2": yield return PutOn(ClothingType.Headwear); break;
                    case "3": yield return PutOn(ClothingType.Socks); break;
                    case "4": yield return PutOn(ClothingType.Shirt); break;
                    case "5": yield return PutOn(ClothingType.Jacket); break;
                    case "6": yield return PutOn(ClothingType.Pants); break;
                    case "7": yield return Leave(); break;
                    case "8": yield return TakeOffPJs(); break;
                    default: yield return Fail(); break;
                }
            }
        }

        private string PutOn(ClothingType clothing)
        {
            return _state.PutOn(clothing) ? _responses.PutOn(clothing) : Fail();
        }

        private string Leave()
        {
            return _state.Leave() ? _responses.Leave() : Fail();
        }

        private string TakeOffPJs()
        {
            return _state.TakeOffPJs() ? _responses.TakeOffPJs() : Fail();
        }
    }
}