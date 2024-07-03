//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Project:         Project 5 - Zork
// File Name:       Participant.cs
// Description:     Implementation of an abstract participant class that will provide methods for participant objects.
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
    /// Implementation of an abstract participant class that will provide methods for participant objects.
    /// </summary>
    public abstract class Participant
    {
        protected string Name;
        protected int Health;
        protected int Damage;

        /// <summary>
        /// Method signature for the deal damage method.
        /// </summary>
        /// <returns>The amount of damage the participant will do.</returns>
        public abstract int DealDamage();

        /// <summary>
        /// Method signature for the damage taken method.
        /// </summary>
        /// <param name="DamageTaken">The amount of damage the participant has taken.</param>
        public abstract void TakeDamage(int DamageTaken);
    }
}
