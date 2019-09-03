using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseRacr
{
    class Winner
    {
        //global variable of class that are used to verify the winner 
        public int Amount;
        public int Horse;
        public Buddies Bettor;
        //constructor method of the class so thus the local value can be pass to global variables
        public Winner(int Amount, int Horse, Buddies Bettor)
        {
            this.Amount = Amount;
            this.Horse = Horse;
            this.Bettor = Bettor;
        }

        // get description is another method that is used to verify the amount after winning or lossing the bet 
        public string GetDescription()
        {
            string description = "";

            if (Amount > 0)
            {
                description = String.Format("{0} bets {1} on Horse #{2}",
                    Bettor.playerName, Amount, Horse);
            }
            else
            {
                description = String.Format("{0} hasn't placed any bets",
                    Bettor.playerName);
            }
            return description;
        }

        // it will generate the pay after winning or lossing the bet 
        public int PayOut(int Winner)
        {
            if (Horse == Winner)
            {
                return Amount;
            }
            return -Amount;
        }
    }
}
