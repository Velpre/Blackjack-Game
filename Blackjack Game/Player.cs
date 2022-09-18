using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_Game
{
	internal class Player : IBlackJack
	{
		
		public List<int> playerCards = new List<int>();



		public int RandomeCard()
		{
			Random random = new Random();
			int randomNr = random.Next(2, 12);

			playerCards.Add(randomNr);
			return randomNr;
		}

		public int TotalScore()
		{
			int totalScore = playerCards.Aggregate((a, b) => a + b);
			
			if (totalScore > 21) {

				int newScore = 0;

				foreach (var number in playerCards) {
					if(number == 11) {
						newScore = newScore + 1;
					}else {
						newScore = newScore + number;
					}
				}
				return newScore;
			}else {
				return totalScore;
			}
		}

	}
}
