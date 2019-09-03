using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace HorseRacr
{
    class Game
    {
        public int Position;
        public int RacetrackLength;
        public PictureBox objPictureBox = null;
        public int Location = 0;
        //object of the random class used for get the random number to change the position of the horse
        public Random MyRandom;
        //user define method for running horse from one location to another this method is boolean function that return true or false 

        public bool move() {

            MyRandom = new Random();
            //calling the next method of the random class and pass the value to the  dist variable from 1 to 5
            int dist = MyRandom.Next(1, 5);

            //calling the method of the movepicture box while passing the arguments to the method
            forwardPictureBox(dist);
            /*increment in the location variable to move the picture and get the current position of the picture so thus check it that it is reached to the last point or not 
                using the conditional statement*/
            Location += dist;

            //condition statement to check the position of the picture and return the true if it is reached at the end
            if (Location >= (RacetrackLength -Position))
            {
                return true;
            }

            return false;
        }

        //this user define method that is used for set all the picture at the starting position . this method is void method it will not return any value
        public void TakeStartingPosition()
        {
            forwardPictureBox(-Location);
            Location = 0;
        }

        // this method is used to move the picture from one location to another 
        public void forwardPictureBox(int distance)
        {
            Point p = objPictureBox.Location;
            p.X += distance;
            objPictureBox.Location = p;
        }

    }

}
