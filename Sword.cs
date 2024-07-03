//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Project:         Project 5 - Zork
// File Name:       Sword.cs
// Description:     Implementation of a sword class that inherits from the weapon class.
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
    /// Implementation of a sword class that inherits from the weapon class.
    /// </summary>
    public class Sword : Weapon
    {
        /// <summary>
        /// Name property to get the name of the weapon.
        /// </summary>
        public string Name { get; private set; }
        public int damage;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Sword()
        {
            base.Name = "Sword";
            Damage = 3;
        }
    }
}