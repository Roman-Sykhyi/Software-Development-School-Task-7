using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Задача_2
{
    public class IngredentsInfo
    {
        public Dictionary<string, float> Values { get; }

        public IngredentsInfo(string filePath)
        {
            Values = new Dictionary<string, float>();
            FillWeightsFromFile(filePath);
        }
        private void FillWeightsFromFile(string filePath)
        {
            #region Перевірки
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException("Шлях до файлу не може бути пустим.", nameof(filePath));
            }

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Файлу за вказаним шляхом не знайдено.", nameof(filePath));
            }

            if (string.Compare(new FileInfo(filePath).Extension, ".txt") != 0)
            {
                throw new ArgumentOutOfRangeException(nameof(filePath), "Доступно тільки розширення файлу .txt .");
            }
            #endregion

            using (StreamReader file = new StreamReader(filePath))
            {
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    string[] product = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    if (product.Length != 2)
                        continue;

                    string productName = product[0];

                    if (!float.TryParse(product[1], NumberStyles.Float, CultureInfo.InvariantCulture, out float productWeight))
                    {
                        throw new FormatException("Помилка читання ваги продукту з файлу. Неправильно заповнено файл.");
                    }

                    if (!Values.ContainsKey(productName))
                    {
                        Values.Add(productName, productWeight);
                    }
                    else
                    {
                        Values[productName] += productWeight;
                    }
                }
            }
        }
    }
}