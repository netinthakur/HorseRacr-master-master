using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HorseRacr
{
    public partial class Form1 : Form
    {
        /*object of other class that are used to call the method of class according to
            requirement object of betsetting class that is used to check the name of player and verify the amount respectively
        */
        BetSetting objbetSetting = new BetSetting();
        /*
                object of game class that is used to move the picture box from one location to another and also move the position of horse
                to starting point

             */
        Game[] objgame= new Game[3];

        /*
         
            buddies class is used for player specially to set the amount or bet amount so thus the player can set his bet 
             */
        Buddies[] objBuddies = new Buddies[3];

        // global variable that are used count and get the amount to pass the value to another class
        int ct = 0,Amount=0;
        

        public Form1()
        {
            InitializeComponent();

            // get the position of the Race Track set starting point using the local variable of startposition
            int startPosition = pbHorse1.Right - track.Left;

            /*get the width of the of the reacetrack to get the ending point position of the track
            for getting the winner with the help of racetrackLength
            */
            int raceTrackLength =track.Size.Width;

            //pass the value to game class using the object 
            objgame[0] = new Game()
            {
                objPictureBox = pbHorse1,
                RacetrackLength = raceTrackLength,
                Position = startPosition
            };
            objgame[1] = new Game()
            {
                objPictureBox = pbHorse2,
                RacetrackLength = raceTrackLength,
                Position = startPosition
            };
            objgame[2] = new Game()
            {
                objPictureBox = pbHorse3,
                RacetrackLength = raceTrackLength,
                Position = startPosition
            };



            //pass the name of  the players and money to recpectively buddies class
            objBuddies[0] = new Buddies("Harpreet", null, 50, chkHarpreet, lblHarpreet);
            objBuddies[1] = new Buddies("Joban", null, 50, chkJoban,lblJoban);
            objBuddies[2] = new Buddies("Happy", null, 50, chkHappy, lblHappy);


            // this foreach loop is used for printing the name of players on label using the object of Guy class with the help of object
            foreach (Buddies guy in objBuddies)
            {
                guy.UpdateLabels();
            }



        }

        private void chkHarpreet_CheckedChanged(object sender, EventArgs e)
        {
            //pass the value to label after selecting the check box
            if (chkHarpreet.Checked == true){
                lblPlayer.Text = "Harpreet";
                Amount = 50;
                chkJoban.Checked = false;
                chkHappy.Checked = false;
            }
            

        }

        private void chkJoban_CheckedChanged(object sender, EventArgs e)
        {

            //pass the value to label after selecting the check box
            if (chkJoban.Checked == true)
            {
                lblPlayer.Text = "Joban";
                Amount = 50;
                chkHarpreet.Checked = false;
                chkHappy.Checked = false;
            }
        }

        private void chkHappy_CheckedChanged(object sender, EventArgs e)
        {
            //pass the value to label after selecting the check box
            if (chkHappy.Checked == true)
            {
                lblPlayer.Text = "Happy";
                Amount = 50;
                chkHarpreet.Checked = false;
                chkJoban.Checked = false;
            }
        }

        private void btnBet_Click(object sender, EventArgs e)
        {
            // bet trigger that is used to check the first of all the bet amount if it is less than 9 then generate an error message
            int BuddiesNumber = 0;
            if (betAmount.Value < 1) {
                MessageBox.Show("You Must have to fill the Bet amount more then 1 dollar");
            }
            // check the horse value it must be between range like 0 to 3
            else if (nmHorse.Value==0 || nmHorse.Value>3) {
                MessageBox.Show("Horse Value must be between 1 to 3");
            }
            //after all type of verifcation set the bet so thus game can be start 
            else if (!lblPlayer.Text.Equals("") && betAmount.Value >= 1 && nmHorse.Value > 0 && nmHorse.Value < 4)
            {
                //verify the bet amount after verifying the amount of the player
                if (objbetSetting.betAmountVerify(lblPlayer.Text, Convert.ToInt32(betAmount.Value)))
                {

                    ct++;
                    
                    if (lblPlayer.Text.Equals("Harpreet") )
                    {
                        BuddiesNumber = 0;
                        //    lblHarpreet.Text = lblPlayer.Text + " fix a Bet of Amount $" + Convert.ToInt32(betAmount.Value) + " Dollar on Horse No " + Convert.ToInt32(nmHorse.Value);
                    }
                    else if (lblPlayer.Text.Equals("Joban"))
                    {
                        BuddiesNumber = 1;
                        //  lblJoban.Text = lblPlayer.Text + " fix a Bet of Amount $" + Convert.ToInt32(betAmount.Value) + " Dollar on Horse No " + Convert.ToInt32(nmHorse.Value);
                    }
                    else if (lblPlayer.Text.Equals("Happy"))
                    {
                        BuddiesNumber = 2;
                        //lblHappy.Text = lblPlayer.Text + " fix a Bet of Amount $" + Convert.ToInt32(betAmount.Value) + " Dollar on Horse No " + Convert.ToInt32(nmHorse.Value);
                    }
                    else
                    {
                        //  MessageBox.Show("Miti");
                    }

                    // pass the name and amount of the buddies class to set the which no of player set the bet now
                    objBuddies[BuddiesNumber].PlaceBet((int)betAmount.Value, (int)nmHorse.Value);
                    // calling the updateLabel Method from guy class that is used for printing the statement 
                    objBuddies[BuddiesNumber].UpdateLabels();

                }
                //generate an error message
                else
                {
                    MessageBox.Show("You must have to select a Player and Select the Amount more than 1 dollar and suitable Horse No");
                }
            }
            else {
                //generate an error message
                MessageBox.Show("you must have to verify the Bet Amount and Horse No before fixing the Bet");
            }

        }

        private void lblJoban_Click(object sender, EventArgs e)
        {

        }

        private void betAmount_ValueChanged(object sender, EventArgs e)
        {
            //verify the bet amount means if the player has not enough money and set the bet amount more then that then it will genrate an error message
            if (lblPlayer.Text.Equals("Harpreet") && betAmount.Value<1) {
                MessageBox.Show("You didn't have Enough Balance");
            }
            if (lblJoban.Text.Equals("Joban") && betAmount.Value <1) {
                MessageBox.Show("You didn't have Enough Balance");
            }
            if (lblHappy.Text.Equals("Happy") && betAmount.Value<1) {
                MessageBox.Show("You didn't have Enough Balance");
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //this button is used to start the game 
            if (ct > 0)
            {
                bool NoWinner = true;
                int winningHorse;
                //starting the while loop after clicking on the race button 
                while (NoWinner)
                {
                    Application.DoEvents();
                    /*for loop that is used to move the dogs from one location to another 
                        using the object of the greyhounds class wih the help of array
                        one by one
                    */
                    for (int i = 0; i < objgame.Length; i++)
                    {
                        /*check the winning dog from race using the run method of the
                            class greyhounds and increment the value of the local variable to get the position of the winning horse
                        */
                        if (objgame[i].move())
                        {
                            winningHorse = i + 1;
                            //after getting the winner pass  the false value to the local variable of the NoWinner for stopping the while loop
                            NoWinner = false;
                            //printing the message on the dialoge box which dog is winner 
                            MessageBox.Show("We have a winner - Horse No " + winningHorse);
                            // after the race complition the trigger must be enabled false so after again setting the bet then you can start the race again
                            
                            /*for each loop is used to check the player is winner or looser if he is winner the increment the bet amount in his account and
                                if he is looser then decrement the amount as much is set on the bet and update all the lables once again 
                                */
                            foreach (Buddies guy in objBuddies)
                            {
                                //comparing the condition using the conditional statement 
                                if (guy.MyBet != null)
                                {
                                    guy.Collect(winningHorse);
                                    guy.MyBet = null;
                                    //update all the lable by calling the method updatelabels from  guy class 
                                    guy.UpdateLabels();
                                }
                            }
                            //set all the horse at the starting position after complition the game 
                            foreach (Game horse in objgame)
                            {
                                horse.TakeStartingPosition();
                            }
                            betAmount.Value = 0;
                            nmHorse.Value = 1;
                            //break all the loop statement and come out from the block
                            break;
                        }
                    }
                }

            }
            else {
                //generate an error message
                MessageBox.Show("You must have to select the Player and fix a Bet ");
            }
            
        }

        private void PbHorse1_Click(object sender, EventArgs e)
        {

        }

        public void Bet() {
            MessageBox.Show("OK working");
        }
    }
}
