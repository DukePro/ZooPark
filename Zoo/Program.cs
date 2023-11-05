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
        private const string CockooCage = "1";
        private const string OwlCage = "2";
        private const string DuckCage = "3";
        private const string CrowCage = "4";
        private const string Exit = "0";

        public void Run()
        {
            string userInput;
            bool isExit = false;

            Zoo zoo = new Zoo();
            zoo.CreateCages();

            while (isExit == false)
            {
                Console.WriteLine("\nВыберете вольер, чтобы подойти к нему:");
                Console.WriteLine(CockooCage + " - Вольер с кукушками");
                Console.WriteLine(OwlCage + " - Вольер с Совами");
                Console.WriteLine(DuckCage + " - Вольер с утками");
                Console.WriteLine(CrowCage + " - Вольер с воронами");
                Console.WriteLine(Exit + " - Выход\n");

                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CockooCage:
                        zoo.ShowCage("Кукушка");
                        break;

                    case OwlCage:
                        zoo.ShowCage("Сова");
                        break;

                    case DuckCage:
                        zoo.ShowCage("Утка");
                        break;

                    case CrowCage:
                        zoo.ShowCage("Ворона");
                        break;

                    case Exit:
                        isExit = true;
                        break;
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

        public void ShowCage(string title)
        {
            for (int i = 0; i < _cages.Count; i++)
            {
                if (_cages[i].Title == title)
                {
                    _cages[i].ShowTitle();
                    _cages[i].ShowAnimals();
                }
            }
        }
    }

    class Cage
    {
        private List<Animal> _animals;

        public Cage(List<Animal> animals)
        {
            _animals = animals;
            Title = animals[0].Name;
        }

        public string Title { get; private set; }

        public void ShowTitle()
        {
            Console.WriteLine($"Птица в вольере - " + Title);
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

        public int Index { get; protected set; }
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