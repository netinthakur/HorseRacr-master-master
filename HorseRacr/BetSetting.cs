using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseRacr
{
    class BetSetting
    {
        // boolean function that is used to verify the bet amount and the name of the player this method has 2 arguments like name and amount so thus it can easily verify 
        public Boolean betAmountVerify(String Name, int Amount) {
            //To verify the name and amount we can use simple-if or ladder-if here we used ladder-if to check the amount and name and return true or false according to condition
            if (Name.Equals("Harpreet") &&  Amount >= 1)
            {
                return true;
            }
            else if (Name.Equals("Joban") &&  Amount >= 1)
            {
                return true;
            }
            else if (Name.Equals("Happy") &&  Amount >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
