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

		String choosenOption; 
		Boolean runGame = true;

		public Game()
		{
			Console.WriteLine("You: " + player.playerScore[0] + " & " + player.playerScore[1]);
			Console.WriteLine("Your current score is " + player.TotalScore());
			Console.WriteLine("Dealer: " + player.playerScore[0] + " &  XXX");
			choosenOption = HitOrStay();
			run();

		}

		public String HitOrStay()
		{
			Console.WriteLine(" ");
			Console.WriteLine("Choose option:");
			Console.WriteLine("h) Hit");
			Console.WriteLine("s) Stay");
			String choosenOption = Console.ReadLine();
			return choosenOption;
		}

		public void run()
		{
			while (runGame) {
				int dealerTotal = dealer.TotalScore();
				int playerTotal;

				switch (choosenOption) {
					case "h":
						//New card logic
						int newCard = player.RandomeCard();
						Console.WriteLine("Your new card is " + newCard);
						playerTotal = player.TotalScore();

						if (playerTotal > 21) {
							CalculateWinner(playerTotal, dealerTotal);
							break;
						}

						Console.WriteLine("Your current score is " + playerTotal);
						choosenOption = HitOrStay();
						break;
					case "s":
						//EndGame logic
						playerTotal = player.TotalScore();
						CalculateWinner(playerTotal, dealerTotal);

						break;
					default:
						Console.WriteLine("Game over");
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
