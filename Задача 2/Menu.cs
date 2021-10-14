using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Задача_2
{
    public class Menu
    {
        Dictionary<string, float> products;
        Dictionary<string, int> prices;

        public Menu(string menuFilePath, string pricesFilePath)
        {
            products = new Dictionary<string, float>();
            prices = new Dictionary<string, int>();

            FillPricesFromFile(pricesFilePath);
            FillProductsFromFile(menuFilePath);
        }

        public string GetProductsInfo()
        {
            string result = "";

            foreach(var item in products)
            {
                result += $"{item.Key,-10}  {item.Value,-10} ";
                result += (prices[item.Key] * item.Value).ToString("0.0") + "\n";
            }

            return result;
        }

        private void FillPricesFromFile(string filePath)
        {
            StreamReader file = new StreamReader(filePath);
            string line;

            while((line = file.ReadLine()) != null)
            {
                string[] productPrice = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                prices.Add(productPrice[0], int.Parse(productPrice[1]));
            }
        }

        private void FillProductsFromFile(string productsFilePath)
        {
            StreamReader file = new StreamReader(productsFilePath);
            string line;

            while ((line = file.ReadLine()) != null)
            {
                string[] product = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (product.Length != 2)
                    continue;

                string productName = product[0];
                float productWeight = float.Parse(product[1], CultureInfo.InvariantCulture);

                if(!products.ContainsKey(productName))
                {
                    products.Add(productName, productWeight);
                }
                else
                {
                    products[productName] += productWeight;
                }
            }
        }
    }
}
