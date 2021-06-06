using System;
using System.Collections.Generic;
using System.Threading;

namespace Betting_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] odds;
            string oddsString;
            string howMuch;
            string players;
            int playerCount = 0;
            int result;
            int[] betArr;
            
            Random random = new Random();

            int RollTheDice(int bet, double odds)
            {
                if (random.NextDouble() > odds)
                {
                    return 0;
                }
                else
                {
                    
                    return bet *= 2;
                }
            }


            // ------------------------------ TITLE LOOP ------------------------------ 

            Console.WriteLine("Welcome to the Casino.");

            //do loop to get a valid number from 1 - 4 of players to play this multiplayer game
            do
            {
                Console.Write("How many Players(1-4): ");
                players = Console.ReadLine();
                if (int.TryParse(players, out int count))
                {
                    if (count > 4 || count < 1 )
                    {
                        Console.WriteLine("Invalid Player number.");
                    }
                    else
                    {
                       playerCount = count;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Player number.");
                }

            } while (playerCount < 1 || playerCount > 4);

            //Creates a List of player objects equel to the player count
            // and also creates an array to store the players bets
            List<Player> playerList = new List<Player>() ;
            betArr = new int[playerCount];
            odds = new double[playerCount];

            //goes to each index of the array and creates a player with a name and gives them $100 in cash to start with
            for (int i = 0; i < playerCount; i++ )
            {
                Console.Write("Player " + (i + 1) + " please enter your name: ");
                playerList.Add(new Player() {Name = Console.ReadLine(), Cash = 100  });

                Console.WriteLine("Hello " + playerList[i].Name + " You have got $" + playerList[i].Cash);
            }



            // ------------------------------ MAIN GAME LOOP ------------------------------
            while (playerCount > 0 )
             {

                Console.Clear();
                // this loops if for placing the bets
                for (int i = 0; i < playerList.Count ; i++)
                {
                    //removes player when they run out of cash
                    if (playerList[i].Cash == 0)
                    {
                        Console.WriteLine("\n" + playerList[i].Name + " is out of cash. Bad luck.");
                        playerList.RemoveAt(i);
                        playerCount--;
                        break;
                    }

                    //sets the odds for each player
                    oddsString = random.NextDouble().ToString("0.00");
                    odds[i] = Convert.ToDouble(oddsString);
                    Console.WriteLine("\n" + playerList[i].Name + " your odds are " + odds[i]);

                    //takes the bets
                    playerList[i].WriteMyInfo();
                    Console.Write(playerList[i].Name + " how much will you bet: ");
                    howMuch = Console.ReadLine();

                    if (int.TryParse(howMuch, out int amount))
                    {

                        betArr[i] = playerList[i].GiveCash(amount);
                        Console.WriteLine(playerList[i].Name + " has bet " + betArr[i]);
                        if (betArr[i] == 0)
                        {
                            i--;
                            Console.WriteLine("You cannot bet 0...");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid number...");
                        i--;
                    }
                    
                }
                
                for(int k = 0; k < playerList.Count; k++)
                {
                   result = RollTheDice(betArr[k], odds[k]);
                    if (result == 0)
                    {
                        Console.WriteLine("\n Bad luck " + playerList[k].Name + ". You loose " + betArr[k]);
                    }
                    else
                    {
                        Console.WriteLine("\n Congradulations " + playerList[k].Name + ". You win " + result);
                        playerList[k].ReceiveCash(result);
                        
                    }
                }

                Thread.Sleep(2000);
                /*

              
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
              */
             }
            Console.Clear();
            Console.WriteLine("The house always wins");
        }
    }
}
