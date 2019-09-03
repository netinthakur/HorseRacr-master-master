using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HorseRacr
{
    class Buddies
    {
        //string variable for getting the name of the player
        public string playerName;
        // bet object of the bet variable
        public Winner MyBet;
        //integer variable of the class for getting the cash 
        public int playerCash;

        public CheckBox objcheckBox;

        public Label MyLabel;

        public Buddies(string Name, Winner MyBet, int Cash, CheckBox objcheckBox, Label MyLabel)
        {
            //passing the local value to global  variable using this keyword

            this.playerName = Name;
            this.MyBet = MyBet;
            this.playerCash = Cash;
            this.objcheckBox = objcheckBox;
            this.MyLabel = MyLabel;
        }

        // this method is used to update the label is that which one player has set the bet on which horse and how much amount
        public void UpdateLabels()
        {
            //if the user has not set any bet then it will display no one has set the bet 
            if (MyBet == null)
            {
                MyLabel.Text = String.Format("{0} hasn't placed any bets", playerName);
            }
            else
            {
                // if any player set the bet then it will call the another method to print his name and horse no also
                MyLabel.Text = MyBet.GetDescription();
            }
            objcheckBox.Text = playerName + " has " + playerCash + " Amount ";
        }
        //it is used to clear the amount of the bet after completion the race
        public void ClearBet()
        {
            //pass the value to the numeric object 
            MyBet.Amount = 0;
        }
        //another boolean method that is used for set the bet so thus get the amount using arguments
        public bool PlaceBet(int Amount, int Horse)
        {
            if (Amount <= playerCash)
            {
                MyBet = new Winner(Amount, Horse, this);
                return true;
            }
            return false;
        }
        //this method is used for collection of the player if he is winer than it will increment in his account 
        public void Collect(int Winner)
        {
            playerCash += MyBet.PayOut(Winner);
        }
    }
}
