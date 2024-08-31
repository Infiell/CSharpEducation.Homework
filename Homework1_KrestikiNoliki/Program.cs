using System;
using System.Linq;

namespace Homework1_KrestikiNoliki
{
    class Program
    {
        static int[] krestOrNolik = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в крестики и нолики.");
            Console.WriteLine("Каждый ход нужно выбирать в какое место поставить крестик либо нолик.");
            Question();
            Console.ReadKey();
        }
        static private void Render(char krestNol, int kres)
        {
            krestOrNolik[kres] = krestNol;
            Console.WriteLine($"1 {krestOrNolik[1]} | {krestOrNolik[2]} | {krestOrNolik[3]}\n" +
                              $" ----------\n" +
                              $"2 {krestOrNolik[4]} | {krestOrNolik[5]} | {krestOrNolik[6]}\n" +
                              $" ----------\n" +
                              $"3 {krestOrNolik[7]} | {krestOrNolik[8]} | {krestOrNolik[9]}\n" +
                              $"  1   2   3   ");
        }
        static private void Question()
        {
            short answ;
            Console.WriteLine("С крестика или нолика начнем ход? 0 - Крестик, 1 - Нолик");
            answ = Convert.ToInt16(Console.ReadLine());
            Change(answ);
        }
         
        static private void Change(short answ)
        {
            int j = 0;
            string whatIsTurn = "нолик";
            char krestNol = 'O';
            for (int i = 0; i < krestOrNolik.Count(); i++) { krestOrNolik[i] = ' '; }
            while (j != 9)
            {
                Console.WriteLine($"Введите куда поставить {whatIsTurn}");
                int kres = Convert.ToInt32(Console.ReadLine());
                Render(krestNol, kres);
                j++;
            }
        }
    }
}
