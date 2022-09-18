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
		public List<int> dealerCards = new List<int>();


		public int RandomeCard()
		{
			Random random = new Random();
			int randomNr = random.Next(2, 12);

			dealerCards.Add(randomNr);
			return randomNr;
		}

		//Giving all cards to dealer - total score must be over 17
		public void GiveDealerCards()
		{
			int totalScore = TotalScore();

			while (totalScore < 17) {
				RandomeCard();
				totalScore = TotalScore();
			}
		}

		public int TotalScore()
		{
			int totalScore = dealerCards.Aggregate((a, b) => a + b);

			if (totalScore > 21) {

				int newScore = 0;

				foreach (var number in dealerCards) {
					if (number == 11) {
						newScore = newScore + 1;
					}
					else {
						newScore = newScore + number;
					}
				}
				return newScore;
			}
			else {
				return totalScore;
			}
		}


	}
}
