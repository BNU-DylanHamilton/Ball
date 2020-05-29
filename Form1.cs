using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Ball
{
    public partial class Form1 : Form
    {
        Random rand = new Random();
        private int xOne = 0, yOne = 0, xTwo = 0, yTwo = 0; // starting position of the balls
        private int xOneMove = 10, yOneMove = 10, xTwoMove = 10, yTwoMove = 10; // amount of movement for each tick
        private int xOneSize = 30, yOneSize = 30, xTwoSize = 30, yTwoSize = 30; //sets the starting size of the balls

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void drawBall(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;      // get a graphics object

            if(xOne == 0 || yOne == 0)
            {
                xOne = rand.Next(0, displayPictureBox.Width - 20); //sets a random x coordinate within the width of the picture
                yOne = rand.Next(0, displayPictureBox.Height - 20); //sets a random y coordinate within the height of the picture
            }

            if(xTwo == 0 || yTwo == 0)
            {
                xTwo = rand.Next(0, displayPictureBox.Width); //sets a random x coordinate within the width of the picturebox
                yTwo = rand.Next(0, displayPictureBox.Height); //sets a random y coordinate within the height of the picturebox
            }
            
              // draw a red ball, with the size given in variables, at x, y position
            g.FillEllipse(Brushes.Red, xOne, yOne, xOneSize, yOneSize);
            g.FillEllipse(Brushes.Green, xTwo, yTwo, xTwoSize, yTwoSize);
        }

        /// <summary>
        /// This method makes the movement of the balls that are drawn and makes them change 
        /// direction change if the balls hit the edges of the picturebox
        /// </summary>
        private void showAnimation(object sender, EventArgs e)
        {
            xOne += xOneMove;             // add 10 to x and y positions
            yOne += yOneMove;
            xTwo += xTwoMove;
            yTwo += yTwoMove;
            
            if(yOne + yOneSize >= displayPictureBox.Height)
            {
                yOneMove = -yOneMove;
            }
            else if(yOne + 20 <= displayPictureBox.Top)
            {
                yOneMove = -yOneMove;
            }

            if(xOne + xOneSize >= displayPictureBox.Width)
            {
                xOneMove = -xOneMove;
            }
            else if(xOne + 20 <= displayPictureBox.Left)
            {
                xOneMove = -xOneMove;
            }

            if (yTwo + yTwoSize >= displayPictureBox.Height)
            {
                yTwoMove = -yTwoMove;
            }
            else if (yTwo + 20 <= displayPictureBox.Top)
            {
                yTwoMove = -yTwoMove;
            }

            if (xTwo + xTwoSize >= displayPictureBox.Width)
            {
                xTwoMove = -xTwoMove;
            }
            else if (xTwo + 20 <= displayPictureBox.Left)
            {
                xTwoMove = -xTwoMove;
            }

            Refresh();              // refresh the`screen .. calling Paint() again

        }

        private void closeApplication(object sender, EventArgs e)
        {
            Application.Exit();
        }

  
        private void startTimer(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void stopTimer(object sender, EventArgs e)
        {
            timer1.Enabled= false;
        }

        /// <summary>
        /// This method increases and decreases the size of the balls
        /// once the correct keys are pressed.
        /// </summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            string input;
            input = keyData.ToString();

            if (input == "Up")
            {
                xOneSize += 5;
                yOneSize += 5;
                return true;
            }
            else if(input == "Down")
            {
                xOneSize -= 5;
                yOneSize -= 5;
                return true;
            }
            else if(input == "C")
            {
                displayPictureBox.BackColor = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
            }

            return false;    // return true if key processed, otherwise false
        }

    }
}