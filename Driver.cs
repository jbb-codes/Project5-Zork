//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Project:         Project 5 - Zork
// File Name:       Driver.cs
// Description:     Implementation of a Driver that will allow the user to play the Zork game.
// Course:          CSCI 1260-001 – Introduction to Computer Science II
// Author:          Noah Drumwright, Jarren Bess, Drumwrightn@etsu.edu, bessjb@etsu.edu, Department of Computing, East Tennessee State University
// Created:         Tuesday, November 29, 2022
// Copyright:       Noah Drumwright, Jarren Bess, 2022
//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Threading;

namespace Project5Zork
{
    /// <summary>
    /// Driver class that implements game mechanics and runs the game.
    /// </summary>
    public class Driver
    {

        /// <summary>
        /// Entry point of the program that takes user input and contains game loop.
        /// </summary>
        public static void Main()
        {
            Random rnd = new Random();
            Dungeon MyDungeon = new Dungeon(rnd.Next(5, 11));
            Weapon weapon = new Weapon();
            Monster monster = new Monster();
            Player MyPlayer = new Player();

            string userDir;
            bool PlayerIsAlive = true;
            bool Exited = false;

            Cell StartCell = new Cell(MyPlayer, null);
            MyDungeon.Cells[0] = StartCell;

            Random WeaponLocation = new Random();
            int WeaponPosition = WeaponLocation.Next(1, MyDungeon.Size);

            for (int i = 1; i < MyDungeon.Cells.Length; i++)
            {
                if (i == WeaponPosition)
                {
                    MyDungeon.Cells[i] = new Cell(monster.RandomMonster(), weapon.randomWeapon());
                }
                else
                {
                    Cell NewCell = new Cell();
                    NewCell = NewCell.FillCells();
                    MyDungeon.Cells[i] = NewCell;
                }
            }

            Intro();

            while (PlayerIsAlive == true && Exited == false)
            {
                int PlayerPosition = MyDungeon.CurrentPosition;
                int NextCell = PlayerPosition + 1;
                ShowDungeon(MyDungeon);
                Console.WriteLine("Your remaining health points: " + MyPlayer.PlayerHealth);

                Console.WriteLine("\nWhat would you like to do next? Your choices are 'go east' and 'go west'.");
                userDir = Console.ReadLine().ToLower();

                switch (userDir)
                {
                    case "go west":
                        if (MyDungeon.CurrentPosition == 0)
                        {
                            Console.WriteLine("Sorry but I can't go in that direction");
                        }
                        else
                        {
                            MyDungeon.GoWest();
                        }
                        break;
                    case "go east":
                        if (NextCell == MyDungeon.Cells.Count())
                        {
                            Console.WriteLine("You have beaten the dungeon and all of its monsters - congratulations!");
                            Exited = true;
                        }
                        else
                        {
                            if (MyDungeon.Cells[NextCell].GetWeapon() != null)
                            {
                                MyPlayer.EquipWeapon(MyDungeon.Cells[NextCell].GetWeapon());
                                Console.WriteLine("\nYou found a " + MyDungeon.Cells[NextCell].weapons.Name + " and picked it up. You now do " + MyDungeon.Cells[NextCell].weapons.Damage + " more damage!\n");
                            }

                            if (MyDungeon.Cells[NextCell].GetParticipant() != null)
                            {
                                Combat(MyPlayer, new Monster());
                            }

                            if (MyPlayer.PlayerHealth == 0)
                            {
                                PlayerIsAlive = false;
                            }
                            else
                            {
                                MyDungeon.GoEast(MyPlayer);
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("I do not know what you mean.");
                        break;
                }
            }
        }

        /// <summary>
        /// Message that displays at the start of the game.
        /// </summary>
        public static void Intro()
        {
            Console.WriteLine("Welcome to the Zork Game");
            Console.WriteLine("\n-----------------------------");
            Console.WriteLine("In this game, there is a dungeon with 5 to 10 cells.");
            Console.WriteLine("The player begins in the west-most cell and tries to get");
            Console.WriteLine("to the east-most cell which contains the dungeon exit.");
            Console.WriteLine("A successful exit from the final cell wins the game.");
            Console.WriteLine("Along the way, each cell may have a monster that must be defeated.");
            Console.WriteLine("One cell contains a weapon which may be used on the monsters, if any.");

            Console.WriteLine("\nThe game continues until the player is defeated by a monster");
            Console.WriteLine("or until the player successfully exits the dungeon.");
            Console.WriteLine("In each cell, a player may move one cell to the east or one");
            Console.WriteLine("to the west, if there is an exit in that direction.");
            Console.WriteLine("-----------------------------------\n");
        }

        /// <summary>
        /// Displays the dungeon positions.
        /// </summary>
        /// <param name="MyDungeon">The dungeon object to display.</param>
        public static void ShowDungeon(Dungeon MyDungeon)
        {
            Console.WriteLine(MyDungeon);
        }

        /// <summary>
        /// Handles combat between player and monster.
        /// </summary>
        /// <param name="MyPlayer">The player object that is in combat.</param>
        /// <param name="monster">The monster object that is in combat.</param>
        public static void Combat(Player MyPlayer, Monster monster)
        {
            bool Fighting = true;

            Console.WriteLine("\nThere is a monster here - and the fight begins");

            while (Fighting == true)
            {
                int PlayerDamage = MyPlayer.DealDamage();

                if (MyPlayer.PlayerHealth <= 0)
                {
                    Console.WriteLine("You have been defeated.");
                    Fighting = false;
                }
                else
                {
                    if (PlayerDamage == 0)
                    {
                        Console.WriteLine("Player Missed");
                    }
                    else
                    {
                        monster.TakeDamage(PlayerDamage);
                        if (monster.MonsterHealth <= 0)
                        {
                            Console.WriteLine("The Monster has been slain\n");
                            Fighting = false;
                        }
                        else
                        {
                            Console.WriteLine("Monster was hit: points = " + monster.MonsterHealth);
                        }
                    }
                    if (monster.MonsterHealth > 0)
                    {
                        int MonsterDamage = monster.DealDamage();
                        if (MonsterDamage == 0)
                        {
                            Console.WriteLine("Monster Missed");
                        }
                        else
                        {
                            MyPlayer.TakeDamage(MonsterDamage);
                            Console.WriteLine("Player was hit by the monster : points = " + MyPlayer.PlayerHealth);
                        }
                    }
                }
            }
        }
    }
}
