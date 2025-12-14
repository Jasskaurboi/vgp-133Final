using System.Security.Cryptography;

namespace ConsoleApp1
{
    public class Player
    {
        private string name;
        // private string _unitType;

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
            gold = 50;
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

        public void Equip(Equipment equipment)
        {
            if (equipment.Type == EquipmentType.Armor)
            {
                armor = equipment;
            }
            else if (equipment.Type == EquipmentType.Weapon)
            {
                weapon = equipment;
            }

            UpdateMaxHP(equipment.HP);
            attack += equipment.Attack;
            defense += equipment.Defence;
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
