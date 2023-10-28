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

            while (isExit == false)
            {
                Console.WriteLine("Выберете вольер, чтобы подойти к нему:");
                Console.WriteLine(CockooCage + " - Вольер 1");
                Console.WriteLine(OwlCage + " - Вольер 2");
                Console.WriteLine(DuckCage + " - Вольер 3");
                Console.WriteLine(CrowCage + " - Вольер 4");
                Console.WriteLine(Exit + " - Exit\n");

                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CockooCage:
                        zoo.CageCuckoos.ShowCageTitle();
                        zoo.CageCuckoos.ShowInhabitants();
                        break;

                    case OwlCage:
                        zoo.CageOwls.ShowCageTitle();
                        zoo.CageOwls.ShowInhabitants();
                        break;

                    case DuckCage:
                        zoo.CageDucks.ShowCageTitle();
                        zoo.CageDucks.ShowInhabitants();
                        break;

                    case CrowCage:
                        zoo.CageCrows.ShowCageTitle();
                        zoo.CageCrows.ShowInhabitants();
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
        public Cage CageCuckoos = new Cage(1, "Кукушки");
        public Cage CageOwls = new Cage(2, "Совы");
        public Cage CageDucks = new Cage(3, "Утки");
        public Cage CageCrows = new Cage(4, "Вороны");
    }

    class Cage
    {
        private int _cageCapacity = 3;

        public Cage(int inhabitantIndex, string title)
        {
            InhabitantIndex = inhabitantIndex;
            Title = title;
            _inhabitants = FillCage(inhabitantIndex);
        }

        public string Title { get; protected set; }
        public int InhabitantIndex { get; protected set; }
        private List<Animal> _inhabitants;

        public void ShowCageTitle()
        {
            Console.WriteLine($"Вольер где живут - " + Title);
        }

        public void ShowInhabitants()
        {
            for (int i = 0; i < _inhabitants.Count; i++)
            {
                Console.WriteLine($"Птица - {_inhabitants[i].Name}, пол - {_inhabitants[i].Sex}, говорит - {_inhabitants[i].Sound}");
            }
        }

        private List<Animal> FillCage(int index)
        {

            List<Animal> cage = new List<Animal>();

            for (int i = 0; i < _cageCapacity; i++)
            {
                if (index != null)
                {
                    cage.Add(CreateAnimal(index));
                }
                else
                {
                    Console.WriteLine("Ошибка, неверный индекс животного.");
                }
            }

            return cage;
        }

        private Animal CreateAnimal(int index)
        {
            switch (index)
            {
                case 1:
                    return new Cuckoo();
                case 2:
                    return new Owl();
                case 3:
                    return new Duck();
                case 4:
                    return new Crow();
                default:
                    return null;
            }
        }
    }

    class Animal
    {
        public Animal()
        {
            Index = 0;
            Name = "Animal";
            Sound = "Fiu...";
            Sex = GetSex();
        }

        public int Index { get; protected set; }
        public string Name { get; protected set; }
        public string Sound { get; protected set; }
        public string Sex { get; private set; }

        private string GetSex()
        {
            Random random = new Random();

            if (random.Next(2) == 0)
            {
                return "Мужской";
            }
            else
            {
                return "Женский";
            }
        }
    }

    class Cuckoo : Animal
    {
        public Cuckoo() 
        {
            Index = 1;
            Name = "Кукушка";
            Sound = "Ку-ку!";
        }
    }

    class Owl : Animal
    {
        public Owl()
        {
            Index = 2;
            Name = "Сова";
            Sound = "Уху!";
        }
    }

    class Duck : Animal
    {
        public Duck()
        {
            Index = 3;
            Name = "Утка";
            Sound = "Кря!";
        }
    }

    class Crow : Animal
    {
        public Crow()
        {
            Index = 4;
            Name = "Ворона";
            Sound = "Каррр!";
        }
    }
}