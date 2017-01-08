using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

/*
Ivan Almazan
Assignment: Dice Rolling.
Summary: Dice Rolling, Forms, Menus, AI.
*/

namespace Dice_Rolling
{
    public partial class Form1 : Form
    {
        static int sum1 = 0;
        static int sum2 = 0;
        static int win = 100;
        static int points = 0;
        static Random random = new Random();
        static int temp = 0;
        static int turn = 1;
        static bool ai = true;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void playerTextBox_TextChanged(object sender, EventArgs e)
        {
            if (turnLabel.Text == player1Label.Text)
            {
                player1Label.Text = player1TextBox.Text;
                player2Label.Text = player2TextBox.Text;
                turnLabel.Text = player1TextBox.Text;
            }
            else
            {
                player1Label.Text = player1TextBox.Text;
                player2Label.Text = player2TextBox.Text;
                turnLabel.Text = player2TextBox.Text;
            }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newGame();
        }

        private void newGame()
        {
            sum1 = 0;
            sum2 = 0;
            points = 0;
            temp = 0;
            turn = 1;
            ai = true;

            player1Label.Text = player1TextBox.Text = "Player 1";
            player2Label.Text = player2TextBox.Text = "Bot";
            turnLabel.Text = "Player 1";
            rolledTextBox.Text = pointsTextBox.Text = total1TextBox.Text = total2TextBox.Text = "0";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ai = true;
            player2Label.Text = player2TextBox.Text = "Bot";
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ai = false;
            player2Label.Text = player2TextBox.Text = "Player 2";
        }

        private void rollButton_Click(object sender, EventArgs e)
        {
            rollDice();
        }

        private void rollDice()
        {
            temp = random.Next(1, 7);
            if (temp == 1)
            {
                nextPlayer();
            }
            else
                points += temp;
            updateForm();
        }

        private void standButton_Click(object sender, EventArgs e)
        {
            stand();
        }

        private void stand()
        {
            total();
            nextPlayer();
            updateForm();
        }


        private void nextPlayer()
        {
            points = 0;
            turn = turn == 1 ? 2 : 1;
        }

        private void total()
        {
            if (turn == 1)
            {
                sum1 += points;
            }
            else
            {
                sum2 += points;
            }
        }

        private void updateForm()
        {
            rolledTextBox.Text = temp.ToString();
            pointsTextBox.Text = points.ToString();

            total1TextBox.Text = sum1.ToString();
            total2TextBox.Text = sum2.ToString();

            if (sum1 >= win || sum2 >= win)
            {
                timer1.Enabled = false;
                MessageBox.Show(turnLabel.Text + " has won the game");
                newGame();
            }

            if (turn == 1)
                turnLabel.Text = player1TextBox.Text;
            else
                turnLabel.Text = player2TextBox.Text ;

            if (turn == 2 && ai)
                startTimer();
            else
                stopTimer();
        }

        private void startTimer()
        {
            timer1.Enabled = true;
            rollButton.Enabled = false;
            standButton.Enabled = false;
        }

        private void stopTimer()
        {
            timer1.Enabled = false;
            rollButton.Enabled = true;
            standButton.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (points > 20)
                stand();
            else
                rollDice();
        }
    }
}
