using System;
using System.Diagnostics;
using System.IO.Hashing;
using System.Text;
using Force.Crc32;
using Xunit;
using Xunit.Abstractions;

namespace Test
{
    [Collection("Crc32")]
    public class Crc32Test(ITestOutputHelper output)
    {
        private readonly ITestOutputHelper _output = output;
        [Fact]
        public void Crc32Algorithm_Should_Match_SystemIOHashingCrc32()
        {
            // Arrange
            string testData = "Hello, World!";
            byte[] bytes = Encoding.UTF8.GetBytes(testData);

            // Act
            var forceCrc32Stopwatch = Stopwatch.StartNew();
            uint forceCrc32Result = Crc32Algorithm.Compute(bytes);
            forceCrc32Stopwatch.Stop();

            var systemCrc32Stopwatch = Stopwatch.StartNew();
            uint systemCrc32Result = Crc32.HashToUInt32(bytes);
            systemCrc32Stopwatch.Stop();

            _output.WriteLine($"Force.Crc32 execution time: {forceCrc32Stopwatch.Elapsed.TotalMilliseconds:F4} ms");
            _output.WriteLine($"System.IO.Hashing.Crc32 execution time: {systemCrc32Stopwatch.Elapsed.TotalMilliseconds:F4} ms");

            // Assert
            Assert.Equal(forceCrc32Result, systemCrc32Result);
        }

        [Theory]
        [InlineData("")]
        [InlineData("a")]
        [InlineData("Hello, World!")]
        [InlineData("The quick brown fox jumps over the lazy dog")]
        [InlineData("Lorem ipsum dolor sit amet, consectetur adipiscing elit")]
        public void Crc32Algorithm_Should_Match_SystemIOHashingCrc32_WithVariousInputs(string input)
        {
            // Arrange
            byte[] bytes = Encoding.UTF8.GetBytes(input);

            // Act
            var forceCrc32Stopwatch = Stopwatch.StartNew();
            uint forceCrc32Result = Crc32Algorithm.Compute(bytes);
            forceCrc32Stopwatch.Stop();

            var systemCrc32Stopwatch = Stopwatch.StartNew();
            uint systemCrc32Result = Crc32.HashToUInt32(bytes);
            systemCrc32Stopwatch.Stop();

            _output.WriteLine($"Input: '{input}' | Force.Crc32: {forceCrc32Stopwatch.Elapsed.TotalMilliseconds:F4} ms | System.IO.Hashing.Crc32: {systemCrc32Stopwatch.Elapsed.TotalMilliseconds:F4} ms");

            // Assert
            Assert.Equal(forceCrc32Result, systemCrc32Result);
        }
    }
}
