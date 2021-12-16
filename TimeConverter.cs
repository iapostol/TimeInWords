using System.Collections.Generic;

namespace TimeInWords
{
    public class TimeConverter
    {
        private static readonly Dictionary<int, string> numbersToLetters = new Dictionary<int, string>
        {
            {1,"one"},
            {2,"two"},
            {3,"three"},
            {4,"four"},
            {5,"five"},
            {6,"six"},
            {7,"seven"},
            {8,"eight"},
            {9,"nine"},
            {10,"ten"},
            {11,"eleven"},
            {12,"twelve"},
            {13,"thirteen"},
            {14,"fourteen"},
            {15,"quarter"},
            {16,"sixteen"},
            {17,"seventeen"},
            {18,"eighteen"},
            {19,"nineteen"},
            {20,"twenty"},
            {30,"half"}
        };
        public static string Convert(int hour, int minutes)
        {
            if (minutes == 0)
                return $"{numbersToLetters[hour]} o'clock";

            var preposition = "";
            
            if (minutes > 30)
            {
                preposition = "to";
                
                minutes = 60 - minutes;
                hour++;
            }
            else
            {
                preposition = "past";
            }

            return $"{GetMinutesInWords(minutes)} {preposition} {numbersToLetters[hour]}";
        }

        private static string GetMinutesInWords(int minutes)
        {
            var minutesInWords = "";
            
            if (!numbersToLetters.ContainsKey(minutes))
                minutesInWords = TensWordFor(minutes);
            else
                minutesInWords = numbersToLetters[minutes];
            
            var text = minutes == 15 || minutes == 30 ? "" : $" minute{(minutes > 1 ? "s" : "")}";
            
            return $"{minutesInWords}{text}";
        }
        
        private static string TensWordFor(int number)
        {
            var remainder = number % 10;
            var decade = number - remainder;

            return remainder > 0 ? $"{numbersToLetters[decade]} {numbersToLetters[remainder]}" : numbersToLetters[decade];
        }
    }
}