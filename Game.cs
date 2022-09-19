using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{

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
        int currentFighterIndex = 0;
        bool gameOver = false;
        Character[] characters;


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
            
            if (currentFighter1._health <= 0 || currentFighter2._health <= 0)
                currentScene = 2;
        }

        /// <summary>
        /// Increment the fighter count and return the next fighter at the new index
        /// </summary>
        /// <returns></returns>
        Character GetNextCharacter()
        {
            currentFighterIndex++;

            Character character = new Character { Name = "null" };

            if (currentFighterIndex < characters.Length)
                character = characters[currentFighterIndex];

            return character;
        }

        void DisplayBattleResult()
        {
            //Create default result message
            string resultMessage = "The winner is ";

            //If the first fighter won...
            if (currentFighter1._health > 0)
            {
                //...update the result message and change fighter 2
                resultMessage += currentFighter1.Name;
                currentFighter2 = GetNextCharacter();
            }
            //Otherwise if the second fighter won...
            else if (currentFighter2._health > 0)
            {
                //...update the result message and change fighter 1
                resultMessage += currentFighter2.Name;
                currentFighter1 = GetNextCharacter();
            }
            //Otherwise if it was a draw...
            else if (currentFighterIndex < characters.Length)
            {
                //update the the result message and change both fighters
                resultMessage = "Match is draw";

                currentFighter1 = GetNextCharacter();

                currentFighter2 = GetNextCharacter();
            }

            Console.WriteLine(resultMessage);
            Console.ReadKey();
            Console.Clear();

            if (currentFighter1.Name == "null" || currentFighter2.Name == "null")
                currentScene = 3;
            else
                currentScene = 1;
        }

        void DisplayGameResult()
        {
            if (currentFighter1.Name != "null")
            {
                Console.WriteLine("The Monarch of the Mountain is: " + currentFighter1.Name);
            }
            else if (currentFighter2.Name != "null")
            {
                Console.WriteLine("The Monarch of the Mountain is: " + currentFighter2.Name);
            }
            else
            {
                Console.WriteLine("There is no winner. Everyone loses. ");
            }

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
            terry = new Character { Name = "Terry", Attack = 8f, _strength = 0, _defense = 0, _armor = 0, _health = 1f, _isAlive = true };
            coldSteel = new Character { Name = "ColdSteel", Attack = 8f, _strength = 0, _defense = 0, _armor = 0, _health = 1f, _isAlive = true };
            nemisis = new Character { Name = "Nemesis", Attack = 10, _strength = 2, _defense = 1, _armor = 0, _health = 1, _isAlive = true };
            kidKnuckles = new Character { Name = "KidKnickles", Attack = 10, _strength = 30010, _defense = 1, _health = 1, _armor = 10, _isAlive = true };
            sumtinGuuud = new Character { Name = "SumtinGUUUD", Attack = 5, _strength = 525000, _defense = 1, _armor = 1738, _health = 1, _isAlive = true };

            terry._attacks = new Attack[] { swordSlash, kamehameha, punch };
            coldSteel._attacks = new Attack[] { punch, kick, kamehameha };
            nemisis._attacks = new Attack[] { swordSlash, kamehameha, punch };
            kidKnuckles._attacks = new Attack[] { punch, kick, kamehameha };
            sumtinGuuud._attacks = new Attack[] { swordSlash, kamehameha, punch };

            characters = new Character[] { terry, coldSteel, nemisis, kidKnuckles, sumtinGuuud };

            int test = new int();

            test++;

            //Set current fighters
            currentFighter1 = terry;
            currentFighter2 = coldSteel;
            currentFighterIndex = 1;
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
            else if (currentScene == 3)
            {
                DisplayGameResult();
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
