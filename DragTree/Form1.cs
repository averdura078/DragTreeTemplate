using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DragTree
{
    public partial class Form1 : Form
    {
        //create an int variable to track currentRow,
        //create a Stopwatch object called stopwatch 
        int currentRow = 1;
        Stopwatch stopwatch = new Stopwatch();

        //create a timer on the form called lightTimer (interval 400ms)
        //create the tick event for the lightTimer

        public Form1()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            // TODO - start the timer
            lightTimer.Start();
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            //stop the stopwatch
            stopwatch.Stop();

            //check if the ellapsed time in milliseconds is > 0. 
            //if yes show the time.
            //if no show "FOUL START" 
            if (stopwatch.ElapsedMilliseconds > 0)
            {
                timeLabel.Text = stopwatch.Elapsed.ToString(@"ss\:ff");
            }
            else
            {
                timeLabel.Text = "FOUL START";
            }

        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            //reset the stopwatch
            stopwatch.Reset();

            //put rows 1-3 colours back to DimGray and row 4 back to DarkOliveGreen
            row1col1.BackColor = Color.DimGray;
            row1col2.BackColor = Color.DimGray;
            row2col1.BackColor = Color.DimGray;
            row2col2.BackColor = Color.DimGray;
            row3col1.BackColor = Color.DimGray;
            row3col2.BackColor = Color.DimGray;
            row4col1.BackColor = Color.DarkOliveGreen;
            row4col2.BackColor = Color.DarkOliveGreen;

            //reset row value and timeLabel text
            currentRow = 1;
            timeLabel.Text = stopwatch.Elapsed.TotalMilliseconds + "";
        }

        private void lightTimer_Tick(object sender, EventArgs e)
        {
            //create a switch block that checks currentRow. In each case
            //it will light up the appropriate lights, (labels). 

            switch (currentRow)
            {
                case 1:
                    row1col1.BackColor = Color.Yellow;
                    row1col2.BackColor = Color.Yellow;
                    break;
                case 2:
                    row2col1.BackColor = Color.Yellow;
                    row2col2.BackColor = Color.Yellow;
                    break;
                case 3:
                    row3col1.BackColor = Color.Yellow;
                    row3col2.BackColor = Color.Yellow;
                    break;
                case 4:
                    row4col1.BackColor = Color.SpringGreen;
                    row4col2.BackColor = Color.SpringGreen;
                    lightTimer.Stop();
                    stopwatch.Start();
                    break;
            }

            //increment the currentRow value by 1
            currentRow++;
        }
    }
}
