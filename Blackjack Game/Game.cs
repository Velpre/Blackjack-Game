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
				switch (choosenOption) {
					case "h":
						//Player logic
						Console.WriteLine("Your new card is " + player.RandomeCard());
						Console.WriteLine("Your current score is " + player.TotalScore());

						choosenOption = HitOrStay();
						break;
					case "s":
						//EndGame logic
						int playerTotal = player.TotalScore();
						int dealerTotal = dealer.TotalScore();


						CalculateWinner(playerTotal, dealerTotal);

						Console.WriteLine("Total:");
						Console.WriteLine("You:" + playerTotal);
						Console.WriteLine("Dealer:" + dealerTotal);

						runGame = false;
						break;
					default:
						Console.WriteLine("Game over");
						break;
				}

			}
		}


		void CalculateWinner(int playerScore, int dealaerScore)
		{

			if (playerScore > 21 && dealaerScore > 21) {
				Console.WriteLine("Draw");
			}
			else if (playerScore == dealaerScore) {
				Console.WriteLine("Draw");
			}
			else if (playerScore > 21) {
				Console.WriteLine("Dealer wins");
			}
			else if (dealaerScore > 21) {
				Console.WriteLine("You wins");
			}
			else if (playerScore > dealaerScore) {
				Console.WriteLine("You win");
			}
			else if (playerScore < dealaerScore) {
				Console.WriteLine("Dealer wins");
			}
		}
		


	}
}
