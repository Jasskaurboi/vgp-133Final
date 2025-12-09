namespace ConsoleApp1
{
    public class Player
    {
        private string name;
        // private string _unitType;

        private int maxHP;
        private int currentHP;
        private int attack;
        private int defence;
        private string hairColour;
        private string gender;
        private int age;
        private int gold;
        private int level;
        private int expThreshold;
        private int exp;
        private Armor armor;
        private Weapon weapon;

        private List<Item> inventory = new List<Item>();

        public int MaxHP { get { return maxHP; } }




        public Player() // Default constructor, used for testing purposes
        {
            name = " ";
            maxHP = 0;
            currentHP = 0;
            attack = 0;
            defence = 0;
            hairColour = "";
            gender = " ";
            age = 0;
            gold = 0;
            level = 0;
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

        public void UpdateGold(int value)
        {
            gold = Math.Max(gold + value, 0);
        }

        public void AddItem(Item item)
        {
            inventory.Add(item);
        }

        public void UseItem()
        {

        }

        public void ShowInventory()
        {

        }

        public void Equip(Equipment equipment)
        {
            if (equipment.Type == EquipmentType.Armor)
            {
                armor = (Armor)equipment;
            }
            else if (equipment.Type == EquipmentType.Weapon)
            {
                weapon = (Weapon)equipment;
            }

            UpdateMaxHP(equipment.HP);
            attack += equipment.Attack;
            defence += equipment.Defence;
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
            defence -= equipment.Defence;
        }
        public void Attack()
        {

        }

        public void TakeDamage(int damage)
        {

        }

    }
}
