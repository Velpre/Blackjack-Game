using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_Game
{
	internal class Player : IBlackJack
	{
		
		public List<int> playerScore = new List<int>();


		public Player()
		{
			RandomeCard();
			RandomeCard();
		}	

		public int RandomeCard()
		{
			Random random = new Random();
			int randomNr = random.Next(2, 12);

			playerScore.Add(randomNr);
			return randomNr;
		}

		public int TotalScore()
		{
			int totalScore = playerScore.Aggregate((a, b) => a + b);
			
			if (totalScore > 21) {

				int newScore = 0;

				foreach (var number in playerScore) {
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
