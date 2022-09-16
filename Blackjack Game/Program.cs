using System;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;

namespace Blackjack_Game
{
	internal class Program
	{
		static void Main(string[] args)
		{

			Player player = new();
			Dealer dealer = new();

			Console.WriteLine("You: " + player.playerScore[0] + " & " + player.playerScore[1]);
			Console.WriteLine("Your current score is " + player.TotalScore());

			Console.WriteLine("Dealer: " + player.playerScore[0] + " &  XXX" );


			//Giving options for user HitOrStay or Stay
			String choosenOption = HitOrStay();
			Boolean runGame = true;


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
						Console.WriteLine("You:" + player.TotalScore());
						Console.WriteLine("Dealer:" + dealer.TotalScore());
						runGame = false;
						break;
					default:
						Console.WriteLine("Game over");

						break;
				}

			}



			String HitOrStay()
			{
				Console.WriteLine(" ");
				Console.WriteLine("Choose option:");
				Console.WriteLine("h) Hit");
				Console.WriteLine("s) Stay");
				String choosenOption = Console.ReadLine();
				return choosenOption;
			}
		}
	}
}
