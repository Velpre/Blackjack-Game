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
			int randomNr = random.Next(1, 14);
			playerScore.Add(randomNr);
			return randomNr;
		}

		public int TotalScore()
		{
			int totalScore = playerScore.Aggregate((a, b) => a + b);
			return totalScore;
		}


	}
}
