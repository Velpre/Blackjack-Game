using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_Game
{
	internal class Game
	{
		Player player = new();
		Dealer dealer = new();
		Print printer = new Print();

		int playerTotalScore;
		String choosenOption; 
		Boolean runGame = true;

		public Game()
		{
			playerTotalScore = player.TotalScore();
			printer.PrintIntro(player.playerCards[0], player.playerCards[1], playerTotalScore, dealer.dealerCards[0]);
			choosenOption = printer.PrintHitOrStay();
			run();

		}



		public void run()
		{
			while (runGame) {
				int dealerTotal = dealer.TotalScore();
				
				switch (choosenOption) {
					case "h":
						//New card logic
						int newCard = player.RandomeCard();
						Console.WriteLine("Your new card is " + newCard);
						playerTotalScore = player.TotalScore();

						if (playerTotalScore > 21) {
							CalculateWinner(playerTotalScore, dealerTotal);
							break;
						}

						Console.WriteLine("Your current score is " + playerTotalScore);
						choosenOption = printer.PrintHitOrStay();
						break;
					case "s":
						//EndGame logic
						playerTotalScore = player.TotalScore();
						CalculateWinner(playerTotalScore, dealerTotal);
						break;
					default:
						Console.WriteLine("Game over");
						runGame = false;
						break;
				}

			}
		}


		void CalculateWinner(int playerScore, int dealaerScore)
		{

			Console.WriteLine("");
			Console.WriteLine("Total:");
			Console.WriteLine("You:" + playerScore);
			Console.WriteLine("Dealer:" + dealaerScore);
			Console.WriteLine("");

			if (playerScore > 21 && dealaerScore > 21) {
				Console.WriteLine("Draw");
				runGame = false;
			}
			else if (playerScore == dealaerScore) {
				Console.WriteLine("Draw");

				runGame = false;
			}
			else if (playerScore > 21) {
				Console.WriteLine("Dealer wins");

				runGame = false;
			}
			else if (dealaerScore > 21) {
				Console.WriteLine("You wins");

				runGame = false;
			}
			else if (playerScore > dealaerScore) {
				Console.WriteLine("You win");

				runGame = false;
			}
			else if (playerScore < dealaerScore) {
				Console.WriteLine("Dealer wins");

				runGame = false;
			}
		}
		


	}
}
