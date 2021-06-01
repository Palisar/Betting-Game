using System;

namespace Betting_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            double odds = 0.75;
            string oddsString;
            Random random = new Random();
            string howMuch;

            Guy player = new Guy() { Cash = 100, Name = "The player" };
            Console.WriteLine("Welcome to the Casino.");
            
            while (player.Cash > 0 )
            {
                player.WriteMyInfo();
                
              
                Console.WriteLine("The Odds are " + odds);
                Console.Write("How much do you want to bet: ");
                howMuch = Console.ReadLine();
                if(int.TryParse(howMuch, out int amount))
                {
                    if (player.Cash >= amount)
                    {
                        player.GiveCash(amount);
                        int pot = amount * 2;
                        if (random.NextDouble() < odds)
                        {
                            player.ReceiveCash(pot);
                            Console.WriteLine("You win " + pot);
                        }
                        else
                        {
                            Console.WriteLine("Bad luck, you lose.");
                        }
                        oddsString = random.NextDouble().ToString("0.00");
                        odds = Convert.ToDouble(oddsString);
                    }
                    else
                    {
                        Console.WriteLine("Please enter an amount you can afford...");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid number...");
                }
            }

            Console.WriteLine("The house always wins");
        }
    }
}
