using System;
using System.Collections.Generic;

namespace BaconsCipherDecoder
{
    static class Program
    {
        static Dictionary<string, string> letters = new Dictionary<string, string>()
        {
            {"AAAAA", "A"}, {"AAAAB", "B"}, {"AAABA", "C"}, {"AAABB", "D"}, {"AABAA", "E"}, {"AABAB", "F"}, {"AABBA", "G"}, {"AABBB", "H"}, {"ABAAA", "(I/J)"}, {"ABAAB", "K"}, {"ABABA", "L"}, {"ABABB", "M"}, {"ABBAA", "N"}, {"ABBAB", "O"}, {"ABBBA", "P"}, {"ABBBB", "Q"}, {"BAAAA", "R"}, {"BAAAB", "S"}, {"BAABA", "T"}, {"BAABB", "(U/V)"}, {"BABAA", "W"}, {"BABAB", "X"}, {"BABBA", "Y"}, {"BABBB", "Z"}
        };
        
        static void Main(string[] args)
        {
            
            while (true)
            {
                Console.WriteLine("\nEnter the text you want to decode:");
                
                string cipheredText = Console.ReadLine();

                while (cipheredText.Length % 5 != 0 || String.IsNullOrEmpty(cipheredText))
                {
                    Console.WriteLine("\nRemove any extra characters and make sure the input is not empty. Enter the text you want to decode:");
                
                    cipheredText = Console.ReadLine();
                }

                var cipheredLetters = cipheredText.SplitIntoLetters();

                Console.WriteLine("Translation: " + cipheredLetters.DecipherLetters());
            }
        }

        private static List<string> SplitIntoLetters(this string text)
        {
            List<string> seperatedText = new List<string>();

            for (int i = 0; i < text.Length; i += 5)
            {
                seperatedText.Add(text.Substring(i, 5));
            }

            return seperatedText;
        }

        private static string DecipherLetters(this List<string> cipheredLetters)
        {
            string decipheredText = "";
            
            foreach (var cipheredLetter in cipheredLetters)
            {
                if (letters.ContainsKey(cipheredLetter))
                    decipheredText += letters[cipheredLetter];
                else
                {
                    throw new Exception("The encrypted message entered is not in the Bacon's Cipher format.");
                }
            }
            
            return decipheredText;
        }
    }
}
