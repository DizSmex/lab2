using System;

namespace Lab2
{
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
}
