using System;
using System.Collections.Generic;
using System.Text;

namespace Задача_1
{
    public class TranslatedText
    {
        public string value { get; private set; }

        private Dictionary<string, string> dictionary;
        private char[] delimiters = { ' ', ',', '.', ':', '\t' };

        public TranslatedText(string text, Dictionary<string, string> dictionary)
        {
            value = text;
            this.dictionary = dictionary;

            string[] words = value.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            FillDictionary(words);
            TranslateText(words);
        }

        private void TranslateText(string[] words)
        {
            foreach(string word in words)
            {
                value = value.Replace(word, dictionary.GetValueOrDefault(word));
            }
        }

        private void FillDictionary(string[] words)
        {
            foreach (string word in words)
            {
                if (!dictionary.ContainsKey(word))
                {
                    string translation = GetTranslation(word);
                    AddWordToDictionary(word, translation);
                }
            }
        }

        private void AddWordToDictionary(string word, string translation)
        {
            dictionary.Add(word, translation);
        }

        private string GetTranslation(string word)
        {
            Console.Write("Enter translation for " + word + ": ");
            return Console.ReadLine();
        }
    }
}
