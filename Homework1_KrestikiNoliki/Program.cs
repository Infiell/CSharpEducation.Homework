using System;

namespace Homework1_KrestikiNoliki
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в крестики и нолики.");
            Console.WriteLine("Каждый ход нужно выбирать в какое место поставить крестик либо нолик.");
            Question();
            Console.ReadKey();
        }
        static private void Render(char krestNol, Int32 kres)
        {
            char[] kest = new char[32];
            kest[kres] = krestNol;
            Console.WriteLine($"1 {kest[1]} | {kest[2]} | {kest[3]}\n" +
                              $" ----------\n" +
                              $"2 {kest[4]} | {kest[5]} | {kest[6]}\n" +
                              $" ----------\n" +
                              $"3 {kest[7]} | {kest[8]} | {kest[9]}\n" +
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
            char symbol;
            char[] krestNol = new char[32];
            Int32 coordinat;
            if (answ == 1)
                symbol = 'O';
            else symbol = 'X';
            short stage = 1;
            while (stage !=9) {
                Console.WriteLine($"Введите координаты куда поставить {symbol}.");
                coordinat = Convert.ToInt32(Console.ReadLine());
                krestNol[coordinat] = symbol;
                Render(krestNol[coordinat], coordinat);
                stage++;
            }
        }
    }
}
