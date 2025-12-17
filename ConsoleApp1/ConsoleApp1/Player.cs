using System.Security.Cryptography;

namespace ConsoleApp1
{
    public class Player
    {
        private string name;
        private int maxHP;
        private int currentHP;
        private int attack;
        private int defense;
        private string hairColour;
        private string gender;
        private int age;
        private int gold;
        private int level;
        private int expThreshold;
        private int exp;
        private Equipment armor;
        private Equipment weapon;

        private List<Item> inventory = new List<Item>();

        public string Name { get { return name; } }


        public int MaxHP { get { return maxHP; } }

        public int CurrentHP { get { return currentHP; } }

        public int Gold { get { return gold; } }




        public Player() // Default constructor, used for testing purposes
        {
            name = "player";
            maxHP = 100;
            currentHP = maxHP;
            attack = 5;
            defense = 2;
            hairColour = "";
            gender = " ";
            age = 0;
            gold = 150;
            level = 1;
            expThreshold = 10;
            exp = 0;
            armor = null;
            weapon = null;

        }

        public void UpdateHealth(int value)
        {
            currentHP = Math.Clamp(currentHP + value, 0, maxHP);
        }
        public void UpdateMaxHP(int value)
        {
            maxHP = Math.Max(maxHP + value, 1);

            if (currentHP > maxHP)
            {
                currentHP = maxHP;
            }
        }

        public void UpdateExp(int value)
        {
            exp += value;

            if (exp >= expThreshold)
            {

                level++;
                exp -= expThreshold;
                expThreshold += 20;
                Random random = new Random();
                int randomStats = random.Next(1, 4);

                switch (randomStats)
                {
                    case 1:
                        UpdateMaxHP(5);
                        UpdateHealth(5);
                        Console.WriteLine("Max HP has increased by 5!!");
                        break;
                    case 2:
                        attack += 1;
                        Console.WriteLine("Attack has increased by 1!!");
                        break;
                    case 3:
                        defense += 1;
                        Console.WriteLine("Defense has increased by 1!!");
                        break;

                    default:
                        break;
                }
                Console.ReadKey();
            }

        }

        public void CombatLose()
        {
            currentHP = 1;
            gold /= 2;

        }

        public void UpdateGold(int value)
        {
            gold = Math.Max(gold + value, 0);
        }

        public void AddItemToInventory(Item item)
        {
            inventory.Add(item);
        }

        public void UseItem()
        {

        }

        public void ShowInventory()
        {
            Console.WriteLine("Inventory:");
            foreach (Item item in inventory)
            {
                Console.WriteLine(item.Name);
            }
        }

        public void DisplayStats()
        {
            Console.Clear();
            Console.WriteLine("Character stats");
            Console.WriteLine($"Name: {name}");
            //hair, gopld, etc.............
        }

        //public void EquipmentMenu()
        //{
        //    Console.WriteLine("Equipment menu:");

        //    var equipmentList = (from item in inventory
        //                         where item is Equipment
        //                         group item by item.Name into equipments
        //                         orderby equipments.Key ascending
        //                         select new { Name = equipments.Key, Count = equipments.Count(), Num = equipments.ToList()}).ToList();

        //    if (equipmentList.Count() == 0)
        //    {
        //        Console.WriteLine("You have no equipment.");
        //        return;
        //    }

        //    if (armor != null)
        //    {
        //        Console.WriteLine($"Current armor: {armor.Name}");
        //    }

        //    if (weapon != null)
        //    {
        //        Console.WriteLine($"Current weapon: {weapon.Name}");
        //    }

        //    int input = 0;
        //    int i = 0;

        //    foreach (var equipment in equipmentList)
        //    {
        //        i++;
        //        Console.WriteLine($"{i}. {equipment.Name}");
        //    }

        //    Console.WriteLine("Select an equipment:");
        //    while (true)
        //    {

        //        if (int.TryParse(Console.ReadLine(), out input) && input >= 0 && input <= equipmentList.Count())
        //        {
        //            break;
        //        }
        //    }

        //    var newEquipment = equipmentList[input - 1].Num[0];

        //    if(newEquipment is Equipment newItem)
        //    {
        //        if ((Equipment)newEquipment.Type == EquipmentType.Armor)
        //        {

        //        }
        //    }
        //}

        public void EquipmentMenu()
        {
            Console.WriteLine("Equipment menu:");

            List<Equipment> equipments = new List<Equipment>();
            foreach (Item item in inventory)
            {
                if (item.Type == ItemType.Equipment)
                {
                    equipments.Add((Equipment)item);
                }
            }

            if (armor != null)
            {
                Console.WriteLine($"Current armor: {armor.Name}");
            }

            if (weapon != null)
            {
                Console.WriteLine($"Current weapon: {weapon.Name}");
            }

            for (int i = 0; i < equipments.Count(); i++)
            {
                Console.WriteLine($"{i + 1}. {equipments[i].Name}");
            }

            int input;
            Console.WriteLine("Select an equipment: (0 to cancel)");
            while (true)
            {

                if (int.TryParse(Console.ReadLine(), out input) && input >= 0 && input <= equipments.Count())
                {
                    break;
                }
            }

            if(input ==0)
            {
                return;
            }

            Equipment newEquipment = equipments[input - 1];
            Equip(newEquipment);
        }
        public void Equip(Equipment equipment)
        {
            if (equipment.Type == EquipmentType.Armor)
            {
                if (armor != null)
                {
                    inventory.Add(armor);
                }

                armor = equipment;
            }
            else if (equipment.Type == EquipmentType.Weapon)
            {
                if (weapon != null)
                {
                    inventory.Add(weapon);
                }

                weapon = equipment;
            }

            inventory.Remove(equipment);
            UpdateMaxHP(equipment.HP);
            attack += equipment.Attack;
            defense += equipment.Defence;

            Console.WriteLine("You equipped an equipment.");
        }

        public void SwapEquipment()
        {

        }

        public void RemoveEquipment(Equipment equipment)
        {
            if (equipment.Type == EquipmentType.Armor)
            {
                armor = null;
            }
            else if (equipment.Type == EquipmentType.Weapon)
            {
                weapon = null;
            }

            UpdateMaxHP(-equipment.HP);
            attack -= equipment.Attack;
            defense -= equipment.Defence;
        }
        public void Attack(Enemy enemy)
        {
            Console.WriteLine($"{name} are attacking {enemy.Name}!");
            enemy.TakeDamage(attack);

        }

        public void TakeDamage(int damage)
        {
            damage = Math.Max(damage - defense, 1);
            Console.WriteLine($"{name} took {damage} damage!");
            UpdateHealth(-damage);

        }

    }
}
