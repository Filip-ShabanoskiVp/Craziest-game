using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crazy_Game
{
    public class Player
    {
        
        public int Life { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Image imgRight;
        public Image imgSegasna;
        public Image imgLeft;
        public Image imgDown;
        public Image imgUp;
        public List<FireBall> fireBalls;
        public DIRECTION Nasoka { get; set; }
        public int Radius;
        public enum DIRECTION
        {
            Gore,
            Dole,
            Levo,
            Desno
        }
        public Player player;
        public Player()
        {
           
            Life = 4;
            X = 600;
            Y = 0;
            imgRight = Crazy_Game.Properties.Resources.playerRight;
            imgLeft = Crazy_Game.Properties.Resources.playerLeft;
            imgDown = Crazy_Game.Properties.Resources.playerDown;
            imgUp = Crazy_Game.Properties.Resources.playerUp;
            imgSegasna = imgRight;
            Nasoka = DIRECTION.Desno;
            Radius = 20;
            fireBalls = new List<FireBall>();
            imgSegasna.Tag = "playerPic";
        }
       
      
        public void ChangeDirection(DIRECTION direction)
        {
            Nasoka = direction;
        }
        
        public void Move(int dx, int dy)
        {
            if (Nasoka == DIRECTION.Desno)
            {
                if (X >= 600)
                    X = 600;
                else
                    X += dx;
                
            }
            if (Nasoka == DIRECTION.Levo)
            {
                X -= dx;
                if (X < 0)
                    X = 0;
            }
            if (Nasoka == DIRECTION.Gore)
            {
                Y -= dx;
                if (Y < 0)
                    Y = 0;
            }
            if (Nasoka == DIRECTION.Dole)
            {
                Y += dx;
                if (Y >= 395)
                    Y = 395;
            }
        }


        public void Draw(Graphics g)
        {
           
            g.DrawImage(imgSegasna, X, Y, 50, 50);
        }

       public void fireeBalls()
        {
            fireBalls.Add(new FireBall(X + 10, Y+15,Nasoka));
        }
        public void RemoveFireBalls(int i)
        {
            fireBalls.Remove(fireBalls[i]);
        }
        public List<FireBall> getFireBall()
        {
            return fireBalls;
        }
        public void moveFireBalls(int i)
        {
               fireBalls[i].MoveBall();    
        }
       public void loseLife()
        {
            Life--;
        }
        public int getLife()
        {
            return Life;
        }
        public void setLife(int Life)
        {
            this.Life = Life;
        }
        public void RemoveFire(int i)
        {
            fireBalls.Remove(fireBalls[i]);
        }
      public Image getImage()
        {
            return imgSegasna;
        }
    }
}
