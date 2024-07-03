//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Project:         Project 5 - Zork
// File Name:       Dungeon.cs
// Description:     Implementation of a dungeon class that contains methods for player movement, constructors, and to string method.
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
    /// Implementation of a dungeon class that contains methods for player movement.
    /// </summary>
    public class Dungeon
    {

        /// <summary>
        /// Property to get the current position in the dungeon.
        /// </summary>
        public int CurrentPosition { get; private set; }

        /// <summary>
        /// Property to get the size of the dungeon.
        /// </summary>
        public int Size { get; private set; }

        /// <summary>
        /// Property to get the current cell in the dungeon.
        /// </summary>
        public Cell[] Cells { get; private set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Dungeon()
        {
            Size = 5;
        }

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="size"></param>
        public Dungeon(int size)
        {
            Size = size;
            Cells = new Cell[Size];
            CurrentPosition = 0;
        }

        /// <summary>
        /// Allows the player to move to the left.
        /// </summary>
        public void GoWest()
        {
            Cells[CurrentPosition] = new Cell();
            CurrentPosition -= 1;
            Cells[CurrentPosition] = new Cell(new Player(), null);
        }

        /// <summary>
        /// Allows the player to move to the right.
        /// </summary>
        /// <param name="player">The player object to move.</param>
         public void GoEast(Player player)
        {
            CurrentPosition += 1;
            Cells[CurrentPosition - 1] = new Cell();
            Cells[CurrentPosition] = new Cell(player, null);
        }

        /// <summary>
        /// Puts the dungeon cells in a readable format.
        /// </summary>
        /// <returns>The formatted string containing the dungeon cells.</returns>
        public override string ToString()
        {
            string info = "";
            for (int i = 0; i < Cells.Length; i++)
            {
                info += Cells[i].ToString();
            }
            return info;
        }
    }
}
