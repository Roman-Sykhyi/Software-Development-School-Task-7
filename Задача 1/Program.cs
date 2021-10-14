using System;
using System.Collections.Generic;

namespace Задача_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>()
            {
                { "I", "Boy" },
                { "go", "run" },
                { "to", "to"},
                { "school", "cinema"}
            };

            TranslatedText translatedText = new TranslatedText("I go to school. Girl runs to school", dictionary);
            Console.WriteLine(translatedText.value);
        }
    }
}
