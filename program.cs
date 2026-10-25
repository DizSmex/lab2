using System;

internal class Program
{
    private static void Main(string[] args)
    {
        // Настраиваем кодировку для корректного ввода и вывода русских букв
        try
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
        }
        catch
        {
            // Если среда не поддерживает UTF-8, оставляем стандартную кодировку
        }

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
        Console.WriteLine("--- ЗАДАНИЕ 1.3. Имена ---");

        string name1 = Validator.ReadString("Введите имя (например, Клеопатра): ");
        Name n1 = new Name(name1);

        string f2 = Validator.ReadString("Введите имя (Александр): ");
        string s2 = Validator.ReadString("Введите фамилию (Пушкин): ");
        string p2 = Validator.ReadString("Введите отчество (Сергеевич): ");
        Name n2 = new Name(f2, s2, p2);

        string f3 = Validator.ReadString("Введите имя (Владимир): ");
        string s3 = Validator.ReadString("Введите фамилию (Маяковский): ");
        Name n3 = new Name(f3, s3);

        Console.WriteLine("Результат:");
        Console.WriteLine(n1);
        Console.WriteLine(n2);
        Console.WriteLine(n3);
        Console.WriteLine();
    }

    private static void Task2_2_HumanWithName()
    {
        Console.WriteLine("--- ЗАДАНИЕ 2.2. Человек с именем ---");

        string f = Validator.ReadString("Введите имя человека: ");
        string s = Validator.ReadString("Введите фамилию: ");
        string p = Validator.ReadString("Введите отчество: ");
        int h = Validator.ReadInt("Введите рост: ");

        Name name = new Name(f, s, p);
        Human human = new Human(name, h);

        Console.WriteLine("Результат: " + human);
        Console.WriteLine();
    }

    private static void Task2_3_HumanWithParent()
    {
        Console.WriteLine("--- ЗАДАНИЕ 2.3. Человек с родителем ---");

        Console.WriteLine("Создаем отца:");
        string f1 = Validator.ReadString("Введите имя отца: ");
        string s1 = Validator.ReadString("Введите фамилию отца: ");
        int h1 = Validator.ReadInt("Введите рост отца: ");
        Human ivan = new Human(new Name(f1, s1), h1);

        Console.WriteLine("Создаем сына (отчество и фамилия возьмутся от отца):");
        string f2 = Validator.ReadString("Введите имя сына: ");
        int h2 = Validator.ReadInt("Введите рост сына: ");
        Human petr = new Human(new Name(f2), h2, ivan);

        Console.WriteLine("Создаем внука (отчество и фамилия возьмутся от отца):");
        string f3 = Validator.ReadString("Введите имя внука: ");
        int h3 = Validator.ReadInt("Введите рост внука: ");
        Human boris = new Human(new Name(f3), h3, petr);

        Console.WriteLine("Результат:");
        Console.WriteLine(ivan);
        Console.WriteLine(petr);
        Console.WriteLine(boris);
        Console.WriteLine();
    }

    private static void Task3_3_Cities()
    {
        Console.WriteLine("--- ЗАДАНИЕ 3.3. Города ---");

        City a = new City("A");
        City b = new City("B");
        City c = new City("C");
        City d = new City("D");
        City e = new City("E");
        City f = new City("F");

        a.Paths = new Path[] { new Path(b, 5), new Path(f, 1), new Path(d, 6) };
        b.Paths = new Path[] { };
        c.Paths = new Path[] { new Path(b, 3), new Path(a, 1) };
        d.Paths = new Path[] { new Path(c, 4) };
        e.Paths = new Path[] { new Path(d, 2) };
        f.Paths = new Path[] { new Path(b, 1), new Path(e, 2) };

        Console.WriteLine("Результат (схема с рисунка):");
        Console.WriteLine(a);
        Console.WriteLine(b);
        Console.WriteLine(c);
        Console.WriteLine(d);
        Console.WriteLine(e);
        Console.WriteLine(f);
        Console.WriteLine();
    }

    private static void Task4_5_CreateNames()
    {
        Console.WriteLine("--- ЗАДАНИЕ 4.5. Создаем Имена ---");

        string n1 = Validator.ReadString("Введите имя: ");
        Name name1 = new Name(n1);

        string f2 = Validator.ReadString("Введите имя: ");
        string s2 = Validator.ReadString("Введите фамилию: ");
        string p2 = Validator.ReadString("Введите отчество: ");
        Name name2 = new Name(f2, s2, p2);

        string f3 = Validator.ReadString("Введите имя: ");
        string s3 = Validator.ReadString("Введите фамилию: ");
        Name name3 = new Name(f3, s3);

        string f4 = Validator.ReadString("Введите имя (Христофор): ");
        string s4 = Validator.ReadString("Введите фамилию (Бонифатьевич): ");
        Name name4 = new Name(f4, s4);

        Console.WriteLine("Результат:");
        Console.WriteLine(name1);
        Console.WriteLine(name2);
        Console.WriteLine(name3);
        Console.WriteLine(name4);
        Console.WriteLine();
    }

    private static void Task4_6_CreateHuman()
    {
        Console.WriteLine("--- ЗАДАНИЕ 4.6. Создаем Человека ---");

        Console.WriteLine("Создаем Льва (строка + рост):");
        string n1 = Validator.ReadString("Введите имя: ");
        int h1 = Validator.ReadInt("Введите рост: ");
        Human lev = new Human(n1, h1);

        Console.WriteLine("Создаем Сергея (Имя + рост + отец):");
        string f2 = Validator.ReadString("Введите имя: ");
        string s2 = Validator.ReadString("Введите фамилию: ");
        int h2 = Validator.ReadInt("Введите рост: ");
        Human sergey = new Human(new Name(f2, s2), h2, lev);

        Console.WriteLine("Создаем Александра (строка + рост + отец):");
        string n3 = Validator.ReadString("Введите имя: ");
        int h3 = Validator.ReadInt("Введите рост: ");
        Human alexander = new Human(n3, h3, sergey);

        Console.WriteLine("Результат:");
        Console.WriteLine(lev);
        Console.WriteLine(sergey);
        Console.WriteLine(alexander);
        Console.WriteLine();
    }

    private static void Task5_2_Cat()
    {
        Console.WriteLine("--- ЗАДАНИЕ 5.2. Кот мяукает ---");

        string name = Validator.ReadString("Введите имя кота: ");
        Cat cat = new Cat(name);

        Console.WriteLine("Результат: " + cat);
        cat.Meow();

        int n = Validator.ReadInt("Сколько раз мяукнуть? ");
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

internal class Name
{
    private string _surname;
    private string _firstName;
    private string _patronymic;

    public string Surname { get { return _surname; } set { _surname = value; } }
    public string FirstName { get { return _firstName; } set { _firstName = value; } }
    public string Patronymic { get { return _patronymic; } set { _patronymic = value; } }

    public Name(string firstName) { _firstName = firstName; }
    public Name(string firstName, string surname) { _firstName = firstName; _surname = surname; }
    public Name(string firstName, string surname, string patronymic)
    {
        _firstName = firstName;
        _surname = surname;
        _patronymic = patronymic;
    }

    public override string ToString()
    {
        string result = "";
        if (!string.IsNullOrEmpty(_surname)) result += _surname + " ";
        if (!string.IsNullOrEmpty(_firstName)) result += _firstName + " ";
        if (!string.IsNullOrEmpty(_patronymic)) result += _patronymic + " ";
        return result.Trim();
    }
}

internal class Human
{
    private Name _personName;
    private int _height;
    private Human _father;

    public Name PersonName { get { return _personName; } set { _personName = value; } }
    public int Height { get { return _height; } set { _height = value; } }
    public Human Father { get { return _father; } set { _father = value; } }

    public Human(Name name, int height, Human father)
    {
        string surname = name.Surname;
        string patronymic = name.Patronymic;

        if (father != null)
        {
            if (string.IsNullOrEmpty(surname) && !string.IsNullOrEmpty(father.PersonName.Surname))
                surname = father.PersonName.Surname;

            if (string.IsNullOrEmpty(patronymic) && !string.IsNullOrEmpty(father.PersonName.FirstName))
                patronymic = father.PersonName.FirstName + "ович";
        }

        _personName = new Name(name.FirstName, surname, patronymic);
        _height = height;
        _father = father;
    }

    public Human(string name, int height) : this(new Name(name), height, null) { }
    public Human(string name, int height, Human father) : this(new Name(name), height, father) { }
    public Human(Name name, int height) : this(name, height, null) { }

    public override string ToString()
    {
        return _personName.ToString() + ", рост: " + _height;
    }
}

internal class Path
{
    private City _destination;
    private int _cost;

    public City Destination { get { return _destination; } set { _destination = value; } }
    public int Cost { get { return _cost; } set { _cost = value; } }

    public Path(City destination, int cost)
    {
        _destination = destination;
        _cost = cost;
    }
}

internal class City
{
    private string _name;
    private Path[] _paths;

    public string Name { get { return _name; } set { _name = value; } }
    public Path[] Paths { get { return _paths; } set { _paths = value; } }

    public City(string name) { _name = name; }

    public override string ToString()
    {
        string s = _name + ": ";
        if (_paths == null || _paths.Length == 0) return s + "нет путей";

        for (int i = 0; i < _paths.Length; i++)
        {
            s += _paths[i].Destination.Name + ":" + _paths[i].Cost;
            if (i < _paths.Length - 1) s += ", ";
        }
        return s;
    }
}

internal class Cat
{
    private string _name;
    public string Name { get { return _name; } set { _name = value; } }

    public Cat(string name) { _name = name; }

    public override string ToString() { return "кот: " + _name; }

    public void Meow() { Console.WriteLine(_name + ": мяу!"); }

    public void Meow(int n)
    {
        string s = _name + ": ";
        for (int i = 0; i < n; i++)
        {
            s += "мяу";
            if (i < n - 1) s += "-";
        }
        Console.WriteLine(s + "!");
    }
}
