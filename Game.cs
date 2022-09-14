using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    struct Character
    {
        public string Name;
        public float Health;
        public float Attack;
        public float Strength;
        public float Armor;
        public float Defense;
        public bool IsAlive;
        public Attack[] Attacks;
    }

    struct Attack
    {
        public string Name;
        public float Damage;
        public int CastTime;
        public int Cooldown;
    }

    class Game
    {

        //Initialize monsters
        Character terry;
        Character coldSteel;
        Character nemisis;
        Character kidKnuckles;
        Character sumtinGuuud;
        Character currentFighter1;
        Character currentFighter2;

        int currentScene =  0;
        bool gameOver = false;
        Character[] characters;

        void PrintAllStats()
        {
            for (int i = 0; i < characters.Length; i++)
            {
                Console.WriteLine(characters[i].Name);
                Console.WriteLine(characters[i].Health);
                Console.WriteLine(characters[i].Attack);
                Console.WriteLine(characters[i].Strength);
                Console.WriteLine(characters[i].Defense);
            }
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

        //Function overloading example vv
        float CalculateDamage(Character monster1, Character monster2)
        {
            if (monster1.Attack <= monster2.Defense)
            {
                return 0;
            }

            float totalDamage = (monster1.Attack * monster1.Strength) - (monster2.Defense * monster2.Armor);

            return totalDamage;
        }

        void PrintStats(Character monster)
        {
            Console.WriteLine(monster.Name + "'s Stats:");
            Console.WriteLine("Health: " + monster.Health);
            Console.WriteLine("Attack: " + monster.Attack);
            Console.WriteLine("Strength: " + monster.Strength);
            Console.WriteLine("Defense: " + monster.Defense);
            Console.WriteLine("Armor: " + monster.Armor);
        }

        float Attack(ref Character attacker, int attackIndex, ref Character defender)
        {
            Attack currentAttack = attacker.Attacks[attackIndex];

            float damage = currentAttack.Damage;

            float damageTaken = CalculateDamage(damage, defender.Defense);
            defender.Health -= damageTaken;

            if (defender.Health < 0)
            {
                defender.Health = 0;
            }

            return damageTaken;
        }

        void ScaleStats(ref Character monster, float scale)
        {
            monster.Attack *= scale;
            monster.Defense *= scale;
            monster.Health *= scale;
            monster.Armor *= scale;
            monster.Strength *= scale;
        }

        void DisplayStartMenu()
        {
            Console.Clear();
            Console.WriteLine("Super Mecha Death Battle: Volume 8 Reloaded V5.0 Z");
            Console.WriteLine("Press Any Key To Continue");
            Console.ReadKey();
            Console.Clear();

            currentScene = 1;
        }

        void DisplayFightScene()
        {
            Console.Clear();

            //Display current stats
            PrintStats(currentFighter1);
            Console.WriteLine();
            PrintStats(currentFighter2);

            //Make the first fighter punch the second
            float damageTaken = Attack(ref currentFighter1, 2, ref currentFighter2);

            //Display damage message for player feedback
            Console.WriteLine(currentFighter2.Name + " took " + damageTaken + " damage!");
            Console.ReadKey();

            damageTaken = Attack(ref currentFighter2, 0, ref currentFighter1);

            //Display damage message for player feedback
            Console.WriteLine(currentFighter1.Name + " took " + damageTaken + " damage!");
            Console.ReadKey();
            
            if (currentFighter1.Health <= 0 || currentFighter2.Health <= 0)
                currentScene = 2;
        }

        void DisplayBattleResult()
        {
            //Create default result message
            string resultMessage = "The winner is ";

            if (currentFighter1.Health > 0)
            {
                resultMessage += currentFighter1.Name;
            }
            else if (currentFighter2.Health > 0)
            {
                resultMessage += currentFighter2.Name;
            }
            else
            {
                resultMessage = "Match is draw";
                currentFighter1 = characters[2];
                currentFighter2 = characters[3];
            }

            Console.WriteLine(resultMessage);
            Console.ReadKey();
            Console.Clear();

            gameOver = true;
        }

        /// <summary>
        /// Called when the game begins
        /// </summary>
        void Start()
        {
            //Initialize attacks
            Attack swordSlash = new Attack { Name = "Sword Slash", Damage = 12 };
            Attack punch = new Attack { Name = "Punch", Damage = 15 };
            Attack kick = new Attack { Name = "Kick", Damage = 20 };
            Attack kamehameha = new Attack { Name = "Kamehameha", Damage = 8999, CastTime = 5 };

            //Initialize fighters
            terry = new Character { Name = "Terry", Attack = 8f, Strength = 0, Defense = 0, Armor = 0, Health = 100f, IsAlive = true };
            coldSteel = new Character { Name = "ColdSteel", Attack = 8f, Strength = 0, Defense = 0, Armor = 0, Health = 100f, IsAlive = true };
            nemisis = new Character { Name = "Nemesis", Attack = 10, Strength = 2, Defense = 100000, Armor = 0, Health = 720000, IsAlive = true };
            kidKnuckles = new Character { Name = "KidKnickles", Attack = 10, Strength = 30010, Defense = 10, Health = 10, Armor = 10, IsAlive = true };
            sumtinGuuud = new Character { Name = "SumtinGUUUD", Attack = 5, Strength = 525000, Defense = 600, Armor = 1738, Health = 4000, IsAlive = true };

            terry.Attacks = new Attack[] { swordSlash, kamehameha, punch };
            coldSteel.Attacks = new Attack[] { punch, kick, kamehameha };

            characters = new Character[] { terry, coldSteel, nemisis, kidKnuckles, sumtinGuuud };

            //Set current fighters
            currentFighter1 = terry;
            currentFighter2 = coldSteel;
        }

        /// <summary>
        /// Called every time the game loops
        /// </summary>
        void Update()
        {
            if (currentScene == 0)
            {
                DisplayStartMenu();
            }
            else if (currentScene == 1)
            {
                DisplayFightScene();
            }
            else if (currentScene == 2)
            {
                DisplayBattleResult();
            }
        }

        void End()
        {
            Console.WriteLine("Thank a you so much for playin mah game");
        }

        public void Run()
        {
            Start();

            while (!gameOver)
            {
                Update();
            }

            End();
        }
    }
}
