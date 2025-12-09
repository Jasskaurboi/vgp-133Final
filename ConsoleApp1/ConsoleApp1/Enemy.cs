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
        private int defence;
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
            name = " ";
            maxHP = 0;
            currentHP = 0;
            attack = 0;
            defence = 0;
            gold=0;
            xpDrop=0;
        }


        public void UpdateHealth(int value)
        {
            currentHP = Math.Clamp(currentHP + value, 0, maxHP);
        }

        public void Attack()
        {

        }

        public void SpecialAttack()
        {

        }

        public void TakeDamage(int damage)
        {

        }

        public void Death()
        {

        }
    }
}
