using System;

namespace Задача_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string pricesFilePath = @"E:\Sigma Pract\Завдання 7\Задача 2\prices.txt";
            string menuFilePath = @"E:\Sigma Pract\Завдання 7\Задача 2\menu.txt";

            Menu menu = new Menu(menuFilePath, pricesFilePath);
            Console.WriteLine(menu.GetProductsInfo());
        }
    }
}
