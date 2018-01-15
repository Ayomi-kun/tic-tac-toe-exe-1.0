using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tic_tac_toe_GUI_1._0
{
    public partial class Form1 : Form
    {
       

        bool turn = true; // true = X turn false=Y trun
        int turnCount = 0;
        int xHasWon = 0;
        int oHasWon = 0;


        public Form1()
        {
            InitializeComponent();
            turnToPlay.Text = "Its \"X\"s turn to play";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
            {
                b.Text = "X";
                // after playing for X display message that its O's turn to play
                turnToPlay.Text = "Its \"O\"s turn to play";
            }
            else
            {
                b.Text = "O";
                //After playing for O display message that its X's turn to play
                turnToPlay.Text = "Its \"X\"s turn to play";
            }
            turn = !turn;
            b.Enabled = false;
            checkForWinner();
            turnCount++;
            
        }

        private void versionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Version 1.0, \n The Initiator!");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is a tic tac toe game created and designed by Phinix Works.\n Software engineer in charge: Ayomikun Oluwayemi");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           // MessageBox.Show(" \"X\" gets the first chance to play");
        }

        private void checkForWinner()
        {
            bool thereIsAWinner = false;
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (A1.Enabled == false))
                thereIsAWinner = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (B1.Enabled == false))
                thereIsAWinner = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                thereIsAWinner = true;
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (A1.Enabled == false))
                thereIsAWinner = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (A2.Enabled == false))
                thereIsAWinner = true;
            else if ((A3.Text == B3.Text) && (A3.Text == C3.Text) && (!C3.Enabled))
                thereIsAWinner = true;
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                thereIsAWinner = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!A3.Enabled))
                thereIsAWinner = true;

            if (thereIsAWinner)
            {
                dissablebutton();
                
              
                string winner = "";
                if (turn) {
                    //if true that means it is X turn to play that means O won the game
                    winner = "O";
                    turnToPlay.Text = "Player " + winner + " has won the game";
                    oHasWon++;
                }
                else {
                    winner = "X";
                    turnToPlay.Text = "Player " + winner + " has won the game";
                    xHasWon++;
                }

                MessageBox.Show("Player with marker \"" + winner + "\" is the winner \n\n X has won: "+xHasWon+" time(s) \n O has won: "+oHasWon+" time(s)");
               
            }
            else
            {
                if (turnCount == 8)
                {
                    MessageBox.Show("This game ends in a draw \n\n X has won: " + xHasWon + " time(s) \n O has won: " + oHasWon + " time(s)");
                    
                }
            }
        }//this is where we check for winners after every move and print winner marker out

        private void dissablebutton()
        {
            A1.Enabled = false;
            A2.Enabled = false;
            A3.Enabled = false;
            B1.Enabled = false;
            B2.Enabled = false;
            B3.Enabled = false;
            C1.Enabled = false;
            C2.Enabled = false;
            C3.Enabled = false;

        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // for a new game session
            turnCount = 0;
            turn = true;

            newGame();
        }


        private void newGame()
        {
            A1.Enabled = true;
            A1.Text = "";
            A2.Enabled = true;
            A2.Text = "";
            A3.Enabled = true;
            A3.Text = "";
            B1.Enabled = true;
            B1.Text = "";
            B2.Enabled = true;
            B2.Text = "";
            B3.Enabled = true;
            B3.Text = "";
            C1.Enabled = true;
            C1.Text = "";
            C2.Enabled = true;
            C2.Text = "";
            C3.Enabled = true;
            C3.Text = "";
            turnToPlay.Text = "Its \"X\"s turn to play";
        }
        private void turnToPlay_TextChanged(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            // this is just to close the whole game.
            // we would add a database soon to keep track of every players moves, and also keep an up to date scoreboard.

        }
    }
}