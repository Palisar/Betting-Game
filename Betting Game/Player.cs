using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betting_Game
{
    class Player
    {
        public string Name ="";
        public int Cash;

        /// <summary>
        /// Writes my name and the amount of cash i have to the console.
        /// </summary>
        public void WriteMyInfo()
        {
            Console.WriteLine(Name + " has " + Cash + " bucks.");
        }

        /// <summary>
        /// Gives some of my cash, removit it from my wallet (or printing a message to the console 
        /// if i dont have enough cash).
        /// </summary>
        /// <param name="amount">Amount of cash to give.</param>
        /// <returns>The amount of cash removed from my wallet, or 0 if I don't have enough cash (or the amount is invalid).
        /// </returns>
        public int GiveCash(int amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine(Name + " says: " + amount + " isn't a valid amount.");
                return 0;
            }
            if (amount > Cash)
            {
                Console.WriteLine(Name + " says: " + "I don't have enough cash to give you " + amount);
                return 0;
            }
            Cash -= amount;
            return amount;
        }

        /// <summary>
        /// Receive some cash, adding it to my wallet ( or printing 
        /// a message to the console if the amount is invalid).
        /// </summary>
        /// <param name="amount">Amount of cash to give.</param>
        public void ReceiveCash(int amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine(Name + " says: " + amount + " isn't an amount I'll take");
            }
            else
            {
                Cash += amount;
            }
        }
    }
}
