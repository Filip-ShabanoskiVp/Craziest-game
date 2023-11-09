using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crazy_Game
{
   public class myEnemy
    {
        public Bitmap myEnemyImg { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int speed { get; set; }
        public int life { get; set; }
        public int DifferentEnemies { get; set; }
        public myEnemy(int x,int y,int different)
        {
            DifferentEnemies = different;
            if(different == 0)
            {
                myEnemyImg = new Bitmap(global::Crazy_Game.Properties.Resources.enemyRight);
            }else if(different == 1)
            {
                myEnemyImg = new Bitmap(global::Crazy_Game.Properties.Resources.enemyScary);
            }else if (different == 2)
            {
                myEnemyImg = new Bitmap(global::Crazy_Game.Properties.Resources.ghost);
            }
            else
            {
                myEnemyImg = new Bitmap(global::Crazy_Game.Properties.Resources.ghostPurple);
            }
            X = x;
            Y = y;
            speed =6;
            life = 1;
        }
        public bool myEnemyMove(int maxHeight)
        {
            if(Y+speed <maxHeight)
            {
                Y = Y+ speed;
                return true;
            }
            return false;
        }
        public void LoseLife()
        {
            life--;
        }
        public void Draw(Graphics g)
        {
            g.DrawImage(myEnemyImg, X, Y,50,50);
        }
        public int getX()
        {
            return X;
        }
        public int getY()
        {
            return Y;
        }
        public void setX(int x)
        {
            X = x;
        }
        public Bitmap getImage()
        {
            return myEnemyImg;
        }
        public int getLife()
        {
            return life;
        }
    }
}
