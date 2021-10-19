using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Задача_2
{
    public class Menu
    {
        IngredentsInfo dishes;
        IngredientsPrices prices;

        public Menu(string menuFilePath, string pricesFilePath)
        {
            dishes = new IngredentsInfo(menuFilePath);
            prices = new IngredientsPrices(pricesFilePath);
        }

        public string GetProductsInfo()
        {
            string result = "";

            foreach(var item in dishes.Values)
            {
                result += $"{item.Key,-10}  {item.Value,-10} ";
                result += (prices.Values[item.Key] * item.Value).ToString("0.0") + "\n";
            }

            return result;
        }
    }
}