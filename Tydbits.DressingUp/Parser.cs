using System;
using System.Collections.Generic;

namespace Tydbits.DressingUp
{
    public class Parser
    {
        private readonly string _input;
        private int _inputPos;
        private bool _failure;

        public Parser(string input)
        {
            _input = input;
            _inputPos = 0;
        }

        public void Fail()
        {
            _failure = true;
        }

        public string ParseIdentifier()
        {
            return ExtractToken(char.IsLetterOrDigit);
        }

        public IEnumerable<string> ParseCommands()
        {
            do
                yield return ExtractToken(char.IsDigit);
            while (ExtractToken(char.IsPunctuation) == ",");
        }

        private string ExtractToken(Func<char, bool> charClass)
        {
            var start = Skip(char.IsWhiteSpace);
            var end = Skip(charClass);
            return _input.Substring(start, end - start);
        }

        private int Skip(Func<char, bool> charClass)
        {
            if (_failure)
                return _inputPos = _input.Length;
            while (_inputPos < _input.Length && charClass(_input[_inputPos]))
                ++_inputPos;
            return _inputPos;
        }
    }
}