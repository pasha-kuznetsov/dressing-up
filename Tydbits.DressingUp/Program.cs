using System;

namespace Tydbits.DressingUp
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var input = string.Join(" ", args);
            var output = Process(input);
            Console.WriteLine(output);
        }

        public static string Process(string input)
        {
            var parser = new Parser(input);
            var output = new Interpreter(parser).Process();
            return string.Join(", ", output);
        }
    }
}
