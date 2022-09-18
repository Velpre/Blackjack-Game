using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_Game
{
	internal class Game
	{
		int roundCounter = 0;
		int playerRoundsScore = 0;
		int dealerRoundsScore = 0;

		Boolean runGame = true;

		//Objects
		Print printer = new Print();
		Player player = new();
		Dealer dealer = new();

		public void NewRound()
		{
		
			Round currentRound = new(player, dealer);
			roundCounter++;

			Console.WriteLine("Round: " + roundCounter);

			if (roundCounter >= 2) {
				Console.WriteLine("");
				Console.WriteLine("Resault:");
				Console.WriteLine("You: " + playerRoundsScore);
				Console.WriteLine("Dealer: " + dealerRoundsScore);
				Console.WriteLine("");

			}

			int playerTotalScore;
			String choosenOption;

			playerTotalScore = player.TotalScore();
			printer.PrintIntro(player.playerCards[0], player.playerCards[1], playerTotalScore, dealer.dealerCards[0]);
			choosenOption = printer.PrintHitOrStay();
			
			
			while (runGame) {
				int dealerTotalScore = dealer.TotalScore();
				
				switch (choosenOption) {
					case "h":
						//New card logic
						int newCard = player.RandomeCard();
						Console.WriteLine("Your new card is " + newCard);
						playerTotalScore = player.TotalScore();

						if (playerTotalScore >= 21) {
							CalculateWinner(playerTotalScore, dealerTotalScore, currentRound);
							PlayNewRound();
							runGame = false;
							break;
						}

						Console.WriteLine("Your current score is " + playerTotalScore);
						choosenOption = printer.PrintHitOrStay();
						break;
					case "s":
						//Ending Round logic
						playerTotalScore = player.TotalScore();
						CalculateWinner(playerTotalScore, dealerTotalScore, currentRound); //Calculating winner of this round
						PlayNewRound(); //Checking if player want to play more
						runGame = false;
						break;
					default:
						Console.WriteLine("Game over");
						runGame = false;
						break;
				}
			}
		}



		void PlayNewRound()
		{
			Console.WriteLine(" ");
			Console.WriteLine("Would you like to play new round:");
			Console.WriteLine("y) Yes");
			Console.WriteLine("n) No");
			String choosenOption = Console.ReadLine();

			switch (choosenOption) {
				case "y":
					Console.WriteLine(".............................................");
					Console.WriteLine("This is new round");
					Console.WriteLine(" ");

				
					NewRound();
					break;
				case "n":
					Console.WriteLine(" ");
					Console.WriteLine("Thank you for playing");
					break;
				default:
					Console.WriteLine(" ");
					Console.WriteLine("That is not valid option. Game over");
					break;
			}
			
		}


		void CalculateWinner(int playerScore, int dealaerScore, Round currentRound)
		{

			Console.WriteLine("");
			Console.WriteLine("Total in this round:");
			Console.WriteLine("You:" + playerScore);
			Console.WriteLine("Dealer:" + dealaerScore);
			Console.WriteLine("");

			if (playerScore > 21 && dealaerScore > 21) {
				Console.WriteLine("Draw");
				
			}
			else if (playerScore == dealaerScore) {
				Console.WriteLine("Draw");

			}
			else if (playerScore > 21) {
				Console.WriteLine("Dealer wins");
				dealerRoundsScore++;

			}
			else if (dealaerScore > 21) {
				Console.WriteLine("You wins");
				playerRoundsScore++;
			}
			else if (playerScore > dealaerScore) {
				Console.WriteLine("You win");
				playerRoundsScore++;
			}
			else if (playerScore < dealaerScore) {
				Console.WriteLine("Dealer wins");
				dealerRoundsScore++;

			}

		}

	}
}
