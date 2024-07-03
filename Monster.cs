//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Project:         Project 5 - Zork
// File Name:       Monster.cs
// Description:     Implementation of a monster class that will create monster objects that inherit from the participant class.
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
    /// Implementation of a monster class that will create monster objects that inherit from the participant class.
    /// </summary>
    public class Monster : Participant
    {

        /// <summary>
        /// Property to get the health of the monster.
        /// </summary>
        public int MonsterHealth { get; private set; }
        private string MonsterName;
        private int MonsterDamage;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Monster()
        {
            Name = "M";
            MonsterHealth = 20;
            MonsterDamage = 4;
        }

        /// <summary>
        /// Parameterized constructor.
        /// </summary>
        /// <returns>A randomly generated monster object or null.</returns>
        public Monster RandomMonster()
        {
            Random randMonster = new Random();
            Monster monster = new Monster();
            monster = randMonster.Next(0, 100) > 49 ? new Monster() : null;
            return monster;
        }

        /// <summary>
        /// Randomly generated monster damage with 20% miss rate.
        /// </summary>
        /// <returns>The amount of damage dealt.</returns>
        public override int DealDamage()
        {
            int DamageDealt = 0;

            Random Hit = new Random();
            if (Hit.Next(1, 101) < 80)
            {
                DamageDealt = MonsterDamage;
            }

            return DamageDealt;
        }

        /// <summary>
        /// The amount of damage the monster takes from the player.
        /// </summary>
        /// <param name="DamageTaken">The amount of damage taken from the player.</param>
        public override void TakeDamage(int DamageTaken)
        {
            MonsterHealth -= DamageTaken;
        }
    }
}