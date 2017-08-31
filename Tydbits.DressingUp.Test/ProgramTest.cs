using NUnit.Framework;

namespace Tydbits.DressingUp.Tests
{
    [TestFixture]
    public class ProgramTest
    {
        [TestCase(
            "HOT 8, 6, 4, 2, 1, 7",
            "Removing PJs, shorts, t-shirt, sun visor, sandals, leaving house")]
        [TestCase(
            " COLD  8 , 6, 3 , 4, 2, 5, 1, 7 ",
            "Removing PJs, pants, socks, shirt, hat, jacket, boots, leaving house")]
        public void Spec_Success(string input, string expectedOutput)
        {
            Assert.That(Program.Process(input), Is.EqualTo(expectedOutput));
        }

        [TestCase(
            "HOT 8, 6, 6",
            "Removing PJs, shorts, fail")]
        [TestCase(
            "HOT 8, 6, 3",
            "Removing PJs, shorts, fail")]
        [TestCase(
            " COLD 8 , 6, 3 , 4, 2, 5, 7 ",
            "Removing PJs, pants, socks, shirt, hat, jacket, fail")]
        [TestCase(
            "COLD 6",
            "fail")]
        public void Spec_Failure(string input, string expectedOutput)
        {
            Assert.That(Program.Process(input), Is.EqualTo(expectedOutput));
        }

        [TestCase(
            "6",
            "fail")]
        [TestCase(
            "HOT8, 6, 6",
            "fail")]
        public void Other_Failure(string input, string expectedOutput)
        {
            Assert.That(Program.Process(input), Is.EqualTo(expectedOutput));
        }
    }
}
