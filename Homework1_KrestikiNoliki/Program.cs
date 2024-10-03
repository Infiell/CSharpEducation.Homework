using System;
using System.Linq;

namespace Homework1_KrestikiNoliki
{
    class Program
    {
        static int[] krestOrNolik;
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в крестики и нолики.");
            Console.WriteLine("Игра начинается с нолика.");
            Console.ReadKey();
        }
        static private void Render(char symb, int place)
        {
            krestOrNolik[place] = symb;
            Console.WriteLine($"1 {krestOrNolik[0]} | {krestOrNolik[1]} | {krestOrNolik[2]}\n" +
                              $" ----------\n" +
                              $"2 {krestOrNolik[3]} | {krestOrNolik[4]} | {krestOrNolik[5]}\n" +
                              $" ----------\n" +
                              $"3 {krestOrNolik[6]} | {krestOrNolik[7]} | {krestOrNolik[8]}\n" +
                              $"  1   2   3   ");
        }

        static private void Place()
        {
            string symb = "O";
            int a = 0;
            while (a != 9)
            {
                Console.WriteLine($"Введите куда поставить {symb}");
                a++;
            }
        }
    }
}
