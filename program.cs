using System;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace Lab2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                Console.InputEncoding = System.Text.Encoding.UTF8;
                Console.OutputEncoding = System.Text.Encoding.UTF8;
            }
            catch { }

            Task1_3_Names();
            Task2_2_HumanWithName();
            Task2_3_HumanWithParent();
            Task3_3_Cities();
            Task4_5_CreateNames();
            Task4_6_CreateHuman();
            Task5_2_Cat();

            Console.ReadKey();
        }

        private static void Task1_3_Names()
        {
            Console.WriteLine("Задание 1.3. Имена");
            string name1 = Validator.ReadString("Введите имя (например, Клеопатра): ");
            Name n1 = new Name(name1);

            Console.WriteLine("Введите данные второго имени:");
            string f2 = Validator.ReadString("Введите имя (Александр): ");
            string s2 = Validator.ReadString("Введите фамилию (Пушкин): ");
            string p2 = Validator.ReadString("Введите отчество (Сергеевич): ");
            Name n2 = new Name(f2, s2, p2);

            Console.WriteLine("Введите данные третьего имени:");
            string f3 = Validator.ReadString("Введите имя (Владимир): ");
            string s3 = Validator.ReadString("Введите фамилию (Маяковский): ");
            Name n3 = new Name(f3, s3);

            Console.WriteLine($"\n1. {n1}");
            Console.WriteLine($"2. {n2}");
            Console.WriteLine($"3. {n3}\n");
        }

        private static void Task2_2_HumanWithName()
        {
            Console.WriteLine("Задание 2.2. Человек с именем");
            string f = Validator.ReadString("Введите имя человека: ");
            string s = Validator.ReadString("Введите фамилию: ");
            string p = Validator.ReadString("Введите отчество: ");
            int h = Validator.ReadInt("Введите рост (в см): ");

            Name name = new Name(f, s, p);
            Human human = new Human(name, h);

            Console.WriteLine($"\nСоздан человек: {human}\n");
        }

        private static void Task2_3_HumanWithParent()
        {
            Console.WriteLine("Задание 2.3. Человек с родителем");
            Console.WriteLine("Создаем отца:");
            string f1 = Validator.ReadString("Имя: ");
            string s1 = Validator.ReadString("Фамилия: ");
            int h1 = Validator.ReadInt("Рост: ");
            Human ivan = new Human(new Name(f1, s1), h1);

            Console.WriteLine("\nСоздаем сына (фамилия и отчество наследуются):");
            string f2 = Validator.ReadString("Имя: ");
            int h2 = Validator.ReadInt("Рост: ");
            Human petr = new Human(new Name(f2), h2, ivan);

            Console.WriteLine("\nСоздаем внука (фамилия и отчество наследуются):");
            string f3 = Validator.ReadString("Имя: ");
            int h3 = Validator.ReadInt("Рост: ");
            Human boris = new Human(new Name(f3), h3, petr);

            Console.WriteLine($"\nОтец: {ivan}");
            Console.WriteLine($"Сын: {petr}");
            Console.WriteLine($"Внук: {boris}\n");
        }

        private static void Task3_3_Cities()
        {
            Console.WriteLine("Задание 3.3. Города");
            City a = new City("A");
            City b = new City("B");
            City c = new City("C");
            City d = new City("D");
            City e = new City("E");
            City f = new City("F");

            // Твои исправленные связи по стрелочкам
            a.Paths = new Path[] { new Path(b, 5), new Path(d, 6), new Path(f, 1) };
            b.Paths = new Path[] { new Path(a, 5), new Path(c, 3) };
            c.Paths = new Path[] { new Path(b, 3), new Path(d, 4) };
            d.Paths = new Path[] { new Path(c, 4), new Path(a, 6), new Path(e, 2) };
            e.Paths = new Path[] { new Path(f, 2) };
            f.Paths = new Path[] { new Path(b, 1) };

            Console.WriteLine("\nСхема маршрутов:");
            Console.WriteLine(a); Console.WriteLine(b); Console.WriteLine(c);
            Console.WriteLine(d); Console.WriteLine(e); Console.WriteLine(f);
            Console.WriteLine();
        }

        private static void Task4_5_CreateNames()
        {
            Console.WriteLine("Задание 4.5. Создаем Имена");
            string n1 = Validator.ReadString("Введите имя (Клеопатра): ");
            Name name1 = new Name(n1);

            Console.WriteLine("Введите данные второго имени:");
            string f2 = Validator.ReadString("Введите имя (Александр): ");
            string s2 = Validator.ReadString("Введите фамилию (Пушкин): ");
            string p2 = Validator.ReadString("Введите отчество (Сергеевич): ");
            Name name2 = new Name(f2, s2, p2);

            Console.WriteLine("Введите данные третьего имени:");
            string f3 = Validator.ReadString("Введите имя (Владимир): ");
            string s3 = Validator.ReadString("Введите фамилию (Маяковский): ");
            Name name3 = new Name(f3, s3);

            Console.WriteLine("Введите данные четвертого имени:");
            string f4 = Validator.ReadString("Введите имя (Христофор): ");
            string s4 = Validator.ReadString("Введите фамилию (Бонифатьевич): ");
            Name name4 = new Name(f4, s4);

            Console.WriteLine($"\n1. {name1}");
            Console.WriteLine($"2. {name2}");
            Console.WriteLine($"3. {name3}");
            Console.WriteLine($"4. {name4}\n");
        }

        private static void Task4_6_CreateHuman()
        {
            Console.WriteLine("Задание 4.6. Создаем Человека");
            Console.WriteLine("Создаем Льва (только имя и рост):");
            string n1 = Validator.ReadString("Имя (Лев): ");
            int h1 = Validator.ReadInt("Рост (170): ");
            Human lev = new Human(n1, h1);

            Console.WriteLine("\nСоздаем Сергея (Имя, рост и отец):");
            string f2 = Validator.ReadString("Имя (Сергей): ");
            string s2 = Validator.ReadString("Фамилия (Пушкин): ");
            int h2 = Validator.ReadInt("Рост (168): ");
            Human sergey = new Human(new Name(f2, s2), h2, lev);

            Console.WriteLine("\nСоздаем Александра (Имя строкой, рост и отец):");
            string n3 = Validator.ReadString("Имя (Александр): ");
            int h3 = Validator.ReadInt("Рост (167): ");
            Human alexander = new Human(n3, h3, sergey);

            Console.WriteLine($"\nЛев: {lev}");
            Console.WriteLine($"Сергей: {sergey}");
            Console.WriteLine($"Александр: {alexander}\n");
        }

        private static void Task5_2_Cat()
        {
            Console.WriteLine("Задание 5.2. Кот мяукает");
            string name = Validator.ReadString("Введите имя кота (Барсик): ");
            Cat cat = new Cat(name);

            Console.WriteLine($"\nВы завели: {cat}");
            cat.Meow();
            int n = Validator.ReadInt("Сколько раз мяукнуть (3): ");
            cat.Meow(n);
            Console.WriteLine();
        }
    }

    internal static class Validator
    {
        public static string ReadString(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string s = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(s)) return s.Trim();
                Console.WriteLine("Ошибка! Строка не может быть пустой.");
            }
        }

        public static int ReadInt(string prompt)
        {
            int x;
            while (true)
            {
                Console.Write(prompt);
                string s = Console.ReadLine();
                if (int.TryParse(s, out x)) return x;
                Console.WriteLine("Ошибка! Введите целое число.");
            }
        }
    }
}
