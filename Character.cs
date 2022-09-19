using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Character
    {
        private string _name;
        private float _health;
        private float _attack;
        private float _strength;
        private float _armor;
        private float _defense;
        private bool _isAlive;
        private Attack[] _attacks;


        void ScaleStats(float scale)
        {
            _attack *= scale;
            _defense *= scale;
            _health *= scale;
            _armor *= scale;
            _strength *= scale;
        }

        //Function overloading example vv
        float CalculateDamage(Character defender)
        {
            if (_attack <= defender._defense)
            {
                return 0;
            }

            float totalDamage = (_attack * _strength) - (defender._defense * defender._armor);

            return totalDamage;
        }

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


        float Attack(ref Character attacker, int attackIndex, ref Character defender)
        {
            Attack currentAttack = attacker._attacks[attackIndex];

            float damage = currentAttack.Damage;

            float damageTaken = CalculateDamage(damage, defender._defense);
            defender._health -= damageTaken;

            if (defender._health < 0)
            {
                defender._health = 0;
            }

            return damageTaken;
        }

        void PrintStats()
        {
            Console.WriteLine(_name + "'s Stats:");
            Console.WriteLine("Health: " + _health);
            Console.WriteLine("Attack: " + _attack);
            Console.WriteLine("Strength: " + _strength);
            Console.WriteLine("Defense: " + _defense);
            Console.WriteLine("Armor: " + _armor);
        }
    }
}
