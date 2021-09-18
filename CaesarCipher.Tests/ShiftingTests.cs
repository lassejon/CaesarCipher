using System;
using FluentAssertions;
using Xunit;


namespace CaesarCipher.Tests
{
    public class ShiftingTests
    {
        [Theory] 
        [InlineData('a', 0, 'a')]
        [InlineData('a', -26, 'a')]
        [InlineData('a', 26, 'a')]
        [InlineData('a', -1, 'z')]
        [InlineData('a', -27, 'z')]
        [InlineData('a', 25, 'z')]
        [InlineData('a', 27, 'b')]
        [InlineData('a', -25, 'b')]
        [InlineData('a', 1, 'b')]
        [InlineData('L', 21, 'G')]
        public void RotateSingleChar(char character, int shifkey, char expected)
        {
            // Arrange
            var sut = new RotationalCipher();
            
            // Act
            var result = sut.EncryptChar(character, shifkey);
            
            // Assert
            result.Should().Be(expected);
        }
        
        [Theory] 
        [InlineData("BBP", 5, "GGU")]
        [InlineData("BBP", -16, "LLZ")]
        public void RotateCapitalLetters(string text, int shiftKey, string expected)
        {
            // Arange
            var sut = new RotationalCipher();
            
            // Act
            var result = sut.EncryptText(text, shiftKey);
            
            // Assert
            result.Should().Be(expected);

        }
        
        [Theory] 
        [InlineData("O M G", 5, "T R L")]
        public void RotateSpaces(string text, int shiftKey, string expected)
        {
            // Arange
            var sut = new RotationalCipher();
            
            // Act
            var result = sut.EncryptText(text, shiftKey);
            
            // Assert
            result.Should().Be(expected);
        }
        
        [Theory]
        [InlineData("Let's eat, Grandma!", 21, "Gzo'n zvo, Bmviyhv!")]
        public void RotatePunctuation(string text, int shiftKey, string expected)
        {
            // Arange
            var sut = new RotationalCipher();
            
            // Act
            var result = sut.EncryptText(text, shiftKey);
            
            // Assert
            result.Should().Be(expected);
        }
        
        [Theory]
        [InlineData("The quick brown fox jumps over the lazy dog.", 13, "Gur dhvpx oebja sbk whzcf bire gur ynml qbt.")]
        public void RotateAllLetters(string text, int shiftKey, string expected)
        {
            // Arange
            var sut = new RotationalCipher();
            
            // Act
            var result = sut.EncryptText(text, shiftKey);
            
            // Assert
            result.Should().Be(expected);
        }
        
        [Theory]
        [InlineData("Testing 1 2 3 testing", 4, "Xiwxmrk 1 2 3 xiwxmrk")]
        public void RotateNumbers(string text, int shiftKey, string expected)
        {
            // Arange
            var sut = new RotationalCipher();
            
            // Act
            var result = sut.EncryptText(text, shiftKey);
            
            // Assert
            result.Should().Be(expected);
        }
    }
}