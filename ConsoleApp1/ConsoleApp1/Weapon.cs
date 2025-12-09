namespace ConsoleApp1
{
    public class Weapon : Equipment
    {
        public Weapon(string name, int hp, int attack, int defence, int price) : base(name, hp, attack, defence, price)
        {
            Type = EquipmentType.Weapon;
        }
    }

}
