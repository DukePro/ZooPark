namespace ZooPark
{
    class Program
    {
        static void Main()
        {
            Menu menu = new Menu();
            menu.Run();
        }
    }

    class Menu
    {
        private const string Exit = "0";

        public void Run()
        {
            string userInput;
            int indexFromUser;
            bool isExit = false;

            Zoo zoo = new Zoo();
            zoo.CreateCages();

            while (isExit == false)
            {
                Console.WriteLine("\nВыберете вольер, чтобы подойти к нему:");
                zoo.ShowAllCages();
                Console.WriteLine(Exit + " - Выход\n");

                userInput = Console.ReadLine();

                if (userInput == Exit)
                {
                    isExit = true;
                }
                else if (int.TryParse(userInput, out indexFromUser) == false)
                {
                    Console.Write("Wrong index");
                    return;
                }
                else
                {
                    zoo.ShowCage(indexFromUser);
                }
            }
        }
    }

    class Zoo
    {
        private List<Cage> _cages = new List<Cage>();

        public void CreateCages()
        {
            Animal[] baseAnimals = { new Cuckoo(), new Owl(), new Duck(), new Crow() };

            int minAnimalsCount = 5;
            int maxAnimalsCount = 10;

            for (int i = 0; i < baseAnimals.Length; i++)
            {
                int animalsCount = Utils.GetRandomNumber(minAnimalsCount, maxAnimalsCount);
                List<Animal> animals = new List<Animal>();

                for (int j = 0; j < animalsCount; j++)
                {
                    Animal animal = baseAnimals[i];
                    animals.Add(new Animal(animal.Name, animal.Sound));
                }

                _cages.Add(new Cage(animals));
            }
        }

        public void ShowCage(int id)
        {
            for (int i = 0; i < _cages.Count; i++)
            {
                if (_cages[i].Id == id)
                {
                    _cages[i].ShowTitle();
                    _cages[i].ShowAnimals();
                }
            }
        }

        public void ShowAllCages()
        {
            for (int i = 0; i < _cages.Count; i++)
            {
                Console.Write($"{i+1} - ");
                _cages[i].ShowTitle();
            }
        }
    }

    class Cage
    {
        private static int _id = 1;

        private List<Animal> _animals;

        public Cage(List<Animal> animals)
        {
            Id = _id++;
            _animals = animals;
            Title = animals[0].Name;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }

        public void ShowTitle()
        {
            Console.WriteLine($"Вольер с птицей - " + Title);
        }

        public void ShowAnimals()
        {
            Console.WriteLine($"количество птиц в вольере - {_animals.Count}");

            for (int i = 0; i < _animals.Count; i++)
            {
                Console.WriteLine($"Птица - {_animals[i].Name}, пол - {_animals[i].Gender}, говорит - {_animals[i].Sound}");
            }
        }
    }

    class Animal
    {
        public Animal(string name, string sound)
        {
            Name = name;
            Sound = sound;
            GenerateGender();
        }

        public string Name { get; protected set; }
        public string Sound { get; protected set; }
        public string Gender { get; private set; }

        public void GenerateGender()
        {
            string[] genders = { "Самец", "Самка" };
            int index = Utils.GetRandomNumber(genders.Length);
            Gender = genders[index];
        }
    }

    class Cuckoo : Animal
    {
        public Cuckoo() : base("Кукушка", "Ку-ку!")
        {
        }
    }

    class Owl : Animal
    {
        public Owl() : base("Сова", "Уху!")
        {
        }
    }

    class Duck : Animal
    {
        public Duck() : base("Утка", "Кря!")
        {
        }
    }

    class Crow : Animal
    {
        public Crow() : base("Ворона", "Каррр!")
        {
        }
    }

    class Utils
    {
        private static Random s_random = new Random();

        public static int GetRandomNumber(int minValue, int maxValue)
        {
            return s_random.Next(minValue, maxValue);
        }

        public static int GetRandomNumber(int maxValue)
        {
            return s_random.Next(maxValue);
        }
    }
}