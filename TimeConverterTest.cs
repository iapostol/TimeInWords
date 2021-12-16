using Xunit;

namespace TimeInWords
{

    public class TimeConverterTest
    {
        [Theory]
        [InlineData("five o'clock", 5, 00)]
        [InlineData("one minute past five", 5, 01)]
        [InlineData("ten minutes past five", 5, 10)]
        [InlineData("quarter past five", 5, 15)]
        [InlineData("half past five", 5, 30)]
        [InlineData("twenty minutes to six", 5, 40)]
        [InlineData("quarter to six", 5, 45)]
        [InlineData("thirteen minutes to six", 5, 47)]
        [InlineData("twenty eight minutes past five", 5, 28)]
        [InlineData("twenty five minutes to six", 5, 35)]
        public void TimeInWordsForH_M(string word, int hours, int minutes)
        {
            Assert.Equal(word, TimeConverter.Convert(hours,minutes));
        }
    }
}