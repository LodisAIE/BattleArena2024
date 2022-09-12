using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    struct Monster
    {
        public string Name;
        public float Health;
        public float Attack;
        public float Strength;
        public float Armor;
        public float Defense;
        public bool IsAlive;
    }

    class Game
    {
        //Make a function that can calculate and return the total damage a monster would recieve.
        //Total damage is going to be opponents base damage subtracted by the defending monsters defense.

        float CalculateDamage(float attack, float defense)
        {
            if (attack <= defense)
            {
                return 0;
            }

            float totalDamage = attack - defense;

            return totalDamage;
        }

        //Function overloading example vv
        float CalculateDamage(Monster monster1, Monster monster2)
        {
            if (monster1.Attack <= monster2.Defense)
            {
                return 0;
            }

            float totalDamage = (monster1.Attack * monster1.Strength) - (monster2.Defense * monster2.Armor);

            return totalDamage;
        }

        void PrintStats(Monster monster)
        {
            Console.WriteLine(monster.Name + "'s Stats:");
            Console.WriteLine("Health: " + monster.Health);
            Console.WriteLine("Attack: " + monster.Attack);
            Console.WriteLine("Strength: " + monster.Strength);
            Console.WriteLine("Defense: " + monster.Defense);
            Console.WriteLine("Armor: " + monster.Armor);
        }

        float Attack(Monster attacker, Monster defender)
        {
            float damageTaken = CalculateDamage(attacker, defender);
            defender.Health -= damageTaken;

            if (defender.Health < 0)
            {
                defender.Health = 0;
            }

            return damageTaken;
        }

        
        void ChangeNumber(int number)
        {
            number = 2;
        }

        public void Run()
        {
            //Initialize monsters
            Monster monster1 = new Monster { Name = "Terry", Attack = 8999f, Strength = 1.5f, Defense = 6f, Armor = 2.3f, Health = 20f, IsAlive = true};
            Monster monster2 = new Monster { Name = "ColdSteel", Attack = 8999f, Strength = 2.1f, Defense = 2043f, Armor = 1.3f, Health = 2.3f, IsAlive = true };
            int number1 = 5;

            //number = number1
            ChangeNumber(number1);

            //Monster 1 attacks monster 2
            float damageTaken = Attack(monster1, monster2);

            Console.WriteLine("Monster 2 has taken " + damageTaken + " damage!");
            PrintStats(monster2);
        }
    }
}
