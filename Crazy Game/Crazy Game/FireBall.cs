using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crazy_Game
{
    public class FireBall 
    {
        Player.DIRECTION Nasoka;
        private Bitmap fireBall;
        private int speed;
        private int X;
        private int Y;
        public FireBall(int x,int y,Player.DIRECTION d)
        {
            fireBall = new Bitmap(global::Crazy_Game.Properties.Resources.fireUp);
            X = x;
            Y = y;
            speed = 30;
            Nasoka = d;
            
        }
    
        public void MoveBall()
        {
                if (Nasoka.Equals(Player.DIRECTION.Desno))
                {
                    X = X + speed;
                }
                else if (Nasoka.Equals(Player.DIRECTION.Gore))
                {
                    Y = Y - speed;
                }
                else if (Nasoka.Equals(Player.DIRECTION.Levo))
                {
                    X = X - speed;
                }
                else if (Nasoka.Equals(Player.DIRECTION.Dole))
                {
                    Y = Y + speed;
                }
            
        }
       
        public void DrawFire(Graphics g)
        {
            g.DrawImage(fireBall, X, Y);
        }

        public int getSpeed()
        {
            return speed;
        }
        public Bitmap getImage()
        {
            return fireBall;
        }
        public int GetX()
        {
            return X;
        }
        public int getY()
        {
            return Y;
        }

        
    }
}
