//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Project:         Project 5 - Zork
// File Name:       Weapon.cs
// Description:     Implementation of a weapon class that contains fields and methods for weapon objects.
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
    /// Implementation of a weapon class that contains fields and methods for weapon objects.
    /// </summary>
    public class Weapon
    {
        public string Name;
        public int Damage;

        /// <summary>
        /// Randomly generates what type of weapon object to create.
        /// </summary>
        /// <returns>The type of weapon object created.</returns>
        public Weapon randomWeapon()
        {
            Random randWeapon = new Random();
            Weapon weapon = randWeapon.Next(0, 100) > 49 ? new Sword() : new Stick();
            return weapon;
        }
    }
}
