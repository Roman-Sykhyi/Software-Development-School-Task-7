using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Задача_2
{
    public class IngredientsPrices
    {
        public Dictionary<string, int> Values { get; }

        public IngredientsPrices(string filePath)
        {
            Values = new Dictionary<string, int>();
            FillPricesFromFile(filePath);
        }

        private void FillPricesFromFile(string filePath)
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
                    string[] productPrice = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    if (!int.TryParse(productPrice[1], out int price))
                    {
                        throw new FormatException("Помилка читання ціни продукту з файлу. Неправильно заповнено файл.");
                    }

                    Values.Add(productPrice[0], price);
                }
            }
        }
    }
}