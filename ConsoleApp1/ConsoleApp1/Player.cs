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

        private bool isGameOver;



        private List<Item> inventory = new List<Item>();

        public string Name { get { return name; } }


        public int MaxHP { get { return maxHP; } }

        public int CurrentHP { get { return currentHP; } }

        public int Gold { get { return gold; } }

        public bool IsGameOver { get { return isGameOver; } }


        public Player() // Default constructor, used for testing purposes
        {
            name = "player";
            maxHP = 100;
            currentHP = maxHP;
            attack = 100;
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
            isGameOver = false;
        }

        public Player(string name, string hairColour, string gender, int age)
        {
            this.name = name;
            maxHP = 100;
            currentHP = maxHP;
            attack = 10;
            defense = 2;
            this.hairColour = hairColour;
            this.gender = gender;
            this.age = age;
            gold = 0;
            level = 1;
            expThreshold = 10;
            exp = 0;
            armor = null;
            weapon = null;
            isGameOver = false;
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

                Console.WriteLine("You leveled up!!");

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

        public void WinTheGame()
        {
            isGameOver = true;
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
            Console.WriteLine("Inventory :");

            List<Consumable>consumables = new List<Consumable>();
            foreach(Item item in inventory)
            {
                if(item.Type== ItemType.Consumable)
                {
                    consumables.Add((Consumable)item);
                }
            }

            if (consumables.Count == 0)
            {
                Console.WriteLine("There are no items!");
                return;
            }

            Console.WriteLine("Choose item to use :");

            for (int i = 0; i < consumables.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {consumables[i].Name}");

            }
            int input = -1;

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out input) && input > 0 && input < consumables.Count)
                {
                    break;
                }
            }

            Console.WriteLine($"You used an item! Healed{consumables[input].HealAmount} ");
            UpdateHealth(consumables[input].HealAmount);
            inventory.Remove(consumables[input]);

        }

        public void ShowInventory()
        {
            Console.WriteLine("Inventory:");
            if (inventory.Count == 0)
            {
                Console.WriteLine("Inventory is empty!!");
                return;
            }
            foreach (Item item in inventory)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("\nSort by: \n0. Exit\n 1 .Quantity \n 2.Name \n3.Type ");
            int input = -1;

            while (true)
            {

                if (int.TryParse(Console.ReadLine(), out input) && input >= 0 && input <= 3)
                {
                    break;
                }
            }

            if (input == 0)
            {
                return;
            }

            var sorted = from item in inventory
                         group item by item.Name into sortedItems
                         let itemType = sortedItems.First().Type
                         select new { Name = sortedItems.Key, Count = sortedItems.Count(), Type = itemType };

            if (input == 1)
            {
                sorted = sorted.OrderByDescending(item => item.Count);
            }
            else if (input == 2)
            {
                sorted = sorted.OrderBy(item => item.Name);
            }
            else if (input == 3)
            {
                sorted = sorted.OrderBy(item => item.Type).ThenBy(item => item.Name);
            }

            Console.Clear();
            Console.WriteLine("Inventory: ");

            foreach (var sortedItems in sorted)
            {
                Console.WriteLine($"{sortedItems.Name} | {sortedItems.Type} | x{sortedItems.Count}");
            }


        }

        public void DisplayStats()
        {
            Console.Clear();
            Console.WriteLine("Character stats");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"HP: {currentHP}/{maxHP}");
            Console.WriteLine($"Attack: {attack}");
            Console.WriteLine($"Defense: {defense}");
            Console.WriteLine($"Hair: {hairColour}");
            Console.WriteLine($"Gender: {gender}");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine($"Gold: {gold}");
            Console.WriteLine($"Level: {level}");
        }

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

            if (input == 0)
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
                    RemoveEquipment(equipment.Type);
                }

                armor = equipment;
            }
            else if (equipment.Type == EquipmentType.Weapon)
            {
                if (weapon != null)
                {
                    inventory.Add(weapon);
                    RemoveEquipment(equipment.Type);

                }

                weapon = equipment;
            }

            currentHP += equipment.HP;
            maxHP += equipment.HP;
            attack += equipment.Attack;
            defense += equipment.Defence;
            inventory.Remove(equipment);

            Console.WriteLine("You equipped an equipment.");
        }

        public void RemoveEquipment(EquipmentType type)
        {
            if (type == EquipmentType.Armor)
            {
                currentHP -= armor.HP;
                maxHP -= armor.HP;
                attack -= armor.Attack;
                defense -= armor.Defence;

                armor = null;
            }
            else if (type == EquipmentType.Weapon)
            {
                currentHP -= weapon.HP;
                maxHP -= weapon.HP;
                attack -= weapon.Attack;
                defense -= weapon.Defence;

                weapon = null;
            }
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
