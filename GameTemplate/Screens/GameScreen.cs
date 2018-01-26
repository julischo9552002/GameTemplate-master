using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameTemplate.Dialogs;
using System.Diagnostics;

namespace GameTemplate.Screens
{
    //a game by Julia Scholz
    //the goal in this game is to color as many blocks as possible in your color in 30 seconds
    //each round is 30 seconds and there are 3 rounds per game
    //this game is an only multiplayer game

    public partial class GameScreen : UserControl
    {
        //global variables
        bool right1, left1, jump1, right2, left2, jump2;
        bool GameOn = true;
        bool hasCollided = false;
        int G = 15;
        int speed = 10;
        int Force1, Force2;
        int score1 = 0;
        int score2 = 0;
        int redblocks = 0;
        int blueblocks = 0;
        int gamesleft = 1;
       
        Stopwatch sw = new Stopwatch();
        List<PictureBox> pL = new List<PictureBox>();
        
        public GameScreen()
        {
            InitializeComponent();

            sw.Start();

            //adding all of the blocks on the map
            pL.Add(block1);
            pL.Add(block2);
            pL.Add(block3);
            pL.Add(block4);
            pL.Add(block5);
            pL.Add(block6);
            pL.Add(block7);
            pL.Add(block8);
            pL.Add(block9);
            pL.Add(block10); 
            pL.Add(block11);
            pL.Add(block12);
            pL.Add(block13);
            pL.Add(block14);
            pL.Add(block15);
            pL.Add(block16);
            pL.Add(block17);
            pL.Add(block18);
            pL.Add(block19);
            pL.Add(block20);
            pL.Add(block21);
            pL.Add(block22);
            pL.Add(block23);
        }

        #region required global values - DO NOT CHANGE

        //player1 button control keys - DO NOT CHANGE
        Boolean leftArrowDown, downArrowDown, rightArrowDown, upArrowDown, bDown, nDown, mDown, spaceDown;

        //player2 button control keys - DO NOT CHANGE
        Boolean aDown, sDown, dDown, wDown, cDown, vDown, xDown, zDown;

        public static Point startCentre = new Point(Screen.PrimaryScreen.WorkingArea.Width / 2 - 1300 / 2, Screen.PrimaryScreen.WorkingArea.Height / 2 - 900 / 2);


        private void GameScreen_Load(object sender, EventArgs e)
        {
            this.Width = 1300;
            this.Height = 900;

            this.Location = startCentre;
        }

        #endregion

        //TODO - Place game global variables here 
        //---------------------------------------

        //initial starting points for black rectangle
        int drawX = 100;
        int drawY = 100;

        //Graphics objects
        SolidBrush heroBrush = new SolidBrush(Color.Black);

        //----------------------------------------


        // PreviewKeyDown required for UserControl instead of KeyDown as on a form

        //my code:
        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                pauseGame();
            }

            //player1
            if (e.KeyCode == Keys.Right) { right1 = true; }
            if (e.KeyCode == Keys.Left) { left1 = true; }

            if (jump1 != true)
            {
                if (e.KeyCode == Keys.Up)
                {
                    jump1 = true;
                    Force1 = G;
                }
            }
            //player2
            if (e.KeyCode == Keys.D) { right2 = true; }
            if (e.KeyCode == Keys.A) { left2 = true; }

