using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Blackjack_Game
{
	internal class Dealer : IBlackJack
	{
		public List<int> dealerScore = new List<int>();

		public Dealer()
		{
			RandomeCard();
			int totalScore = TotalScore();

			while (totalScore < 17) {
				totalScore = TotalScore();
				RandomeCard();
			}
		}


		public int RandomeCard()
		{
			Random random = new Random();
			int randomNr = random.Next(1, 14);
			dealerScore.Add(randomNr);
			return randomNr;
		}
		public int TotalScore()
		{
			int totalScore = dealerScore.Aggregate((a, b) => a + b);
			return totalScore;
		}
	
	}
}
