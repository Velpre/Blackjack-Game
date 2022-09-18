using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_Game
{
	internal class Round
	{


		public Round(Player player, Dealer dealer)
		{

			//Clear the lists
			dealer.dealerCards.Clear();
			player.playerCards.Clear();

			//Giving 2 starting cards to Player
			player.RandomeCard();
			player.RandomeCard();

			//Giving cards to Dealer
			dealer.RandomeCard();
			dealer.GiveDealerCards();

		}

	}
}
