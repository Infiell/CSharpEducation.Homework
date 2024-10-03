using System;
using System.IO;
using System.Linq;

namespace Homework3_UchetPersone
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (File.Exists(InitialBD()))
            {
                Console.WriteLine("Добро пожаловать в систему учета персоналом.\n" +
                    "Для продолжения выберете что бы вы хотели сделать: \n" +
                    "1. Добавить нового человека \n" +
                    "2. Изменить даннные о людях \n" +
                    "3. Удалить данные о людях \n" +
                    "4. Посмотреть данные о людях");
                switch (Console.ReadLine())
                {
                    case "1": AddPerson(); break;
                    case "2": EditPersone(); break;
                    case "3": DelPersone(); break;
                    case "4": ViewPerson(); break;
                    default: Console.WriteLine("Необходимо выбрать число от 1 до 4."); break;
                }
            }
            else
            {
                Console.WriteLine("Файл БД не найден.");
            }
        }

        static private void AddPerson ()
        {
            Console.WriteLine("Введите данные нового человека через запятую.\n" +
                "Пример: Алексей,Рашидовеч,23,Пенза");
            string newRecord = Console.ReadLine();
            try
            {
                File.AppendAllText(InitialBD(),newRecord + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }

        static private void DelPersone ()
        {
            try
            {
                string[] lines = File.ReadAllLines(InitialBD());
                Console.WriteLine("Введите запись вида (Имя,Фамилия,Возвраст,Город) для удаления");
                string nameToDelete = Console.ReadLine();

                var updatedLines = lines.Where(line => !line.StartsWith(nameToDelete)).ToArray();
                File.WriteAllLines(InitialBD(), updatedLines);
                Console.WriteLine("Запись удалена");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }

        static private void EditPersone ()
        {
            string[] lines = File.ReadAllLines(InitialBD());
            Console.WriteLine("Введите имя человека для изменения данных");
            string nameToChange = Console.ReadLine();
            Console.WriteLine("Введите фамилию человека для изменения данных");
            string secondNameToChange = Console.ReadLine();
            Console.WriteLine("Сколько лет хотите поставить человеку?");
            string ageToUpdate = Console.ReadLine();
            Console.WriteLine("Какой город хотите поставить человеку?");
            string cityToUpdate = Console.ReadLine();

            var updatedLines = lines.Select(line => {
                var parts = line.Split(',');
                string name = parts[0].Trim();
                string secondName = parts[1].Trim();
                if (name == nameToChange || secondName == secondNameToChange)
                {
                    return $"{name},{secondName},{ageToUpdate},{cityToUpdate}";
                }
                return line;
            }).ToArray();

            File.WriteAllLines(InitialBD(), updatedLines);
            Console.WriteLine($"Запись по {nameToChange} {secondNameToChange} обновлена.");
        }

        static private void ViewPerson()
        {
            Console.WriteLine(InitialBD());
            string[] lines = File.ReadAllLines(InitialBD());
            Console.WriteLine("Имя | Фамилия | Возвраст | Город");
            foreach (string line in lines)
            {
                string[] data = line.Split(new char[] { ',' });
                string name = data[0];
                string secondName = data[1];
                string age = data[2];
                string city = data[3];
                Console.WriteLine($"{name} | {secondName} | {age} | {city}");
            }
        }

        static private string InitialBD()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "base.txt");
            return filePath;
        }
    }
}
