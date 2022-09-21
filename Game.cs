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
            currentFighter1.PrintStats();
            Console.WriteLine();
            currentFighter2.PrintStats();

            //Make the first fighter punch the second
            float damageTaken = currentFighter1.Attack(2, currentFighter2);

            //Display damage message for player feedback
            Console.WriteLine(currentFighter2.GetName() + " took " + damageTaken + " damage!");
            Console.ReadKey();

            damageTaken = currentFighter2.Attack(0, ref currentFighter1);

            //Display damage message for player feedback
            Console.WriteLine(currentFighter1.GetName() + " took " + damageTaken + " damage!");
            Console.ReadKey();
            
            if (currentFighter1.GetHealth() <= 0 || currentFighter2.GetHealth() <= 0)
                currentScene = 2;
        }

        /// <summary>
        /// Increment the fighter count and return the next fighter at the new index
        /// </summary>
        /// <returns></returns>
        Character GetNextCharacter()
        {
            currentFighterIndex++;

            Character character = null;

            if (currentFighterIndex < characters.Length)
                character = characters[currentFighterIndex];

            return character;
        }

        void DisplayBattleResult()
        {
            //Create default result message
            string resultMessage = "The winner is ";

            //If the first fighter won...
            if (currentFighter1.GetHealth() > 0)
            {
                //...update the result message and change fighter 2
                resultMessage += currentFighter1.GetName();
                currentFighter2 = GetNextCharacter();
            }
            //Otherwise if the second fighter won...
            else if (currentFighter2.GetHealth() > 0)
            {
                //...update the result message and change fighter 1
                resultMessage += currentFighter2.GetName();
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

            if (currentFighter1.GetName() == "null" || currentFighter2.GetName() == "null")
                currentScene = 3;
            else
                currentScene = 1;
        }

        void DisplayGameResult()
        {
            if (currentFighter1.GetName() != "null")
            {
                Console.WriteLine("The Monarch of the Mountain is: " + currentFighter1.GetName());
            }
            else if (currentFighter2.GetName() != "null")
            {
                Console.WriteLine("The Monarch of the Mountain is: " + currentFighter2.GetName());
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

            Attack[] terryAttacks = new Attack[] { swordSlash, kamehameha, punch };


            //Initialize fighters
            terry = new Character("Terry", 1, 10, 5, 23, 4, terryAttacks);



            coldSteel = new Character("ColdSteel", 8f, 0, 0, 0, 1f, new Attack[] { punch, kick, kamehameha });
            nemisis = new Character("Nemesis", 10, 2, 1, 0, 1, new Attack[] { swordSlash, kamehameha, punch });
            kidKnuckles = new Character("KidKnickles", 10, 30010, 1, 1, 10, new Attack[] { punch, kick, kamehameha });
            sumtinGuuud = new Character("SumtinGUUUD", 5, 525000, 1, 1738, 1, new Attack[] { swordSlash, kamehameha, punch } );


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
