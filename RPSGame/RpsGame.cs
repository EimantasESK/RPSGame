using System;
using System.Collections.Generic;
using System.Text;

namespace RPSGame
{
    class RpsGame
    {
        private string RockGraphic = @"    _______
---'   ____)
      (_____)
      (_____)
      (____)
---.__(___)";
        private string ScissorsGraphic = @"    _______
---'   ____)____
          ______)
        __________)
      (____)
---.__(___)";
        private string PaperGraphic = @"    _______
---'   ____)____
          ______)
          _______)
          _______)
---.__________)";
        private string ErrorGraphic = @"  ___ _ __ _ __ ___  _ __ 
/ _ \ '__| '__/ _ \| '__|
|  __/ |  | | | (_) | |   
\___|_|  |_|  \___/|_|";
        public void Play()
        {
            Console.Title = "=== RPS Game ===";
            Console.WriteLine("Let's play some RPS!");

            Console.WriteLine("Please choose: rock, paper or scissors?");
            string playerMove = Console.ReadLine().Trim().ToLower();

            if (playerMove != "rock" && playerMove != "paper" && playerMove != "scissors")
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("You entered something wrong");
                Console.WriteLine(ErrorGraphic);
                PlayAgain();
            }
            else
            {
                string[] choise = { "rock", "paper", "scissors" };
                Random rng = new Random();
                int computerMoveNumber = rng.Next(0, choise.Length);
                string computerMove = choise[computerMoveNumber];

                Console.WriteLine($"\nYou played: {playerMove}...");
                DisplayMoveGraphic(playerMove);

                Console.WriteLine($"\nComputer move: {computerMove}...");
                DisplayMoveGraphic(computerMove);

                if ((computerMove == "rock" && playerMove == "paper")
                    || (computerMove == "paper" && playerMove == "scissors")
                    || (computerMove == "scissors" && playerMove == "rock"))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nYou win!");
                }
                else if (computerMove == playerMove)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nThis is a draw! Try again");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\nYou lose :(");
                }

                PlayAgain();
            }

        }
        private void DisplayMoveGraphic(string move)
        {
            if (move == "rock") Console.WriteLine(RockGraphic);
            else if (move == "paper") Console.WriteLine(PaperGraphic);
            else if (move == "scissors") Console.WriteLine(ScissorsGraphic);
        }

        private void PlayAgain()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nWould you like to play again? (y/n)");
            string playResponse = Console.ReadLine().Trim().ToLower();
            if (playResponse == "y")
            {
                Console.Clear();
                Play();
            }
            else
            {
                Console.WriteLine("Ok, see you next time :)");
            }
        }
    }
}
