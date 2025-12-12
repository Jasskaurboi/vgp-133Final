using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Enemy
    {
        private string name;
        // private string _unitType;

        private int maxHP;
        private int currentHP;
        private int attack;
        private int defense;
        private int gold;
        private int xpDrop;

        public string Name { get { return name; } }
        public int CurrentHP { get { return currentHP; } }
        public int MaxHP { get { return maxHP; } }
        public int GoldDrop { get { return gold; } }
        public int XPDrop { get { return xpDrop; } }
        public bool IsDead { get { return currentHP <= 0; } }

        public Enemy()
        {
            name = "enemy";
            maxHP = 5;
            currentHP = maxHP;
            attack = 1;
            defense = 1;
            gold=1;
            xpDrop=8;
        }


        public void UpdateHealth(int value)
        {
            currentHP = Math.Clamp(currentHP + value, 0, maxHP);
        }

        public void Attack(Player player)
        {
            Console.WriteLine($"{name} are attacking {player.Name}!");
            player.TakeDamage(attack);

        }
        public void SpecialAttack()
        {

        }
        public void TakeDamage(int damage)
        {
            damage = Math.Max(damage - defense, 1);
            Console.WriteLine($"{name} took {damage} damage!");
            UpdateHealth(-damage);
        }

        public void Death()
        {

        }
    }
}
