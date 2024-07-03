//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Project:         Project 5 - Zork
// File Name:       Player.cs
// Description:     Implementation of a player class that inherits from participant and uses its methods.
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
    /// Implementation of a player class that inherits from participant and uses its methods.
    /// </summary>
    public class Player : Participant
    {

        /// <summary>
        /// Property to get the health of the player.
        /// </summary>
        public int PlayerHealth { get; private set; }
        private string PlayerName;
        private int PlayerDamage;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Player()
        {
            Name = "P";
            PlayerHealth = 100;
            PlayerDamage = 5;
        }

        /// <summary>
        /// The amount of damage the player will deal.
        /// </summary>
        /// <returns>The amount of damage the player will do.</returns>
        public override int DealDamage()
        {
            int DamageDealt = 0;

            Random Hit = new Random();
            if (Hit.Next(1, 101) < 90)
            {
                DamageDealt += PlayerDamage;
            }
            else
            {
                DamageDealt = 0;
            }

            return DamageDealt;
        }

        /// <summary>
        /// Subtracts health points from the player.
        /// </summary>
        /// <param name="DamageTaken">The damage dealt to the player.</param>
        public override void TakeDamage(int DamageTaken)
        {
            PlayerHealth -= DamageTaken;
        }

        /// <summary>
        /// Increases the attack damage of the player.
        /// </summary>
        /// <param name="weapon">The type of weapon the player finds.</param>
        public void EquipWeapon(Weapon weapon)
        {
            int WeaponDamage;
            Weapon EquippedWeapon = weapon;

            if (EquippedWeapon is Sword)
            {
                WeaponDamage = ((Sword)EquippedWeapon).Damage;
                PlayerDamage += WeaponDamage;
            }
            if (EquippedWeapon is Stick)
            {
                WeaponDamage = ((Stick)EquippedWeapon).Damage;
                PlayerDamage += WeaponDamage;
            }
        }
    }
}

