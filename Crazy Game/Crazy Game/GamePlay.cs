using Crazy_Game.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Crazy_Game
{
    public partial class GamePlay : Form
    {

        SoundPlayer enemyDead;
        Score Scoore;
        public List<myEnemy> myEnemies;
       /* public List<Enemy> enemies;*/
      /*  int generateEnemy;
        EnemyDoc EnemyDoc;*/
        Random random = new Random();

        private static readonly int Time = 500;
        private int timeElipsed;
        Timer timer;
        Player player;
        static readonly int WORLD_WIDTH = 10;
        static readonly int WORLD_HEIGHT = 15;
      /*  Enemy myEnemy;*/
        SoundPlayer soundPlayer;
        public GamePlay()
        {
          
            InitializeComponent();
           /* EnemyDoc = new EnemyDoc();*/
            soundPlayer = new SoundPlayer(global::Crazy_Game.Properties.Resources.Soundtrack);
            soundPlayer.Stop();
            DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            StartPosition = FormStartPosition.CenterScreen;
            enemyDead = new SoundPlayer(global::Crazy_Game.Properties.Resources.Dead);
            timer = new Timer();
            timer.Interval = 100;
            timer.Tick += new EventHandler(timer_Tick);

            timer.Start();
            newGame();
           /* generateEnemy = 0;
            
            myEnemy = new Enemy();*/
            
        }
       
        public void newGame()
        {
           
            myEnemies = new List<myEnemy>();
            addEnemy();
            Scoore = new Score();
            ScoreLabel.Text = "0";
           /* enemies = new List<Enemy>();*/
            timeElipsed = 0;
            UpdateTime();
            pbTime.Maximum = Time;
            pbTime.Value = Time;
            player = new Player();
            this.Width = 60 * (WORLD_WIDTH + 1);
            this.Height = 32 * (WORLD_HEIGHT + 1);
         
        }
        public void addEnemy()
        {
            Random r = new Random();
            for(int i=myEnemies.Count;i<10;i++)
            {
                myEnemies.Add(new myEnemy(random.Next(750), random.Next(1000), random.Next(4)));
            }
        }


        void timer_Tick(object sender, EventArgs e)
        {
            
            timeElipsed++;
            player.Move(10, 20);
            MoveBall();
            pbTime.Value = Time - timeElipsed;
            if (timeElipsed == Time)
            {
               
              
                timer.Stop();
                EndGame();
            }
            enemyMove();
           
            ScoreLabel.Text = string.Format("{0}", Scoore.getScore());
            /*   if (generateEnemy % 10 == 0)
               {
                   int y = random.Next(2 * myEnemy.Radius, Height - (myEnemy.Radius * 2));
                   int x = -myEnemy.Radius;
                   EnemyDoc.addEnemy(new Point(x, y));
               }

               ++generateEnemy;
               EnemyDoc.Move(Width);*/

           
            UpdateTime();
           
            Invalidate(true);
        }
        public void EndGame()
        {
            this.Hide();
            GameOver gameOver = new GameOver(Scoore.getScore());
            gameOver.ShowDialog();
        }
        public void UpdateTime()
        {
            int left = Time - timeElipsed;
            int min = left / 60;
            int sec = left % 60;
        }

        private void GamePlay_Paint(object sender, PaintEventArgs e)
        {
            for(int i=0;i<myEnemies.Count;i++)
            {
                myEnemies[i].Draw(e.Graphics);
            }
           /* EnemyDoc.Draw(e.Graphics);*/
            player.Draw(e.Graphics);

            for (int i = 0; i < player.getFireBall().Count; i++)
            {
                player.getFireBall()[i].DrawFire(e.Graphics);
            }
          
           
        }
        public void enemyMove()
        {
            for(int i=0;i<myEnemies.Count-1;i++)
            {
                Rectangle r1 = new Rectangle(player.X, player.Y, player.getImage().Width, player.getImage().Height);
                Rectangle r2 = new Rectangle(myEnemies[i].getX(), myEnemies[i].getY(), myEnemies[i].getImage().Width,
                    myEnemies[i].getImage().Height);
                if (!myEnemies[i].myEnemyMove(WORLD_HEIGHT))
                {
                    myEnemies.Remove(myEnemies[i]);
                }
               
            }
            if (myEnemies.Count < 10)
                addEnemy();
        }

        private void GamePlay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                        player.ChangeDirection(Player.DIRECTION.Gore);
                        player.imgSegasna = player.imgUp;
            }
            if (e.KeyCode == Keys.Left)
            {
                        player.ChangeDirection(Player.DIRECTION.Levo);
                        player.imgSegasna = player.imgLeft;
            }
            if (e.KeyCode == Keys.Down)
            {
                        player.ChangeDirection(Player.DIRECTION.Dole);
                        player.imgSegasna = player.imgDown;
            }
            if (e.KeyCode == Keys.Right)
            {
                        player.ChangeDirection(Player.DIRECTION.Desno);
                        player.imgSegasna = player.imgRight;
            }
            if (e.KeyCode == Keys.Space)
            {
                player.fireeBalls();
  
            }

            Invalidate();
        }
        public void MoveBall()
        {
            for (int i = 0; i < player.getFireBall().Count; i++)
            {
                player.moveFireBalls(i);
                if (player.getFireBall()[i].getY() < 0)
                {
                    player.RemoveFireBalls(i);
                }
                else
                {
                    for(int j=0;j<myEnemies.Count;j++)
                    {
                        Rectangle r1 = new Rectangle(player.getFireBall()[i].GetX(), player.getFireBall()[i].getY(),
                            player.getFireBall()[i].getImage().Width, player.getFireBall()[i].getImage().Height);
                        Rectangle r2 = new Rectangle(myEnemies[j].getX(), myEnemies[j].getY(), myEnemies[j].getImage().Width,
                myEnemies[j].getImage().Height);
                        if(r1.IntersectsWith(r2))
                        {
                            player.RemoveFireBalls(i);
                            myEnemies[j].LoseLife();
                            if(myEnemies[j].getLife()<=0)
                            {
                                enemyDead.Play();
                                myEnemies.Remove(myEnemies[j]);
                                Scoore.UpdateScore();
                                addEnemy();
                               
                            }
                            ScoreLabel.Text = Scoore.getScore().ToString();
                            break;
                        }
                    }
                }
            }
            
        }
        
        private void toolStripStatusLabel7_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel7_Click_1(object sender, EventArgs e)
        {
            timer.Stop();
            if (MessageBox.Show("Are you sure the you want to start a new Game ?", "New Game", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                newGame();
                timer.Start();
            }
            else
            {
                timer.Start();
            }
            
        }

        private void toolStripStatusLabel8_Click(object sender, EventArgs e)
        {
            timer.Stop();
            if (MessageBox.Show("Are you sure the you want to quit the Game ?", "Quit Game", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Hide();
                Form1 form1 = new Form1();
                form1.ShowDialog();
                
            }
            else
            {
                timer.Start();
            }
        }



      
    }
}
