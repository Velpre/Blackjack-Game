using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_Game
{
	internal class Print
	{
		public void PrintIntro(int card1, int card2, int totalScore, int dealerCard)
		{

			Console.WriteLine("You: " + card1 + " & " + card2);
			Console.WriteLine("Your current score is " + totalScore);
			Console.WriteLine("Dealer: " + dealerCard + " &  XXX");

		}

		public String PrintHitOrStay()
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
