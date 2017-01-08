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
Assignment: TicTacToe
Summary: Tic Tac Toe - Form.
*/

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        private Game game;
        private char shape1, shape2;
        private string player1Name, player2Name;
        private int firstPlayer;
        private int tie;
        DialogResult result;
        public Form1()

		{
			InitializeComponent();
			firstPlayer = 1;
            tie = 0;
			shape1 = 'X';
			shape2 = 'O';
			player1Name = toolStripTextBox1.Text;
			player2Name = toolStripTextBox2.Text;
			toolStripComboBox1.SelectedIndex = 0;
            game = new Game(firstPlayer);
		}

		private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
		{
            game = new Game(firstPlayer);
            foreach (Control control in this.Controls)
            {
                tie = 0;
                if (control.GetType() == typeof(Button))
                {
                    Button button = (Button)control;
                    button.Text = string.Empty;
                }
            }
		}

		private void toolStripTextBox_TextChanged(object sender, EventArgs e)
		{
			player1Name = toolStripTextBox1.Text;
			player2Name = toolStripTextBox2.Text;
		}

		private void button_Click(object sender, EventArgs e)
		{
            tie++;
			if (game.winner)
				return;

			Button clicked = (Button)sender;

			int row = clicked.TabIndex / 3;
			int column = clicked.TabIndex % 3;

			if (game.select(row, column))
            {
				if (game.CurrentPlayer == 2)
					clicked.Text = shape1.ToString();
				else
					clicked.Text = shape2.ToString();
			}

			if (game.winner)
			{
                if (game.CurrentPlayer == 2)
                {
                    MessageBox.Show(player1Name + " has won the game!");
                    result = MessageBox.Show("Do you want to play again?", "Another Game?", MessageBoxButtons.YesNo);
                    if(result == DialogResult.Yes)
                    {
                        game = new Game(1);
                        tie = 0;
                        foreach (Control control in this.Controls)
                        {
                            if (control.GetType() == typeof(Button))
                            {
                                Button button = (Button)control;
                                button.Text = string.Empty;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show(player2Name + " has won the game!");
                    result = MessageBox.Show("Do you want to play again?", "Another Game?", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        game = new Game(2);
                        tie = 0;
                        foreach (Control control in this.Controls)
                        {
                            if (control.GetType() == typeof(Button))
                            {
                                Button button = (Button)control;
                                button.Text = string.Empty;
                            }
                        }
                    }
                }
			}

            if (game.winner == false && tie == 9)
            {
                if (game.CurrentPlayer == 2)
                {
                    MessageBox.Show("The game is a tie!");
                    result = MessageBox.Show("Do you want to play again?", "Another Game?", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        game = new Game(2);
                        tie = 0;
                        foreach (Control control in this.Controls)
                        {
                            if (control.GetType() == typeof(Button))
                            {
                                Button button = (Button)control;
                                button.Text = string.Empty;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("The game is a tie!");
                    result = MessageBox.Show("Do you want to play again?", "Another Game?", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        game = new Game(1);
                        tie = 0;
                        foreach (Control control in this.Controls)
                        {
                            if (control.GetType() == typeof(Button))
                            {
                                Button button = (Button)control;
                                button.Text = string.Empty;
                            }
                        }
                    }
                }
            }
		}

		private void shapeChange_Click(object sender, EventArgs e)
		{
			char temp = shape1;
			shape1 = shape2;
			shape2 = temp;

			foreach (Control control in this.Controls)
			{
				if (control.GetType() == typeof(Button))
				{
					Button button = (Button)control;
					if (button.Text == shape1.ToString())
						button.Text = shape2.ToString();
					else if (button.Text == shape2.ToString())
						button.Text = shape1.ToString();
				}
			}
		}

		private void toolStripComboBox2_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (toolStripComboBox1.SelectedIndex == 0)
				firstPlayer = 1;
			else
				firstPlayer = 2;
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

        private void Form1_Load(object sender, EventArgs e)
        {

        }
	}

    class Game
    {
        public int[,] grid { get; private set; }
        public int CurrentPlayer { get; private set; }
        public bool winner { get; private set; }

        public Game(int first)
        {
            CurrentPlayer = first;
            grid = new int[3, 3];
            winner = false;
        }

        public bool select(int x, int y)
        {
            if (grid[x, y] == 0)
            {
                grid[x, y] = CurrentPlayer;
                checkWin();
                return true;
            }
            else
                return false;
        }

        private void checkWin()
        {
            
            if ((grid[0, 0] != 0 && grid[0, 0] == grid[0, 1] && grid[0, 0] == grid[0, 2])
                || (grid[1, 0] != 0 && grid[1, 0] == grid[1, 1] && grid[1, 0] == grid[1, 2])
                || (grid[2, 0] != 0 && grid[2, 0] == grid[2, 1] && grid[2, 0] == grid[2, 2]))
                winner = true;

            if ((grid[0, 0] != 0 && grid[0, 0] == grid[1, 0] && grid[0, 0] == grid[2, 0])
                || (grid[0, 1] != 0 && grid[0, 1] == grid[1, 1] && grid[0, 1] == grid[2, 1])
                || (grid[0, 2] != 0 && grid[0, 2] == grid[1, 2] && grid[0, 2] == grid[2, 2]))
                winner = true;

            if ((grid[0, 0] != 0 && grid[0, 0] == grid[1, 1] && grid[0, 0] == grid[2, 2])
                || (grid[2, 0] != 0 && grid[2, 0] == grid[1, 1] && grid[2, 0] == grid[0, 2]))
                winner = true;

            NextPlayer();
        }

        private void NextPlayer()
        {
            CurrentPlayer = CurrentPlayer == 1 ? 2 : 1;
        }
    }

}