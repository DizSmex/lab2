using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Вызываем каждое задание отдельно
        Task1_3_Names();
        Task2_2_HumanWithName();
        Task2_3_HumanWithParent();
        Task3_3_Cities();
        Task4_5_CreateNames();
        Task4_6_CreateHuman();
        Task5_2_Cat();

        Console.WriteLine("\n=== ВСЕ ЗАДАНИЯ ВЫПОЛНЕНЫ ===");
        Console.ReadKey();
    }

    // ЗАДАНИЕ 1.3: Имена
    private static void Task1_3_Names()
    {
        Console.WriteLine("--- ЗАДАНИЕ 1.3. Имена ---");
        Name name1 = new Name("Клеопатра");
        Name name2 = new Name("Александр", "Пушкин", "Сергеевич");
        Name name3 = new Name("Владимир", "Маяковский");

        Console.WriteLine(name1);
        Console.WriteLine(name2);
        Console.WriteLine(name3);
        Console.WriteLine();
    }

    // ЗАДАНИЕ 2.2: Человек с именем
    private static void Task2_2_HumanWithName()
    {
        Console.WriteLine("--- ЗАДАНИЕ 2.2. Человек с именем ---");
        Name name1 = new Name("Клеопатра");
        Name name2 = new Name("Александр", "Пушкин", "Сергеевич");
        Name name3 = new Name("Владимир", "Маяковский");

        Human h1 = new Human(name1, 152);
        Human h2 = new Human(name2, 167);
        Human h3 = new Human(name3, 189);

        Console.WriteLine(h1);
        Console.WriteLine(h2);
        Console.WriteLine(h3);
        Console.WriteLine();
    }

    // ЗАДАНИЕ 2.3: Человек с родителем
    private static void Task2_3_HumanWithParent()
    {
        Console.WriteLine("--- ЗАДАНИЕ 2.3. Человек с родителем ---");
        Human ivan = new Human(new Name("Иван", "Чудов"), 180);
        Human petr = new Human(new Name("Петр"), 175, ivan);
        Human boris = new Human(new Name("Борис"), 170, petr);

        Console.WriteLine(ivan);
        Console.WriteLine(petr);
        Console.WriteLine(boris);
        Console.WriteLine();
    }

    // ЗАДАНИЕ 3.3: Города
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

        Console.WriteLine(a);
        Console.WriteLine(b);
        Console.WriteLine(c);
        Console.WriteLine(d);
        Console.WriteLine(e);
        Console.WriteLine(f);
        Console.WriteLine();
    }

    // ЗАДАНИЕ 4.5: Создаем Имена (демонстрация конструкторов)
    private static void Task4_5_CreateNames()
    {
        Console.WriteLine("--- ЗАДАНИЕ 4.5. Создаем Имена ---");
        Name n1 = new Name("Клеопатра");
        Name n2 = new Name("Александр", "Пушкин", "Сергеевич");
        Name n3 = new Name("Владимир", "Маяковский");
        // Христофор это имя, а Бонифатьевич - фамилия (по условию задачи)
        Name n4 = new Name("Христофор", "Бонифатьевич");

        Console.WriteLine(n1);
        Console.WriteLine(n2);
        Console.WriteLine(n3);
        Console.WriteLine(n4);
        Console.WriteLine();
    }

    // ЗАДАНИЕ 4.6: Создаем Человека (демонстрация конструкторов и отца)
    private static void Task4_6_CreateHuman()
    {
        Console.WriteLine("--- ЗАДАНИЕ 4.6. Создаем Человека ---");
        Human lev = new Human("Лев", 170);
        Human sergey = new Human(new Name("Сергей", "Пушкин"), 168, lev);
        Human alexander = new Human("Александр", 167, sergey);

        Console.WriteLine(lev);
        Console.WriteLine(sergey);
        Console.WriteLine(alexander);
        Console.WriteLine();
    }

    // ЗАДАНИЕ 5.2: Кот мяукает
    private static void Task5_2_Cat()
    {
        Console.WriteLine("--- ЗАДАНИЕ 5.2. Кот мяукает ---");
        Cat cat = new Cat("Барсик");
        Console.WriteLine(cat);
        cat.Meow();
        cat.Meow(3);
        Console.WriteLine();
    }
}

// ================= КЛАССЫ =================

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

    // Главный конструктор, где выполняются все присвоения и логика родителя (Задание 2.3 и 4.6)
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

    // Остальные конструкторы вызывают главный через this() (как требует Задание 4.6)
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
