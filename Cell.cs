//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Project:         Project 5 - Zork
// File Name:       Cell.cs
// Description:     Implementation of a Cell class that will add cells to the dungeon.
// Course:          CSCI 1260-001 – Introduction to Computer Science II
// Author:          Noah Drumwright, Jarren Bess, Drumwrightn@etsu.edu, bessjb@etsu.edu, Department of Computing, East Tennessee State University
// Created:         Tuesday, November 29, 2022
// Copyright:       Noah Drumwright, Jarren Bess, 2022
//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
namespace Project5Zork
{
    /// <summary>
    /// Implementation of a Cell class that will add cells to the dungeon.
    /// </summary>
    public class Cell
    {

        private string s_participant;
        private string s_weapon;
        private Participant participants;
        private Monster monsters;

        /// <summary>
        /// Property to get the current weapon in the dungeon.
        /// </summary>
        public Weapon weapons { get; private set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Cell()
        {
            s_participant = "_";
            s_weapon = "_";
        }

        /// <summary>
        /// Parameterized constructor.
        /// </summary>
        /// <param name="participant">Participant object passed in.</param>
        /// <param name="weapon">Weapon objcet passed in.</param>
        public Cell(Participant participant, Weapon weapon)
        {
            participants = participant;
            weapons = weapon;

            bool MonsterPresent = false;

            if (participants is Player)
            {
                s_participant = "P";
            }
            else if (participants is Monster)
            {
                s_participant = "M";
                MonsterPresent = true;
            }
            else if (participants == null)
            {
                s_participant = "_";
            }

            if (weapon is Stick)
            {
                s_weapon = "St";

            }
            else if (weapon is Sword)
            {
                s_weapon = "Sw";

            }
            else if (weapon == null)
            {
                s_weapon = "_";
            }
        }

        /// <summary>
        /// Gets the type of weapon.
        /// </summary>
        /// <returns>The type of weapon that the object is.</returns>
        public Weapon GetWeapon()
        {
            return weapons;
        }
        public Participant GetParticipant()
        {
            return participants;
        }
        public Monster GetMonster()
        {
            return monsters;
        }

        /// <summary>
        /// Fill the dungeon cells with randomly generated monsters.
        /// </summary>
        /// <returns>The cell and its contents.</returns>
        public Cell FillCells()
        {
            bool MonsterPresent = false;

            Cell MyCell = null;

            Random Add = new Random();
            if (Add.Next(0, 100) < 50)
            {
                MonsterPresent = true;
            }
            else
            {
                MonsterPresent = false;
            }

            if (MonsterPresent == true)
            {
                MyCell = new Cell(new Monster(), null);
            }
            else
            {
                MyCell = new Cell();
            }

            return MyCell;
        }

        /// <summary>
        /// Puts the participant and weapon object in a readable format.
        /// </summary>
        /// <returns>The formatted string containing the participant and weapon.</returns>
        public override string ToString()
        {
            string info = "";
            info += $"|{s_participant}___{s_weapon}| ";
            return info;
        }
    }
}