            if (jump2 != true)
            {
                if (e.KeyCode == Keys.W)
                {
                    jump2 = true;
                    Force2 = G;
                }
            }
        }
        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            //player1
            if (e.KeyCode == Keys.Right) { right1 = false; }
            if (e.KeyCode == Keys.Left) { left1 = false; }

            //player2
            if (e.KeyCode == Keys.D) { right2 = false; }
            if (e.KeyCode == Keys.A) { left2 = false; }
        }

        /// <summary>
        /// All game update logic must be placed in this event method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gameTimer_Tick(object sender, EventArgs e)
        {
                if (GameOn == true)
                {
                //moving right and left + side collision for player1
                if (right1 == true && player1.Right <= panel.Width - 3) { player1.Left += speed; }
                if (left1 == true && player1.Left >= 3) { player1.Left -= speed; }

                //jump for player 1
                if (jump1 == true && player1.Top >= 0)
                {
                    player1.Top -= Force1;
                    Force1 -= 1;
                    if (Force1 == 0)
                    {
                        jump1 = false;
                    }
                    if (player1.Top <= 0)
                    {
                        player1.Top = 1;
                    }
                }
                else
                {
                    //making the rectangle for player1
                    Rectangle p1Rec = new Rectangle(player1.Location.X, player1.Location.Y, player1.Width, player1.Height);
                    hasCollided = false;

                    //Intersection with blocks for player 1
                    for (int i = 0; i < pL.Count; i++)
                    {
                        Rectangle bRec = new Rectangle(pL[i].Location.X, pL[i].Location.Y, pL[i].Width, pL[i].Height);

                        if (!(p1Rec.IntersectsWith(bRec)))
                        {
                            
                        }
                        else
                        {
                            pL[i].BackColor = Color.Red;
                            hasCollided = true;
                        }
                    }

                    if (!hasCollided)
                    {
                        player1.Top += Force1;
                        Force1 += 1;
                    }
                }
            }
            else
            {   
                //If game is not on, stops the player
                right1 = false;
                left1 = false;
            }

            //moving player 2 (jump, left, right)
            if (GameOn == true)
            {
                //right and left + side collision for player2
                if (right2 == true && player2.Right <= panel.Width - 3) { player2.Left += speed; }
                if (left2 == true && player2.Left >= 3) { player2.Left -= speed; }

                //jump for player 2
                if (jump2 == true)
                {
                    player2.Top -= Force2;
                    Force2 -= 1;
                    if (Force2 == 0)
                    {
                        jump2 = false;
                    }
                    if (player2.Top <= 0)
                    {
                        player2.Top = 1;
                    }
                }
                else
                {
                    //making the rectangle for player2
                    Rectangle p2Rec = new Rectangle(player2.Location.X, player2.Location.Y, player2.Width, player2.Height);
                    hasCollided = false;

                    //Intersection with blocks for player2
                    for (int i = 0; i < pL.Count; i++)
                    {
                        Rectangle bRec = new Rectangle(pL[i].Location.X, pL[i].Location.Y, pL[i].Width, pL[i].Height);

                        if (!(p2Rec.IntersectsWith(bRec)))
                        {
                            
                        }
                        else
                        {
                            pL[i].BackColor = Color.Blue;
                            hasCollided = true;
                        }
                    }
                    if (!hasCollided)
                    {
                        player2.Top += Force2;
                        Force2 += 1;
                    }
                }
            }
            else
            {   
                //If game is not on, stops the player
                right2 = false;
                left2 = false;
            }
            //graphics and brush
            Graphics fG = this.CreateGraphics();
            SolidBrush timeBrush = new SolidBrush(Color.Black);

            //timer
            TimeSpan ts = sw.Elapsed;
            secondsLabel.Text = ts.Seconds + ":" + ts.Milliseconds.ToString("#");

            //games left Label
            gamesleftLabel.Text = gamesleft + " game left";

            //score label
            scoreLabel.Text = score1 + ":" + score2;

            //test score
            //testLabel.Text = redblocks + "";

            //after 30 secs
            if (ts.Seconds >= 30)
            {
                //make everything invisible and stop game
                GameOn = false;
                secondsLabel.Visible = false;
                
                ///this doesn't work
                for (int i = 0; i < pL.Count; i++)
                {
                    if (pL[i].BackColor == Color.Blue)
                    {
                        blueblocks++;
                    }
                    if (pL[i].BackColor == Color.Red)
                    {
                        redblocks++;
                    }
                }
                ////if more red blocks player 1 gets a point
                //if (redblocks > blueblocks)
                //{
                //    score1++;
                //}
                ////if more blue blocks player 2 gets a point
                //if (redblocks < blueblocks)
                //{
                //    score2++;
                //}
                ////if tie nobody gets a point
                //if (redblocks == blueblocks)
                //{
                //    tieLabel.Text = "Tie!";
                //}
            }
            //after 3 games
            //if (gamesleft < 0)
            //{
                //pL[i].BackColor = Color.DimGray;
                //player1.Location.X = 41;
                //player1.Location.Y = 580;
                //player2.Location.X = 911;
                //player2.Location.Y = 589;
            //}
            Refresh();
        }

        /// <summary>
        /// Open the pause dialog box and gets Cancel or Abort result from it
        /// </summary>
        private void pauseGame()
        {
            gameTimer.Enabled = false;
            rightArrowDown = leftArrowDown = upArrowDown = downArrowDown = false;

            DialogResult result = PauseDialog.Show();

            if (result == DialogResult.Cancel)
            {
                gameTimer.Enabled = true;
            }
            if (result == DialogResult.Abort)
            {
                ScreenControl.changeScreen(this, "MenuScreen");
            }
        }

        /// <summary>
        /// All drawing, (and only drawing), to be done here
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            //draw rectangle to screen
            //e.Graphics.FillRectangle(heroBrush, drawX, drawY, 20, 20);
        }
    }
}
