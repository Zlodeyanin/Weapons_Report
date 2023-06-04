using System;
using System.Collections.Generic;
using System.Linq;

namespace Weapons_Report
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MilitaryUnit militaryUnit = new MilitaryUnit();
            militaryUnit.Work();
        }
    }

    class Soldier
    {
        public Soldier(string rank) 
        {
            int minQuantityMounts = 0;
            int maxQuantityMounts = 13;
            Name = UserUtils.GenerateRandomName();
            Weapon = UserUtils.GenerateRandomWeapon();
            Rank = rank;
            Tour = UserUtils.GenerateRandomTour(minQuantityMounts, maxQuantityMounts);
        }

        public string Name { get; private set; }
        public string Weapon { get; private set; }
        public string Rank { get; private set; }
        public int Tour { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name} .Оружие - {Weapon} .Звание - {Rank}. Срок службы - {Tour} месяцев.");
        }
    }

    class UserUtils
    {
        private static Random _random = new Random();

        public static string GenerateRandomName()
        {
            string[] names = { "Иван", "Евгений", "Василий", "Владимир", "Вячеслав" };
            string name = "";
            return name += names[_random.Next(names.Length)];
        }

        public static string GenerateRandomWeapon()
        {
            string[] weapons = { "Автомат", "Пулёмет", "Винтовка", "Штык нож", "Ракетница" };
            string weapon = "";
            return weapon += weapons[_random.Next(weapons.Length)];
        }

        public static int GenerateRandomTour(int min, int max)
        {
            return _random.Next(min, max);
        }
    }

    class MilitaryUnit
    {
        private List<Soldier> _soldiers = new List<Soldier>();

        public MilitaryUnit() 
        {
            CreateSoldiers();
        }

        public void Work()
        {
            const string CommandShowAllSoldersInfo = "1";
            const string CommandShowNameAndRankSoldiers = "2";
            const string CommandExit = "3";

            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine($"Введите {CommandShowAllSoldersInfo}, чтобы вывести всю информацию о солтадах.");
                Console.WriteLine($"Введите {CommandShowNameAndRankSoldiers}, чтобы вывести только имена и звания солдат.");
                Console.WriteLine($"Введите {CommandExit}, чтобы завершить работу.");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandShowAllSoldersInfo:
                        ShowAllSoldersInfo();
                        break;

                        case CommandShowNameAndRankSoldiers:
                        ShowNameAndRankSoldiers();
                        break;

                        case CommandExit:
                        isWork= false;
                        break;

                    default:
                        Console.WriteLine("Нет такой команды...");
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        private void CreateSoldiers()
        {
            _soldiers.Add(new Soldier("Маршал"));
            _soldiers.Add(new Soldier("Генерал"));
            _soldiers.Add(new Soldier("Полковник"));
            _soldiers.Add(new Soldier("Майор"));
            _soldiers.Add(new Soldier("Лейтенант"));
        }

        private void ShowAllSoldersInfo()
        {
            foreach (Soldier soldier in _soldiers)
            {
                soldier.ShowInfo();
            }
        }

        private void ShowNameAndRankSoldiers()
        {
            var nameAndRankSoldiers = _soldiers.Select(soldier => new { Name = soldier.Name, Rank = soldier.Rank });

            foreach (var soldier in nameAndRankSoldiers)
            {
                Console.WriteLine($"{soldier.Name} .Звание - {soldier.Rank} .");
            }
        }
    }
}